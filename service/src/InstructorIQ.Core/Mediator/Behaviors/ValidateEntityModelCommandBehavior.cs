using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using InstructorIQ.Core.Mediator.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Behaviors
{
    public class ValidateEntityModelCommandBehavior<TEntityModel, TResponse> : PipelineBehaviorBase<EntityModelCommand<TEntityModel, TResponse>, TResponse>
        where TEntityModel : class
    {
        private readonly IValidator<TEntityModel> _validator;

        public ValidateEntityModelCommandBehavior(ILoggerFactory loggerFactory, IValidator<TEntityModel> validator) : base(loggerFactory)
        {
            _validator = validator;
        }

        protected override async Task<TResponse> Process(EntityModelCommand<TEntityModel, TResponse> request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // validate before processing
            await _validator.ValidateAndThrowAsync(request.Model).ConfigureAwait(false);

            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}