using System;
using System.Net;
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
    public class AuthenticateEntityModelCommandBehavior<TEntityModel, TResponse> : PipelineBehaviorBase<EntityModelCommand<TEntityModel, TResponse>, TResponse>
        where TEntityModel : class
    {

        private readonly UserClaimManager _claimManager;

        public AuthenticateEntityModelCommandBehavior(ILoggerFactory loggerFactory, UserClaimManager claimManager) : base(loggerFactory)
        {
            _claimManager = claimManager;
        }

        protected override async Task<TResponse> Process(EntityModelCommand<TEntityModel, TResponse> request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Authorize(request);

            // continue pipeline
            return await next().ConfigureAwait(false);
        }

        private void Authorize(EntityModelCommand<TEntityModel, TResponse> request)
        {
            var principal = request.Principal;
            if (principal == null)
                return;

            var isGlobalAdmin = _claimManager.IsGlobalAdministrator(principal);
            if (isGlobalAdmin)
                return;

            // check principal organization is same of model organization
            if (!(request.Model is IHaveTenant<Guid> tenantModel))
                return;

            var tenantId = _claimManager.GetRequiredTenantId(principal);
            if (tenantId == tenantModel.TenantId)
                return;

            throw new DomainException(HttpStatusCode.Forbidden, "User does not have access to specified tenant.");
        }
    }
}