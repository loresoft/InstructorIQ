using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstructorIQ.Core.Services
{
    public class SelectItemFactory
    {
        private static readonly Lazy<IReadOnlyCollection<SelectListItem>> _years;
        private static readonly Lazy<IReadOnlyCollection<SelectListItem>> _months;
        private static readonly Lazy<IReadOnlyCollection<SelectListItem>> _boolean;

        static SelectItemFactory()
        {
            _years = new Lazy<IReadOnlyCollection<SelectListItem>>(BuildYears);
            _months = new Lazy<IReadOnlyCollection<SelectListItem>>(BuildMonths);
            _boolean = new Lazy<IReadOnlyCollection<SelectListItem>>(BuildBoolean);
        }

        public static IReadOnlyCollection<SelectListItem> Years()
        {
            return _years.Value;
        }

        public static IReadOnlyCollection<SelectListItem> Months()
        {
            return _months.Value;
        }

        public static IReadOnlyCollection<SelectListItem> Boolean()
        {
            return _boolean.Value;
        }


        private static IReadOnlyCollection<SelectListItem> BuildBoolean()
        {
            var vales = new List<SelectListItem>
            {
                new SelectListItem("No", false.ToString()),
                new SelectListItem("Yes", true.ToString())
            };

            return vales;
        }

        private static IReadOnlyCollection<SelectListItem> BuildMonths()
        {
            var months = Enumerable
                .Range(1, 12)
                .Select(x => new SelectListItem
                {
                    Value = x.ToString(),
                    Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x)
                })
                .ToList();

            return months;
        }

        private static IReadOnlyCollection<SelectListItem> BuildYears()
        {
            var years = new List<SelectListItem>();
            var year = DateTime.Now.Year;
            var start = year - 5;
            var end = year + 5;

            for (int i = start; i <= end; i++)
            {
                var c = i.ToString();
                years.Add(new SelectListItem(c, c));
            }

            return years;
        }
    }
}
