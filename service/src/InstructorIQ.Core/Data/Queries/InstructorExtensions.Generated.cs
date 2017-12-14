using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.Instructor"/>.
    /// </summary>
    public static partial class InstructorExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Instructor"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Instructor"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Instructor GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Instructor> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.Instructor>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Instructor"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Instructor"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.Instructor> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Instructor> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.Instructor>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(i => i.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Instructor> ByEmailAddress(this IQueryable<InstructorIQ.Core.Data.Entities.Instructor> queryable, string emailAddress)
        {
            return queryable.Where(i => i.EmailAddress == emailAddress);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Instructor> ByUserId(this IQueryable<InstructorIQ.Core.Data.Entities.Instructor> queryable, Guid? userId)
        {
            return queryable.Where(i => (i.UserId == userId || (userId == null && i.UserId == null)));
        }
    }
}
