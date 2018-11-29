using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.UserRole" />.
    /// </summary>
    public static partial class UserRoleExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.UserRole GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.UserRole> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.UserRole> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.UserRole> dbSet)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="userId">The value to filter by.</param>
        /// <param name="tenantId">The value to filter by.</param>
        /// <param name="roleId">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.UserRole GetByUserIdTenantIdRoleId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid userId, Guid tenantId, Guid roleId)
        {
            return queryable.FirstOrDefault(q => q.UserId == userId
                && q.TenantId == tenantId
                    && q.RoleId == roleId);
            }

            /// <summary>
            /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> by using a unique index.
            /// </summary>
            /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
            /// <param name="userId">The value to filter by.</param>
            /// <param name="tenantId">The value to filter by.</param>
            /// <param name="roleId">The value to filter by.</param>
            /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.UserRole"/> or null if not found.</returns>
            public static Task<InstructorIQ.Core.Data.Entities.UserRole> GetByUserIdTenantIdRoleIdAsync(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid userId, Guid tenantId, Guid roleId)
            {
                return queryable.FirstOrDefaultAsync(q => q.UserId == userId
                    && q.TenantId == tenantId
                        && q.RoleId == roleId);
                }

                /// <summary>
                /// Filters a sequence of values based on a predicate.
                /// </summary>
                /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
                /// <param name="roleId">The value to filter by.</param>
                /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
                public static IQueryable<InstructorIQ.Core.Data.Entities.UserRole> ByRoleId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid roleId)
                {
                    return queryable.Where(q => q.RoleId == roleId);
                }

                /// <summary>
                /// Filters a sequence of values based on a predicate.
                /// </summary>
                /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
                /// <param name="tenantId">The value to filter by.</param>
                /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
                public static IQueryable<InstructorIQ.Core.Data.Entities.UserRole> ByTenantId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid tenantId)
                {
                    return queryable.Where(q => q.TenantId == tenantId);
                }

                /// <summary>
                /// Filters a sequence of values based on a predicate.
                /// </summary>
                /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
                /// <param name="userId">The value to filter by.</param>
                /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
                public static IQueryable<InstructorIQ.Core.Data.Entities.UserRole> ByUserId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid userId)
                {
                    return queryable.Where(q => q.UserId == userId);
                }

                #endregion

            }
        }
