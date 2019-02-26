using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Behaviors;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Definitions;
using InstructorIQ.Core.Security;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Behaviors
{
    public class TenantCreateCommandBehavior<TEntityModel, TResponse>
        : PipelineBehaviorBase<EntityCreateCommand<TEntityModel, TResponse>, TResponse>
        where TEntityModel : class
    {
        private readonly UserClaimManager _userClaimManager;


        public TenantCreateCommandBehavior(ILoggerFactory loggerFactory, UserClaimManager userClaimManager) : base(loggerFactory)
        {
            _userClaimManager = userClaimManager;
        }

        protected override async Task<TResponse> Process(EntityCreateCommand<TEntityModel, TResponse> request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            SetTenantId(request);

            // continue pipeline
            return await next().ConfigureAwait(false);
        }

        private void SetTenantId(EntityCreateCommand<TEntityModel, TResponse> request)
        {
            if (!(request.Model is IHaveTenant<Guid> tenantModel))
                return;

            if (tenantModel.TenantId != Guid.Empty)
                return;

            var tenantString = _userClaimManager.GetTenantId(request.Principal);
            if (Guid.TryParse(tenantString, out var tenantId))
                tenantModel.TenantId = tenantId;
        }
    }
}
