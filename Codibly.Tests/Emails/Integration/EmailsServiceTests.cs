using Codibly.Domain.Emails.Model;
using Codibly.Domain.Emails.Model.Configuration;
using Codibly.Domain.Emails.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Codibly.Tests
{
    public class EmailsServiceTests
    {


        [Fact]
        public async Task EmailsService_SendEmail_Test()
        {
            var emailService = new EmailsService(
                Options.Create(new EmailConfiguration
                {
                    DefaultSender = "adam.joka@gmail.com"
                }));

            await Assert.ThrowsAsync<ArgumentNullException>
                (async () => await emailService.SendEmail(null, CancellationToken.None));
            
        }
    }
}
