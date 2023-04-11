using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;

using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Member;

public class CreateModel : MediatorModelBase
{
    private readonly UserManager<Core.Data.Entities.User> _userManager;

    public CreateModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, UserManager<Core.Data.Entities.User> userManager)
        : base(tenant, mediator, loggerFactory)
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

        [Display(Name = "Send Invite")]
        public bool SendInvite { get; set; }
    }

    public void OnGet()
    {
        Input = new InputModel { SendInvite = true };
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var user = await GetOrCreateUser();
        if (user == null)
            return Page();

        await UpdateMembership(user);

        if (Input.SendInvite)
        {
            await SendInvite(user);
            ShowAlert("Successfully sent invite email");
        }
        else
        {
            ShowAlert("Successfully saved user");
        }

        return RedirectToPage("/Member/Index", new { tenant = TenantRoute });
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

        var membershipQuery = new TenantMembershipQuery(User, Tenant.Value.Id, user.Id);
        var membership = await Mediator.Send(membershipQuery);

        // make sure user is member
        membership.IsMember = true;

        var membershipCommand = new TenantMembershipCommand(User, membership);
        membership = await Mediator.Send(membershipCommand);
    }

    private async Task SendInvite(Core.Data.Entities.User user)
    {
        var model = new UserInviteModel
        {
            User = user,
            ReturnUrl = Url.Content("~/"),
        };
        Request.ReadUserAgent(model);

        var command = new SendUserInviteEmailCommand(User, model);
        await Mediator.Send(command);
    }
}
