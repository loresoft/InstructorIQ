using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using EntityChange.Extensions;

using InstructorIQ.Core.Security;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstructorIQ.WebApplication.Pages.Global.User;

[Authorize(Policy = UserPolicies.GlobalAdministratorPolicy)]
public class EditModel : PageModel
{
    private readonly UserManager<Core.Data.Entities.User> _userManager;

    public EditModel(UserManager<Core.Data.Entities.User> userManager)
    {
        _userManager = userManager;
    }

    [BindProperty(SupportsGet = true)]
    public string Id { get; set; }

    [BindProperty(SupportsGet = true)]
    public string TenantId { get; set; }

    [BindProperty]
    public InputModel Input { get; set; }

    public string Username { get; set; }

    public class InputModel
    {
        [Required]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [Display(Name = "Display Name")]
        public string SortName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "First Name")]
        public string GivenName { get; set; }

        [Display(Name = "Last Name")]
        public string FamilyName { get; set; }

        [Display(Name = "Title")]
        public string JobTitle { get; set; }

    }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.FindByIdAsync(Id);
        if (user == null)
            return NotFound($"Unable to load user with ID '{Id}'.");

        var displayName = user.DisplayName;
        var sortName = user.SortName;
        var userName = await _userManager.GetUserNameAsync(user);
        var email = await _userManager.GetEmailAsync(user);
        var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

        Username = userName;

        Input = new InputModel
        {
            DisplayName = displayName,
            SortName = sortName,
            Email = email,
            PhoneNumber = phoneNumber,
            JobTitle = user.JobTitle,
            FamilyName = user.FamilyName,
            GivenName = user.GivenName
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var user = await _userManager.FindByIdAsync(Id);
        if (user == null)
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

        if (string.IsNullOrEmpty(user.SecurityStamp))
            await _userManager.UpdateSecurityStampAsync(user);

        var userId = await _userManager.GetUserIdAsync(user);
        var email = await _userManager.GetEmailAsync(user);
        if (Input.Email != email)
        {
            var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
            CheckResult(setEmailResult, userId);
        }

        var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        if (Input.PhoneNumber != phoneNumber)
        {
            var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            CheckResult(setPhoneResult, userId);
        }

        user.DisplayName = Input.DisplayName;
        user.SortName = Input.SortName.HasValue() ? Input.SortName : ToSortName(Input);
        user.GivenName = Input.GivenName;
        user.FamilyName = Input.FamilyName;
        user.JobTitle = Input.JobTitle;

        var updateResult = await _userManager.UpdateAsync(user);
        CheckResult(updateResult, userId);

        ShowAlert("Successfully saved user");

        return RedirectToPage("/Global/User/Edit", new { id = Id });
    }

    public async Task<IActionResult> OnPostDeleteUser()
    {
        var user = await _userManager.FindByIdAsync(Id);
        if (user == null)
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded)
        {
            ShowAlert("Successfully deleted tenant");

            return RedirectToPage("/Global/User/Index");
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return Page();
    }

    private void CheckResult(IdentityResult identityResult, string userId)
    {
        if (identityResult.Succeeded)
            return;

        throw new InvalidOperationException($"Unexpected error occurred updating user with ID '{userId}'.");
    }

    protected void ShowAlert(string message, string type = "success")
    {
        TempData["alert.type"] = type;
        TempData["alert.message"] = message;
    }

    private string ToSortName(InputModel user)
    {
        if (user.FamilyName.HasValue() && user.GivenName.HasValue())
            return $"{user.FamilyName}, {user.GivenName}";

        if (user.FamilyName.HasValue())
            return user.FamilyName;

        return user.DisplayName;
    }
}
