using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class SessionInstructorExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.SessionInstructor GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.SessionInstructor>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(s => s.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> BySessionIdInstructorId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid sessionId, Guid instructorId)
        {
            return queryable.Where(s => s.SessionId == sessionId
                && s.InstructorId == instructorId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> BySessionId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid sessionId)
        {
            return queryable.Where(s => s.SessionId == sessionId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> ByInstructorId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionInstructor> queryable, Guid instructorId)
        {
            return queryable.Where(s => s.InstructorId == instructorId);
        }
    }
}
