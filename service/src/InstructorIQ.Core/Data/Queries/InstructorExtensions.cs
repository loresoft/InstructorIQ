using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.Instructor" />.
    /// </summary>
    public static partial class InstructorExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Instructor"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Instructor GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.Instructor> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Instructor> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Instructor"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.Instructor> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.Instructor> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Instructor> dbSet)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="emailAddress">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Instructor> ByEmailAddress(this IQueryable<InstructorIQ.Core.Data.Entities.Instructor> queryable, string emailAddress)
        {
            return queryable.Where(q => (q.EmailAddress == emailAddress || (emailAddress == null && q.EmailAddress == null)));
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="tenantId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Instructor> ByTenantId(this IQueryable<InstructorIQ.Core.Data.Entities.Instructor> queryable, Guid tenantId)
        {
            return queryable.Where(q => q.TenantId == tenantId);
        }

        #endregion

    }
}
