using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Data.Definitions;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Behaviors
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
            var organizationModel = request.Model as IHaveOrganization;
            if (organizationModel == null)
                return;

            var organizationString = principal.Identity?.GetOrganizationId();
            Guid.TryParse(organizationString, out Guid organizationId);

            if (organizationId == organizationModel.OrganizationId)
                return;

            throw new MediatorException((int)HttpStatusCode.Forbidden, "User does not have access to specified organization.");
        }
    }
}