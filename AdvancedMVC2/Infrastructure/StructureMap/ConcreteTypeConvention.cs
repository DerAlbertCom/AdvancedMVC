using System;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace AdvancedMVC2.Infrastructure.StructureMap
{
    public class ConcreteTypeConvention : IRegistrationConvention
    {
        private static bool IsConcreteClass(Type type)
        {
            return !type.IsAbstract && type.IsClass && type != typeof (string);
        }

        public void Process(Type type, Registry registry)
        {
            if (IsConcreteClass(type))
            {
                registry.AddType(type, type);
            }
        }
    }
}