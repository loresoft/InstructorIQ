using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Security;
using InstructorIQ.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InstructorIQ.WebApplication.Pages.Account
{
    [AllowAnonymous]
    public class PasswordlessModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly UserManager<Core.Data.Entities.User> _userManager;
        private readonly IEmailTemplateService _templateService;
        private readonly ILogger<LoginModel> _logger;
        private readonly IOptions<PasswordlessLoginTokenProviderOptions> _passwordlessOptions;

        public PasswordlessModel(UserManager<Core.Data.Entities.User> userManager, IEmailTemplateService templateService, ILogger<LoginModel> logger, IOptions<PasswordlessLoginTokenProviderOptions> passwordlessOptions, IMediator mediator)
        {
            _userManager = userManager;
            _logger = logger;
            _passwordlessOptions = passwordlessOptions;
            _mediator = mediator;
            _templateService = templateService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }


        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }


        public async Task OnGetAsync()
        {
            ReturnUrl = ReturnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError("Input.Email", "Email address not registered.");
                return Page();
            }

            // fix issue where imported uses have null security stamp
            var securityStamp = await _userManager.GetSecurityStampAsync(user);
            if (securityStamp.IsNullOrEmpty())
                await _userManager.UpdateSecurityStampAsync(user);

            var token = _userManager.GenerateNewAuthenticatorKey();

            await CreateLinkToken(user, token);

            await SendEmail(user, token);

            return RedirectToPage("./PasswordlessConfirmation");
        }

        private async Task SendEmail(Core.Data.Entities.User user, string token)
        {
            var loginLink = Url.Page(
                "/Account/Link",
                pageHandler: null,
                values: new {token},
                protocol: Request.Scheme);

            var model = new UserPasswordlessEmail
            {
                DisplayName = user.DisplayName,
                EmailAddress = user.Email,
                Link = loginLink,
                ExpireHours = (int) _passwordlessOptions.Value.TokenLifespan.TotalHours
            };
            Request.ReadUserAgent(model);

            var result = await _templateService.SendPasswordlessLoginEmail(model);
        }

        private async Task CreateLinkToken(Core.Data.Entities.User user, string token)
        {
            var createModel = new LinkTokenCreateModel
            {
                Expires = DateTimeOffset.UtcNow.Add(_passwordlessOptions.Value.TokenLifespan),
                Url = ReturnUrl,
                UserName = user.UserName
            };

            var createCommand = new LinkTokenCreateCommand(User, createModel, token);
            var linkToken = await _mediator.Send(createCommand);
        }
    }
}