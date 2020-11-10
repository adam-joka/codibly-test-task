using Codibly.Domain.Emails.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codibly.Domain.Emails.Requests
{
    public class CreateEmail : IRequest<int>
    {
        public EmailModel Email { get; set; }
    }
}
