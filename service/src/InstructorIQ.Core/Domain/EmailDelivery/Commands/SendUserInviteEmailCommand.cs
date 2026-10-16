using System.Security.Claims;

using InstructorIQ.Core.Models;

using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public record SendUserInviteEmailCommand : EntityModelCommand<UserInviteModel, CompleteModel>
{
    public SendUserInviteEmailCommand(ClaimsPrincipal principal, UserInviteModel model)
        : base(principal, model)
    {
    }
}
