using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.User"/>.
    /// </summary>
    public static partial class UserExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.User GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.User> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.User>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.User> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.User> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.User>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.User GetByEmailAddress(this IQueryable<InstructorIQ.Core.Data.Entities.User> queryable, string emailAddress)
        {
            return queryable.FirstOrDefault(u => u.EmailAddress == emailAddress);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> by using a unique index asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.User"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.User> GetByEmailAddressAsync(this IQueryable<InstructorIQ.Core.Data.Entities.User> queryable, string emailAddress)
        {
            return queryable.FirstOrDefaultAsync(u => u.EmailAddress == emailAddress);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.User> ByLastOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.User> queryable, Guid? lastOrganizationId)
        {
            return queryable.Where(u => (u.LastOrganizationId == lastOrganizationId || (lastOrganizationId == null && u.LastOrganizationId == null)));
        }
    }
}
