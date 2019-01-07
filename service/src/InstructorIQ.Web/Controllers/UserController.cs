using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.Web.Controllers
{
    [Authorize]
    [Route("api/User")]
    public class UserController : MediatorCommandControllerBase<Guid, UserReadModel, UserCreateModel, UserUpdateModel>
    {
        public UserController(IMediator mediator) : base(mediator)
        {

        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        public async Task<IActionResult> Login(CancellationToken cancellationToken, TokenRequest tokenRequest)
        {
            var userAgent = Request.UserAgent();
            var command = new AuthenticateCommand(userAgent, tokenRequest);

            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Ok(result);

        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> Register(CancellationToken cancellationToken, UserRegisterModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new UserManagementCommand<UserRegisterModel>(model, User, userAgent);

            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("forgetPassword")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> ForgotPassword(CancellationToken cancellationToken, UserForgotPasswordModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new UserManagementCommand<UserForgotPasswordModel>(model, User, userAgent);

            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("resetPassword")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> ResetPassword(CancellationToken cancellationToken, UserResetPasswordModel model)
        {
            var userAgent = Request.UserAgent();
            var command = new UserManagementCommand<UserResetPasswordModel>(model, User, userAgent);

            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Ok(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, Guid id)
        {
            var readModel = await GetQuery(id, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPost("query")]
        [ProducesResponseType(typeof(EntityListResult<UserReadModel>), 200)]
        public async Task<IActionResult> Query(CancellationToken cancellationToken, EntityQuery query)
        {
            var listResult = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(listResult);
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(EntityListResult<UserReadModel>), 200)]
        public async Task<IActionResult> List(CancellationToken cancellationToken, string q = null, string sort = null, int page = 1, int size = 20)
        {
            var query = new EntityQuery(q, page, size, sort);
            var listResult = await ListQuery(query, cancellationToken).ConfigureAwait(false);

            return Ok(listResult);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> Update(CancellationToken cancellationToken, Guid id, UserUpdateModel updateModel)
        {
            var readModel = await UpdateCommand(id, updateModel, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> Patch(CancellationToken cancellationToken, Guid id, JsonPatchDocument jsonPatch)
        {
            var readModel = await PatchCommand(id, jsonPatch, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken, Guid id)
        {
            var readModel = await DeleteCommand(id, cancellationToken).ConfigureAwait(false);

            return Ok(readModel);
        }

        [HttpPut("{id}/changePassword")]
        [ProducesResponseType(typeof(UserReadModel), 200)]
        public async Task<IActionResult> ChangePassword(CancellationToken cancellationToken, Guid id, UserChangePasswordModel updateModel)
        {
            var userAgent = Request.UserAgent();

            var command = new UserManagementCommand<UserChangePasswordModel>(updateModel, User, userAgent);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return Ok(result);
        }

    }
}