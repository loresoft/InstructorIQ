using System;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace EntityFrameworkCore.CommandQuery.Commands
{
    public class EntityUpdateCommand<TKey, TEntity, TUpdateModel, TReadModel> : EntityModelCommand<TUpdateModel, TReadModel>
        where TEntity : class, new()
    {
        public EntityUpdateCommand(TKey id, TUpdateModel model, IPrincipal principal) : base(model, principal)
        {
            Id = id;

            var identityName = principal?.Identity?.Name;

            if (model is ITrackUpdated updatedModel)
            {
                updatedModel.Updated = DateTimeOffset.UtcNow;
                updatedModel.UpdatedBy = identityName;
            }
        }

        public TKey Id { get; set; }

        public TReadModel Original { get; set; }
    }
}