using Codibly.Domain.Emails.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codibly.Domain.Emails.Requests
{
    public class GetAllEmails: IRequest<List<EmailModel>>
    {
    }
}
