using System.Web.Mvc;
using AdvancedMVC2.ActionFilters;

namespace AdvancedMVC2.Extensions
{
    public static class ViewJavaScriptExtension
    {
        public static MvcHtmlString ViewJavaScript(this HtmlHelper htmlHelper)
        {
            var scriptUrl = GetJavaScriptUrl(htmlHelper);
            string result = string.Empty;
            if (!string.IsNullOrEmpty(scriptUrl))
            {
                result = CreateScriptTag(scriptUrl);
            }
            return MvcHtmlString.Create(result);
        }

        private static string CreateScriptTag(string scriptUrl)
        {
            var tag = new TagBuilder("script");
            tag.Attributes.Add("src", scriptUrl);
            tag.Attributes.Add("type", "text/javascript");
            return tag.ToString(TagRenderMode.Normal);
        }

        private static string GetJavaScriptUrl(HtmlHelper htmlHelper)
        {
            return (string)htmlHelper.ViewContext.Controller.ViewData[ViewJavaScriptAttribute.Key];
        }
    }
}