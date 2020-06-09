using System.Security.Principal;
using InstructorIQ.Core.Models;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands
{
    public class SendUserLinkEmailCommand : EntityModelCommand<UserLinkModel, CompleteModel>
    {
        public SendUserLinkEmailCommand(IPrincipal principal, UserLinkModel model)
            : base(principal, model)
        {

        }
    }
}
