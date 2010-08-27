using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdvancedMVC2.Infrastructure.MVC
{
    public class ServiceLocatorControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;
            return ServiceLocator.Current.GetInstance(controllerType) as IController;
        }
    }
}