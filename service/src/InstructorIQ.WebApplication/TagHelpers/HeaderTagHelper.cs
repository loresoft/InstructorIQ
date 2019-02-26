using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InstructorIQ.WebApplication.TagHelpers
{
    [HtmlTargetElement("header", Attributes = "sort-by")]
    public class HeaderTagHelper : AnchorTagHelper
    {

        public HeaderTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override int Order => -1001;

        [HtmlAttributeName("sort-by")]
        public string SortField { get; set; }

        [HtmlAttributeName("sort-by-descending")]
        public string SortFieldDescending { get; set; }


        [HtmlAttributeName("sort-current")]
        public string SortCurrent { get; set; }

        [HtmlAttributeName("sort-route-name")]
        public string SortRouteName { get; set; } = "s";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;

            if (string.IsNullOrWhiteSpace(SortFieldDescending))
                SortFieldDescending = $"{SortField}:desc";

            bool isFieldAscending = String.Equals(SortField, SortCurrent, StringComparison.OrdinalIgnoreCase);
            bool isFieldDescending = String.Equals(SortFieldDescending, SortCurrent, StringComparison.OrdinalIgnoreCase);

            RouteValues[SortRouteName] = isFieldAscending ? SortFieldDescending : SortField;

            base.Process(context, output);

            output.AddClass("sort-by", HtmlEncoder.Default);

            if (isFieldAscending)
                output.AddClass("ascending", HtmlEncoder.Default);
            else if (isFieldDescending)
                output.AddClass("descending", HtmlEncoder.Default);
        }
    }
}
