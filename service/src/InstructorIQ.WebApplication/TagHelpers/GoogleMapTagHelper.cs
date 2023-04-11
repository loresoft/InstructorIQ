using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using InstructorIQ.Core.Extensions;

using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InstructorIQ.WebApplication.TagHelpers;

[HtmlTargetElement("google-map")]
public class GoogleMapTagHelper : TagHelper
{
    public const string GoogleUrl = "https://www.google.com/maps/search/?api=1";

    [HtmlAttributeName("address")]
    public string AddressLine1 { get; set; }

    [HtmlAttributeName("city")]
    public string City { get; set; }

    [HtmlAttributeName("state")]
    public string StateProvince { get; set; }

    [HtmlAttributeName("postal")]
    public string PostalCode { get; set; }


    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var builder = new StringBuilder();

        builder.AppendIf(AddressLine1, s => s.HasValue());
        builder.AppendIf(", ", s => builder.Length > 0);
        builder.AppendIf(City, s => s.HasValue());
        builder.AppendIf(", ", s => builder.Length > 0);
        builder.AppendIf(StateProvince, s => s.HasValue());
        builder.AppendIf(", ", s => builder.Length > 0);
        builder.AppendIf(PostalCode, s => s.HasValue());

        if (builder.Length <= 0)
        {
            output.TagName = "span";
            return;
        }

        var addess = builder.ToString();
        addess = Uri.EscapeDataString(addess);

        var url = $"{GoogleUrl}&query={addess}";

        output.TagName = "a";
        output.Attributes.SetAttribute("href", url);
        output.Attributes.SetAttribute("target", "_blank");
        output.Attributes.SetAttribute("title", "View Google Map");
    }
}
