using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries;

/// <summary>
/// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.TopicInstructor" />.
/// </summary>
public static partial class TopicInstructorExtensions
{
    #region Generated Extensions
    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.TopicInstructor"/> or null if not found.</returns>
    public static InstructorIQ.Core.Data.Entities.TopicInstructor GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> queryable, Guid id)
    {
        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.TopicInstructor> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.TopicInstructor"/> or null if not found.</returns>
    public static ValueTask<InstructorIQ.Core.Data.Entities.TopicInstructor> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> queryable, Guid id)
    {
        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.TopicInstructor> dbSet)
            return dbSet.FindAsync(id);

        var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
        return new ValueTask<InstructorIQ.Core.Data.Entities.TopicInstructor>(task);
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="instructorRoleId">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> ByInstructorRoleId(this IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> queryable, Guid? instructorRoleId)
    {
        return queryable.Where(q => (q.InstructorRoleId == instructorRoleId || (instructorRoleId == null && q.InstructorRoleId == null)));
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="topicId">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> ByTopicId(this IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> queryable, Guid topicId)
    {
        return queryable.Where(q => q.TopicId == topicId);
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="topicId">The value to filter by.</param>
    /// <param name="instructorId">The value to filter by.</param>
    /// <param name="instructorRoleId">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> ByTopicIdInstructorIdInstructorRoleId(this IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> queryable, Guid topicId, Guid instructorId, Guid? instructorRoleId)
    {
        return queryable.Where(q => q.TopicId == topicId
            && q.InstructorId == instructorId
                && (q.InstructorRoleId == instructorRoleId || (instructorRoleId == null && q.InstructorRoleId == null)));
    }

    #endregion

}
