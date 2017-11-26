using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using InstructorIQ.Core.Mediator.Queries;

namespace InstructorIQ.Core.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int page, int pageSize)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            if (pageSize <= 0)
                pageSize = 10;

            page = Math.Max(1, page);
            var skip = Math.Max(pageSize * (page - 1), 0);

            return query.Skip(skip).Take(pageSize);
        }

        public static IQueryable<T> Sort<T>(this IQueryable<T> query, IEnumerable<EntitySort> sorts)
        {
            if (sorts == null || !sorts.Any())
                return query;

            // Create ordering expression e.g. Field1 asc, Field2 desc
            var builder = new StringBuilder();
            foreach (var sort in sorts)
            {
                if (builder.Length > 0)
                    builder.Append(",");

                builder.Append(sort.Name).Append(" ");

                var isDescending = !string.IsNullOrWhiteSpace(sort.Direction)
                    && sort.Direction.StartsWith("desc", StringComparison.OrdinalIgnoreCase);

                builder.Append(isDescending ? "desc" : "asc");
            }

            return query.OrderBy(builder.ToString());
        }

        public static IQueryable<T> Filter<T>(this IQueryable<T> query, EntityFilter filter)
        {
            if (filter == null)
                return query;

            var filters = filter.Flatten();
            var values = filters.Select(f => f.Value).ToArray();

            string predicate = filter.ToExpression(filters);
            return query.Where(predicate, values);
        }
    }
}
