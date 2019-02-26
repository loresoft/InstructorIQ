using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InstructorIQ.WebApplication.TagHelpers
{
    [HtmlTargetElement("alert", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class AlertTagHelper : TagHelper
    {
        public string Type { get; set; }

        public string Message { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            return base.ProcessAsync(context, output);
        }
    }
}
