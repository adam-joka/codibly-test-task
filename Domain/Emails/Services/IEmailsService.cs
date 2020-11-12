using  Domain.Emails.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Domain.Emails.Services
{
    public interface IEmailsService
    {
        Task SendEmail(EmailModel email, CancellationToken cancellationToken);
    }
}
