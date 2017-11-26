using System;
using System.Threading.Tasks;
using FluentValidation;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Behaviors
{
    public class ValidateEntityUpdateCommandBehavior<TEntity, TUpdateModel, TReadModel> : IPipelineBehavior<EntityUpdateCommand<TEntity, TUpdateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TUpdateModel : EntityUpdateModel
        where TReadModel : EntityReadModel
    {
        private readonly IValidator<TUpdateModel> _validator;

        public ValidateEntityUpdateCommandBehavior(IValidator<TUpdateModel> validator)
        {
            _validator = validator;
        }

        public async Task<TReadModel> Handle(EntityUpdateCommand<TEntity, TUpdateModel, TReadModel> request, RequestHandlerDelegate<TReadModel> next)
        {
            // validate before processing
            await _validator.ValidateAndThrowAsync(request.Model).ConfigureAwait(false);

            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}