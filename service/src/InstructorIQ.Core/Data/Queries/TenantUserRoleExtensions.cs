using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.TenantUserRole" />.
    /// </summary>
    public static partial class TenantUserRoleExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.TenantUserRole"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.TenantUserRole GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.TenantUserRole> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.TenantUserRole> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.TenantUserRole"/> or null if not found.</returns>
        public static ValueTask<InstructorIQ.Core.Data.Entities.TenantUserRole> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.TenantUserRole> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.TenantUserRole> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<InstructorIQ.Core.Data.Entities.TenantUserRole>(task);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="tenantId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.TenantUserRole> ByTenantId(this IQueryable<InstructorIQ.Core.Data.Entities.TenantUserRole> queryable, Guid tenantId)
        {
            return queryable.Where(q => q.TenantId == tenantId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="tenantId">The value to filter by.</param>
        /// <param name="userId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.TenantUserRole> ByTenantIdUserId(this IQueryable<InstructorIQ.Core.Data.Entities.TenantUserRole> queryable, Guid tenantId, Guid? userId)
        {
            return queryable.Where(q => q.TenantId == tenantId
                && (q.UserId == userId || (userId == null && q.UserId == null)));
        }

        #endregion

    }
}
