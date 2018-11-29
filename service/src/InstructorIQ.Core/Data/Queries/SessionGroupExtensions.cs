using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.SessionGroup" />.
    /// </summary>
    public static partial class SessionGroupExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.SessionGroup"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.SessionGroup GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.SessionGroup> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.SessionGroup"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.SessionGroup> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.SessionGroup> dbSet)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="sessionId">The value to filter by.</param>
        /// <param name="groupId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> BySessionIdGroupId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> queryable, Guid sessionId, Guid groupId)
        {
            return queryable.Where(q => q.SessionId == sessionId
                && q.GroupId == groupId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="groupId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> ByGroupId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> queryable, Guid groupId)
        {
            return queryable.Where(q => q.GroupId == groupId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="sessionId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> BySessionId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> queryable, Guid sessionId)
        {
            return queryable.Where(q => q.SessionId == sessionId);
        }

        #endregion

    }
}
