using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.User" />.
    /// </summary>
    public static partial class UserExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.User GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.User> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.User> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.User> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.User> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.User> dbSet)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="emailAddress">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.User GetByEmailAddress(this IQueryable<InstructorIQ.Core.Data.Entities.User> queryable, string emailAddress)
        {
            return queryable.FirstOrDefault(q => q.EmailAddress == emailAddress);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="emailAddress">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.User> GetByEmailAddressAsync(this IQueryable<InstructorIQ.Core.Data.Entities.User> queryable, string emailAddress)
        {
            return queryable.FirstOrDefaultAsync(q => q.EmailAddress == emailAddress);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="lastTenantId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.User> ByLastTenantId(this IQueryable<InstructorIQ.Core.Data.Entities.User> queryable, Guid? lastTenantId)
        {
            return queryable.Where(q => (q.LastTenantId == lastTenantId || (lastTenantId == null && q.LastTenantId == null)));
        }

        #endregion

    }
}
