using System.Web.Mvc;
using System.Web.Routing;
using AdvancedMVC2.Infrastructure.Bootstrap;

namespace AdvancedMVC2.Bootstrap
{
    public class BootstrapRoutes : IBootstrapItem
    {
        public void Execute()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }


        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = ""} // Parameter defaults
                );
        }
    }
}