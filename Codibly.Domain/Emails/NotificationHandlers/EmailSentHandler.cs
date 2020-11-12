using  Domain.Emails.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Domain.Emails.NotificationHandlers
{
    public class EmailSentHandler : INotificationHandler<EmailSent>
    {
        public Task Handle(EmailSent notification, CancellationToken cancellationToken)
        {
            // TODO: Implement handling email sent
            return Task.CompletedTask;
        }
    }
}
