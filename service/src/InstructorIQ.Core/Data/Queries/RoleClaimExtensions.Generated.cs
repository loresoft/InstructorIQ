using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class RoleClaimExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.RoleClaim GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.RoleClaim> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.RoleClaim>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(r => r.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.RoleClaim> ByRoleId(this IQueryable<InstructorIQ.Core.Data.Entities.RoleClaim> queryable, Guid roleId)
        {
            return queryable.Where(r => r.RoleId == roleId);
        }
    }
}
