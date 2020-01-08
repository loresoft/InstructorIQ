using System;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Models
{
    public abstract class MediatorModelBase : PageModel
    {
        protected MediatorModelBase(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        {
            Tenant = tenant;
            Mediator = mediator;
            Logger = loggerFactory.CreateLogger(GetType());
        }

        public ITenant<TenantReadModel> Tenant { get; }

        public string TenantRoute => Tenant?.Value?.Slug ?? string.Empty;


        protected ILogger Logger { get; }

        protected IMediator Mediator { get; }


        protected void ShowAlert(string message, string type = "success")
        {
            TempData["alert.type"] = type;
            TempData["alert.message"] = message;
        }
    }
}