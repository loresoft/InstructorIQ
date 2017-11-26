using System;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class EntityUpdateCommandHandler<TEntity, TUpdateModel, TReadModel> : IAsyncRequestHandler<EntityUpdateCommand<TEntity, TUpdateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TUpdateModel : EntityUpdateModel
        where TReadModel : EntityReadModel
    {
        private readonly InstructorIQContext _context;
        private readonly IMapper _mapper;

        public EntityUpdateCommandHandler(InstructorIQContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TReadModel> Handle(EntityUpdateCommand<TEntity, TUpdateModel, TReadModel> message)
        {
            var dbSet = _context
                .Set<TEntity>();

            var entity = await dbSet
                .FindAsync(message.Id)
                .ConfigureAwait(false);

            if (entity == null && !message.Upsert)
                return null;

            if (entity != null)
            {
                _mapper.Map(message.Model, entity);
            }
            else
            {
                entity = _mapper.Map<TEntity>(message.Model);
                await dbSet
                    .AddAsync(entity)
                    .ConfigureAwait(false);
            }

            

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            var readModel = _mapper.Map<TReadModel>(entity);

            return readModel;
        }
    }
}