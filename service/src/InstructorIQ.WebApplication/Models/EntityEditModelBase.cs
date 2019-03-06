using System;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Models
{
    public abstract class EntityEditModelBase<TModel> : MediatorModelBase
        where TModel : new()
    {
        protected EntityEditModelBase(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
            Entity = new TModel();
        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public TModel Entity { get; set; }


        public virtual async Task<IActionResult> OnGetAsync()
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