using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AdvancedMVC2.Extensions
{
    public static class RegularlyLinkExtensions
    {
        public static MvcHtmlString AreaActionLink(this HtmlHelper htmlHelper, string area, string caption, string action, string controller, object htmlAttributes=null)
        {
            return htmlHelper.ActionLink(caption, action, controller, new {area = area}, htmlAttributes);
        }
    }
}