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
    public class ValidateEntityUpdateCommandBehavior<TEntity, TUpdateModel, TReadModel> : PipelineBehaviorBase<EntityUpdateCommand<TEntity, TUpdateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TUpdateModel : EntityUpdateModel
        where TReadModel : EntityReadModel
    {
        private readonly IValidator<TUpdateModel> _validator;

        public ValidateEntityUpdateCommandBehavior(ILoggerFactory loggerFactory, IValidator<TUpdateModel> validator) : base(loggerFactory)
        {
            _validator = validator;
        }

        protected override async Task<TReadModel> Process(EntityUpdateCommand<TEntity, TUpdateModel, TReadModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<TReadModel> next)
        {
            // validate before processing
            await _validator.ValidateAndThrowAsync(request.Model).ConfigureAwait(false);

            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}