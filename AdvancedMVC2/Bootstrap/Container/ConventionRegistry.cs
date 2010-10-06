using System.ComponentModel;
using AdvancedMVC2.Factories;
using AdvancedMVC2.Infrastructure.Repositories;
using AdvancedMVC2.ModelBinder;
using AdvancedMVC2.Services;
using AdvancedMVC2.Settings;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace AdvancedMVC2.Bootstrap.Container
{
    public class ConventionRegistry : Registry
    {
        public ConventionRegistry()
        {
            DefaultInterfaceConvention();
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
                    x.IncludeNamespace(typeof(IDesignSettings).Namespace);
                    x.IncludeNamespace(typeof(IHashing).Namespace);
                    x.IncludeNamespace(typeof(IRepository<>).Namespace);
                    x.IncludeNamespace(typeof(IWebUserFactory).Namespace);
                    x.WithDefaultConventions();
                });
        }

        private void AddAssemblies(IAssemblyScanner x)
        {
            x.Assembly(GetType().Assembly);
        }
    }
}