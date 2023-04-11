using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Member.Import;

public class IndexModel : MediatorModelBase
{
    public IndexModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {

    }

    [Required]
    [BindProperty]
    public IFormFile Upload { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var importCommand = new MemberImportUploadCommand(User, Upload, Tenant.Value.Id);
        var importJobModel = await Mediator.Send(importCommand);

        return RedirectToPage("/Member/Import/Mapping", new { id = importJobModel.Id, tenant = TenantRoute });
    }
}
