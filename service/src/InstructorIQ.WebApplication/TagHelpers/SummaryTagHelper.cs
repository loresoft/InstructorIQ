using System.Threading.Tasks;
using Humanizer;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InstructorIQ.WebApplication.TagHelpers
{
    [HtmlTargetElement("summary-text", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SummaryTagHelper : TagHelper
    {
        private readonly IHtmlService _htmlService;

        public SummaryTagHelper(IHtmlService htmlService)
        {
            _htmlService = htmlService;
        }

        public ModelExpression Content { get; set; }

        [HtmlAttributeName("truncate")]
        public int? Truncate { get; set; }

        [HtmlAttributeName("default-text")]
        public string DefaultText { get; set; } = string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            var content = await GetContent(output);
            if (content.IsNullOrWhiteSpace())
            {
                output.Content.SetContent(DefaultText);
                return;
            }

            var text = _htmlService.PlanText(content);

            text = text.RemoveExtended();

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

    }
}
