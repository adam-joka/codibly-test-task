using  Domain.Emails.Exceptions;
using  Domain.Emails.Model;
using  Domain.Emails.Notifications;
using  Domain.Emails.Repositories;
using  Domain.Emails.Requests;
using  Domain.Emails.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Domain.Emails.RequestHandlers
{
    public class SendAllPendingEmailsHandler : IRequestHandler<SendAllPendingEmails>
    {
        private readonly IEmailsRepository emailsRepository;
        private readonly IEmailsService emailsService;
        private readonly IMediator mediator;

        public SendAllPendingEmailsHandler(IEmailsRepository emailsRepository,
            IEmailsService emailsService, IMediator mediator)
        {
            this.emailsRepository = emailsRepository;
            this.emailsService = emailsService;
            this.mediator = mediator;
        }
        public async Task<Unit> Handle(SendAllPendingEmails request,
            CancellationToken cancellationToken)
        {
            List<EmailModel> pendingEmails = await emailsRepository.GetPendingEmails(cancellationToken);

            foreach (EmailModel pendingEmail in pendingEmails)
            {
                try
                {
                    await emailsService.SendEmail(pendingEmail, cancellationToken);
                }
                catch (EmailSendException emailSendException)
                {
                    await mediator.Publish(new FailedToSendEmail
                    {
                        Id = pendingEmail.Id,
                        Reason = emailSendException.ToString()
                    });

                    throw emailSendException;
                }

                // TODO: what if email was sent but we fail to mark it as sent? 
                //    it might be sent again when this is called next time
                await emailsRepository.MarkAsSent(pendingEmail.Id, cancellationToken);
            }

            return Unit.Value;
        }
    }
}
