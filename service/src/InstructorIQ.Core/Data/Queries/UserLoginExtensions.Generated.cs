using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class UserLoginExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.UserLogin GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.UserLogin> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.UserLogin>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(u => u.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.UserLogin> ByUserId(this IQueryable<InstructorIQ.Core.Data.Entities.UserLogin> queryable, Guid userId)
        {
            return queryable.Where(u => u.UserId == userId);
        }

        /// <summary>
        /// Gets an instance by using a unique index.
        /// </summary>
        /// <returns>An instance of the entity or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.UserLogin GetByLoginProviderProviderKey(this IQueryable<InstructorIQ.Core.Data.Entities.UserLogin> queryable, string loginProvider, string providerKey)
        {
            return queryable.FirstOrDefault(u => u.LoginProvider == loginProvider
                && u.ProviderKey == providerKey);
        }
    }
}
