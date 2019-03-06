using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Behaviors;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Definitions;
using InstructorIQ.Core.Domain;
using InstructorIQ.Core.Security;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Behaviors
{
    public class TenantUpdateCommandBehavior<TKey, TEntityModel, TResponse>
        : PipelineBehaviorBase<EntityUpdateCommand<TKey, TEntityModel, TResponse>, TResponse>
        where TEntityModel : class
    {
        private readonly UserClaimManager _userClaimManager;

        public TenantUpdateCommandBehavior(ILoggerFactory loggerFactory, UserClaimManager userClaimManager) : base(loggerFactory)
        {
            _userClaimManager = userClaimManager;
        }

        protected override async Task<TResponse> Process(EntityUpdateCommand<TKey, TEntityModel, TResponse> request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            SetTenantId(request);

            // continue pipeline
            return await next().ConfigureAwait(false);
        }

        private void SetTenantId(EntityUpdateCommand<TKey, TEntityModel, TResponse> request)
        {
            if (!(request.Model is IHaveTenant<Guid> tenantModel))
                return;

            if (tenantModel.TenantId != Guid.Empty)
                return;

            var tenantId = _userClaimManager.GetRequiredTenantId(request.Principal);
            tenantModel.TenantId = tenantId;
        }
    }
}