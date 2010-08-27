using AdvancedMVC2.Infrastructure.Bootstrap;
using Microsoft.Practices.ServiceLocation;

namespace AdvancedMVC2.Bootstrap
{
    public class  BootstrapFilters : IBootstrapItem
    {
        private readonly IServiceLocator serviceLocator;

        public BootstrapFilters(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public void Execute()
        {
        }
    }

}