using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.Role"/>.
    /// </summary>
    public static partial class RoleExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Role"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Role"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Role GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Role> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.Role>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Role"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Role"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.Role> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Role> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.Role>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(r => r.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Role"/> by using a unique index.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Role"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Role GetByName(this IQueryable<InstructorIQ.Core.Data.Entities.Role> queryable, string name)
        {
            return queryable.FirstOrDefault(r => r.Name == name);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Role"/> by using a unique index asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Role"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.Role> GetByNameAsync(this IQueryable<InstructorIQ.Core.Data.Entities.Role> queryable, string name)
        {
            return queryable.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
