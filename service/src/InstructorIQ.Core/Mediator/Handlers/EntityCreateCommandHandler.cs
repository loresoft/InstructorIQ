using System;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class EntityCreateCommandHandler<TEntity, TCreateModel, TReadModel> : IAsyncRequestHandler<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TCreateModel : EntityCreateModel
        where TReadModel : EntityReadModel
    {
        private readonly InstructorIQContext _context;
        private readonly IMapper _mapper;

        public EntityCreateCommandHandler(InstructorIQContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TReadModel> Handle(EntityCreateCommand<TEntity, TCreateModel, TReadModel> message)
        {
            var entity = _mapper.Map<TEntity>(message.Model);

            var dbSet = _context
                .Set<TEntity>();

            await dbSet
                .AddAsync(entity)
                .ConfigureAwait(false);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            var readModel = _mapper.Map<TReadModel>(entity);

            return readModel;
        }
    }
}