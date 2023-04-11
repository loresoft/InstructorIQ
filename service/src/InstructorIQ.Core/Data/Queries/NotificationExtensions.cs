using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries;

/// <summary>
/// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.Notification" />.
/// </summary>
public static partial class NotificationExtensions
{
    #region Generated Extensions
    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Notification"/> or null if not found.</returns>
    public static InstructorIQ.Core.Data.Entities.Notification GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.Notification> queryable, Guid id)
    {
        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Notification> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Notification"/> or null if not found.</returns>
    public static ValueTask<InstructorIQ.Core.Data.Entities.Notification> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.Notification> queryable, Guid id)
    {
        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Notification> dbSet)
            return dbSet.FindAsync(id);

        var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
        return new ValueTask<InstructorIQ.Core.Data.Entities.Notification>(task);
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="tenantId">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static IQueryable<InstructorIQ.Core.Data.Entities.Notification> ByTenantId(this IQueryable<InstructorIQ.Core.Data.Entities.Notification> queryable, Guid tenantId)
    {
        return queryable.Where(q => q.TenantId == tenantId);
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="userName">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static IQueryable<InstructorIQ.Core.Data.Entities.Notification> ByUserName(this IQueryable<InstructorIQ.Core.Data.Entities.Notification> queryable, string userName)
    {
        return queryable.Where(q => q.UserName == userName);
    }

    #endregion

}
