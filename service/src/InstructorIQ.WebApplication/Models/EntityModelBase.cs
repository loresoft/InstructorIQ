using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Models
{
    public abstract class EntityModelBase<TEntity> : MediatorModelBase
        where TEntity : new()
    {
        protected EntityModelBase(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
            Entity = new TEntity();
        }

        [BindProperty]
        public TEntity Entity { get; set; }

        protected void ShowAlert(string message, string type = "success")
        {
            TempData["alert.type"] = type;
            TempData["alert.message"] = message;
        }
    }
}