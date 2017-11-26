using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class TopicExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.Topic GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.Topic>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(t => t.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Topic> ByCalendarYear(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, short calendarYear)
        {
            return queryable.Where(t => t.CalendarYear == calendarYear);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Topic> ByOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, Guid organizationId)
        {
            return queryable.Where(t => t.OrganizationId == organizationId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Topic> ByTitle(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, string title)
        {
            return queryable.Where(t => t.Title == title);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Topic> ByLeadInstructorId(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, Guid? leadInstructorId)
        {
            return queryable.Where(t => (t.LeadInstructorId == leadInstructorId || (leadInstructorId == null && t.LeadInstructorId == null)));
        }
    }
}
