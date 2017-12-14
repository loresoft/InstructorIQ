using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.Organization"/>.
    /// </summary>
    public static partial class OrganizationExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Organization"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Organization"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Organization GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Organization> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.Organization>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(o => o.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Organization"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Organization"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.Organization> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Organization> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.Organization>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(o => o.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Organization> ByIsDeleted(this IQueryable<InstructorIQ.Core.Data.Entities.Organization> queryable, bool isDeleted)
        {
            return queryable.Where(o => o.IsDeleted == isDeleted);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Organization> ByName(this IQueryable<InstructorIQ.Core.Data.Entities.Organization> queryable, string name)
        {
            return queryable.Where(o => o.Name == name);
        }
    }
}
