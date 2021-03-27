namespace AutoXen.Web.TagHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement(Attributes = "is-active-route")]
    public class ActiveRouteTagHelper : TagHelper
    {
        private IDictionary<string, string> routeValues;

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-area")]
        public string Area { get; set; }

        [HtmlAttributeName("asp-page")]
        public string Page { get; set; }

        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
        public IDictionary<string, string> RouteValues
        {
            get
            {
                if (this.routeValues == null)
                {
                    this.routeValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                }

                return this.routeValues;
            }

            set
            {
                this.routeValues = value;
            }
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (this.ShouldBeActive())
            {
                this.MakeActive(output);
            }

            output.Attributes.RemoveAll("is-active-route");
        }

        private bool ShouldBeActive()
        {
            if (this.ViewContext.RouteData.Values.ContainsKey("Area"))
            {
                string currentArea = this.ViewContext.RouteData.Values["Area"].ToString();
                string currentPage = this.ViewContext.RouteData.Values["Page"].ToString();

                if (!string.IsNullOrWhiteSpace(this.Area) && this.Area.ToLower() != currentArea.ToLower())
                {
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(this.Page) && this.Page.ToLower() != currentPage.ToLower())
                {
                    return false;
                }

                return true;
            }

            string currentController = this.ViewContext.RouteData.Values["Controller"].ToString();
            string currentAction = this.ViewContext.RouteData.Values["Action"].ToString();

            if (!string.IsNullOrWhiteSpace(this.Controller) && this.Controller.ToLower() != currentController.ToLower())
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(this.Action) && this.Action.ToLower() != currentAction.ToLower())
            {
                return false;
            }

            foreach (KeyValuePair<string, string> routeValue in this.RouteValues)
            {
                if (!this.ViewContext.RouteData.Values.ContainsKey(routeValue.Key) ||
                    this.ViewContext.RouteData.Values[routeValue.Key].ToString() != routeValue.Value)
                {
                    return false;
                }
            }

            return true;
        }

        private void MakeActive(TagHelperOutput output)
        {
            var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");
            if (classAttr == null)
            {
                classAttr = new TagHelperAttribute("class", "active");
                output.Attributes.Add(classAttr);
            }
            else if (classAttr.Value == null || classAttr.Value.ToString().IndexOf("active") < 0)
            {
                output.Attributes.SetAttribute(
                    "class",
                    classAttr.Value == null ? "active" : classAttr.Value.ToString() + " active");
            }
        }
    }
}
