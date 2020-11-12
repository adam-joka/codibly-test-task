using Controllers;
using Domain.Emails.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Emails.Unit
{
    public class EmailContollerUnitTests
    {
        [Fact]
        public async Task Index_ReturnsAJsonResult_WithAListOfEmails()
        {
            //Arange
            var mediator = new Mock<IMediator>();           

            var emailController = new EmailController(mediator.Object);

            var result = await emailController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
