using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CommonMark;

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InstructorIQ.WebApplication.TagHelpers;

[HtmlTargetElement("markdown", TagStructure = TagStructure.NormalOrSelfClosing)]
[HtmlTargetElement(Attributes = "markdown")]
public class MarkdownTagHelper : TagHelper
{
    public ModelExpression Content { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (output.TagName == "markdown")
            output.TagName = null;

        output.Attributes.RemoveAll("markdown");

        var content = await GetContent(output);
        var html = CommonMarkConverter.Convert(content);

        output.Content.SetHtmlContent(html ?? "");
    }

    private async Task<string> GetContent(TagHelperOutput output)
    {
        if (Content != null)
            return Content.Model?.ToString();

        var childContent = await output.GetChildContentAsync();
        return childContent.GetContent();
    }
}
