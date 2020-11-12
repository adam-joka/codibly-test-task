using  Domain.Emails.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Domain.Emails.Requests
{
    public class GetEmail : IRequest<EmailModel>
    {
        public int Id { get; set; }
    }
}
