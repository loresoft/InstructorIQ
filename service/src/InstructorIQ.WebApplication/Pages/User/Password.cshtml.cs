using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.User;

[Authorize]
public class PasswordModel : MediatorModelBase
{
    private readonly UserManager<Core.Data.Entities.User> _userManager;
    private readonly SignInManager<Core.Data.Entities.User> _signInManager;

    public PasswordModel(
        ITenant<TenantReadModel> tenant,
        IMediator mediator,
        ILoggerFactory loggerFactory,
        UserManager<Core.Data.Entities.User> userManager,
        SignInManager<Core.Data.Entities.User> signInManager)
        : base(tenant, mediator, loggerFactory)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string CurrentPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

        var hasPassword = await _userManager.HasPasswordAsync(user);
        if (!hasPassword)
            return RedirectToPage("./SetPassword");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            var userId = _userManager.GetUserId(User);
            return NotFound($"Unable to load user with ID '{userId}'.");
        }

        var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.CurrentPassword, Input.NewPassword);
        if (!changePasswordResult.Succeeded)
        {
            foreach (var error in changePasswordResult.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }

        await _signInManager.RefreshSignInAsync(user);

        Logger.LogInformation("User changed their password successfully.");
        ShowAlert("Your password has been changed");

        return RedirectToPage();
    }
}
