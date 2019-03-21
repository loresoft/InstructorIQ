using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Models
{
    public abstract class EntityCreateModelBase<TEntity> : MediatorModelBase
        where TEntity : new()
    {
        protected EntityCreateModelBase(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
            Entity = new TEntity();
        }

        [BindProperty]
        public TEntity Entity { get; set; }
    }
}