using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.SessionInstructor" />.
    /// </summary>
    public static partial class SessionInstructorExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.SessionInstructor"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.SessionInstructor GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.SessionInstructor> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.SessionInstructor"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.SessionInstructor> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.SessionInstructor> dbSet)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="instructorId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> ByInstructorId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid instructorId)
        {
            return queryable.Where(q => q.InstructorId == instructorId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="instructorRoleId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> ByInstructorRoleId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid? instructorRoleId)
        {
            return queryable.Where(q => (q.InstructorRoleId == instructorRoleId || (instructorRoleId == null && q.InstructorRoleId == null)));
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="sessionId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> BySessionId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid sessionId)
        {
            return queryable.Where(q => q.SessionId == sessionId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="sessionId">The value to filter by.</param>
        /// <param name="instructorId">The value to filter by.</param>
        /// <param name="instructorRoleId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> BySessionIdInstructorIdInstructorRoleId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid sessionId, Guid instructorId, Guid? instructorRoleId)
        {
            return queryable.Where(q => q.SessionId == sessionId
                && q.InstructorId == instructorId
                    && (q.InstructorRoleId == instructorRoleId || (instructorRoleId == null && q.InstructorRoleId == null)));
            }

            #endregion

    }
}
