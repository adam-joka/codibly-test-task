using  Domain.Emails.Model;
using  Domain.Emails.Repositories;
using  Domain.Emails.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Domain.Emails.RequestHandlers
{
    public class GetAllEmailsHandler : IRequestHandler<GetAllEmails, List<EmailModel>>
    {
        private readonly IEmailsRepository emailsRepository;

        public GetAllEmailsHandler(IEmailsRepository emailsRepository)
        {
            this.emailsRepository = emailsRepository;
        }

        public async Task<List<EmailModel>> Handle(GetAllEmails request, CancellationToken cancellationToken)
        {
            return await emailsRepository.GetEmails(cancellationToken);
        }
    }
}
