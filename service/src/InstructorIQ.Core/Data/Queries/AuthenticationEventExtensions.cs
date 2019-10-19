using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.AuthenticationEvent" />.
    /// </summary>
    public static partial class AuthenticationEventExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="emailAddress">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.AuthenticationEvent> ByEmailAddress(this IQueryable<InstructorIQ.Core.Data.Entities.AuthenticationEvent> queryable, string emailAddress)
        {
            return queryable.Where(q => q.EmailAddress == emailAddress);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.AuthenticationEvent"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.AuthenticationEvent GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.AuthenticationEvent> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.AuthenticationEvent> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.AuthenticationEvent"/> or null if not found.</returns>
        public static ValueTask<InstructorIQ.Core.Data.Entities.AuthenticationEvent> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.AuthenticationEvent> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.AuthenticationEvent> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<InstructorIQ.Core.Data.Entities.AuthenticationEvent>(task);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="userName">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.AuthenticationEvent> ByUserName(this IQueryable<InstructorIQ.Core.Data.Entities.AuthenticationEvent> queryable, string userName)
        {
            return queryable.Where(q => q.UserName == userName);
        }

        #endregion

    }
}
