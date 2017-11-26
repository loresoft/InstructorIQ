using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class GroupExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.Group GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Group> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.Group>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(g => g.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Group> ByName(this IQueryable<InstructorIQ.Core.Data.Entities.Group> queryable, string name)
        {
            return queryable.Where(g => g.Name == name);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Group> ByOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.Group> queryable, Guid organizationId)
        {
            return queryable.Where(g => g.OrganizationId == organizationId);
        }
    }
}
