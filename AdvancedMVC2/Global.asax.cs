using System;
using System.Web.Mvc;
using System.Web.Routing;
using AdvancedMVC2.Bootstrap;
using AdvancedMVC2.Infrastructure.Bootstrap;

namespace AdvancedMVC2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {


        protected void Application_Start()
        {
            Bootstrapper
                .Start()
                .With<BootstrapContainer>()
                .With<BootstrapControllerFactory>()
                .With<BootstrapMapper>()
                .With<BootstrapViewEngine>()
                .With<BootstrapRoutes>()
                .With<BootstrapFilters>()
                .With<BootstrapModelBinder>()
                .With<BootstrapValidators>()
                .Execute();
        }
    }
}