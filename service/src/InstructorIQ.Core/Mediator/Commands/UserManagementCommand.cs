using System;
using System.Security.Principal;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Commands
{
    public class UserManagementCommand<TUserModel> : EntityModelCommand<TUserModel, UserReadModel>
    {
        public UserManagementCommand(TUserModel model) : base(model, null)
        {
        }

        public UserManagementCommand(TUserModel model, IPrincipal principal) : base(model, principal)
        {
        }
    }
}