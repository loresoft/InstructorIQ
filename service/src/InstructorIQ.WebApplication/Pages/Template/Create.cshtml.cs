using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Template
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class CreateModel : EntityCreateModelBase<TemplateCreateModel>
    {
        public CreateModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var createModel = new TemplateCreateModel();

            // only update input fields
            await TryUpdateModelAsync(
                createModel,
                nameof(Entity),
                p => p.Name,
                p => p.Description,
                p => p.TemplateBody,
                p => p.TemplateType
            );

            var command = new EntityCreateCommand<TemplateCreateModel, TemplateReadModel>(createModel, User);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully created template");

            return RedirectToPage("/Template/Edit", new { id = result.Id, tenant = TenantRoute });
        }
    }
}