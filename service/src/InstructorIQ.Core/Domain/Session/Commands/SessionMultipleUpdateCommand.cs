using System.Collections.Generic;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public record SessionMultipleUpdateCommand : PrincipalCommandBase<CompleteModel>
{
    public SessionMultipleUpdateCommand(ClaimsPrincipal principal, IReadOnlyCollection<SessionMultipleUpdateModel> models) : base(principal)
    {
        Models = models;
    }

    public IReadOnlyCollection<SessionMultipleUpdateModel> Models { get; set; }
}
