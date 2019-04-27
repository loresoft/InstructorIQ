using System;
using System.Threading.Tasks;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Member
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class EditModel : EntityIdentifierModelBase<MemberUpdateModel>
    {
        public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        [BindProperty]
        public TenantMembershipModel Membership { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetAsync();

            Membership = await LoadMembership();

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var readCommand = new EntityIdentifierQuery<Guid, MemberUpdateModel>(User, Id);
            var updateModel = await Mediator.Send(readCommand);
            if (updateModel == null)
                return NotFound();

            // only update input fields
            await TryUpdateModelAsync(
                updateModel,
                nameof(Entity),
                p => p.DisplayName,
                p => p.FamilyName,
                p => p.GivenName,
                p => p.JobTitle,
                p => p.Email,
                p => p.PhoneNumber
            );

            var updateCommand = new EntityUpdateCommand<Guid, MemberUpdateModel, MemberReadModel>(User, Id, updateModel);
            var updateResult = await Mediator.Send(updateCommand);

            // make sure correct user and tenant
            Membership.UserName = updateResult.UserName;
            Membership.TenantId = Tenant.Value.Id;

            var membershipCommand = new TenantMembershipCommand(User, Membership);
            var membershipResult = await Mediator.Send(membershipCommand);

            ShowAlert("Successfully saved member");

            return RedirectToPage("/Member/Edit", new { id = Id, tenant = TenantRoute });
        }

        public async Task<IActionResult> OnPostDeleteEntity()
        {
            var command = new EntityDeleteCommand<Guid, LocationReadModel>(User, Id);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully deleted member");

            return RedirectToPage("/Member/Index", new { tenant = TenantRoute });

        }


        private async Task<TenantMembershipModel> LoadMembership()
        {
            if (!Tenant.HasValue)
                return new TenantMembershipModel();

            var command = new TenantMembershipQuery(User, Tenant.Value.Id, Entity.Email);
            return await Mediator.Send(command);
        }

    }
}