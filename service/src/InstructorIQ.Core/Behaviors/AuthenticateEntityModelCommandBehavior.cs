﻿using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Behaviors;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Definitions;
using InstructorIQ.Core.Domain;
using InstructorIQ.Core.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Behaviors
{
    public class AuthenticateEntityModelCommandBehavior<TEntityModel, TResponse> : PipelineBehaviorBase<EntityModelCommand<TEntityModel, TResponse>, TResponse>
        where TEntityModel : class
    {
        public AuthenticateEntityModelCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override async Task<TResponse> Process(EntityModelCommand<TEntityModel, TResponse> request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            AuthorizeOrganization(request);

            // continue pipeline
            return await next().ConfigureAwait(false);
        }

        private void AuthorizeOrganization(EntityModelCommand<TEntityModel, TResponse> request)
        {
            var principal = request.Principal;
            if (principal == null)
                return;

            var isGlobalAdmin = principal.IsGlobalAdministrator();
            if (isGlobalAdmin)
                return;

            // check principal organization is same of model organization
            if (!(request.Model is IHaveTenant<Guid> tenantModel))
                return;

            var organizationString = principal.Identity?.GetTenantId();
            Guid.TryParse(organizationString, out var organizationId);

            if (organizationId == tenantModel.TenantId)
                return;

            throw new DomainException(HttpStatusCode.Forbidden, "User does not have access to specified organization.");
        }
    }
}