using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class UserClaimExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.UserClaim GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.UserClaim> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.UserClaim>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(u => u.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.UserClaim> ByUserId(this IQueryable<InstructorIQ.Core.Data.Entities.UserClaim> queryable, Guid userId)
        {
            return queryable.Where(u => u.UserId == userId);
        }
    }
}
