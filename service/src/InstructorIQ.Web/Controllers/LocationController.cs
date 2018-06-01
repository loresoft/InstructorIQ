using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Infrastructure.Models;
using InstructorIQ.Web.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.Web.Controllers
{
    [Authorize]
    [ValidateModelState]
    [Route("api/Location")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorModel), 422)]
    [ProducesResponseType(typeof(ErrorModel), 500)]
    public class LocationController : MediatorCommandControllerBase<Guid, Location, LocationReadModel, LocationCreateModel, LocationUpdateModel>
    {
        public LocationController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LocationReadModel), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {
            var readModel = await GetQuery(id, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPost("query")]
        [ProducesResponseType(typeof(EntityListResult<LocationReadModel>), 200)]
        public async Task<IActionResult> Query(CancellationToken cancellationToken, [FromBody]EntityQuery query)
        {
            var listResult = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(listResult);
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(EntityListResult<LocationReadModel>), 200)]
        public async Task<IActionResult> List(CancellationToken cancellationToken, string q = null, string sort = null, int page = 1, int size = 20)
        {
            var query = new EntityQuery(q, page, size, sort);
            var listResult = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(listResult);
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(LocationReadModel), 200)]
        public async Task<IActionResult> Create(CancellationToken cancellationToken, [FromBody]LocationCreateModel createModel)
        {
            var readModel = await CreateCommand(createModel, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LocationReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id, [FromBody]LocationUpdateModel updateModel)
        {
            var readModel = await UpdateCommand(id, updateModel, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(LocationReadModel), 200)]
        public async Task<IActionResult> Patch(CancellationToken cancellationToken, Guid id, [FromBody]JsonPatchDocument<Location> jsonPatch)
        {
            var readModel = await PatchCommand(id, jsonPatch, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(LocationReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken, Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }
    }
}