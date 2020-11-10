using System;
using System.Collections.Generic;
using System.Text;

namespace Codibly.Domain.Emails.Exceptions
{
    public class EmailSendException : Exception
    {
        public EmailSendException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
