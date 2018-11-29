using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.Web.Controllers
{
    [Authorize]
    [Route("api/UserLogin")]
    public class UserLoginController : MediatorQueryControllerBase<Guid, UserLoginReadModel>
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
        public async Task<IActionResult> Query(CancellationToken cancellationToken, EntityQuery query)
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