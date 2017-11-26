using System;
using System.Threading.Tasks;
using FluentValidation;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Behaviors
{
    public class ValidateEntityCreateCommandBehavior<TEntity, TCreateModel, TReadModel> : IPipelineBehavior<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TCreateModel : EntityCreateModel
        where TReadModel : EntityReadModel
    {
        private readonly IValidator<TCreateModel> _validator;

        public ValidateEntityCreateCommandBehavior(IValidator<TCreateModel> validator)
        {
            _validator = validator;
        }

        public async Task<TReadModel> Handle(EntityCreateCommand<TEntity, TCreateModel, TReadModel> request, RequestHandlerDelegate<TReadModel> next)
        {
            // validate before processing
            await _validator.ValidateAndThrowAsync(request.Model).ConfigureAwait(false);

            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}
