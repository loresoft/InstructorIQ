using System.Security.Principal;

using InstructorIQ.Core.Models;

using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public class SendUserInviteEmailCommand : EntityModelCommand<UserInviteModel, CompleteModel>
{
    public SendUserInviteEmailCommand(IPrincipal principal, UserInviteModel model)
        : base(principal, model)
    {
    }
}
