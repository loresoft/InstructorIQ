using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Global.User
{
    [Authorize(Policy = UserPolicies.GlobalAdministratorPolicy)]
    public class MembershipModel : MediatorModelBase
    {
        private readonly UserManager<Core.Data.Entities.User> _userManager;

        public MembershipModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, UserManager<Core.Data.Entities.User> userManager)
            : base(tenant, mediator, loggerFactory)
        {
            _userManager = userManager;

            Membership = new TenantMembershipModel();
            Tenants = new List<TenantDropdownModel>();
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid TenantId { get; set; }

        [BindProperty]
        public TenantMembershipModel Membership { get; set; }

        public Core.Data.Entities.User Entity { get; set; }

        public IReadOnlyCollection<TenantDropdownModel> Tenants { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
                return NotFound($"Unable to load user with ID '{Id}'.");

            Entity = user;

            var loadTenantsTask = LoadTenants();
            var loadMembershipTask = LoadMembership();

            await Task.WhenAll(
                loadTenantsTask,
                loadTenantsTask
            );

            Tenants = loadTenantsTask.Result;
            Membership = loadMembershipTask.Result;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var command = new TenantMembershipCommand(User, Membership);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully saved membership");

            return RedirectToPage("/Global/User/Membership", new { Id, TenantId });
        }

        private async Task<IReadOnlyCollection<TenantDropdownModel>> LoadTenants()
        {
            var dropdownQuery = new TenantDropdownQuery(User);
            return await Mediator.Send(dropdownQuery);
        }

        private async Task<TenantMembershipModel> LoadMembership()
        {
            if (TenantId == Guid.Empty)
                return new TenantMembershipModel();

            var command = new TenantMembershipQuery(User, TenantId, Entity.Id);
            return await Mediator.Send(command);
        }
    }
}