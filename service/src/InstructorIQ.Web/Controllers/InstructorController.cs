using System;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.Web.Controllers
{
    [Authorize]
    [Route("api/Instructor")]
    [Produces("application/json")]
    public class InstructorController : MediatorController<Instructor, InstructorReadModel, InstructorCreateModel, InstructorUpdateModel>
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

        [HttpGet("")]
        [ProducesResponseType(typeof(EntityListResult<InstructorReadModel>), 200)]
        public async Task<IActionResult> Query(CancellationToken cancellationToken, [FromBody]EntityQuery query)
        {
            var model = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(model);
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(InstructorReadModel), 200)]
        public async Task<IActionResult> Create(CancellationToken cancellationToken, [FromBody]InstructorCreateModel createModel)
        {
            var readModel = await CreateCommand(createModel, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(InstructorReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id, [FromBody]InstructorUpdateModel updateModel)
        {
            var readModel = await UpdateCommand(id, updateModel, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(InstructorReadModel), 200)]
        public async Task<IActionResult> Patch(CancellationToken cancellationToken, Guid id, [FromBody]JsonPatchDocument<Instructor> jsonPatch)
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
