using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class InstructorOrganizationExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.InstructorOrganization GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.InstructorOrganization> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.InstructorOrganization>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(i => i.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.InstructorOrganization> ByInstructorIdOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.InstructorOrganization> queryable, Guid instructorId, Guid organizationId)
        {
            return queryable.Where(i => i.InstructorId == instructorId
                && i.OrganizationId == organizationId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.InstructorOrganization> ByInstructorId(this IQueryable<InstructorIQ.Core.Data.Entities.InstructorOrganization> queryable, Guid instructorId)
        {
            return queryable.Where(i => i.InstructorId == instructorId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.InstructorOrganization> ByOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.InstructorOrganization> queryable, Guid organizationId)
        {
            return queryable.Where(i => i.OrganizationId == organizationId);
        }
    }
}
