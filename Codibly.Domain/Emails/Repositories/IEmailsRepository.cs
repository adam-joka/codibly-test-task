using Codibly.Domain.Emails.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Codibly.Domain.Emails.Repositories
{
    public interface IEmailsRepository
    {
        Task<EmailModel> GetEmail(int emailId, CancellationToken cancellationToken);

        Task<List<EmailModel>> GetEmails(CancellationToken cancellationToken);

        Task<int> CreateEmail(EmailModel email, CancellationToken cancellationToken);

        Task MarkAsSent(int emailId, CancellationToken cancellationToken);
        Task<List<EmailModel>> GetPendingEmails(CancellationToken cancellationToken);
    }
}
