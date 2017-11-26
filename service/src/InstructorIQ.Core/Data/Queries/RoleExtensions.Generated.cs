using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class RoleExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.Role GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Role> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.Role>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Gets an instance by using a unique index.
        /// </summary>
        /// <returns>An instance of the entity or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Role GetByName(this IQueryable<InstructorIQ.Core.Data.Entities.Role> queryable, string name)
        {
            return queryable.FirstOrDefault(r => r.Name == name);
        }
    }
}
