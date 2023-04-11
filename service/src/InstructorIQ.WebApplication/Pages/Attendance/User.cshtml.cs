using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.Core.Services;
using InstructorIQ.WebApplication.Models;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Attendance;

[Authorize(Policy = UserPolicies.UserPolicy)]
public class UserModel : MediatorModelBase
{
    private readonly IStateService _stateService;

    public UserModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, IStateService stateService)
        : base(tenant, mediator, loggerFactory)
    {
        _stateService = stateService;
    }

    [BindProperty(Name = "q", SupportsGet = true)]
    public string Query { get; set; }

    [BindProperty(Name = "year", SupportsGet = true)]
    public int? Year { get; set; }

    [BindProperty(Name = "month", SupportsGet = true)]
    public int? Month { get; set; }

    [BindProperty(Name = "username", SupportsGet = true)]
    public string UserName { get; set; }

    public IReadOnlyCollection<MemberDropdownModel> Members { get; set; }

    public IReadOnlyCollection<AttendanceSessionModel> Items { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        ReadHistory();

        var loadTask = LoadItems();
        var loadMembersTask = LoadMembers();

        // load all in parallel
        await Task.WhenAll(
            loadTask,
            loadMembersTask
        );

        Items = loadTask.Result;
        Members = loadMembersTask.Result;

        WriteHistory();

        return Page();
    }

    private async Task<IReadOnlyCollection<MemberDropdownModel>> LoadMembers()
    {
        var command = new MemberSelectQuery(User, Tenant.Value.Id);
        command.RoleId = Core.Data.Constants.Role.Attendee;

        var members = await Mediator.Send(command);

        return members
            .OrderBy(m => m.SortName)
            .Select(m => new MemberDropdownModel
            {
                Value = m.UserName,
                Text = m.SortName
            })
            .ToList();
    }

    private async Task<IReadOnlyCollection<AttendanceSessionModel>> LoadItems()
    {
        var command = new AttendanceSessionQuery(User, Tenant.Value.Id);
        command.SearchText = Query;
        command.UserName = UserName;

        if (Year.HasValue && Month.HasValue && Month.Value > 0)
        {
            var startDate = new DateTime(Year.Value, Month.Value, 1);
            command.StartDate = startDate;
            command.EndDate = startDate.AddMonths(1);
        }
        else if (Year.HasValue)
        {
            var startDate = new DateTime(Year.Value, 1, 1);
            command.StartDate = startDate;
            command.EndDate = startDate.AddYears(1);
        }

        var result = await Mediator.Send(command);

        return result;
    }

    private void WriteHistory()
    {
        var state = new SessionQueryState
        {
            Year = Year,
            Month = Month,
            Query = Query,
            UserName = UserName
        };

        _stateService.WriteState(state, "attend_user");
    }

    private void ReadHistory()
    {
        var state = _stateService.ReadState<SessionQueryState>("attend_user");
        if (Year == null || Year == 0)
            Year = state?.Year ?? DateTime.Now.Year;

        if (Month == null)
            Month = state?.Month ?? DateTime.Now.Month;

        if (!Request.Query.ContainsKey("q"))
            Query = state?.Query?.Trim();

        if (!Request.Query.ContainsKey("username"))
            UserName = state?.UserName?.Trim();
    }
}
