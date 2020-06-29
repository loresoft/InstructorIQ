using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.SignUpTopic" />.
    /// </summary>
    public static partial class SignUpTopicExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.SignUpTopic"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.SignUpTopic GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.SignUpTopic> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.SignUpTopic> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.SignUpTopic"/> or null if not found.</returns>
        public static ValueTask<InstructorIQ.Core.Data.Entities.SignUpTopic> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.SignUpTopic> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.SignUpTopic> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<InstructorIQ.Core.Data.Entities.SignUpTopic>(task);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="signUpId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SignUpTopic> BySignUpId(this IQueryable<InstructorIQ.Core.Data.Entities.SignUpTopic> queryable, Guid signUpId)
        {
            return queryable.Where(q => q.SignUpId == signUpId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="topicId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.SignUpTopic> ByTopicId(this IQueryable<InstructorIQ.Core.Data.Entities.SignUpTopic> queryable, Guid topicId)
        {
            return queryable.Where(q => q.TopicId == topicId);
        }

        #endregion

    }
}
