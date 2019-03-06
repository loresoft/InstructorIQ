using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Behaviors;
using EntityFrameworkCore.CommandQuery.Definitions;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Security;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Behaviors
{
    public class TenantFilterQueryBehavior<TEntityModel> : PipelineBehaviorBase<EntityListQuery<TEntityModel>, EntityListResult<TEntityModel>>
    {
        private readonly UserClaimManager _userClaimManager;

        public TenantFilterQueryBehavior(ILoggerFactory loggerFactory, UserClaimManager userClaimManager) : base(loggerFactory)
        {
            _userClaimManager = userClaimManager;
        }

        protected override async Task<EntityListResult<TEntityModel>> Process(EntityListQuery<TEntityModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<EntityListResult<TEntityModel>> next)
        {
            // add tenant filter
            SetTenantQuery(request);

            // continue pipeline
            return await next().ConfigureAwait(false);
        }

        private void SetTenantQuery(EntityListQuery<TEntityModel> request)
        {
            bool supportsTenant = typeof(TEntityModel).Implements<IHaveTenant<Guid>>();
            if (!supportsTenant)
                return;

            var tenantId = _userClaimManager.GetRequiredTenantId(request.Principal);
            var tenantFilter = new EntityFilter
            {
                Name = nameof(IHaveTenant<Guid>.TenantId),
                Value = tenantId,
                Operator = EntityFilterOperators.Equal
            };

            var currentFilter = request.Query.Filter;
            if (currentFilter == null)
            {
                request.Query.Filter = tenantFilter;
                return;
            }

            var boolFilter = new EntityFilter
            {
                Logic = EntityFilterLogic.And,
                Filters = new[]
                {
                    tenantFilter,
                    currentFilter
                }
            };
            request.Query.Filter = boolFilter;
        }
    }
}