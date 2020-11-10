using Codibly.Domain.Emails.Repositories;
using Codibly.Domain.Emails.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Codibly.Domain.Emails.RequestHandlers
{
    public class CreateEmailHandler : IRequestHandler<CreateEmail, int>
    {
        private readonly IEmailsRepository emailsRepository;

        public CreateEmailHandler(IEmailsRepository emailsRepository)
        {
            this.emailsRepository = emailsRepository;
        }

        public async Task<int> Handle(CreateEmail request, CancellationToken cancellationToken)
        {
            return await emailsRepository.CreateEmail(request.Email, cancellationToken);
        }
    }
}
