using System.Web.Mvc;
using AdvancedMVC2.Infrastructure.Extensions;
using AdvancedMVC2.Infrastructure.MVC.Commands;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace AdvancedMVC2.Infrastructure.MVC
{
    public class StructureMapControllerActionInvoker : ControllerActionInvoker
    {
        private readonly IContainer container;

        public StructureMapControllerActionInvoker()
        {
            container = ServiceLocator.Current.GetInstance<IContainer>();
        }

        private void InjectDependencies(object target)
        {
            container.BuildUp(target);
        }

        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filterInfo = base.GetFilters(controllerContext, actionDescriptor);
            filterInfo.ActionFilters.ForEach(InjectDependencies);
            filterInfo.AuthorizationFilters.ForEach(InjectDependencies);
            filterInfo.ExceptionFilters.ForEach(InjectDependencies);
            filterInfo.ResultFilters.ForEach(InjectDependencies);
            return filterInfo;
        }

        protected override void InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
        {
            InjectDependencies(actionResult);
            base.InvokeActionResult(controllerContext, actionResult);
        }
    }
}