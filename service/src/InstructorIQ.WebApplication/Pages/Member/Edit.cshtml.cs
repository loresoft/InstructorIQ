using System;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Commands;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Member
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class EditModel : EntityIdentifierModelBase<MemberUpdateModel>
    {
        private readonly UserManager<Core.Data.Entities.User> _userManager;

        public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, UserManager<Core.Data.Entities.User> userManager)
            : base(tenant, mediator, loggerFactory)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public TenantMembershipModel Membership { get; set; }

        [BindProperty]
        public bool IsMemberDisabled { get; set; }


        public override async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetAsync();

            IsMemberDisabled = Entity.LockoutEnd.HasValue;

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
                p => p.SortName,
                p => p.FamilyName,
                p => p.GivenName,
                p => p.JobTitle,
                p => p.Email,
                p => p.PhoneNumber
            );

            // compute sort name
            if (updateModel.SortName.IsNullOrWhiteSpace())
                updateModel.SortName = ToSortName(updateModel);

            if (IsMemberDisabled && updateModel.LockoutEnd == null)
                updateModel.LockoutEnd = DateTimeOffset.Now.AddYears(100);
            else if (!IsMemberDisabled && updateModel.LockoutEnd.HasValue)
                updateModel.LockoutEnd = null;

            var updateCommand = new EntityUpdateCommand<Guid, MemberUpdateModel, MemberReadModel>(User, Id, updateModel);
            var updateResult = await Mediator.Send(updateCommand);

            // make sure correct user and tenant
            Membership.UserId = updateResult.Id;
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

        public async Task<IActionResult> OnPostSendInvite()
        {
            var userId = Id.ToString();
            var user = await _userManager.FindByIdAsync(userId);

            var model = new UserInviteModel
            {
                User = user,
                ReturnUrl = Url.Content("~/"),
            };
            Request.ReadUserAgent(model);

            var command = new SendUserInviteEmailCommand(User, model);
            await Mediator.Send(command);

            ShowAlert("Successfully sent member invite email");

            return RedirectToPage("/Member/Index", new { tenant = TenantRoute });

        }

        private async Task<TenantMembershipModel> LoadMembership()
        {
            if (!Tenant.HasValue)
                return new TenantMembershipModel();

            var command = new TenantMembershipQuery(User, Tenant.Value.Id, Id);
            return await Mediator.Send(command);
        }

        private string ToSortName(MemberUpdateModel user)
        {
            if (user.FamilyName.HasValue() && user.GivenName.HasValue())
                return $"{user.FamilyName}, {user.GivenName}";

            if (user.FamilyName.HasValue())
                return user.FamilyName;

            return user.DisplayName;
        }

    }
}