using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class EntityPatchCommandHandler<TEntity, TReadModel> : RequestHandlerBase<EntityPatchCommand<TEntity, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        private readonly InstructorIQContext _context;
        private readonly IMapper _mapper;

        public EntityPatchCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext context, IMapper mapper) : base(loggerFactory)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<TReadModel> Process(EntityPatchCommand<TEntity, TReadModel> message, CancellationToken cancellationToken)
        {
            var dbSet = _context
                .Set<TEntity>();

            var keyValue = new[] { message.Id };

            // find entity to update by message id, not model id
            var entity = await dbSet
                .FindAsync(keyValue, cancellationToken)
                .ConfigureAwait(false);

            if (entity == null)
                return null;

            // save original for later pipeline processing
            message.Original = _mapper.Map<TReadModel>(entity);

            // apply json patch to entity
            message.Patch.ApplyTo(entity);

            await _context
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            // return read model
            var model = _mapper.Map<TReadModel>(entity);

            return model;
        }
    }
}