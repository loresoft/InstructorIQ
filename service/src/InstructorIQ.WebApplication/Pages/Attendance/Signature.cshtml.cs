using System;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Attendance
{
    public class SignatureModel : EntityIdentifierModelBase<MemberReadModel>
    {
        public SignatureModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        [BindProperty]
        public AttendanceCreateModel Attendance { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid SessionId { get; set; }

        public SessionReadModel Session { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetAsync();
            await LoadSession();

            if (Entity == null || Session == null)
                return NotFound();

            Attendance = new AttendanceCreateModel
            {
                AttendedBy = Entity.UserName,
                SessionId = Session.Id,
                TenantId = Tenant.Value.Id,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var createModel = new AttendanceCreateModel();

            // only update input fields
            await TryUpdateModelAsync(
                createModel,
                nameof(Attendance),
                p => p.SessionId,
                p => p.TenantId,
                p => p.Signature,
                p => p.SignatureType,
                p => p.AttendedBy
            );
            createModel.Attended = DateTimeOffset.UtcNow;

            var command = new EntityCreateCommand<AttendanceCreateModel, AttendanceReadModel>(User, createModel);
            var result = await Mediator.Send(command);

            return RedirectToPage("/attendance/session", new { id = result.SessionId, tenant = TenantRoute });
        }

        private async Task LoadSession()
        {
            var command = new EntityIdentifierQuery<Guid, SessionReadModel>(User, SessionId);
            var result = await Mediator.Send(command);

            Session = result;
        }
    }
}