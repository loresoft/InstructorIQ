﻿using System;
using System.IO;
using System.Text;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using CsvHelper;
using DataGenerator;
using DataGenerator.Sources;
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
            var generator = Generator.Create(c =>
                {
                    c.Entity<MemberImportModel>(e =>
                    {
                        e.Property(p => p.GivenName).DataSource<FirstNameSource>();
                        e.Property(p => p.FamilyName).DataSource<LastNameSource>();
                        e.Property(p => p.Email).Value(m => $"{m.GivenName}.{m.FamilyName}@mailinator.com");
                        e.Property(p => p.DisplayName).Value(m => $"{m.GivenName} {m.FamilyName}");
                        e.Property(p => p.SortName).Value(m => $"{m.FamilyName}, {m.GivenName}");
                    });
                });

            var users = generator.List<MemberImportModel>(20);

            var configuration = new CsvHelper.Configuration.Configuration();
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