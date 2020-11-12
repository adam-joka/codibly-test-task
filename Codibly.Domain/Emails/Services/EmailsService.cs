using  Domain.Emails.Model;
using  Domain.Emails.Model.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Domain.Emails.Services
{
    public class EmailsService : IEmailsService
    {
        private readonly EmailConfiguration emailConfiguration;

        public EmailsService(IOptions<EmailConfiguration> emailConfigurationOptions)
        {
            this.emailConfiguration = emailConfigurationOptions.Value;
        }
        public Task SendEmail(EmailModel email, CancellationToken cancellationToken)
        {
            if(email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            // set the right sender
            string sender = null;
            if (string.IsNullOrWhiteSpace(email.Sender))
            {
                sender = emailConfiguration.DefaultSender;
            }
            else
            {
                sender = email.Sender;
            }

            // TODO: implement sending emails here

            return Task.CompletedTask;
        }

    }
}
