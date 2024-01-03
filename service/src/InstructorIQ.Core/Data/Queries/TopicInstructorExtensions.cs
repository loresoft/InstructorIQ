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
    public static InstructorIQ.Core.Data.Entities.TopicInstructor GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> queryable, Guid id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.TopicInstructor> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.TopicInstructor"/> or null if not found.</returns>
    public static async System.Threading.Tasks.ValueTask<InstructorIQ.Core.Data.Entities.TopicInstructor> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> queryable, Guid id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.TopicInstructor> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="instructorRoleId">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> ByInstructorRoleId(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> queryable, Guid? instructorRoleId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.InstructorRoleId == instructorRoleId || (instructorRoleId == null && q.InstructorRoleId == null)));
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="topicId">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> ByTopicId(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> queryable, Guid topicId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

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
    public static System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> ByTopicIdInstructorIdInstructorRoleId(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.TopicInstructor> queryable, Guid topicId, Guid instructorId, Guid? instructorRoleId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.TopicId == topicId
            && q.InstructorId == instructorId
                && (q.InstructorRoleId == instructorRoleId || (instructorRoleId == null && q.InstructorRoleId == null)));
        }

        #endregion

}
