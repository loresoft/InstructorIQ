using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.LinkToken" />.
    /// </summary>
    public static partial class LinkTokenExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.LinkToken GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.LinkToken> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.LinkToken> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.LinkToken> dbSet)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="tenantId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> ByTenantId(this IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, Guid? tenantId)
        {
            return queryable.Where(q => (q.TenantId == tenantId || (tenantId == null && q.TenantId == null)));
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="tokenHash">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.LinkToken GetByTokenHash(this IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, string tokenHash)
        {
            return queryable.FirstOrDefault(q => q.TokenHash == tokenHash);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="tokenHash">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.LinkToken> GetByTokenHashAsync(this IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, string tokenHash)
        {
            return queryable.FirstOrDefaultAsync(q => q.TokenHash == tokenHash);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="userName">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> ByUserName(this IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, string userName)
        {
            return queryable.Where(q => q.UserName == userName);
        }

        #endregion

    }
}
