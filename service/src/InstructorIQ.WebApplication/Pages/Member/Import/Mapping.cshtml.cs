using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Member.Import
{
    public class MappingModel : MediatorModelBase
    {
        public MappingModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public MemberImportJobModel Import { get; set; }

        public List<SelectListItem> Headers { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var importQuery = new MemberImportJobQuery(User, Id);
            var importJobModel = await Mediator.Send(importQuery);
            if (importJobModel == null)
                return NotFound();

            Import = importJobModel;

            Headers = importJobModel.Headers
                .Select(h => new SelectListItem(h, h))
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var importCommand = new MemberImportProcessCommand(User, Import);
            var importJobModel = await Mediator.Send(importCommand);
            
            return RedirectToPage("/Member/Index", new { tenant = TenantRoute });
        }

    }
}