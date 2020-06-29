using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.Topic" />.
    /// </summary>
    public static partial class TopicExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="calendarYear">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Topic> ByCalendarYear(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, short calendarYear)
        {
            return queryable.Where(q => q.CalendarYear == calendarYear);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Topic"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.Topic GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Topic> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.Topic"/> or null if not found.</returns>
        public static ValueTask<InstructorIQ.Core.Data.Entities.Topic> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.Topic> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<InstructorIQ.Core.Data.Entities.Topic>(task);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="tenantId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Topic> ByTenantId(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, Guid tenantId)
        {
            return queryable.Where(q => q.TenantId == tenantId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="title">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.Topic> ByTitle(this IQueryable<InstructorIQ.Core.Data.Entities.Topic> queryable, string title)
        {
            return queryable.Where(q => q.Title == title);
        }

        #endregion

    }
}
