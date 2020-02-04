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
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Services;

namespace InstructorIQ.WebApplication.Pages.Topic
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class CreateModel : EntityCreateModelBase<TopicCreateModel>
    {
        private readonly IHtmlService _htmlService;

        public CreateModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, IHtmlService htmlService)
            : base(tenant, mediator, loggerFactory)
        {
            _htmlService = htmlService;
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
                p => p.CalendarYear,
                p => p.TargetMonth,
                p => p.IsRequired
            );

            // update summary
            if (createModel.Description.HasValue())
                createModel.Summary = _htmlService.PlainText(createModel.Description).RemoveExtended().Truncate(256);

            var command = new EntityCreateCommand<TopicCreateModel, TopicReadModel>(User, createModel);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully created topic");

            return RedirectToPage("/Topic/Edit", new { id = result.Id, tenant = TenantRoute });
        }
    }
}