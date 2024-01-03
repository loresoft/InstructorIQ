using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries;

/// <summary>
/// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.RefreshToken" />.
/// </summary>
public static partial class RefreshTokenExtensions
{
    #region Generated Extensions
    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> or null if not found.</returns>
    public static InstructorIQ.Core.Data.Entities.RefreshToken GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> queryable, Guid id)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.RefreshToken> dbSet)
            return dbSet.Find(id);

        return queryable.FirstOrDefault(q => q.Id == id);
    }

    /// <summary>
    /// Gets an instance by the primary key.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="id">The value to filter by.</param>
    /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> or null if not found.</returns>
    public static async System.Threading.Tasks.ValueTask<InstructorIQ.Core.Data.Entities.RefreshToken> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> queryable, Guid id, System.Threading.CancellationToken cancellationToken = default)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        if (queryable is DbSet<InstructorIQ.Core.Data.Entities.RefreshToken> dbSet)
            return await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return await queryable.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    /// <summary>
    /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> by using a unique index.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="tokenHash">The value to filter by.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> or null if not found.</returns>
    public static InstructorIQ.Core.Data.Entities.RefreshToken GetByTokenHash(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> queryable, string tokenHash)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.FirstOrDefault(q => q.TokenHash == tokenHash);
    }

    /// <summary>
    /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> by using a unique index.
    /// </summary>
    /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
    /// <param name="tokenHash">The value to filter by.</param>
    /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.RefreshToken"/> or null if not found.</returns>
    public static async System.Threading.Tasks.Task<InstructorIQ.Core.Data.Entities.RefreshToken> GetByTokenHashAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> queryable, string tokenHash, System.Threading.CancellationToken cancellationToken = default)
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
    public static System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> ByUserName(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.RefreshToken> queryable, string userName)
    {
        if (queryable is null)
            throw new ArgumentNullException(nameof(queryable));

        return queryable.Where(q => q.UserName == userName);
    }

    #endregion

}
