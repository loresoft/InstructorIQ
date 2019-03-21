using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Location
{
    public class CreateModel : EntityCreateModelBase<LocationCreateModel>
    {
        public CreateModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var createModel = new LocationCreateModel();

            // only update input fields
            await TryUpdateModelAsync(
                createModel,
                nameof(Entity),
                p => p.Name,
                p => p.Description,
                p => p.AddressLine1,
                p => p.City,
                p => p.StateProvince,
                p => p.PostalCode
            );

            var command = new EntityCreateCommand<LocationCreateModel, LocationReadModel>(createModel, User);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully created location");

            return RedirectToPage("/Location/Edit", new { id = result.Id, tenant = TenantRoute });
        }
    }
}