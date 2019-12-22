using System.Collections.Generic;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands
{
    public class SessionMultipleUpdateCommand : PrincipalCommandBase<CommandCompleteModel>
    {
        public SessionMultipleUpdateCommand(IPrincipal principal, IReadOnlyCollection<SessionMultipleUpdateModel> models) : base(principal)
        {
            Models = models;
        }

        public IReadOnlyCollection<SessionMultipleUpdateModel> Models { get; set; }
    }
}
