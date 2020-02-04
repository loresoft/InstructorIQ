using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Messaging
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class IntroductionModel : MessagingModel
    {
        private readonly UserClaimManager _userClaimManager;

        public IntroductionModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, UserClaimManager userClaimManager)
            : base(tenant, mediator, loggerFactory)
        {
            _userClaimManager = userClaimManager;
        }

        public override async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetAsync();

            // set defaults
            Message.Subject = $"{Entity.Title} Training";

            if (Entity.TargetMonth.HasValue) 
                Message.Subject += $" in {GetMonthName(Entity.TargetMonth.Value)}";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var address = _userClaimManager.GetEmail(User) ?? User.Identity.Name;
            var name = _userClaimManager.GetDisplayName(User);

            var planLink = Url.Page(
                "/topic/planning/view",
                pageHandler: null,
                values: new { id = Id, tenant = TenantRoute },
                protocol: Request.Scheme);

            var email = Message;
            email.ReplyToAddress = address;
            email.ReplyToName = name;
            email.LinkUrl = planLink;
            email.LinkText = "Edit Lesson Plan";

            var command = new SendUserLinkEmailCommand(User, email);
            await Mediator.Send(command);

            ShowAlert("Successfully sent introduction email");

            return RedirectToPage("/topic/planning/view", new { id = Id, tenant = TenantRoute });
        }

        public string TargetMonth()
        {
            if (Entity.TargetMonth.HasValue)
                return GetMonthName(Entity.TargetMonth.Value);

            var startDate = Sessions
                .Where(s => s.StartDate.HasValue)
                .Select(s => s.StartDate)
                .FirstOrDefault();

            if (startDate.HasValue)
                return GetMonthName(startDate.Value.Month);

            return "TBD";
        }
    }
}