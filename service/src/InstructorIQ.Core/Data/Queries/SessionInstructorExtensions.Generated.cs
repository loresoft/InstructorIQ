using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.SessionInstructor"/>.
    /// </summary>
    public static partial class SessionInstructorExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.SessionInstructor"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.SessionInstructor"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.SessionInstructor GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.SessionInstructor>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.SessionInstructor"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.SessionInstructor"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.SessionInstructor> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.SessionInstructor>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> BySessionIdInstructorId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid sessionId, Guid instructorId)
        {
            return queryable.Where(s => s.SessionId == sessionId
                && s.InstructorId == instructorId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> BySessionId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid sessionId)
        {
            return queryable.Where(s => s.SessionId == sessionId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> ByInstructorId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid instructorId)
        {
            return queryable.Where(s => s.InstructorId == instructorId);
        }
    }
}
