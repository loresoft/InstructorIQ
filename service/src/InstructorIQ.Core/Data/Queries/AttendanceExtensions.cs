using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries;

/// <summary>
/// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.Attendance" />.
/// </summary>
public static partial class AttendanceExtensions
{
    #region Generated Extensions
    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="attendeeEmail">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static IQueryable<InstructorIQ.Core.Data.Entities.Attendance> ByAttendeeEmail(this IQueryable<InstructorIQ.Core.Data.Entities.Attendance> queryable, string attendeeEmail)
    {
        return queryable.Where(q => q.AttendeeEmail == attendeeEmail);
    }

    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Attendance"/> or null if not found.</returns>
    public static InstructorIQ.Core.Data.Entities.Attendance GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.Attendance> queryable, Guid id)
    {
        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Attendance> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Attendance"/> or null if not found.</returns>
    public static ValueTask<InstructorIQ.Core.Data.Entities.Attendance> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.Attendance> queryable, Guid id)
    {
        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Attendance> dbSet)
            return dbSet.FindAsync(id);

        var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
        return new ValueTask<InstructorIQ.Core.Data.Entities.Attendance>(task);
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="sessionId">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static IQueryable<InstructorIQ.Core.Data.Entities.Attendance> BySessionId(this IQueryable<InstructorIQ.Core.Data.Entities.Attendance> queryable, Guid sessionId)
    {
        return queryable.Where(q => q.SessionId == sessionId);
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="tenantId">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static IQueryable<InstructorIQ.Core.Data.Entities.Attendance> ByTenantId(this IQueryable<InstructorIQ.Core.Data.Entities.Attendance> queryable, Guid tenantId)
    {
        return queryable.Where(q => q.TenantId == tenantId);
    }

    #endregion

}
