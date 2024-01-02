using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries;

/// <summary>
/// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.EmailDelivery" />.
/// </summary>
public static partial class EmailDeliveryExtensions
{
    #region Generated Extensions
    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailDelivery"/> or null if not found.</returns>
    public static InstructorIQ.Core.Data.Entities.EmailDelivery GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> queryable, Guid id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.EmailDelivery> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.EmailDelivery"/> or null if not found.</returns>
    public static async System.Threading.Tasks.ValueTask<InstructorIQ.Core.Data.Entities.EmailDelivery> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> queryable, Guid id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.EmailDelivery> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="isProcessing">The value to filter by.</param>
    /// <param name="isDelivered">The value to filter by.</param>
    /// <param name="nextAttempt">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> ByIsProcessingIsDeliveredNextAttempt(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> queryable, bool isProcessing, bool isDelivered, DateTimeOffset? nextAttempt)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.IsProcessing == isProcessing
            && q.IsDelivered == isDelivered
                && (q.NextAttempt == nextAttempt || (nextAttempt == null && q.NextAttempt == null)));
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="tenantId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> ByTenantId(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.EmailDelivery> queryable, Guid? tenantId)
        {
            if (queryable is null)
                throw new ArgumentNullException(nameof(queryable));

            return queryable.Where(q => (q.TenantId == tenantId || (tenantId == null && q.TenantId == null)));
        }

        #endregion

}
