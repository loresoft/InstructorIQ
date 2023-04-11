using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Messaging;

[Authorize(Policy = UserPolicies.AdministratorPolicy)]
public class PlanUpdateModel : MessagingModel
{
    private readonly UserClaimManager _userClaimManager;

    public PlanUpdateModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, UserClaimManager userClaimManager)
        : base(tenant, mediator, loggerFactory)
    {
        _userClaimManager = userClaimManager;
    }

    public string SenderName { get; set; }

    public override async Task<IActionResult> OnGetAsync()
    {
        await base.OnGetAsync();

        var name = _userClaimManager.GetDisplayName(User);

        // set defaults
        Message.Subject = $"Update Lesson Plan for {Entity.Title}";
        SenderName = name;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var address = _userClaimManager.GetEmail(User) ?? User.Identity.Name;
        var name = _userClaimManager.GetDisplayName(User);

        var link = Url.Page(
            "/topic/planning/view",
            pageHandler: null,
            values: new { id = Id, tenant = TenantRoute },
            protocol: Request.Scheme);

        var email = Message;
        email.ReplyToAddress = address;
        email.ReplyToName = name;
        email.LinkText = "Update Lesson Plan";
        email.LinkUrl = link;

        var command = new SendUserLinkEmailCommand(User, email);
        await Mediator.Send(command);

        ShowAlert("Successfully sent email");

        return RedirectToPage("/topic/planning/view", new { id = Id, tenant = TenantRoute });
    }


}
