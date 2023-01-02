using System;
using System.Globalization;
using System.IO;
using System.Text;

using AngleSharp.Dom;
using AngleSharp.Html.Parser;

using Bogus;

using CsvHelper;

using InstructorIQ.Core.Domain.Models;

using Xunit;
using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests
{
    public class MemberImportModelTest : UnitTestBase
    {
        public MemberImportModelTest(ITestOutputHelper outputHelper)
            : base(outputHelper)
        {
        }

        [Fact]
        public void Generate()
        {
            var generator = new Faker<MemberImportModel>()
                .RuleFor(p => p.GivenName, faker => faker.Name.FirstName())
                .RuleFor(p => p.FamilyName, faker => faker.Name.LastName())
                .RuleFor(p => p.FamilyName, (faker, instance) => $"{instance.GivenName}.{instance.FamilyName}@mailinator.com")
                .RuleFor(p => p.DisplayName, (faker, instance) => $"{instance.GivenName} {instance.FamilyName}")
                .RuleFor(p => p.SortName, (faker, instance) => $"{instance.FamilyName}, {instance.GivenName}");

            var users = generator.Generate(20);

            var configuration = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.CurrentCulture);
            configuration.HasHeaderRecord = true;

            using (var writer = new StreamWriter($"users-{DateTime.Now.Ticks}.csv"))
            using (var csv = new CsvWriter(writer, configuration))
            {
                csv.WriteRecords(users);
            }
        }

        [Fact]
        public void MyTestMethod()
        {
            var html = "<p>This is a test.</p>\r\n  <p>Another line test</p>";
            var document = new HtmlParser().ParseDocument(html);
            var text = document.Body.Text();
            text = StripExtended(text);

            html = "This is a test";
            document = new HtmlParser().ParseDocument(html);
            text = document.Body.Text();
        }


        static string StripExtended(string text)
        {
            StringBuilder buffer = new StringBuilder(text.Length);
            foreach (char ch in text)
            {
                UInt16 num = Convert.ToUInt16(ch);

                if ((num >= 33u) && (num <= 126u))
                    buffer.Append(ch);
                else if (buffer.Length == 0 || buffer[^1] != ' ')
                    buffer.Append(' ');
            }
            return buffer.ToString();
        }
    }
}
