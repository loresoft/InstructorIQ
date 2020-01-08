using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using InstructorIQ.Core.Extensions;

namespace InstructorIQ.Core.Services
{
    public class HtmlService : IHtmlService
    {
        public string PlanText(string htmlText)
        {
            if (htmlText.IsNullOrWhiteSpace())
                return string.Empty;

            var htmlParser = new HtmlParser();
            var document = htmlParser.ParseDocument(htmlText);
            var text = document.Body.Text();

            return text;
        }

    }
}
