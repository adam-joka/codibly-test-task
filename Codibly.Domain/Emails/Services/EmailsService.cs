using Codibly.Domain.Emails.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Codibly.Domain.Emails.Services
{
    public class EmailsService : IEmailsService
    {
        public Task SendEmail(EmailModel email, CancellationToken cancellationToken)
        {
            // TODO: implement sending email
            return Task.CompletedTask;
        }
    }
}
