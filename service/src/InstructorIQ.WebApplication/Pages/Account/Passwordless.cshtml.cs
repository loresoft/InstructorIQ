using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Security;
using InstructorIQ.Core.Services;
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
        private readonly UserManager<Core.Data.Entities.User> _userManager;
        private readonly IEmailTemplateService _templateService;
        private readonly ILogger<LoginModel> _logger;
        private readonly IOptions<PasswordlessLoginTokenProviderOptions> _passwordlessOptions;

        public PasswordlessModel(UserManager<Core.Data.Entities.User> userManager, IEmailTemplateService templateService, ILogger<LoginModel> logger, IOptions<PasswordlessLoginTokenProviderOptions> passwordlessOptions)
        {
            _userManager = userManager;
            _logger = logger;
            _passwordlessOptions = passwordlessOptions;
            _templateService = templateService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

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

            var token = await _userManager.GenerateUserTokenAsync(
                user, PasswordlessLoginToken.ProviderName, PasswordlessLoginToken.TokenPurpose);

            var loginLink = Url.Page(
                "/Account/LoginCallback",
                pageHandler: null,
                values: new { id = user.Id, token, returnUrl = ReturnUrl },
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

            return RedirectToPage("./PasswordlessConfirmation");
        }

    }
}