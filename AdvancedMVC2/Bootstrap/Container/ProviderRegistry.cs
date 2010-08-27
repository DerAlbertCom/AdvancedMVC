using AdvancedMVC2.Infrastructure.Provider;
using AdvancedMVC2.Provider;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;

namespace AdvancedMVC2.Bootstrap.Container
{
    public class ProviderRegistry : Registry
    {
        public ProviderRegistry()
        {
            For<IStateProvider>()
                .LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.Singleton))
                .Use<HttpSessionStateProvider>();
        }
    }
}