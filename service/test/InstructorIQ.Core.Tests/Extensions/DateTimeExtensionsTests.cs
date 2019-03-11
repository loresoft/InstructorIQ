using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.WebUtilities;
using Xunit;
using Xunit.Abstractions;
using InstructorIQ.Core.Extensions;

namespace InstructorIQ.Core.Tests.Extensions
{
    public class DateTimeExtensionsTests : UnitTestBase
    {
        public DateTimeExtensionsTests(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

        [Fact]
        public void TimezoneTests()
        {
            var localDate = new DateTime(2019, 3, 1, 19, 15, 0, DateTimeKind.Local);
            var utcDate = localDate.ToUniversalTime();
            var zoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var zoneDate = TimeZoneInfo.ConvertTime(localDate, zoneInfo);
            var zoneFromUtc = TimeZoneInfo.ConvertTimeFromUtc(utcDate, zoneInfo);
        }

        [Fact]
        public void TimezoneOffsetTests()
        {
            var utc = DateTime.UtcNow;

            var centralZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            var centralOffset = centralZone.GetUtcOffset(utc);

            var localDate = new DateTime(2019, 3, 1, 19, 15, 0, DateTimeKind.Local);
            var localDateOffset = new DateTimeOffset(2019, 3, 1, 19, 15, 0, centralOffset);

            var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var easternOffset = easternZone.GetUtcOffset(utc);

            var easternDateOffset = localDateOffset.ToOffset(easternOffset);

            var localDateUtc = localDateOffset.ToUniversalTime();
            var easternDateUtc = easternDateOffset.ToUniversalTime();

            //var zoneDate = TimeZoneInfo.ConvertTime(localDate, zoneInfo);
            //var zoneFromUtc = TimeZoneInfo.ConvertTimeFromUtc(utcDate, zoneInfo);
        }

        [Fact]
        public void ToUserTime()
        {
            // server time is east cost, but time entered in ui is central
            var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var easternOffset = easternZone.GetUtcOffset(DateTime.UtcNow);

            var centralZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            var centralOffset = centralZone.GetUtcOffset(DateTime.UtcNow);

            var centralTime = new DateTimeOffset(2019, 3, 1, 19, 15, 0, centralOffset);

            var serverTime = new DateTimeOffset(2019, 3, 1, 19, 15, 0, easternOffset);

            //var userTime = serverTime.ToUserTimeFromServer(centralZone);

            //var userUtc = userTime.ToUniversalTime();
            var centralUtc = centralTime.ToUniversalTime();

            var returnOffset = centralZone.GetUtcOffset(DateTime.UtcNow);

            //var returnTimeA = userUtc.ToUserTimeFromUtc(centralZone);
            //var returnTimeB = userUtc.ToOffset(returnOffset);
            //var returnTimeC = TimeZoneInfo.ConvertTime(userUtc, centralZone);
        }

    }
}
