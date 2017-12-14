using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/>.
    /// </summary>
    public static partial class RefreshTokenExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.RefreshToken GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.RefreshToken>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.RefreshToken> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.RefreshToken>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(r => r.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> ByUserId(this IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> queryable, Guid userId)
        {
            return queryable.Where(r => r.UserId == userId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> ByUserName(this IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> queryable, string userName)
        {
            return queryable.Where(r => r.UserName == userName);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.RefreshToken GetByTokenHashed(this IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> queryable, string tokenHashed)
        {
            return queryable.FirstOrDefault(r => r.TokenHashed == tokenHashed);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> by using a unique index asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.RefreshToken> GetByTokenHashedAsync(this IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> queryable, string tokenHashed)
        {
            return queryable.FirstOrDefaultAsync(r => r.TokenHashed == tokenHashed);
        }
    }
}
