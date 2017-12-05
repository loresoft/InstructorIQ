using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class EntityUpdateCommandHandler<TEntity, TUpdateModel, TReadModel> : RequestHandlerBase<EntityUpdateCommand<TEntity, TUpdateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TUpdateModel : EntityUpdateModel
        where TReadModel : EntityReadModel
    {
        private readonly InstructorIQContext _context;
        private readonly IMapper _mapper;

        public EntityUpdateCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext context, IMapper mapper) : base(loggerFactory)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<TReadModel> Process(EntityUpdateCommand<TEntity, TUpdateModel, TReadModel> message, CancellationToken cancellationToken)
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

            // copy updates from model to entity
            _mapper.Map(message.Model, entity);

            // save updates
            await _context
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            // return read model
            var readModel = _mapper.Map<TReadModel>(entity);

            return readModel;
        }
    }
}