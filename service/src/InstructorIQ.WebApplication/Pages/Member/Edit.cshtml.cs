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
using InstructorIQ.Core.Services;
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
        private readonly IEmailTemplateService _templateService;

        public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, UserManager<Core.Data.Entities.User> userManager, IEmailTemplateService templateService)
            : base(tenant, mediator, loggerFactory)
        {
            _userManager = userManager;
            _templateService = templateService;
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

        public async Task<IActionResult> OnPostSendInvite()
        {
            var userId = Id.ToString();
            var user = await _userManager.FindByIdAsync(userId);

            await SendInvite(user);

            ShowAlert("Successfully sent member invite email");

            return RedirectToPage("/Member/Index", new { tenant = TenantRoute });

        }


        private async Task<TenantMembershipModel> LoadMembership()
        {
            if (!Tenant.HasValue)
                return new TenantMembershipModel();

            var command = new TenantMembershipQuery(User, Tenant.Value.Id, Entity.Email);
            return await Mediator.Send(command);
        }

        private async Task SendInvite(Core.Data.Entities.User user)
        {
            var token = _userManager.GenerateNewAuthenticatorKey();
            await CreateLinkToken(user, token);

            var loginLink = Url.Page(
                "/Account/Link",
                pageHandler: null,
                values: new { token },
                protocol: Request.Scheme);

            var model = new UserInviteEmail
            {
                DisplayName = user.DisplayName,
                EmailAddress = user.Email,
                Link = loginLink,
                TenantName = Tenant.Value.Name
            };
            Request.ReadUserAgent(model);

            await _templateService.SendUserInviteEmail(model);
        }

        private async Task CreateLinkToken(Core.Data.Entities.User user, string token)
        {
            var returnUrl = Url.Content("~/");

            var createModel = new LinkTokenCreateModel
            {
                Expires = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(30)),
                Url = returnUrl,
                UserName = user.UserName,
                TenantId = Tenant.Value.Id
            };

            var createCommand = new LinkTokenCreateCommand(User, createModel, token);
            var linkToken = await Mediator.Send(createCommand);
        }


    }
}