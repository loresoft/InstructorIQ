using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.EmailDelivery"/>.
    /// </summary>
    public static partial class EmailDeliveryExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailDelivery"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailDelivery"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.EmailDelivery GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.EmailDelivery>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailDelivery"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailDelivery"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.EmailDelivery> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.EmailDelivery>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> ByIsProcessingIsDeliveredNextAttempt(this IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> queryable, bool isProcessing, bool isDelivered, DateTimeOffset? nextAttempt)
        {
            return queryable.Where(e => e.IsProcessing == isProcessing
                && e.IsDelivered == isDelivered
                && (e.NextAttempt == nextAttempt || (nextAttempt == null && e.NextAttempt == null)));
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> ByOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> queryable, Guid? organizationId)
        {
            return queryable.Where(e => (e.OrganizationId == organizationId || (organizationId == null && e.OrganizationId == null)));
        }
    }
}
