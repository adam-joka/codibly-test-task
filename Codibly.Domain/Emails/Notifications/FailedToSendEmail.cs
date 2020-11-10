using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codibly.Domain.Emails.Notifications
{
    public class FailedToSendEmail : INotification
    {
        /// <summary>
        /// Email id which failed to be send
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Extra info about the error
        /// </summary>
        public string Reason { get; set; }
    }
}
