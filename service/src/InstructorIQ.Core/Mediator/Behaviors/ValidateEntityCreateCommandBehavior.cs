using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Behaviors
{
    public class ValidateEntityCreateCommandBehavior<TEntity, TCreateModel, TReadModel> : PipelineBehaviorBase<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TCreateModel : EntityCreateModel
        where TReadModel : EntityReadModel
    {
        private readonly IValidator<TCreateModel> _validator;

        public ValidateEntityCreateCommandBehavior(ILoggerFactory loggerFactory, IValidator<TCreateModel> validator) : base(loggerFactory)
        {
            _validator = validator;
        }

        protected override async Task<TReadModel> Process(EntityCreateCommand<TEntity, TCreateModel, TReadModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<TReadModel> next)
        {
            // validate before processing
            await _validator.ValidateAndThrowAsync(request.Model).ConfigureAwait(false);

            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}
