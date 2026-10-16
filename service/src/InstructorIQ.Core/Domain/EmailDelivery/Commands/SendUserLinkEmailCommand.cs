using System.Security.Claims;

using InstructorIQ.Core.Models;

using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public record SendUserLinkEmailCommand : EntityModelCommand<UserLinkModel, CompleteModel>
{
    public SendUserLinkEmailCommand(ClaimsPrincipal principal, UserLinkModel model)
        : base(principal, model)
    {

    }
}
