using  Domain.Emails.Data;
using  Domain.Emails.Model;
using  Domain.Emails.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Domain.Emails.Repositories
{
    public class EmailsRepository : IEmailsRepository
    {
        private readonly EmailsDataContext db;

        public EmailsRepository(EmailsDataContext db)
        {
            this.db = db;
        }

        public async Task<int> CreateEmail(EmailModel email, CancellationToken cancellationToken)
        {
            var newEmail = new Email
            {
                Recipients = string.Join(",", email.Recipients), // pretend one to many relation
                Body = email.Body,
                Sender = email.Sender,
                Subject = email.Subject
            };

            db.Emails.Add(newEmail);

            await db.SaveChangesAsync(cancellationToken);

            return newEmail.Id;
        }

        public async Task<EmailModel> GetEmail(int emailId, CancellationToken cancellationToken)
        {
            Email email = await db.Emails.FirstOrDefaultAsync(e => e.Id == emailId, cancellationToken);

            if (email == null)
            {
                return null;
            }

            return ToEmailModel(email);
        }

        public async Task<List<EmailModel>> GetEmails(CancellationToken cancellationToken)
        {
            List<Email> emails = await db.Emails.ToListAsync(cancellationToken);
            return ToEmailModels(emails);
        }

        public async Task<List<EmailModel>> GetPendingEmails(CancellationToken cancellationToken)
        {
            List<Email> emails = await db.Emails
                .Where(e => e.SentOn == null)
                .ToListAsync(cancellationToken);

            return ToEmailModels(emails);
        }

        public async Task MarkAsSent(int emailId, CancellationToken cancellationToken)
        {
            var email = new Email { Id = emailId, SentOn = DateTime.UtcNow };
            db.Emails.Attach(email);
            db.Entry(email).Property(x => x.SentOn).IsModified = true;
            await db.SaveChangesAsync(cancellationToken);
        }

        private EmailModel ToEmailModel(Email email)
        {
            return new EmailModel
            {
                Id = email.Id,
                Recipients = email.Recipients.Split(',').ToList(),
                Body = email.Body,
                Sender = email.Sender,
                Subject = email.Subject
            };
        }

        private List<EmailModel> ToEmailModels(List<Email> emails)
        {
            return emails.Select(e => ToEmailModel(e)).ToList();
        }
    }
}
