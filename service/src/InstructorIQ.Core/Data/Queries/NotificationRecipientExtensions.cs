using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Data.Queries
{
    /// <summary>
    /// Query extensions for entity <see cref="InstructorIQ.Core.Data.Entities.NotificationRecipient" />.
    /// </summary>
    public static partial class NotificationRecipientExtensions
    {
        #region Generated Extensions
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.NotificationRecipient"/> or null if not found.</returns>
        public static InstructorIQ.Core.Data.Entities.NotificationRecipient GetByKey(this IQueryable<InstructorIQ.Core.Data.Entities.NotificationRecipient> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.NotificationRecipient> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="id">The value to filter by.</param>
        /// <returns>An instance of <see cref="T:InstructorIQ.Core.Data.Entities.NotificationRecipient"/> or null if not found.</returns>
        public static Task<InstructorIQ.Core.Data.Entities.NotificationRecipient> GetByKeyAsync(this IQueryable<InstructorIQ.Core.Data.Entities.NotificationRecipient> queryable, Guid id)
        {
            if (queryable is DbSet<InstructorIQ.Core.Data.Entities.NotificationRecipient> dbSet)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="notificationId">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.NotificationRecipient> ByNotificationId(this IQueryable<InstructorIQ.Core.Data.Entities.NotificationRecipient> queryable, Guid notificationId)
        {
            return queryable.Where(q => q.NotificationId == notificationId);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">An <see cref="T:System.Linq.IQueryable`1" /> to filter.</param>
        /// <param name="userName">The value to filter by.</param>
        /// <returns>An <see cref="T: System.Linq.IQueryable`1" /> that contains elements from the input sequence that satisfy the condition specified.</returns>
        public static IQueryable<InstructorIQ.Core.Data.Entities.NotificationRecipient> ByUserName(this IQueryable<InstructorIQ.Core.Data.Entities.NotificationRecipient> queryable, string userName)
        {
            return queryable.Where(q => q.UserName == userName);
        }

        #endregion

    }
}
