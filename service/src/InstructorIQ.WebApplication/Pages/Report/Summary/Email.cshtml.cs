using System;
using System.Net.Mail;
using System.Threading.Tasks;
using EntityChange.Extensions;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Report.Summary
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class EmailModel : SummaryModel
    {
        private readonly IEmailTemplateService _templateService;
        private readonly UserClaimManager _userClaimManager;

        public EmailModel(
            ITenant<TenantReadModel> tenant,
            IMediator mediator,
            ILoggerFactory loggerFactory,
            IEmailTemplateService templateService,
            UserClaimManager userClaimManager)
            : base(tenant, mediator, loggerFactory)
        {
            _templateService = templateService;
            _userClaimManager = userClaimManager;
            Date = DateTime.Now;
        }

        [BindProperty]
        public SummaryReportEmail Message { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Tenant == null || !Tenant.HasValue)
                return RedirectToPage("/Index");

            var address = _userClaimManager.GetEmail(User) ?? User.Identity.Name;
            var name = _userClaimManager.GetDisplayName(User);
            
            Message = new SummaryReportEmail();
            Message.ReplyToAddress = address;
            Message.ReplyToName = name;

            await Load();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var email = Message;
            await _templateService.SendSummaryEmail(email);

            ShowAlert("Successfully sent email");

            return RedirectToPage("/report/summary/index", new { date = Date.ToString("yyyy-MM-dd"), tenant = TenantRoute });
        }

    }
}