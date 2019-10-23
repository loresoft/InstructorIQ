using System;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
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

        public EmailModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, IEmailTemplateService templateService)
            : base(tenant, mediator, loggerFactory)
        {
            _templateService = templateService;
            Date = DateTime.Now;
        }

        [BindProperty]
        public EmailMessage Message { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Tenant == null || !Tenant.HasValue)
                return RedirectToPage("/Index");
            
            Message = new EmailMessage
            {
                ReplyTo = User.Identity.Name
            };

            await Load();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var email = Message;
            await _templateService.SendMessage(email);

            ShowAlert("Successfully sent email");

            return RedirectToPage("/report/summary/index", new { date = Date.ToString("yyyy-MM-dd"), tenant = TenantRoute });
        }

    }
}