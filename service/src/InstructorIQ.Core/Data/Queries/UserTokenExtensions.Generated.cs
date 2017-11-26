using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class UserTokenExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.UserToken GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.UserToken> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.UserToken>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Gets an instance by using a unique index.
        /// </summary>
        /// <returns>An instance of the entity or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.UserToken GetByUserIdLoginProviderName(this IQueryable<InstructorIQ.Core.Data.Entities.UserToken> queryable, Guid userId, string loginProvider, string name)
        {
            return queryable.FirstOrDefault(u => u.UserId == userId
                && u.LoginProvider == loginProvider
                && u.Name == name);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.UserToken> ByUserId(this IQueryable<InstructorIQ.Core.Data.Entities.UserToken> queryable, Guid userId)
        {
            return queryable.Where(u => u.UserId == userId);
        }
    }
}
