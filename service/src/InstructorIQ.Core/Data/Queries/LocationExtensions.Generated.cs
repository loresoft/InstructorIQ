using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class LocationExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.Location GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Location> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.Location>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(l => l.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Location> ByName(this IQueryable<InstructorIQ.Core.Data.Entities.Location> queryable, string name)
        {
            return queryable.Where(l => l.Name == name);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Location> ByOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.Location> queryable, Guid organizationId)
        {
            return queryable.Where(l => l.OrganizationId == organizationId);
        }
    }
}
