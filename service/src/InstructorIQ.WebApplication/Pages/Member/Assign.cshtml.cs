using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Member
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class AssignModel : MediatorModelBase
    {
        public AssignModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
            SelectedUser = new List<string>();
            SelectedRole = new List<string>();
        }

        [BindProperty]
        public List<string> SelectedUser { get; set; }

        [BindProperty]
        public List<string> SelectedRole { get; set; }

        public IReadOnlyCollection<MemberReadModel> Members { get; set; }

        public IReadOnlyCollection<RoleReadModel> Roles { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            await LoadMembers();
            await LoadRoles();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (SelectedUser.Count == 0)
            {
                ModelState.AddModelError("SelectedUser", "Must select at least one user.");
                return await OnGetAsync();
            }

            if (SelectedRole.Count == 0)
            {
                ModelState.AddModelError("SelectedRole", "Must select at least one role.");
                return await OnGetAsync();
            }

            var command = new MemberAssignRoleCommand(User, Tenant.Value.Id, SelectedUser, SelectedRole);
            var result = await Mediator.Send(command);

            return RedirectToPage("/Member/Index", new { tenant = TenantRoute });
        }

        private async Task LoadRoles()
        {
            var command = new EntitySelectQuery<RoleReadModel>(User, new EntitySelect());
            var roles = await Mediator.Send(command);

            Roles = roles
                .OrderBy(m => m.Name)
                .ToList();
        }

        private async Task LoadMembers()
        {
            var command = new MemberSelectQuery(User, Tenant.Value.Id);
            var members = await Mediator.Send(command);

            Members = members
                .OrderBy(m => m.SortName)
                .ToList();
        }
    }
}