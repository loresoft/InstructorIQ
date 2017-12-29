using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Queryable extension methods for <see cref="T:InstructorIQ.Core.Data.Entities.HistoryRecord"/>.
    /// </summary>
    public static partial class HistoryRecordExtensions
    {

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.HistoryRecord"/> by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.HistoryRecord"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.HistoryRecord GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.HistoryRecord> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.HistoryRecord>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(h => h.Id == id);
        }

        /// <summary>
        /// Gets an instance of <see cref="T:InstructorIQ.Core.Data.Entities.HistoryRecord"/> by the primary key asynchronously.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.HistoryRecord"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.HistoryRecord> GetByKeyAsync(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.HistoryRecord> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<InstructorIQ.Core.Data.Entities.HistoryRecord>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(h => h.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1"></see> to filter.</param>
        /// <returns>An <see cref="T:System.Linq.IQueryable`1"></see> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.HistoryRecord> ByKeyEntity(this IQueryable<InstructorIQ.Core.Data.Entities.HistoryRecord> queryable, Guid key, string entity)
        {
            return queryable.Where(h => h.Key == key
                && h.Entity == entity);
        }
    }
}
