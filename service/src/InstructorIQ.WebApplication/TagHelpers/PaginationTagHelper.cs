using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace InstructorIQ.WebApplication.TagHelpers
{
    [HtmlTargetElement("pagination")]
    public class PaginationTagHelper : TagHelper
    {
        private const string ActionAttributeName = "asp-action";
        private const string ControllerAttributeName = "asp-controller";
        private const string AreaAttributeName = "asp-area";
        private const string PageAttributeName = "asp-page";
        private const string PageHandlerAttributeName = "asp-page-handler";
        private const string FragmentAttributeName = "asp-fragment";
        private const string HostAttributeName = "asp-host";
        private const string ProtocolAttributeName = "asp-protocol";
        private const string RouteAttributeName = "asp-route";
        private const string RouteValuesDictionaryName = "asp-all-route-data";
        private const string RouteValuesPrefix = "asp-route-";

        public PaginationTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
            RouteValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public override int Order => -1000;

        protected IHtmlGenerator Generator { get; }


        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; } = 10;

        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; } = 1;

        [HtmlAttributeName("total-items")]
        public long TotalItems { get; set; }

        [HtmlAttributeName("display-size")]
        public int DisplaySize { get; set; } = 5;

        [HtmlAttributeName("show-boundary")]
        public bool ShowBoundary { get; set; } = true;

        [HtmlAttributeName("show-direction")]
        public bool ShowDirection { get; set; } = true;

        [HtmlAttributeName("show-page")]
        public bool ShowPage { get; set; } = true;

        [HtmlAttributeName("center-selected")]
        public bool CenterSelected { get; set; } = true;

        [HtmlAttributeName("previous-text")]
        public string PreviousText { get; set; } = "‹";

        [HtmlAttributeName("next-text")]
        public string NextText { get; set; } = "›";

        [HtmlAttributeName("first-text")]
        public string FirstText { get; set; } = "«";

        [HtmlAttributeName("last-text")]
        public string LastText { get; set; } = "»";

        [HtmlAttributeName("page-route-name")]
        public string PageRouteName { get; set; } = "p";


        [HtmlAttributeName(ActionAttributeName)]
        public string Action { get; set; }

        [HtmlAttributeName(ControllerAttributeName)]
        public string Controller { get; set; }

        [HtmlAttributeName(AreaAttributeName)]
        public string Area { get; set; }

        [HtmlAttributeName(PageAttributeName)]
        public string Page { get; set; }

        [HtmlAttributeName(PageHandlerAttributeName)]
        public string PageHandler { get; set; }

        [HtmlAttributeName(ProtocolAttributeName)]
        public string Protocol { get; set; }

        [HtmlAttributeName(HostAttributeName)]
        public string Host { get; set; }

        [HtmlAttributeName(FragmentAttributeName)]
        public string Fragment { get; set; }

        [HtmlAttributeName(RouteAttributeName)]
        public string Route { get; set; }

        [HtmlAttributeName(RouteValuesDictionaryName, DictionaryAttributePrefix = RouteValuesPrefix)]
        public IDictionary<string, string> RouteValues { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }


        [HtmlAttributeNotBound]
        protected int PageCount => TotalItems > 0 ? (int)Math.Ceiling(TotalItems / (double)PageSize) : 0;

        [HtmlAttributeNotBound]
        protected bool HasPreviousPage => CurrentPage > 1;

        [HtmlAttributeNotBound]
        protected bool HasNextPage => CurrentPage < PageCount;

        [HtmlAttributeNotBound]
        public bool IsFirstPage => CurrentPage <= 1;

        [HtmlAttributeNotBound]
        public bool IsLastPage => CurrentPage >= PageCount;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // don't show if only 1 page
            if (PageCount <= 1)
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = "ul";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.AddClass("pagination", HtmlEncoder.Default);

            AppendFirstLink(output.Content);
            AppendPreviousLink(output.Content);

            var (start, end) = GetPageEnds();

            if (start > 1)
                AppendPageSet(output.Content, start - 1);

            for (int page = start; page <= end; page++)
                AppendPageLink(output.Content, page);

            if (end < PageCount)
                AppendPageSet(output.Content, end + 1);

            AppendNextLink(output.Content);
            AppendLastLink(output.Content);
        }


        private (int start, int end) GetPageEnds()
        {
            var start = 1;
            var end = PageCount;
            var isMax = DisplaySize > 0 && DisplaySize < PageCount;

            if (!isMax)
                return (start, end);

            if (CenterSelected)
            {
                int f = (int) Math.Floor(DisplaySize / 2d);

                start = Math.Max(CurrentPage - f, 1);
                end = start + DisplaySize - 1;

                if (end <= PageCount)
                    return (start, end);

                end = PageCount;
                start = end - DisplaySize + 1;

                return (start, end);
            }


            int c = (int) Math.Ceiling(CurrentPage / (double) DisplaySize);

            start = (c - 1) * DisplaySize + 1;
            end = Math.Min(start + DisplaySize - 1, PageCount);
            return (start, end);
        }

        private void AppendPageSet(TagHelperContent parent, int page)
        {
            var pageItem = new TagBuilder("li");
            pageItem.AddCssClass("page-item");
            pageItem.Attributes.Add("title", $"Goto to page {page}");

            var pageAnchor = CreatePageLink("...", page);
            pageAnchor.AddCssClass("page-link");

            pageItem.InnerHtml.AppendHtml(pageAnchor);

            parent.AppendHtml(pageItem);
        }


        private void AppendPreviousLink(TagHelperContent parent)
        {
            if (!ShowDirection)
                return;

            var previousItem = new TagBuilder("li");
            previousItem.AddCssClass("page-item");

            var page = CurrentPage - 1;
            if (page < 1)
                page = 1;

            var previousAnchor = CreatePageLink(PreviousText, page);
            previousAnchor.AddCssClass("page-link");

            if (HasPreviousPage)
            {
                previousAnchor.Attributes.Add("title", "Goto to previous page");
            }
            else
            {
                previousItem.AddCssClass("disabled");

                previousAnchor.Attributes["tabindex"] = "-1";
                previousAnchor.Attributes["aria-disabled"] = "true";
            }

            previousItem.InnerHtml.AppendHtml(previousAnchor);
            parent.AppendHtml(previousItem);
        }

        private void AppendNextLink(TagHelperContent parent)
        {
            if (!ShowDirection)
                return;

            var nextItem = new TagBuilder("li");
            nextItem.AddCssClass("page-item");

            var page = CurrentPage + 1;
            if (page > PageCount)
                page = PageCount;

            var nextAnchor = CreatePageLink(NextText, page);
            nextAnchor.AddCssClass("page-link");

            if (HasNextPage)
            {
                nextAnchor.Attributes.Add("title", "Goto to next page");
            }
            else
            {
                nextItem.AddCssClass("disabled");

                nextAnchor.Attributes["tabindex"] = "-1";
                nextAnchor.Attributes["aria-disabled"] = "true";
            }

            nextItem.InnerHtml.AppendHtml(nextAnchor);
            parent.AppendHtml(nextItem);
        }


        private void AppendFirstLink(TagHelperContent parent)
        {
            if (!ShowBoundary)
                return;

            var firstItem = new TagBuilder("li");
            firstItem.AddCssClass("page-item");

            var firstAnchor = CreatePageLink(FirstText, 1);
            firstAnchor.AddCssClass("page-link");

            if (IsFirstPage)
            {
                firstItem.AddCssClass("disabled");

                firstAnchor.Attributes["tabindex"] = "-1";
                firstAnchor.Attributes["aria-disabled"] = "true";
            }
            else
            {
                firstAnchor.Attributes.Add("title", "Goto to first page");
            }

            firstItem.InnerHtml.AppendHtml(firstAnchor);
            parent.AppendHtml(firstItem);
        }

        private void AppendLastLink(TagHelperContent parent)
        {
            if (!ShowBoundary)
                return;

            var lastItem = new TagBuilder("li");
            lastItem.AddCssClass("page-item");

            var lastAnchor = CreatePageLink(LastText, PageCount);
            lastAnchor.AddCssClass("page-link");

            if (IsLastPage)
            {
                lastItem.AddCssClass("disabled");

                lastAnchor.Attributes["tabindex"] = "-1";
                lastAnchor.Attributes["aria-disabled"] = "true";
            }
            else
            {
                lastAnchor.Attributes.Add("title", "Goto to last page");
            }

            lastItem.InnerHtml.AppendHtml(lastAnchor);
            parent.AppendHtml(lastItem);
        }


        private void AppendPageLink(TagHelperContent parent, int page)
        {
            if (!ShowPage)
                return;

            var pageItem = new TagBuilder("li");
            pageItem.AddCssClass("page-item");

            if (CurrentPage == page)
            {
                pageItem.AddCssClass("active");
                pageItem.Attributes["aria-current"] = "page";

                var spanLink = new TagBuilder("span");
                spanLink.AddCssClass("page-link");
                spanLink.InnerHtml.Append(page.ToString());
                spanLink.Attributes.Add("title", "Current Page");

                var spanCurrent = new TagBuilder("span");
                spanCurrent.AddCssClass("sr-only");
                spanCurrent.InnerHtml.Append(" (current)");

                spanLink.InnerHtml.AppendHtml(spanCurrent);
                pageItem.InnerHtml.AppendHtml(spanLink);
            }
            else
            {
                var pageAnchor = CreatePageLink(page.ToString(), page);
                pageAnchor.AddCssClass("page-link");
                pageAnchor.Attributes.Add("title", $"Goto to page {page}");

                pageItem.InnerHtml.AppendHtml(pageAnchor);
            }

            parent.AppendHtml(pageItem);
        }

        private TagBuilder CreatePageLink(string linkText, int page)
        {
            var routeLink = Route != null;
            var pageLink = Page != null || PageHandler != null;

            // make local copy
            var routeValues = new RouteValueDictionary(RouteValues);

            // Unconditionally replace any value from asp-route-area.
            if (Area != null)
                routeValues["area"] = Area;

            // add page route
            routeValues[PageRouteName] = page;


            TagBuilder tagBuilder;
            if (pageLink)
            {
                tagBuilder = Generator.GeneratePageLink(
                    ViewContext,
                    linkText: linkText,
                    pageName: Page,
                    pageHandler: PageHandler,
                    protocol: Protocol,
                    hostname: Host,
                    fragment: Fragment,
                    routeValues: routeValues,
                    htmlAttributes: null);
            }
            else if (routeLink)
            {
                tagBuilder = Generator.GenerateRouteLink(
                    ViewContext,
                    linkText: linkText,
                    routeName: Route,
                    protocol: Protocol,
                    hostName: Host,
                    fragment: Fragment,
                    routeValues: routeValues,
                    htmlAttributes: null);
            }
            else
            {
                tagBuilder = Generator.GenerateActionLink(
                   ViewContext,
                   linkText: linkText,
                   actionName: Action,
                   controllerName: Controller,
                   protocol: Protocol,
                   hostname: Host,
                   fragment: Fragment,
                   routeValues: routeValues,
                   htmlAttributes: null);
            }

            return tagBuilder;
        }
    }
}
