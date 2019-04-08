using System.Collections.Generic;
using System.Security.Principal;
using MediatR.CommandQuery.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands
{
    public class SessionBulkUpdateCommand : PrincipalCommandBase<CommandCompleteModel>
    {
        public SessionBulkUpdateCommand(IPrincipal principal, IReadOnlyCollection<SessionBulkUpdateModel> models) : base(principal)
        {
            Models = models;
        }

        public IReadOnlyCollection<SessionBulkUpdateModel> Models { get; set; }
    }
}
