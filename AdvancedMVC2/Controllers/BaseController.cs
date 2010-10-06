using System.Web.Mvc;
using AdvancedMVC2.ActionFilters;
using AdvancedMVC2.Infrastructure.MVC;
using AdvancedMVC2.Settings;

namespace AdvancedMVC2.Controllers
{
    [MasterPage]
    public abstract class BaseController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            return new StructureMapControllerActionInvoker();
        }

        //public IDesignSettings DesignSettings { get; set; }

        //protected override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    var result = filterContext.Result as ViewResult;
        //    if (result != null)
        //        result.MasterName = DesignSettings.MasterName;

        //    base.OnResultExecuting(filterContext);
        //}
    }
}