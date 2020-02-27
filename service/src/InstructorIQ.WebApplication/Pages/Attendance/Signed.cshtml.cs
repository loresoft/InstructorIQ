using System;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Attendance
{
    public class SignedModel : EntityIdentifierModelBase<AttendanceReadModel>
    {
        public SignedModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        [BindProperty(SupportsGet = true)]
        public Guid SessionId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Route { get; set; }

        public SessionReadModel Session { get; set; }

        public MemberReadModel Member { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetAsync();
            if (Entity == null)
                return NotFound();

            await LoadSession();
            await LoadUser(Entity.AttendeeEmail);

            if (Session == null || Member == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteEntity()
        {
            var command = new EntityDeleteCommand<Guid, AttendanceSessionModel>(User, Id);
            var result = await Mediator.Send(command);

            if (Route == "user")
                return RedirectToPage("/attendance/user", new { tenant = TenantRoute });

            if (Route == "topic")
                return RedirectToPage("/attendance/topic", new { tenant = TenantRoute });

            return RedirectToPage("/attendance/session", new { id = SessionId, tenant = TenantRoute });
        }

        private async Task LoadSession()
        {
            var command = new EntityIdentifierQuery<Guid, SessionReadModel>(User, SessionId);
            var result = await Mediator.Send(command);

            Session = result;
        }

        private async Task LoadUser(string username)
        {
            var command = new MemberUserNameQuery(User, username);
            var result = await Mediator.Send(command);

            Member = result;

        }
    }
}
