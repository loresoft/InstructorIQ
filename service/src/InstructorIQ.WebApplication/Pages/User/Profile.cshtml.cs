using System;
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
public class ProfileModel : MediatorModelBase
{
    private readonly SignInManager<Core.Data.Entities.User> _signInManager;
    private readonly UserManager<Core.Data.Entities.User> _userManager;

    public ProfileModel(
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

    public string Username { get; set; }

    public class InputModel
    {
        [Required]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

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
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

        var displayName = user.DisplayName;
        var userName = await _userManager.GetUserNameAsync(user);
        var email = await _userManager.GetEmailAsync(user);
        var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

        Username = userName;

        Input = new InputModel
        {
            DisplayName = displayName,
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

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return NotFound($"Unable to load user '{User}'.");

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
        user.GivenName = Input.GivenName;
        user.FamilyName = Input.FamilyName;
        user.JobTitle = Input.JobTitle;

        var updateResult = await _userManager.UpdateAsync(user);
        CheckResult(updateResult, userId);

        await _signInManager.RefreshSignInAsync(user);
        ShowAlert("Your profile has been updated");

        return RedirectToPage();
    }

    private void CheckResult(IdentityResult identityResult, string userId)
    {
        if (identityResult.Succeeded)
            return;

        throw new InvalidOperationException($"Unexpected error occurred updating user with ID '{userId}'.");
    }
}
