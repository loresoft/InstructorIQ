using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Security;
using MediatR;
using MediatR.CommandQuery.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.WebApplication.Controllers
{
    [Route("api/template")]
    public class TemplateController : MediatorControllerBase
    {
        private readonly UserClaimManager _userClaimManager;

        public TemplateController(IMediator mediator, UserClaimManager userClaimManager) : base(mediator)
        {
            _userClaimManager = userClaimManager;
        }

        [Authorize]
        [HttpGet("editor")]
        public async Task<ActionResult<IReadOnlyCollection<TemplateEditorModel>>> Get(CancellationToken cancellationToken)
        {
            var tenantId = _userClaimManager.GetTenantId(User) ?? Guid.Empty;
            var userName = User.Identity.Name;

            var command = new EntitySelectQuery<TemplateEditorModel>(User);
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }


    }
}