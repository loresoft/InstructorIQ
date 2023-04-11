using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using EntityChange.Extensions;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using NaturalSort.Extension;

namespace InstructorIQ.WebApplication.Pages.Topic.Messaging;

public abstract class MessagingModel : EntityIdentifierModelBase<TopicListModel>
{
    protected MessagingModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
    }

    [BindProperty]
    public UserLinkModel Message { get; set; }

    public IReadOnlyCollection<MemberDropdownModel> Members { get; set; }

    public IReadOnlyCollection<SessionCalendarModel> Sessions { get; set; }


    public override async Task<IActionResult> OnGetAsync()
    {
        var loadTask = base.OnGetAsync();
        var loadMembers = LoadMembers();
        var loadSessions = LoadSessions();

        // load all in parallel
        await Task.WhenAll(
            loadTask,
            loadMembers,
            loadSessions
        );

        var recipients = GetInstructorEmails();

        Message = new UserLinkModel();
        Message.Recipients = recipients;

        return Page();
    }


    protected List<string> GetInstructorEmails()
    {
        var instructors = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        if (Entity.LeadInstructorEmail.HasValue())
            instructors.Add(Entity.LeadInstructorEmail);

        if (Sessions == null || Sessions.Count == 0)
            return instructors.ToList();

        foreach (var session in Sessions)
        {
            if (session.LeadInstructorEmail.HasValue())
                instructors.Add(session.LeadInstructorEmail);

            foreach (var instructor in session.AdditionalInstructors)
                if (instructor.Email.HasValue())
                    instructors.Add(instructor.Email);
        }

        return instructors.ToList(); ;
    }

    protected virtual async Task LoadMembers()
    {
        var command = new MemberDropdownQuery(User, Tenant.Value.Id);
        command.RoleId = Core.Data.Constants.Role.Member;

        var members = await Mediator.Send(command);

        Members = members.ToList();
    }

    protected virtual async Task LoadSessions()
    {
        var query = new SessionTopicQuery(User, Id);
        var result = await Mediator.Send(query);

        Sessions = result
            .OrderBy(r => r.StartDate)
            .ThenBy(r => r.StartTime)
            .ThenBy(i => i.GroupName, StringComparer.OrdinalIgnoreCase.WithNaturalSort())
            .ToList();
    }


    public string GetMonthName(int month)
    {
        return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
    }

    private string FormatName(MemberReadModel member)
    {
        var name = member.SortName ?? member.DisplayName;
        var email = member.Email;

        return $"{name} <{email}>";
    }

}
