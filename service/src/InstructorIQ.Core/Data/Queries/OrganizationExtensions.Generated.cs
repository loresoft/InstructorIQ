using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class OrganizationExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.Organization GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Organization> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.Organization>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(o => o.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Organization> ByName(this IQueryable<InstructorIQ.Core.Data.Entities.Organization> queryable, string name)
        {
            return queryable.Where(o => o.Name == name);
        }
    }
}
