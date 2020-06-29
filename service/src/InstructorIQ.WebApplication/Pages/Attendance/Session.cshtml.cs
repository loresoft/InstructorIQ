using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Attendance
{
    public class SessionModel : EntityIdentifierModelBase<SessionReadModel>
    {
        public SessionModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        public IReadOnlyCollection<MemberReadModel> Members { get; set; }

        public IReadOnlyCollection<AttendanceSessionModel> Attendances { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetAsync();
            if (Entity == null)
                return NotFound();

            await LoadMembers();
            await LoadAttendances();

            return Page();
        }

        private async Task LoadMembers()
        {
            var command = new MemberSelectQuery(User, Tenant.Value.Id);
            command.RoleId = Core.Data.Constants.Role.Attendee;

            var members = await Mediator.Send(command);

            Members = members
                .OrderBy(m => m.SortName)
                .ToList();
        }

        private async Task LoadAttendances()
        {
            var filter = new EntityFilter
            {
                Operator = EntityFilterOperators.Equal,
                Name = nameof(AttendanceSessionModel.SessionId),
                Value = Id
            };
            var select = new EntitySelect(filter);
            var command = new EntitySelectQuery<AttendanceSessionModel>(User, select);
            var results = await Mediator.Send(command);

            Attendances = results.ToList();
        }

        public AttendanceSessionModel GetAttendee(string username)
        {
            return Attendances
                .FirstOrDefault(a => string.Equals(
                    a.AttendeeEmail,
                    username,
                    StringComparison.OrdinalIgnoreCase
                ));
        }

    }
}