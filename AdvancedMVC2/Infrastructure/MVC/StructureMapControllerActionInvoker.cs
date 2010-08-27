using System.Web.Mvc;
using AdvancedMVC2.Infrastructure.Extensions;
using AdvancedMVC2.Infrastructure.MVC.Commands;
using StructureMap;

namespace AdvancedMVC2.Infrastructure.MVC
{
    public class StructureMapControllerActionInvoker : ControllerActionInvoker
    {
        private readonly IContainer container;

        public StructureMapControllerActionInvoker(IContainer container)
        {
            this.container = container;
        }

        private void InjectInstances(object target)
        {
            container.BuildUp(target);
        }

        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filterInfo = base.GetFilters(controllerContext, actionDescriptor);
            filterInfo.ActionFilters.ForEach(InjectInstances);
            filterInfo.AuthorizationFilters.ForEach(InjectInstances);
            filterInfo.ExceptionFilters.ForEach(InjectInstances);
            filterInfo.ResultFilters.ForEach(InjectInstances);
            return filterInfo;
        }

        protected override ActionResult CreateActionResult(
            ControllerContext controllerContext,
            ActionDescriptor actionDescriptor,
            object actionReturnValue)
        {
            if (actionReturnValue is ICommandResult)
            {
                var openWrappedType = typeof (CommandResultInvokerFacade<>);
                var actionMethodResultType = actionReturnValue.GetType();
                var wrappedResultType = openWrappedType.MakeGenericType(actionMethodResultType);

                var invokerFacade = (ICommandResultInvoker) container.GetInstance(wrappedResultType);

                var result = invokerFacade.Invoke(actionReturnValue, controllerContext);

                return result;
            }
            return base.CreateActionResult(controllerContext, actionDescriptor, actionReturnValue);
        }
    }
}