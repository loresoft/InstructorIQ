using System;

namespace InstructorIQ.Core.Utility;

public static class DateTimeFactory
{
    public static string DefaultTimeZone { get; set; } = "Central Standard Time";

    public static DateTimeOffset? Create(DateOnly? date, TimeOnly? time, string timeZone)
    {
        var zone = TimeZoneInfo.FindSystemTimeZoneById(timeZone ?? DefaultTimeZone);
        return Create(date, time, zone);
    }

    public static DateTimeOffset? Create(DateOnly? date, TimeOnly? time, TimeZoneInfo timeZoneInfo)
    {
        if (date == null || time == null)
            return default;

        return Create(date.Value, time.Value, timeZoneInfo);
    }


    public static DateTimeOffset Create(DateOnly date, TimeOnly time, string timeZone)
    {
        var zone = TimeZoneInfo.FindSystemTimeZoneById(timeZone ?? DefaultTimeZone);
        return Create(date, time, zone);
    }

    public static DateTimeOffset Create(DateOnly date, TimeOnly time, TimeZoneInfo timeZoneInfo)
    {
        if (timeZoneInfo == null)
            throw new ArgumentNullException(nameof(timeZoneInfo));

        return new DateTimeOffset(
            date.Year,
            date.Month,
            date.Day,
            time.Hour,
            time.Minute,
            time.Second,
            time.Millisecond,
            timeZoneInfo.BaseUtcOffset);
    }


    public static DateTimeOffset Create(int year, int month, int day, int hour, int minute, int second, string timeZone)
    {
        return Create(year, month, day, hour, minute, second, 0, timeZone);
    }

    public static DateTimeOffset Create(int year, int month, int day, int hour, int minute, int second, int millisecond, string timeZone)
    {
        var zone = TimeZoneInfo.FindSystemTimeZoneById(timeZone ?? DefaultTimeZone);
        return Create(year, month, day, hour, minute, second, millisecond, zone);
    }


    public static DateTimeOffset Create(int year, int month, int day, int hour, int minute, int second, TimeZoneInfo timeZoneInfo)
    {
        return Create(year, month, day, hour, minute, second, 0, timeZoneInfo);

    }

    public static DateTimeOffset Create(int year, int month, int day, int hour, int minute, int second, int millisecond, TimeZoneInfo timeZoneInfo)
    {
        if (timeZoneInfo == null)
            throw new ArgumentNullException(nameof(timeZoneInfo));

        var date = new DateTime(year, month, day, hour, minute, second, millisecond);
        var offset = timeZoneInfo.GetUtcOffset(date);

        return new DateTimeOffset(year, month, day, hour, minute, second, millisecond, offset);
    }

}
