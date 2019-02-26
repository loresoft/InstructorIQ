using System;
using System.Threading.Tasks;
using AutoMapper;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Group
{
    public class EditModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EditModel(
            ILogger<CreateModel> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public GroupUpdateModel Group { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var command = new EntityIdentifierQuery<Guid, GroupUpdateModel>(Id, User);
            var result = await _mediator.Send(command).ConfigureAwait(false);
            if (result == null)
                return NotFound();

            Group = result;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var readCommand = new EntityIdentifierQuery<Guid, GroupUpdateModel>(Id, User);
            var updateModel = await _mediator.Send(readCommand).ConfigureAwait(false);
            if (updateModel == null)
                return NotFound();

            await TryUpdateModelAsync(
                updateModel,
                "Group",
                p => p.Name,
                p => p.Description,
                p => p.Sequence
            );

            var updateCommand = new EntityUpdateCommand<Guid, GroupUpdateModel, GroupReadModel>(Id, updateModel, User);
            var result = await _mediator.Send(updateCommand).ConfigureAwait(false);

            Message = "Successfully saved group";

            return RedirectToPage("/Group/Edit", new { id = result.Id });
        }
    }
}