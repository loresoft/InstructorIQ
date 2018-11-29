using System;
using System.Security.Principal;
using Microsoft.AspNetCore.JsonPatch;

namespace EntityFrameworkCore.CommandQuery.Commands
{
    public class EntityPatchCommand<TKey, TReadModel>
        : EntityIdentifierCommand<TKey, TReadModel>
    {
        public EntityPatchCommand(TKey id, IJsonPatchDocument patch, IPrincipal principal) : base(id, principal)
        {
            // ReSharper disable once JoinNullCheckWithUsage
            if (patch == null)
                throw new ArgumentNullException(nameof(patch));

            Patch = patch;
        }

        public IJsonPatchDocument Patch { get; }

        public TReadModel Original { get; set; }
    }
}