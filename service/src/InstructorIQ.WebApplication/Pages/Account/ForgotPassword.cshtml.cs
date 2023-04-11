using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace InstructorIQ.WebApplication.Pages.Account;

[AllowAnonymous]
public class ForgotPasswordModel : PageModel
{
    private readonly UserManager<Core.Data.Entities.User> _userManager;
    private readonly IEmailTemplateService _templateService;
    private readonly IOptions<DataProtectionTokenProviderOptions> _tokenOptions;

    public ForgotPasswordModel(UserManager<Core.Data.Entities.User> userManager, IEmailTemplateService templateService, IOptions<DataProtectionTokenProviderOptions> tokenOptions)
    {
        _userManager = userManager;
        _templateService = templateService;
        _tokenOptions = tokenOptions;
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

        // fix issue where imported uses have null security stamp
        var securityStamp = await _userManager.GetSecurityStampAsync(user);
        if (securityStamp.IsNullOrEmpty())
            await _userManager.UpdateSecurityStampAsync(user);

        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetLink = Url.Page(
            "/Account/ResetPassword",
            pageHandler: null,
            values: new { code },
            protocol: Request.Scheme);

        var model = new UserResetPasswordEmail
        {
            RecipientName = user.DisplayName,
            RecipientAddress = user.Email,
            Link = resetLink,
            ExpireHours = (int)_tokenOptions.Value.TokenLifespan.TotalHours
        };
        Request.ReadUserAgent(model);

        var result = await _templateService.SendResetPasswordEmail(model);

        return RedirectToPage("./ForgotPasswordConfirmation");
    }
}
