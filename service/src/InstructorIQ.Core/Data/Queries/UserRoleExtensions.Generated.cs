using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/>.
    /// </summary>
    public static partial class UserRoleExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.UserRole GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.UserRole>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.UserRole> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.UserRole>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.UserRole GetByUserIdOrganizationIdRoleId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid userId, Guid organizationId, Guid roleId)
        {
            return queryable.FirstOrDefault(u => u.UserId == userId
                && u.OrganizationId == organizationId
                && u.RoleId == roleId);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> by using a unique index asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.UserRole> GetByUserIdOrganizationIdRoleIdAsync(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid userId, Guid organizationId, Guid roleId)
        {
            return queryable.FirstOrDefaultAsync(u => u.UserId == userId
                && u.OrganizationId == organizationId
                && u.RoleId == roleId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.UserRole> ByUserId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid userId)
        {
            return queryable.Where(u => u.UserId == userId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.UserRole> ByOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid organizationId)
        {
            return queryable.Where(u => u.OrganizationId == organizationId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.UserRole> ByRoleId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid roleId)
        {
            return queryable.Where(u => u.RoleId == roleId);
        }
    }
}
