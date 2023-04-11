using System;
using System.Threading;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Security;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.WebApplication.Controllers;

[Route("api/notification")]
public class NotificationController : MediatorControllerBase
{
    private readonly UserClaimManager _userClaimManager;

    public NotificationController(IMediator mediator, UserClaimManager userClaimManager) : base(mediator)
    {
        _userClaimManager = userClaimManager;
    }

    [Authorize]
    [HttpGet("unread")]
    public async Task<ActionResult<NotificationUnreadModel>> Get(CancellationToken cancellationToken)
    {
        var tenantId = _userClaimManager.GetTenantId(User) ?? Guid.Empty;
        var userName = User.Identity.Name;

        var command = new NotificationUnreadQuery(User, userName, tenantId);
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }

}
