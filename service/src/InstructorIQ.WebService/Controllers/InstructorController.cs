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
    [Route("api/Instructor")]
    public class InstructorController : MediatorCommandControllerBase<Guid, InstructorReadModel, InstructorCreateModel, InstructorUpdateModel>
    {
        public InstructorController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(InstructorReadModel), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {
            var model = await GetQuery(id, cancellationToken).ConfigureAwait(false);

            return Ok(model);
        }

        [HttpPost("query")]
        [ProducesResponseType(typeof(EntityListResult<InstructorReadModel>), 200)]
        public async Task<IActionResult> Query(CancellationToken cancellationToken, EntityQuery query)
        {
            var listResult = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(listResult);
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(EntityListResult<InstructorReadModel>), 200)]
        public async Task<IActionResult> List(CancellationToken cancellationToken, string q = null, string sort = null, int page = 1, int size = 20)
        {
            var query = new EntityQuery(q, page, size, sort);
            var listResult = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(listResult);
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(InstructorReadModel), 200)]
        public async Task<IActionResult> Create(CancellationToken cancellationToken, InstructorCreateModel createModel)
        {
            var readModel = await CreateCommand(createModel, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(InstructorReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id, InstructorUpdateModel updateModel)
        {
            var readModel = await UpdateCommand(id, updateModel, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(InstructorReadModel), 200)]
        public async Task<IActionResult> Patch(CancellationToken cancellationToken, Guid id, JsonPatchDocument jsonPatch)
        {
            var readModel = await PatchCommand(id, jsonPatch, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(InstructorReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken, Guid id)
        {
            var model = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);

            return Ok(model);
        }
    }
}
