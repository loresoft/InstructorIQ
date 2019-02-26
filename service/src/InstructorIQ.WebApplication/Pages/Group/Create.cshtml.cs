using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Group
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IMediator _mediator;

        public CreateModel(
            ILogger<CreateModel> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public GroupCreateModel Group { get; set; } = new GroupCreateModel();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var createModel = new GroupCreateModel();

            await TryUpdateModelAsync(
                createModel,
                "Group",
                p => p.Name,
                p => p.Description,
                p => p.Sequence
            );

            var command = new EntityCreateCommand<GroupCreateModel, GroupReadModel>(createModel, User);
            var result = await _mediator.Send(command).ConfigureAwait(false);

            Message = "Successfully created group";

            return RedirectToPage("/Group/Edit", new { id = result.Id });
        }
    }
}