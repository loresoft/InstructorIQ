using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class UserRoleExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.UserRole GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.UserRole>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Gets an instance by using a unique index.
        /// </summary>
        /// <returns>An instance of the entity or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.UserRole GetByUserIdOrganizationIdRoleId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid userId, Guid organizationId, Guid roleId)
        {
            return queryable.FirstOrDefault(u => u.UserId == userId
                && u.OrganizationId == organizationId
                && u.RoleId == roleId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.UserRole> ByUserId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid userId)
        {
            return queryable.Where(u => u.UserId == userId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.UserRole> ByOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid organizationId)
        {
            return queryable.Where(u => u.OrganizationId == organizationId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.UserRole> ByRoleId(this IQueryable<InstructorIQ.Core.Data.Entities.UserRole> queryable, Guid roleId)
        {
            return queryable.Where(u => u.RoleId == roleId);
        }
    }
}
