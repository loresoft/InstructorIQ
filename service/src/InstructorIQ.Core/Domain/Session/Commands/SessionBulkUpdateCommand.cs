using System;
using System.Collections.Generic;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands
{
    public class SessionBulkUpdateCommand : PrincipalCommandBase<CommandCompleteModel>
    {
        public SessionBulkUpdateCommand(IPrincipal principal, Guid topicId, IReadOnlyCollection<SessionBulkUpdateModel> models) : base(principal)
        {
            TopicId = topicId;
            Models = models;
        }

        public Guid TopicId { get; set; }

        public IReadOnlyCollection<SessionBulkUpdateModel> Models { get; set; }
    }
}
