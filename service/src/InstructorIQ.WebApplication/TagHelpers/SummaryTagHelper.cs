using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using CommonMark;
using EntityChange.Extensions;
using Humanizer;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InstructorIQ.WebApplication.TagHelpers
{
    [HtmlTargetElement("summary-text", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SummaryTagHelper : TagHelper
    {
        public ModelExpression Content { get; set; }

        [HtmlAttributeName("truncate")]
        public int? Truncate { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            var content = await GetContent(output);
            if (content.IsNullOrWhiteSpace())
            {
                output.Content.SetContent(string.Empty);
                return;
            }

            var htmlParser = new HtmlParser();
            var document = htmlParser.ParseDocument(content);
            var text = document.Body.Text();

            text = StripExtended(text);

            if (Truncate.HasValue)
                text = text.Truncate(Truncate.Value);

            output.Content.SetContent(text ?? "");
        }

        private async Task<string> GetContent(TagHelperOutput output)
        {
            if (Content != null)
                return Content.Model?.ToString();

            var childContent = await output.GetChildContentAsync();
            return childContent.GetContent();
        }

        private static string StripExtended(string text)
        {
            var buffer = new StringBuilder(text.Length);
            foreach (var c in text)
            {
                var n = Convert.ToUInt16(c);

                if ((n >= 33u) && (n <= 126u))
                    buffer.Append(c);
                else if (buffer.Length == 0 || buffer[^1] != ' ')
                    buffer.Append(' ');
            }

            return buffer.ToString();
        }
    }
}
