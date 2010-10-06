using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdvancedMVC2.ActionFilters
{
    public class ViewJavaScriptAttribute : ActionFilterAttribute
    {
        internal const string Key = "ViewJavaScriptAttributeKey";

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (IsValidView(filterContext))
            {
                SetViewJavaScript(filterContext);
            }
            base.OnResultExecuting(filterContext);
        }

        private static bool IsValidView(ResultExecutingContext filterContext)
        {
            return !filterContext.Cancel && !filterContext.IsChildAction && filterContext.Result is ViewResult;
        }

        private static void SetViewJavaScript(ResultExecutingContext filterContext)
        {
            var basePath = GetJavaScriptPath(filterContext);

            if (File.Exists(GetPathOnServer(filterContext, basePath)))
            {
                InitViewData(filterContext.Controller, basePath);
            }
        }

        private static string GetPathOnServer(ResultExecutingContext filterContext, string basePath)
        {
            return filterContext.HttpContext.Server.MapPath(basePath);
        }

        private static void InitViewData(ControllerBase controller, string basePath)
        {
            controller.ViewData[Key] = VirtualPathUtility.ToAbsolute(basePath);
        }

        private static string GetJavaScriptPath(ResultExecutingContext filterContext)
        {
            var routeValues = filterContext.RouteData.Values;
            var dataValues = filterContext.RouteData.DataTokens;

            var viewResult = (ViewResult) filterContext.Result;

            var area = (string) dataValues["area"];
            var controller = (string) routeValues["controller"];
            var viewName = GetViewName(viewResult, routeValues);

            if (!string.IsNullOrEmpty(area))
            {
                return string.Format("~/Areas/{0}/Scripts/{1}/{2}.js", area, controller, viewName);
            }
            return string.Format("~/Scripts/Views/{0}/{1}.js", controller, viewName);
        }

        private static string GetViewName(ViewResult result, RouteValueDictionary values)
        {
            if (!string.IsNullOrEmpty(result.ViewName))
            {
                return result.ViewName;
            }
            return (string) values["action"];
        }
    }
}