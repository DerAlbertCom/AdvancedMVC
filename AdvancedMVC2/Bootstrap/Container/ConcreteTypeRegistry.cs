using AdvancedMVC2.Infrastructure.StructureMap;
using StructureMap.Configuration.DSL;

namespace AdvancedMVC2.Bootstrap.Container
{
    public class ConcreteTypeRegistry : Registry
    {
        public ConcreteTypeRegistry()
        {
            ScanForBootstrap();
            ScanForController();
        }

        private void ScanForController()
        {
            Scan(x=>
                     {
                         x.Assembly(GetType().Assembly);
                         x.Include(type => type.Name.EndsWith("Controller"));
                         x.With(new ConcreteTypeConvention());
                     });
        }

        private void ScanForBootstrap()
        {
            Scan(x =>
                     {
                         x.Assembly(GetType().Assembly);
                         x.IncludeNamespace(typeof(BootstrapContainer).Namespace);
                         x.With(new ConcreteTypeConvention());
                     });
        }
    }
}