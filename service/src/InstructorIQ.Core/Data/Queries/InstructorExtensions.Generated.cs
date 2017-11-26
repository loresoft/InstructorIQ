using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class InstructorExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.Instructor GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.Instructor> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.Instructor>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(i => i.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Instructor> ByEmailAddress(this IQueryable<InstructorIQ.Core.Data.Entities.Instructor> queryable, string emailAddress)
        {
            return queryable.Where(i => i.EmailAddress == emailAddress);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.Instructor> ByUserId(this IQueryable<InstructorIQ.Core.Data.Entities.Instructor> queryable, Guid? userId)
        {
            return queryable.Where(i => (i.UserId == userId || (userId == null && i.UserId == null)));
        }
    }
}
