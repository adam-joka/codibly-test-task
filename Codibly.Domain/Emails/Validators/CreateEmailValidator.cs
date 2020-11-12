using  Domain.Emails.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Domain.Emails.Validators
{
    public class CreateEmailValidator : AbstractValidator<CreateEmail>
    {
        public CreateEmailValidator()
        {
            RuleFor(email => email.Email).NotNull();
            RuleFor(email => email.Email.Recipients).NotEmpty();

            //TODO: validate if recipents are valid emails

            // TODO: validate if sender is valid email

        }
    }
}
