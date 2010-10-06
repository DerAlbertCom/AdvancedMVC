using System;
using System.Web.Mvc;
using AdvancedMVC2.Settings;

namespace AdvancedMVC2.ActionFilters
{
    public class MasterPageAttribute : FilterAttribute, IResultFilter
    {
        public IDesignSettings Settings { get; set; }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                viewResult.MasterName = Settings.MasterName;
            }
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}