using System.Threading.Tasks;
using MediatR.CommandQuery.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace InstructorIQ.WebApplication.Pages.Topic
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class CreateModel : EntityCreateModelBase<TopicCreateModel>
    {
        public CreateModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
            Entity.CalendarYear = (short)DateTime.Now.Year;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var createModel = new TopicCreateModel();

            // only update input fields
            await TryUpdateModelAsync(
                createModel,
                nameof(Entity),
                p => p.Title,
                p => p.Description,
                p => p.CalendarYear
            );

            var command = new EntityCreateCommand<TopicCreateModel, TopicReadModel>(User, createModel);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully created topic");

            return RedirectToPage("/Topic/Edit", new { id = result.Id, tenant = TenantRoute });
        }
    }
}