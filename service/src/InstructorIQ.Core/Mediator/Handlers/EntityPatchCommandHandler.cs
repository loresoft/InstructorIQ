using System;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class EntityPatchCommandHandler<TEntity, TReadModel> : IAsyncRequestHandler<EntityPatchCommand<TEntity, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        private readonly InstructorIQContext _context;
        private readonly IMapper _mapper;

        public EntityPatchCommandHandler(InstructorIQContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TReadModel> Handle(EntityPatchCommand<TEntity, TReadModel> message)
        {
            var dbSet = _context
                .Set<TEntity>();

            var entity = await dbSet
                .FindAsync(message.Id)
                .ConfigureAwait(false);

            message.Patch?.ApplyTo(entity);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            var model = _mapper.Map<TReadModel>(entity);

            return model;
        }
    }
}