using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InstructorIQ.WebApplication.TagHelpers
{
    [HtmlTargetElement("required", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class RequiredTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "text-danger");
            output.Attributes.SetAttribute("title", "This input field is required");
            output.Content.SetContent("*");
        }
    }
}
