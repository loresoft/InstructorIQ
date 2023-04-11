using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using InstructorIQ.Core.Security;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstructorIQ.WebApplication.Pages.Global.User;

[Authorize(Policy = UserPolicies.GlobalAdministratorPolicy)]
public class CreateModel : PageModel
{
    private readonly UserManager<Core.Data.Entities.User> _userManager;

    public CreateModel(UserManager<Core.Data.Entities.User> userManager)
    {
        _userManager = userManager;
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

        var user = new Core.Data.Entities.User
        {
            DisplayName = Input.DisplayName,
            UserName = Input.Email,
            Email = Input.Email
        };

        var result = await _userManager.CreateAsync(user);

        if (result.Succeeded)
        {
            ShowAlert("Successfully created user");

            return RedirectToPage("/Global/User/Edit", new { id = user.Id });
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return Page();
    }

    protected void ShowAlert(string message, string type = "success")
    {
        TempData["alert.type"] = type;
        TempData["alert.message"] = message;
    }

}
