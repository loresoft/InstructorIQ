using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.EmailTemplate"/>.
    /// </summary>
    public static partial class EmailTemplateExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailTemplate"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailTemplate"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.EmailTemplate GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.EmailTemplate> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.EmailTemplate>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailTemplate"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailTemplate"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.EmailTemplate> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.EmailTemplate> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.EmailTemplate>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.EmailTemplate> ByOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.EmailTemplate> queryable, Guid? organizationId)
        {
            return queryable.Where(e => (e.OrganizationId == organizationId || (organizationId == null && e.OrganizationId == null)));
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailTemplate"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailTemplate"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.EmailTemplate GetByKeyMember(this IQueryable<InstructorIQ.Core.Data.Entities.EmailTemplate> queryable, string key)
        {
            return queryable.FirstOrDefault(e => e.Key == key);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailTemplate"/> by using a unique index asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailTemplate"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.EmailTemplate> GetByKeyMemberAsync(this IQueryable<InstructorIQ.Core.Data.Entities.EmailTemplate> queryable, string key)
        {
            return queryable.FirstOrDefaultAsync(e => e.Key == key);
        }
    }
}
