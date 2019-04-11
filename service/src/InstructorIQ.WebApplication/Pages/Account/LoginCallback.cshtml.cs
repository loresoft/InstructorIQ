using System.Threading.Tasks;
using InstructorIQ.Core.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Account
{
    public class LoginCallbackModel : PageModel
    {
        private readonly SignInManager<Core.Data.Entities.User> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginCallbackModel(SignInManager<Core.Data.Entities.User> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ReturnUrl = ReturnUrl ?? Url.Content("~/");

            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(Token))
                return RedirectToPage("/Account/Login", new { ReturnUrl });

            var userManager = _signInManager.UserManager;
            var user = await userManager.FindByIdAsync(Id);
            var isValid = await userManager.VerifyUserTokenAsync(
                user, PasswordlessLoginToken.ProviderName, PasswordlessLoginToken.TokenPurpose, Token);

            if (isValid)
            {
                await userManager.UpdateSecurityStampAsync(user);

                await _signInManager.SignInAsync(user, true);
                _logger.LogInformation("User logged in.");

                return LocalRedirect(ReturnUrl);
            }

            return Page();
        }
    }
}