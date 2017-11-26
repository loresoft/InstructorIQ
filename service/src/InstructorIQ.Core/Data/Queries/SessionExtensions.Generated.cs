using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class SessionExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.Session GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Session> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.Session>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(s => s.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Session> ByName(this IQueryable<InstructorIQ.Core.Data.Entities.Session> queryable, string name)
        {
            return queryable.Where(s => s.Name == name);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Session> ByOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.Session> queryable, Guid organizationId)
        {
            return queryable.Where(s => s.OrganizationId == organizationId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Session> ByTopicId(this IQueryable<InstructorIQ.Core.Data.Entities.Session> queryable, Guid topicId)
        {
            return queryable.Where(s => s.TopicId == topicId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Session> ByLocationId(this IQueryable<InstructorIQ.Core.Data.Entities.Session> queryable, Guid? locationId)
        {
            return queryable.Where(s => (s.LocationId == locationId || (locationId == null && s.LocationId == null)));
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Session> ByLeadInstructorId(this IQueryable<InstructorIQ.Core.Data.Entities.Session> queryable, Guid? leadInstructorId)
        {
            return queryable.Where(s => (s.LeadInstructorId == leadInstructorId || (leadInstructorId == null && s.LeadInstructorId == null)));
        }
    }
}
