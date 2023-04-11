using System.Text.Json;
using System.Threading.Tasks;

using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Services;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InstructorIQ.WebApplication.TagHelpers;

[HtmlTargetElement("json-display", TagStructure = TagStructure.NormalOrSelfClosing)]
public class JsonDisplayTagHelper : TagHelper
{
    private readonly IHtmlService _htmlService;

    public JsonDisplayTagHelper(IHtmlService htmlService)
    {
        _htmlService = htmlService;
    }

    public ModelExpression Content { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = null;

        var content = await GetContent(output);
        if (content.IsNullOrWhiteSpace())
        {
            output.Content.SetContent("");
            return;
        }

        var text = _htmlService.PlainText(content);
        var document = JsonDocument.Parse(text);

        AppendValue(output.Content, document.RootElement);
    }

    private async Task<string> GetContent(TagHelperOutput output)
    {
        if (Content != null)
            return Content.Model?.ToString();

        var childContent = await output.GetChildContentAsync();
        return childContent.GetContent();
    }

    private void AppendValue(IHtmlContentBuilder parent, JsonElement jsonElement)
    {
        switch (jsonElement.ValueKind)
        {
            case JsonValueKind.Object:
                AppendObject(parent, jsonElement);
                break;
            case JsonValueKind.Array:
                foreach (var arrayElement in jsonElement.EnumerateArray())
                    AppendValue(parent, arrayElement);

                break;
            case JsonValueKind.String:
            case JsonValueKind.Number:
            case JsonValueKind.True:
            case JsonValueKind.False:
                parent.Append(jsonElement.ToString());
                break;
            case JsonValueKind.Undefined:
            case JsonValueKind.Null:
            default:
                parent.Append(string.Empty);
                break;
        }
    }

    private void AppendObject(IHtmlContentBuilder parent, JsonElement jsonElement)
    {
        var tableTag = new TagBuilder("table");
        tableTag.AddCssClass("json-object");

        foreach (var jsonProperty in jsonElement.EnumerateObject())
        {
            var rowTag = new TagBuilder("tr");

            var nameTag = new TagBuilder("th");
            nameTag.AddCssClass("json-name");
            nameTag.InnerHtml.Append(jsonProperty.Name);

            var valueTag = new TagBuilder("td");
            valueTag.AddCssClass("json-value");

            AppendValue(valueTag.InnerHtml, jsonProperty.Value);

            rowTag.InnerHtml.AppendHtml(nameTag);
            rowTag.InnerHtml.AppendHtml(valueTag);

            tableTag.InnerHtml.AppendHtml(rowTag);
        }

        parent.AppendHtml(tableTag);
    }
}
