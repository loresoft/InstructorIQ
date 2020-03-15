using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using InstructorIQ.Core.Data.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstructorIQ.Core.Services
{
    public class SelectItemFactory
    {
        private static readonly Lazy<IReadOnlyCollection<SelectListItem>> _years;
        private static readonly Lazy<IReadOnlyCollection<SelectListItem>> _months;
        private static readonly Lazy<IReadOnlyCollection<SelectListItem>> _boolean;
        private static readonly Lazy<IReadOnlyCollection<SelectListItem>> _templateTypes;
        private static readonly Lazy<IReadOnlyCollection<SelectListItem>> _states;
        private static readonly Lazy<IReadOnlyCollection<SelectListItem>> _timeZones;

        static SelectItemFactory()
        {
            _years = new Lazy<IReadOnlyCollection<SelectListItem>>(BuildYears);
            _months = new Lazy<IReadOnlyCollection<SelectListItem>>(BuildMonths);
            _boolean = new Lazy<IReadOnlyCollection<SelectListItem>>(BuildBoolean);
            _templateTypes = new Lazy<IReadOnlyCollection<SelectListItem>>(BuildTemplateTypes);
            _states = new Lazy<IReadOnlyCollection<SelectListItem>>(BuildStates);
            _timeZones = new Lazy<IReadOnlyCollection<SelectListItem>>(BuildTimeZones);
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

        public static IReadOnlyCollection<SelectListItem> TemplateTypes()
        {
            return _templateTypes.Value;
        }

        public static IReadOnlyCollection<SelectListItem> States()
        {
            return _states.Value;
        }

        public static IReadOnlyCollection<SelectListItem> TimeZones()
        {
            return _timeZones.Value;
        }


        private static IReadOnlyCollection<SelectListItem> BuildTemplateTypes()
        {
            var values = new List<SelectListItem>
            {
                new SelectListItem("Editor", TemplateType.Editor),
            };

            return values;
        }

        private static IReadOnlyCollection<SelectListItem> BuildBoolean()
        {
            var values = new List<SelectListItem>
            {
                new SelectListItem("No", false.ToString()),
                new SelectListItem("Yes", true.ToString())
            };

            return values;
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

        private static IReadOnlyCollection<SelectListItem> BuildStates()
        {
            var values = new List<SelectListItem>
            {
                new SelectListItem("AL - Alabama", "AL"),
                new SelectListItem("AK - Alaska", "AK"),
                new SelectListItem("AZ - Arizona", "AZ"),
                new SelectListItem("AR - Arkansas", "AR"),
                new SelectListItem("CA - California", "CA"),
                new SelectListItem("CO - Colorado", "CO"),
                new SelectListItem("CT - Connecticut", "CT"),
                new SelectListItem("DE - Delaware", "DE"),
                new SelectListItem("DC - District Of Columbia", "DC"),
                new SelectListItem("FL - Florida", "FL"),
                new SelectListItem("GA - Georgia", "GA"),
                new SelectListItem("HI - Hawaii", "HI"),
                new SelectListItem("ID - Idaho", "ID"),
                new SelectListItem("IL - Illinois", "IL"),
                new SelectListItem("IN - Indiana", "IN"),
                new SelectListItem("IA - Iowa", "IA"),
                new SelectListItem("KS - Kansas", "KS"),
                new SelectListItem("KY - Kentucky", "KY"),
                new SelectListItem("LA - Louisiana", "LA"),
                new SelectListItem("ME - Maine", "ME"),
                new SelectListItem("MD - Maryland", "MD"),
                new SelectListItem("MA - Massachusetts", "MA"),
                new SelectListItem("MI - Michigan", "MI"),
                new SelectListItem("MN - Minnesota", "MN"),
                new SelectListItem("MS - Mississippi", "MS"),
                new SelectListItem("MO - Missouri", "MO"),
                new SelectListItem("MT - Montana", "MT"),
                new SelectListItem("NE - Nebraska", "NE"),
                new SelectListItem("NV - Nevada", "NV"),
                new SelectListItem("NH - New Hampshire", "NH"),
                new SelectListItem("NJ - New Jersey", "NJ"),
                new SelectListItem("NM - New Mexico", "NM"),
                new SelectListItem("NY - New York", "NY"),
                new SelectListItem("NC - North Carolina", "NC"),
                new SelectListItem("ND - North Dakota", "ND"),
                new SelectListItem("OH - Ohio", "OH"),
                new SelectListItem("OK - Oklahoma", "OK"),
                new SelectListItem("OR - Oregon", "OR"),
                new SelectListItem("PA - Pennsylvania", "PA"),
                new SelectListItem("RI - Rhode Island", "RI"),
                new SelectListItem("SC - South Carolina", "SC"),
                new SelectListItem("SD - South Dakota", "SD"),
                new SelectListItem("TN - Tennessee", "TN"),
                new SelectListItem("TX - Texas", "TX"),
                new SelectListItem("UT - Utah", "UT"),
                new SelectListItem("VT - Vermont", "VT"),
                new SelectListItem("VA - Virginia", "VA"),
                new SelectListItem("WA - Washington", "WA"),
                new SelectListItem("WV - West Virginia", "WV"),
                new SelectListItem("WI - Wisconsin", "WI"),
                new SelectListItem("WY - Wyoming", "WY")
            };

            return values;
        }

        private static IReadOnlyCollection<SelectListItem> BuildTimeZones()
        {
            var zones = new List<SelectListItem>();

            foreach(var z in TimeZoneInfo.GetSystemTimeZones())
                zones.Add(new SelectListItem(z.DisplayName, z.Id));

            return zones;
        }

    }
}
