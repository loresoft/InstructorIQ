using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.UserLogin"/>.
    /// </summary>
    public static partial class UserLoginExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserLogin"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserLogin"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.UserLogin GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.UserLogin> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.UserLogin>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserLogin"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserLogin"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.UserLogin> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.UserLogin> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.UserLogin>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.UserLogin> ByUserId(this IQueryable<InstructorIQ.Core.Data.Entities.UserLogin> queryable, Guid userId)
        {
            return queryable.Where(u => u.UserId == userId);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserLogin"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserLogin"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.UserLogin GetByLoginProviderProviderKey(this IQueryable<InstructorIQ.Core.Data.Entities.UserLogin> queryable, string loginProvider, string providerKey)
        {
            return queryable.FirstOrDefault(u => u.LoginProvider == loginProvider
                && u.ProviderKey == providerKey);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserLogin"/> by using a unique index asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserLogin"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.UserLogin> GetByLoginProviderProviderKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.UserLogin> queryable, string loginProvider, string providerKey)
        {
            return queryable.FirstOrDefaultAsync(u => u.LoginProvider == loginProvider
                && u.ProviderKey == providerKey);
        }
    }
}
