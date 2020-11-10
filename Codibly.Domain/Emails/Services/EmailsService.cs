using Codibly.Domain.Emails.Model;
using Codibly.Domain.Emails.Model.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Codibly.Domain.Emails.Services
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
