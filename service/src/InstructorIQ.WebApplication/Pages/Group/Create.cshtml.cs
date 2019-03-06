using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Group
{
    public class CreateModel : EntityCreateModelBase<GroupCreateModel>
    {
        public CreateModel(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var createModel = new GroupCreateModel();

            // only update input fields
            await TryUpdateModelAsync(
                createModel,
                nameof(Entity),
                p => p.Name,
                p => p.Description,
                p => p.Sequence
            );

            var command = new EntityCreateCommand<GroupCreateModel, GroupReadModel>(createModel, User);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully created group");

            return RedirectToPage("/Group/Edit", new { id = result.Id });
        }
    }
}