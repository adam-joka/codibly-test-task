using Codibly.Domain.Emails.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codibly.Domain.Emails.Validators
{
    public class CreateEmailValidator : AbstractValidator<CreateEmail>
    {
        public CreateEmailValidator()
        {
            RuleFor(email => email.Email).NotNull();
            RuleFor(email => email.Email.Recipients).NotNull();
            RuleFor(email => email.Email.Recipients).NotEmpty();
        }
    }
}
