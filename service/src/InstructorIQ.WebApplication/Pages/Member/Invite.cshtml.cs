using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.Core.Services;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Member
{
    public class InviteModel : MediatorModelBase
    {
        private readonly UserManager<Core.Data.Entities.User> _userManager;
        private readonly IEmailTemplateService _templateService;

        public InviteModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, UserManager<Core.Data.Entities.User> userManager, IEmailTemplateService templateService)
            : base(tenant, mediator, loggerFactory)
        {
            _userManager = userManager;
            _templateService = templateService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Display Name")]
            public string DisplayName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await GetOrCreateUser();
            if (user == null)
                return Page();

            await UpdateMembership(user);

            await SendInvite(user);

            ShowAlert("Successfully sent invite email");

            return RedirectToPage("/Member/Edit", new { id = user.Id });
        }

        private async Task<Core.Data.Entities.User> GetOrCreateUser()
        {
            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user != null)
                return user;

            user = new Core.Data.Entities.User
            {
                DisplayName = Input.DisplayName,
                UserName = Input.Email,
                Email = Input.Email
            };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
                return user;

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return null;

        }

        private async Task UpdateMembership(Core.Data.Entities.User user)
        {
            if (!Tenant.HasValue)
                return;

            var membershipQuery = new TenantMembershipQuery(User, Tenant.Value.Id, user.Email);
            var membership = await Mediator.Send(membershipQuery);

            // make sure user is member
            membership.IsMember = true;

            var membershipCommand = new TenantMembershipCommand(User, membership);
            membership = await Mediator.Send(membershipCommand);
        }

        private async Task SendInvite(Core.Data.Entities.User user)
        {
            var returnUrl = Url.Content("~/");

            var token = await _userManager.GenerateUserTokenAsync(
                user, PasswordlessLoginToken.ProviderName, PasswordlessLoginToken.TokenPurpose);

            var loginLink = Url.Page(
                "/Account/LoginCallback",
                pageHandler: null,
                values: new { id = user.Id, token, returnUrl },
                protocol: Request.Scheme);

            var model = new UserInviteEmail
            {
                DisplayName = user.DisplayName,
                EmailAddress = user.Email,
                Link = loginLink,
            };
            Request.ReadUserAgent(model);

            await _templateService.SendUserInviteEmail(model);
        }
    }
}