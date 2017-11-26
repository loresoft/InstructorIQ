using System;
using System.Collections.Generic;
using System.Linq;

namespace InstructorIQ.Core.Mediator.Queries
{
    public class EntityFilter
    {
        private static readonly IDictionary<string, string> _operatorMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"eq", "=="},
            {"neq", "!="},
            {"lt", "<"},
            {"lte", "<="},
            {"gt", ">"},
            {"gte", ">="}
        };

        public string Name { get; set; }

        public string Operator { get; set; }

        public object Value { get; set; }

        public string Logic { get; set; }

        public IEnumerable<EntityFilter> Filters { get; set; }


        internal IList<EntityFilter> Flatten()
        {
            var filters = new List<EntityFilter>();
            Collect(filters);

            return filters;
        }

        internal string ToExpression(IList<EntityFilter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                var groupExpressions = Filters.Select(filter => filter.ToExpression(filters)).ToArray();
                var logic = string.IsNullOrWhiteSpace(Logic) ? "and" : Logic;
                var groupLogic = String.Join($" {logic} ", groupExpressions);

                return $"({groupLogic})";
            }

            int index = filters.IndexOf(this);


            var o = Operator ?? "==";
            _operatorMap.TryGetValue(o, out string comparison);
            if (string.IsNullOrEmpty(comparison))
                comparison = o.Trim();

            var negation = comparison.StartsWith("!") || comparison.StartsWith("not", StringComparison.OrdinalIgnoreCase) ? "!" : string.Empty;

            if (comparison.EndsWith("StartsWith", StringComparison.OrdinalIgnoreCase))
                return $"{negation}{Name}.StartsWith(@{index})";

            if (comparison.EndsWith("EndsWith", StringComparison.OrdinalIgnoreCase))
                return $"{negation}{Name}.EndsWith(@{index})";

            if (comparison.EndsWith("Contains", StringComparison.OrdinalIgnoreCase))
                return $"{negation}{Name}.Contains(@{index})";

            return $"{Name} {comparison} @{index}";
        }


        private void Collect(IList<EntityFilter> filters)
        {
            if (Filters == null || !Filters.Any())
            {
                filters.Add(this);
                return;
            }

            foreach (var filter in Filters)
            {
                filters.Add(filter);
                filter.Collect(filters);
            }
        }

    }
}