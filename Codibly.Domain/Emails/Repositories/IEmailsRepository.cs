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
        /// <summary>
        /// Gets email with provided id
        /// </summary>
        /// <param name="emailId">id of the email</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Email with provided id or null if not found</returns>
        Task<EmailModel> GetEmail(int emailId, CancellationToken cancellationToken);

        Task<List<EmailModel>> GetEmails(CancellationToken cancellationToken);

        Task<int> CreateEmail(EmailModel email, CancellationToken cancellationToken);

        Task MarkAsSent(int emailId, CancellationToken cancellationToken);
        Task<List<EmailModel>> GetPendingEmails(CancellationToken cancellationToken);
    }
}
