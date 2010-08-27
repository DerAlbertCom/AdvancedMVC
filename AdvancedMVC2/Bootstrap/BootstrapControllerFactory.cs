using System.Web.Mvc;
using AdvancedMVC2.Infrastructure.Bootstrap;
using AdvancedMVC2.Infrastructure.MVC;
using StructureMap;

namespace AdvancedMVC2.Bootstrap
{
    public class BootstrapControllerFactory : IBootstrapItem
    {
        private readonly IContainer container;

        public BootstrapControllerFactory(IContainer container)
        {
            this.container = container;
        }

        public void Execute()
        {
            ControllerBuilder.Current.SetControllerFactory(new ServiceLocatorControllerFactory());
        }
    }
}