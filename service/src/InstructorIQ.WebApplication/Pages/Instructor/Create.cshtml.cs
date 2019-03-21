using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Instructor
{
    public class CreateModel : EntityCreateModelBase<InstructorCreateModel>
    {
        public CreateModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var createModel = new InstructorCreateModel();

            // only update input fields
            await TryUpdateModelAsync(
                createModel,
                nameof(Entity),
                p => p.GivenName,
                p => p.FamilyName,
                p => p.DisplayName,
                p => p.JobTitle,
                p => p.EmailAddress,
                p => p.MobilePhone,
                p => p.BusinessPhone
            );

            var command = new EntityCreateCommand<InstructorCreateModel, InstructorReadModel>(createModel, User);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully created instructor");

            return RedirectToPage("/Instructor/Edit", new { id = result.Id, tenant = TenantRoute });
        }
    }
}