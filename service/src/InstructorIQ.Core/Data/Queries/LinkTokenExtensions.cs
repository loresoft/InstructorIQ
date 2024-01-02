using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries;

/// <summary>
/// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.LinkToken" />.
/// </summary>
public static partial class LinkTokenExtensions
{
    #region Generated Extensions
    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> or null if not found.</returns>
    public static InstructorIQ.Core.Data.Entities.LinkToken GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, Guid id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.LinkToken> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> or null if not found.</returns>
    public static async System.Threading.Tasks.ValueTask<InstructorIQ.Core.Data.Entities.LinkToken> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, Guid id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.LinkToken> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="tenantId">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> ByTenantId(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, Guid? tenantId)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => (q.TenantId == tenantId || (tenantId == null && q.TenantId == null)));
    }

    /// <summary>
    /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> by using a unique index.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="tokenHash">The value to filter by.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> or null if not found.</returns>
    public static InstructorIQ.Core.Data.Entities.LinkToken GetByTokenHash(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, string tokenHash)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.FirstOrDefault(q => q.TokenHash == tokenHash);
    }

    /// <summary>
    /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> by using a unique index.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="tokenHash">The value to filter by.</param>
    /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.LinkToken"/> or null if not found.</returns>
    public static async System.Threading.Tasks.Task<InstructorIQ.Core.Data.Entities.LinkToken> GetByTokenHashAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, string tokenHash, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return await queryable.FirstOrDefaultAsync(q => q.TokenHash == tokenHash, cancellationToken);
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="userName">The value to filter by.</param>
    /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
    public static System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> ByUserName(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.LinkToken> queryable, string userName)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.UserName == userName);
    }

    #endregion

}
