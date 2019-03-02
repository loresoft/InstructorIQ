using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace InstructorIQ.WebApplication.TagHelpers
{
    [HtmlTargetElement("confirm-button")]
    public class ConfirmButtonTagHelper : TagHelper
    {
        public ConfirmButtonTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            UrlHelperFactory = urlHelperFactory;
        }

        private const string ActionAttributeName = "asp-action";
        private const string AreaAttributeName = "asp-area";
        private const string ControllerAttributeName = "asp-controller";
        private const string PageAttributeName = "asp-page";
        private const string PageHandlerAttributeName = "asp-page-handler";
        private const string FragmentAttributeName = "asp-fragment";
        private const string RouteAttributeName = "asp-route";
        private const string RouteValuesDictionaryName = "asp-all-route-data";
        private const string RouteValuesPrefix = "asp-route-";
        private const string FormAction = "formaction";


        protected IUrlHelperFactory UrlHelperFactory { get; }

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

        [HtmlAttributeName(FragmentAttributeName)]
        public string Fragment { get; set; }

        [HtmlAttributeName(RouteAttributeName)]
        public string Route { get; set; }

        [HtmlAttributeName(RouteValuesDictionaryName, DictionaryAttributePrefix = RouteValuesPrefix)]
        public IDictionary<string, string> RouteValues { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }


        [HtmlAttributeName("modal-title")]
        public string ModalTitle { get; set; }

        [HtmlAttributeName("modal-text")]
        public string ModalText { get; set; }

        [HtmlAttributeName("modal-button")]
        public string ModalButton { get; set; }

        [HtmlAttributeName("modal-color")]
        public string ModalColor { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var uniqueId = context.UniqueId;
            var modalId = $"modal-{uniqueId}";

            output.TagName = "button";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("type", "button");
            output.Attributes.SetAttribute("data-toggle", "modal");
            output.Attributes.SetAttribute("data-target", $"#{modalId}");

            var modalTag = CreateModal(modalId, uniqueId);
            output.PostElement.AppendHtml(modalTag);
        }

        private TagBuilder CreateModal(string modalId, string uniqueId)
        {
            var labelId = $"label-{uniqueId}";

            var modalTag = new TagBuilder("div");
            modalTag.AddCssClass("modal");
            modalTag.AddCssClass("fade");
            modalTag.Attributes["id"] = modalId;
            modalTag.Attributes["tabindex"] = "-1";
            modalTag.Attributes["role"] = "dialog";
            modalTag.Attributes["aria-labelledby"] = labelId;
            modalTag.Attributes["aria-hidden"] = "true";

            var dialogTag = new TagBuilder("div");
            dialogTag.AddCssClass("modal-dialog");
            dialogTag.Attributes["role"] = "document";


            var contentTag = new TagBuilder("div");
            contentTag.AddCssClass("modal-content");

            var headerTag = CreateHeader(labelId);
            var bodyTag = CreateBodyTag();
            var footerTag = CreateFooter();

            contentTag.InnerHtml.AppendHtml(headerTag);
            contentTag.InnerHtml.AppendHtml(bodyTag);
            contentTag.InnerHtml.AppendHtml(footerTag);

            dialogTag.InnerHtml.AppendHtml(contentTag);

            modalTag.InnerHtml.AppendHtml(dialogTag);

            return modalTag;
        }

        private TagBuilder CreateBodyTag()
        {
            var text = string.IsNullOrWhiteSpace(ModalText)
                ? "Are you sure?"
                : ModalText;

            var bodyTag = new TagBuilder("div");
            bodyTag.AddCssClass("modal-body");
            bodyTag.InnerHtml.Append(text);
            return bodyTag;
        }

        private TagBuilder CreateFooter()
        {
            var footerTag = new TagBuilder("div");
            footerTag.AddCssClass("modal-footer");

            var cancelButton = new TagBuilder("button");
            cancelButton.AddCssClass("btn");
            cancelButton.AddCssClass("btn-secondary");
            cancelButton.Attributes["type"] = "button";
            cancelButton.Attributes["data-dismiss"] = "modal";
            cancelButton.InnerHtml.Append("Cancel");

            var acceptColor = string.IsNullOrWhiteSpace(ModalColor)
                ? "primary"
                : ModalColor;

            var acceptText = string.IsNullOrWhiteSpace(ModalButton)
                ? "Ok"
                : ModalButton;

            var acceptAction = GetFormAction();

            var acceptButton = new TagBuilder("button");
            acceptButton.AddCssClass("btn");
            acceptButton.AddCssClass($"btn-{acceptColor}");
            acceptButton.Attributes["type"] = "submit";
            acceptButton.Attributes[FormAction] = acceptAction;
            acceptButton.InnerHtml.Append(acceptText);

            footerTag.InnerHtml.AppendHtml(cancelButton);
            footerTag.InnerHtml.AppendHtml(acceptButton);

            return footerTag;
        }

        private TagBuilder CreateHeader(string labelId)
        {
            var headerTag = new TagBuilder("div");
            headerTag.AddCssClass("modal-header");

            if (!string.IsNullOrWhiteSpace(ModalColor))
                headerTag.AddCssClass($"modal-header-{ModalColor}");

            var titleTag = new TagBuilder("h5");
            titleTag.AddCssClass("modal-title");
            titleTag.Attributes["id"] = labelId;

            var titleText = string.IsNullOrWhiteSpace(ModalTitle)
                ? "Confirmation"
                : ModalTitle;

            titleTag.InnerHtml.Append(titleText);

            var closeTag = new TagBuilder("button");
            closeTag.AddCssClass("close");
            closeTag.Attributes["type"] = "button";
            closeTag.Attributes["data-dismiss"] = "modal";
            closeTag.Attributes["aria-label"] = "Close";

            var spanTag = new TagBuilder("span");
            spanTag.Attributes["aria-hidden"] = "true";
            spanTag.InnerHtml.AppendHtml("&times;");

            closeTag.InnerHtml.AppendHtml(spanTag);

            headerTag.InnerHtml.AppendHtml(titleTag);
            headerTag.InnerHtml.AppendHtml(closeTag);
            return headerTag;
        }


        private string GetFormAction()
        {
            var routeLink = Route != null;
            var actionLink = Controller != null || Action != null;
            var pageLink = Page != null || PageHandler != null;

            // make local copy
            var routeValues = new RouteValueDictionary(RouteValues);

            // Unconditionally replace any value from asp-route-area.
            if (Area != null)
                routeValues["area"] = Area;


            var urlHelper = UrlHelperFactory.GetUrlHelper(ViewContext);

            if (pageLink)
            {
                return urlHelper.Page(
                    Page,
                    PageHandler,
                    routeValues,
                    protocol: null,
                    host: null,
                    fragment: Fragment);
            }


            if (routeLink)
            {
                return urlHelper.RouteUrl(
                    Route,
                    routeValues,
                    protocol: null,
                    host: null,
                    fragment: Fragment);
            }

            return urlHelper.Action(
                Action,
                Controller,
                routeValues,
                protocol: null,
                host: null,
                fragment: Fragment);
        }

    }
}
