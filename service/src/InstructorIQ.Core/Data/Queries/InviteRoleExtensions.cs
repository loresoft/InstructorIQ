using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.InviteRole" />.
    /// </summary>
    public static partial class InviteRoleExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.InviteRole"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.InviteRole GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.InviteRole> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.InviteRole> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.InviteRole"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.InviteRole> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.InviteRole> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.InviteRole> dbSet)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="inviteId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.InviteRole> ByInviteId(this IQueryable<InstructorIQ.Core.Data.Entities.InviteRole> queryable, Guid inviteId)
        {
            return queryable.Where(q => q.InviteId == inviteId);
        }

        #endregion

    }
}
