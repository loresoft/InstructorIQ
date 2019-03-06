using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Models
{
    public abstract class EntityCreateModelBase<TEntity> : MediatorModelBase
        where TEntity : new()
    {
        protected EntityCreateModelBase(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
            Entity = new TEntity();
        }

        [BindProperty]
        public TEntity Entity { get; set; }
    }
}