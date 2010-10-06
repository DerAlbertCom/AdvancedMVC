using System.Web.Mvc;
using AdvancedMVC2.Infrastructure.Bootstrap;
using AdvancedMVC2.Infrastructure.MVC;

namespace AdvancedMVC2.Bootstrap
{
    public class BootstrapControllerFactory : IBootstrapItem
    {
        public void Execute()
        {
            ControllerBuilder.Current.SetControllerFactory(new ServiceLocatorControllerFactory());
        }
    }
}