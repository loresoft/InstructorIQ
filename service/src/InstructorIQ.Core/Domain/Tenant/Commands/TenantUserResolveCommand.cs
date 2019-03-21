using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Commands;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands
{
    public class TenantUserResolveCommand : PrincipalCommandBase<TenantUserModel>
    {
        public TenantUserResolveCommand(IPrincipal principal, User user) : base(principal)
        {
            User = user;
        }

        public User User { get; set; }
    }
}
