using Codibly.Domain.Emails.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Codibly.Domain.Emails.NotificationHandlers
{
    public class FailedToSendEmailHandler : INotificationHandler<FailedToSendEmail>
    {
        public Task Handle(FailedToSendEmail notification, CancellationToken cancellationToken)
        {
            // TODO: implement handling failed email
            return Task.CompletedTask;
        }
    }
}
