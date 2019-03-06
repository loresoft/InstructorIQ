using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Models
{
    public abstract class MediatorModelBase : PageModel
    {
        protected MediatorModelBase(IMediator mediator, ILoggerFactory loggerFactory)
        {
            Mediator = mediator;
            Logger = loggerFactory.CreateLogger(GetType());
        }

        protected ILogger Logger { get; }

        protected IMediator Mediator { get; }

        protected void ShowAlert(string message, string type = "success")
        {
            TempData["alert.type"] = type;
            TempData["alert.message"] = message;
        }
    }
}