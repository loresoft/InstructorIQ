using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace InstructorIQ.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetWeekOfYear(this DateTime dateTime)
        {
            var formatInfo = DateTimeFormatInfo.CurrentInfo;
            return GetWeekOfYear(dateTime, formatInfo);
        }

        public static int GetWeekOfYear(this DateTime dateTime, DateTimeFormatInfo formatInfo)
        {
            var calendar = formatInfo.Calendar;
            return calendar.GetWeekOfYear(dateTime, formatInfo.CalendarWeekRule, formatInfo.FirstDayOfWeek);
        }

        public static DateTime GetFirstDayOfWeek(this DateTimeFormatInfo formatInfo, int year, int week)
        {
            var currentDate = new DateTime(year, 1, 1);

            // walk forward till date is first day of week
            while (currentDate.DayOfWeek != formatInfo.FirstDayOfWeek) 
                currentDate = currentDate.AddDays(1);

            var calendar = formatInfo.Calendar;
            int firstWeek = calendar.GetWeekOfYear(currentDate, formatInfo.CalendarWeekRule, formatInfo.FirstDayOfWeek);

            int weekOffset = week - firstWeek;
            return calendar.AddWeeks(currentDate, weekOffset);
        }
    }
}
