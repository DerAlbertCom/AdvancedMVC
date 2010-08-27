using System.ComponentModel;
using AdvancedMVC2.ModelBinder;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace AdvancedMVC2.Bootstrap.Container
{
    public class NamespaceRegistry : Registry
    {
        public NamespaceRegistry()
        {
            DefaultInterfaceConvention();
            FactoriesConvention();
            WithSameBaseType();
        }

        private void WithSameBaseType()
        {
            Scan(x =>
                {
                    AddAssemblies(x);
                    x.AddAllTypesOf(typeof (ITypedModelBinder));
                    x.AddAllTypesOf(typeof (IMappingBootstrapItem));
                    x.AddAllTypesOf(typeof(TypeConverter));
                });

        }

        private void DefaultInterfaceConvention()
        {
            Scan(x =>
                {
                    AddAssemblies(x);

                    x.IncludeNamespace("Regularly.DomainServices");
                    x.IncludeNamespace("Regularly.Services");
                    x.IncludeNamespace("Regularly.Repositories");
                    x.IncludeNamespace("Regularly.Factories");
                    x.IncludeNamespace("Regularly.Infrastructure.Repositories");
                    x.IncludeNamespace("Regularly.Infrastructure.Provider");
                    x.WithDefaultConventions();
                });
        }

        private void FactoriesConvention()
        {
            Scan(x =>
                {
                    AddAssemblies(x);
                    x.RegisterConcreteTypesAgainstTheFirstInterface();
                });
        }

        private void AddAssemblies(IAssemblyScanner x)
        {
            x.Assembly(GetType().Assembly);
        }
    }
}