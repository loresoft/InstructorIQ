using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.SignUp
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class CreateModel : EntityCreateModelBase<SignUpCreateModel>
    {
        public CreateModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var createModel = new SignUpCreateModel();

            // only update input fields
            await TryUpdateModelAsync(
                createModel,
                nameof(Entity),
                p => p.Name,
                p => p.Description
            );

            var command = new EntityCreateCommand<SignUpCreateModel, SignUpReadModel>(User, createModel);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully created instructor signup");

            return RedirectToPage("/SignUp/Edit", new { id = result.Id, tenant = TenantRoute });
        }

    }
}