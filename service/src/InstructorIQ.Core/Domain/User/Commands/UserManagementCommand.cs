using System;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Models;

namespace InstructorIQ.Core.Domain.User.Commands
{
    public class UserManagementCommand<TUserModel> : EntityModelCommand<TUserModel, UserReadModel>
    {
        public UserManagementCommand(TUserModel model) : base(model, null)
        {
        }

        public UserManagementCommand(TUserModel model, IPrincipal principal) : base(model, principal)
        {
        }

        public UserManagementCommand(TUserModel model, IPrincipal principal, UserAgentModel userAgent) : base(model, principal)
        {
            UserAgent = userAgent;
        }

        public UserAgentModel UserAgent { get; set; }
    }
}