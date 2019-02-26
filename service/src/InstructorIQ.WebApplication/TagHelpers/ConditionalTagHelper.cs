using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InstructorIQ.WebApplication.TagHelpers
{
    [HtmlTargetElement(Attributes = IncludeIfAttributeName)]
    [HtmlTargetElement(Attributes = ExcludeIfAttributeName)]
    public class ConditionalTagHelper : TagHelper
    {
        private const string IncludeIfAttributeName = "include-if";
        private const string ExcludeIfAttributeName = "exclude-if";

        public override int Order => -1000;

        [HtmlAttributeName(IncludeIfAttributeName)]
        public bool? Include { get; set; }

        [HtmlAttributeName(ExcludeIfAttributeName)]
        public bool Exclude { get; set; } = false;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll(IncludeIfAttributeName);
            output.Attributes.RemoveAll(ExcludeIfAttributeName);

            var isExcluded = Exclude || (Include.HasValue && !Include.Value);

            if (!isExcluded)
                return;

            output.TagName = null;
            output.SuppressOutput();
        }
    }
}