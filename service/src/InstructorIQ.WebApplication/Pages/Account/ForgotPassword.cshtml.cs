using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstructorIQ.WebApplication.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<Core.Data.Entities.User> _userManager;
        private readonly IEmailTemplateService _templateService;

        public ForgotPasswordModel(UserManager<Core.Data.Entities.User> userManager, IEmailTemplateService templateService)
        {
            _userManager = userManager;
            _templateService = templateService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
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

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Page(
                "/Account/ResetPassword",
                pageHandler: null,
                values: new { code },
                protocol: Request.Scheme);

            var userAgent = Request.UserAgent();
            var model = new UserResetPasswordEmail
            {
                DisplayName = user.DisplayName,
                EmailAddress = user.Email,
                ResetLink = resetLink,
                UserAgent = userAgent
            };
            var result = await _templateService.SendResetPasswordEmail(model);

            return RedirectToPage("./ForgotPasswordConfirmation");
        }
    }
}
