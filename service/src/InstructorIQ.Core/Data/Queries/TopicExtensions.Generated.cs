using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.Topic"/>.
    /// </summary>
    public static partial class TopicExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Topic"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Topic"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Topic GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.Topic>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.Topic"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Topic"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.Topic> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.Topic>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Topic> ByCalendarYear(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, short calendarYear)
        {
            return queryable.Where(t => t.CalendarYear == calendarYear);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Topic> ByOrganizationId(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, Guid organizationId)
        {
            return queryable.Where(t => t.OrganizationId == organizationId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Topic> ByTitle(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, string title)
        {
            return queryable.Where(t => t.Title == title);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Topic> ByLeadInstructorId(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, Guid? leadInstructorId)
        {
            return queryable.Where(t => (t.LeadInstructorId == leadInstructorId || (leadInstructorId == null && t.LeadInstructorId == null)));
        }
    }
}
