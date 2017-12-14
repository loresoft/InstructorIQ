using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.Location"/>.
    /// </summary>
    public static partial class LocationExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Location"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Location"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Location GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Location> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.Location>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(l => l.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Location"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Location"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.Location> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Location> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.Location>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(l => l.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Location> ByName(this IQueryable<InstructorIQ.Core.Data.Entities.Location> queryable, string name)
        {
            return queryable.Where(l => l.Name == name);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Location> ByOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.Location> queryable, Guid organizationId)
        {
            return queryable.Where(l => l.OrganizationId == organizationId);
        }
    }
}
