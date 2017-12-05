using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class EntityDeleteCommandHandler<TEntity, TReadModel> : RequestHandlerBase<EntityDeleteCommand<TEntity, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        private readonly InstructorIQContext _context;
        private readonly IMapper _mapper;

        public EntityDeleteCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext context, IMapper mapper) : base(loggerFactory)
        {
            _context = context;
            _mapper = mapper;
        }


        protected override async Task<TReadModel> Process(EntityDeleteCommand<TEntity, TReadModel> message, CancellationToken cancellationToken)
        {
            var dbSet = _context
                .Set<TEntity>();

            var keyValue = new[] { message.Id };

            var entity = await dbSet
                .FindAsync(keyValue, cancellationToken)
                .ConfigureAwait(false);

            if (entity == null)
                return null;

            dbSet.Remove(entity);

            await _context
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            // convert deleted entity to read model
            var model = _mapper.Map<TReadModel>(entity);

            return model;
        }

    }
}