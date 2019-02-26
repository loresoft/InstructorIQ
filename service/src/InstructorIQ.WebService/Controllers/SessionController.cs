using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.WebService.Controllers
{
    [Authorize]
    [Route("api/Session")]
    public class SessionController : MediatorCommandControllerBase<Guid, SessionReadModel, SessionCreateModel, SessionUpdateModel>
    {
        public SessionController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SessionReadModel), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {
            var readModel = await GetQuery(id, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPost("query")]
        [ProducesResponseType(typeof(EntityListResult<SessionReadModel>), 200)]
        public async Task<IActionResult> Query(CancellationToken cancellationToken, EntityQuery query)
        {
            var listResult = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(listResult);
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(EntityListResult<SessionReadModel>), 200)]
        public async Task<IActionResult> List(CancellationToken cancellationToken, string q = null, string sort = null, int page = 1, int size = 20)
        {
            var query = new EntityQuery(q, page, size, sort);
            var listResult = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(listResult);
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(SessionReadModel), 200)]
        public async Task<IActionResult> Create(CancellationToken cancellationToken, SessionCreateModel createModel)
        {
            var readModel = await CreateCommand(createModel, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SessionReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id, SessionUpdateModel updateModel)
        {
            var readModel = await UpdateCommand(id, updateModel, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(SessionReadModel), 200)]
        public async Task<IActionResult> Patch(CancellationToken cancellationToken, Guid id, JsonPatchDocument jsonPatch)
        {
            var readModel = await PatchCommand(id, jsonPatch, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SessionReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken, Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }
    }
}