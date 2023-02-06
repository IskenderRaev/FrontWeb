using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace WebSti.Infrastructure.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static string IsSelected(this IHtmlHelper html, string controller = null, string cssClass = null)
        {
            if (string.IsNullOrWhiteSpace(cssClass))
            {
                cssClass = "active";
            }

            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (string.IsNullOrWhiteSpace(controller))
            {
                controller = currentController;
            }

            return controller.Equals(currentController, StringComparison.OrdinalIgnoreCase) ? cssClass : string.Empty;
        }

        public static string PageClass(this IHtmlHelper htmplHelper)
        {
            return (string)htmplHelper.ViewContext.RouteData.Values["action"];
        }

    }
}