using System;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Models
{
    public abstract class EntityIdentifierModelBase<TModel> : EntityModelBase<TModel>
        where TModel : new()
    {
        protected EntityIdentifierModelBase(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var command = new EntityIdentifierQuery<Guid, TModel>(Id, User);

            var result = await Mediator.Send(command);
            if (result == null)
                return NotFound();

            Entity = result;

            return Page();
        }
    }
}