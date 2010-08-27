using AdvancedMVC2.Bootstrap.Container;
using AdvancedMVC2.Infrastructure.Bootstrap;
using AdvancedMVC2.Infrastructure.StructureMap;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace AdvancedMVC2.Bootstrap
{
    public class BootstrapContainer : IBootstrapItem
    {
        private IContainer container;

        public void Execute()
        {
            container = new StructureMap.Container(x =>
                {
                    x.AddRegistry(new NamespaceRegistry());
                    x.AddRegistry(new ProviderRegistry());
                    x.AddRegistry(new ConcreteTypeRegistry());
                });

            container.Configure(x => x.For<IContainer>().Add(container));
            SetServiceLocator();
        }

        private void SetServiceLocator()
        {
            var locatorContainer = new StructureMapServiceLocator(container);

            ServiceLocator.SetLocatorProvider(() => locatorContainer);

            container.Configure(x => x.For<IServiceLocator>().Add(locatorContainer));
        }
    }
}