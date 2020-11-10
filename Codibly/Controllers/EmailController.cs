using Codibly.Domain.Emails.Model;
using Codibly.Domain.Emails.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codibly.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmailController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await mediator.Send(new GetAllEmails()).ConfigureAwait(false));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetEmail { Id = id }).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmailModel email)
        {
            return Ok(new
            {
                Id = await mediator.Send(new CreateEmail { Email = email }).ConfigureAwait(false)
            });
        }

        [HttpPost]
        [Route("sendPending")]
        public async Task<IActionResult> Post()
        {
            await mediator.Send(new SendAllPendingEmails()).ConfigureAwait(false);
            return Ok();
        }
    }
}
