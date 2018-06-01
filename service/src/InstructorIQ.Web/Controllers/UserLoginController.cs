using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Infrastructure.Models;
using InstructorIQ.Web.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.Web.Controllers
{
    [Authorize]
    [ValidateModelState]
    [Route("api/UserLogin")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorModel), 422)]
    [ProducesResponseType(typeof(ErrorModel), 500)]
    public class UserLoginController : MediatorQueryControllerBase<Guid, UserLogin, UserLoginReadModel>
    {
        public UserLoginController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserLoginReadModel), 200)]
        [Authorize(Roles = Core.Data.Constants.Role.GlobalAdministrator)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {
            var readModel = await GetQuery(id, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPost("query")]
        [ProducesResponseType(typeof(EntityListResult<UserLoginReadModel>), 200)]
        [Authorize(Roles = Core.Data.Constants.Role.GlobalAdministrator)]
        public async Task<IActionResult> Query(CancellationToken cancellationToken, [FromBody]EntityQuery query)
        {
            var listResult = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(listResult);
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(EntityListResult<UserLoginReadModel>), 200)]
        [Authorize(Roles = Core.Data.Constants.Role.GlobalAdministrator)]
        public async Task<IActionResult> List(CancellationToken cancellationToken, string q = null, string sort = null, int page = 1, int size = 20)
        {
            var query = new EntityQuery(q, page, size, sort);
            var listResult = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(listResult);
        }


        [HttpGet("me")]
        [ProducesResponseType(typeof(EntityListResult<UserLoginReadModel>), 200)]
        public async Task<IActionResult> Self(CancellationToken cancellationToken, string q = null, string sort = null, int page = 1, int size = 20)
        {
            var s = sort ?? "Updated:descending";
            var query = new EntityQuery(q, page, size, s);

            var emailAddress = User.Identity.GetEmail();
            var userId = User.Identity.GetUserId();

            query.Filter = new EntityFilter
            {
                Logic = "OR",
                Filters = new[]
                {
                    new EntityFilter{ Name = "EmailAddress", Value = emailAddress },
                    new EntityFilter{ Name = "UserId", Value = userId }
                }
            };

            var listResult = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(listResult);
        }

    }
}