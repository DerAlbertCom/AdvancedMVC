using AdvancedMVC2.Infrastructure.StructureMap;
using StructureMap.Configuration.DSL;

namespace AdvancedMVC2.Bootstrap.Container
{
    public class ConcreteTypeRegistry : Registry
    {
        public ConcreteTypeRegistry()
        {
            Scan(x =>
                     {
                         x.Assembly(GetType().Assembly);
                         x.IncludeNamespace("Regularly.Bootstrap");
                         x.With(new ConcreteTypeConvention());
                     });
            Scan(x=>
                {
                    x.Assembly(GetType().Assembly);
                    x.Include(type => type.Name.EndsWith("Controller"));
                    x.With(new ConcreteTypeConvention());
                });
        }
    }
}