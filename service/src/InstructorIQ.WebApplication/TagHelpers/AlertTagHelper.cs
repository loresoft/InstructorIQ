using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InstructorIQ.WebApplication.TagHelpers
{
    [HtmlTargetElement("alert", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class AlertTagHelper : TagHelper
    {
        [HtmlAttributeName("type")]
        public string Type { get; set; } = "success";

        [HtmlAttributeName("message")]
        public string Message { get; set; }

        [HtmlAttributeName("dismissible")]
        public bool Dismissible { get; set; } = true;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrWhiteSpace(Message))
            {
                output.SuppressOutput();
                return;
            }

            var type = string.IsNullOrWhiteSpace(Type) ? "success" : Type;

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.AddClass("alert", HtmlEncoder.Default);
            output.AddClass($"alert-{type}", HtmlEncoder.Default);

            output.Attributes.Add("role", "alert");

            output.Content.Append(Message);

            if (!Dismissible)
                return;

            output.AddClass("alert-dismissible", HtmlEncoder.Default);
            output.AddClass("fade", HtmlEncoder.Default);
            output.AddClass("show", HtmlEncoder.Default);

            var buttonTag = new TagBuilder("button");
            buttonTag.AddCssClass("close");
            buttonTag.Attributes["type"] = "button";
            buttonTag.Attributes["data-dismiss"] = "alert";
            buttonTag.Attributes["aria-label"] = "Close";

            var spanTag = new TagBuilder("span");
            spanTag.Attributes["aria-hidden"] = "true";
            spanTag.InnerHtml.AppendHtml("&times;");

            buttonTag.InnerHtml.AppendHtml(spanTag);

            output.Content.AppendHtml(buttonTag);
        }
    }
}
