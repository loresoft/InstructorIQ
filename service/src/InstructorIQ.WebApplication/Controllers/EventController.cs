using System;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.WebApplication.Controllers
{
    [Route("api/event")]
    public class EventController : MediatorControllerBase
    {
        public EventController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{tenantId}")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid tenantId, DateTimeOffset start, DateTimeOffset end)
        {
            var command = new EventRangeQuery(User, tenantId, start, end);
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}