using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using EntityChange.Extensions;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Report.Summary
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class EmailModel : SummaryModel
    {
        private readonly UserClaimManager _userClaimManager;

        public EmailModel(
            ITenant<TenantReadModel> tenant,
            IMediator mediator,
            ILoggerFactory loggerFactory,
            UserClaimManager userClaimManager)
            : base(tenant, mediator, loggerFactory)
        {
            _userClaimManager = userClaimManager;
            Date = DateTime.Now;
        }

        [BindProperty]
        public SummaryReportModel Message { get; set; }

        public IReadOnlyCollection<MemberDropdownModel> Members { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Tenant == null || !Tenant.HasValue)
                return RedirectToPage("/Index");

            var address = _userClaimManager.GetEmail(User) ?? User.Identity.Name;
            var name = _userClaimManager.GetDisplayName(User);
            
            Message = new SummaryReportModel();
            Message.ReplyToAddress = address;
            Message.ReplyToName = name;

            await Load();
            await LoadMembers();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var email = Message;

            var command = new SendSummaryEmailCommand(User, email);
            await Mediator.Send(command);

            ShowAlert("Successfully sent email");

            return RedirectToPage("/report/summary/index", new { date = Date.ToString("yyyy-MM-dd"), tenant = TenantRoute });
        }

        protected virtual async Task LoadMembers()
        {
            var command = new MemberSelectQuery(User, Tenant.Value.Id);
            command.RoleName = Core.Data.Constants.Role.MemberName;

            var members = await Mediator.Send(command);

            Members = members
                .OrderBy(m => m.SortName)
                .Select(m => new MemberDropdownModel
                {
                    Text = FormatName(m),
                    Value = m.Email
                })
                .ToList();
        }

        private string FormatName(MemberReadModel member)
        {
            var name = member.SortName ?? member.DisplayName;
            var email = member.Email;

            return $"{name} <{email}>";
        }
    }
}