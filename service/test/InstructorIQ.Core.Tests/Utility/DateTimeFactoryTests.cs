using System;
using System.Collections.Generic;
using System.Text;

using FluentAssertions;

using InstructorIQ.Core.Utility;

using Xunit;

namespace InstructorIQ.Core.Tests.Utility;

public class DateTimeFactoryTests
{
    //Eastern Standard Time
    //Central Standard Time
    //Mountain Standard Time
    //US Mountain Standard Time // (UTC-07:00) Arizona
    //Pacific Standard Time

    [Fact]
    public void EasternStandardTimeTest()
    {

        var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        var easternDateTime = DateTimeFactory.Create(2019, 4, 1, 14, 15, 30, easternZone);

        easternDateTime.Year.Should().Be(2019);
        easternDateTime.Month.Should().Be(4);
        easternDateTime.Day.Should().Be(1);
        easternDateTime.Hour.Should().Be(14);
        easternDateTime.Minute.Should().Be(15);
        easternDateTime.Second.Should().Be(30);

        var centralZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        var centralDateTime = DateTimeFactory.Create(2019, 4, 1, 14, 15, 30, centralZone);

        centralDateTime.Year.Should().Be(2019);
        centralDateTime.Month.Should().Be(4);
        centralDateTime.Day.Should().Be(1);
        centralDateTime.Hour.Should().Be(14);
        centralDateTime.Minute.Should().Be(15);
        centralDateTime.Second.Should().Be(30);

        // local should be different
        easternDateTime.Should().NotBe(centralDateTime);
    }
}
