using System;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Report.Summary;

public class IndexModel : SummaryModel
{
    public IndexModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
        Date = DateTime.Now;
    }

    public virtual async Task<IActionResult> OnGetAsync()
    {
        if (Tenant == null || !Tenant.HasValue)
            return RedirectToPage("/Index");

        await Load();

        return Page();
    }
}
