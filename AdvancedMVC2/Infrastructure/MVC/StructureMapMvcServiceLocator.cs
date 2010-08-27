using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;

namespace AdvancedMVC2.Infrastructure.MVC
{
    public class StructureMapMvcServiceLocator : IMvcServiceLocator
    {
        private readonly IContainer container;

        public StructureMapMvcServiceLocator(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return container.GetAllInstances<TService>();
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container.GetAllInstances(serviceType).Cast<object>();
        }

        public TService GetInstance<TService>()
        {
            return container.GetInstance<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            return container.GetInstance<TService>(key);
        }

        public object GetInstance(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            return container.GetInstance(serviceType, key);
        }

        public void Release(object instance)
        {
        }
    }
}