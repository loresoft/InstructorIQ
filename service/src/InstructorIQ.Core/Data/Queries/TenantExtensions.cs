using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.Tenant" />.
    /// </summary>
    public static partial class TenantExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Tenant"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Tenant GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.Tenant> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Tenant> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Tenant"/> or null if not found.</returns>
        public static ValueTask<InstructorIQ.Core.Data.Entities.Tenant> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.Tenant> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Tenant> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<InstructorIQ.Core.Data.Entities.Tenant>(task);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="isDeleted">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Tenant> ByIsDeleted(this IQueryable<InstructorIQ.Core.Data.Entities.Tenant> queryable, bool isDeleted)
        {
            return queryable.Where(q => q.IsDeleted == isDeleted);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="name">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Tenant> ByName(this IQueryable<InstructorIQ.Core.Data.Entities.Tenant> queryable, string name)
        {
            return queryable.Where(q => q.Name == name);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Tenant"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="slug">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Tenant"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Tenant GetBySlug(this IQueryable<InstructorIQ.Core.Data.Entities.Tenant> queryable, string slug)
        {
            return queryable.FirstOrDefault(q => q.Slug == slug);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Tenant"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="slug">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Tenant"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.Tenant> GetBySlugAsync(this IQueryable<InstructorIQ.Core.Data.Entities.Tenant> queryable, string slug)
        {
            return queryable.FirstOrDefaultAsync(q => q.Slug == slug);
        }

        #endregion

    }
}
