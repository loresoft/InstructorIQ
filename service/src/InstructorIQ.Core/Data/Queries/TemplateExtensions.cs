using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.Template" />.
    /// </summary>
    public static partial class TemplateExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Template"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Template GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.Template> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Template> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Template"/> or null if not found.</returns>
        public static ValueTask<InstructorIQ.Core.Data.Entities.Template> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.Template> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Template> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<InstructorIQ.Core.Data.Entities.Template>(task);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="name">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Template> ByName(this IQueryable<InstructorIQ.Core.Data.Entities.Template> queryable, string name)
        {
            return queryable.Where(q => q.Name == name);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="templateType">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Template> ByTemplateType(this IQueryable<InstructorIQ.Core.Data.Entities.Template> queryable, string templateType)
        {
            return queryable.Where(q => q.TemplateType == templateType);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="tenantId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Template> ByTenantId(this IQueryable<InstructorIQ.Core.Data.Entities.Template> queryable, Guid tenantId)
        {
            return queryable.Where(q => q.TenantId == tenantId);
        }

        #endregion

    }
}
