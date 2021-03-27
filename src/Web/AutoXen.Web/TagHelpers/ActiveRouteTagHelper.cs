namespace AutoXen.Web.TagHelpers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement(Attributes = "is-active-route")]
    public class ActiveRouteTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-area")]
        public string Area { get; set; }

        [HtmlAttributeName("asp-page")]
        public string Page { get; set; }

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

                if (this.Area == "Identity" && currentArea == this.Area)
                {
                    return true;
                }

                if (string.IsNullOrWhiteSpace(this.Area) || this.Area.ToLower() != currentArea.ToLower())
                {
                    return false;
                }
            }

            if (this.ViewContext.RouteData.Values.ContainsKey("page"))
            {
                string currentPage = this.ViewContext.RouteData.Values["Page"].ToString();

                if (string.IsNullOrWhiteSpace(this.Page) || this.Page.ToLower() != currentPage.ToLower())
                {
                    return false;
                }
            }

            if (this.ViewContext.RouteData.Values.ContainsKey("Controller"))
            {
                string currentController = this.ViewContext.RouteData.Values["Controller"].ToString();
                string currentAction = this.ViewContext.RouteData.Values["Action"].ToString();

                if (string.IsNullOrWhiteSpace(this.Controller) || string.IsNullOrWhiteSpace(this.Action))
                {
                    return false;
                }

                if (this.Controller.ToLower() != currentController.ToLower())
                {
                    return false;
                }

                if (this.Action.ToLower() != currentAction.ToLower())
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
                classAttr = new TagHelperAttribute("class", "active-text-color");
                output.Attributes.Add(classAttr);
            }
            else if (classAttr.Value == null || classAttr.Value.ToString().IndexOf("active-text-color") < 0)
            {
                output.Attributes.SetAttribute(
                    "class",
                    classAttr.Value == null ? "active-text-color" : classAttr.Value.ToString() + " active-text-color");
            }
        }
    }
}
