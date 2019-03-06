using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic
{
    public class CreateModel : EntityCreateModelBase<TopicCreateModel>
    {
        public CreateModel(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {

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

            var command = new EntityCreateCommand<TopicCreateModel, TopicReadModel>(createModel, User);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully created topic");

            return RedirectToPage("/Topic/Edit", new { id = result.Id });
        }
    }
}