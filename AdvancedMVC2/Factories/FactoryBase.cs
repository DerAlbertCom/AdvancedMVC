using System;
using System.Globalization;
using System.Reflection;
using AdvancedMVC2.DomainObjects;

namespace AdvancedMVC2.Factories
{
    public abstract class FactoryBase<T> where T : class
    {
        protected T CreateEntity()
        {
            var instance = CreateInstance();
            var initializable = instance as IInitializable;
            if (initializable != null)
            {
                initializable.Initialize();
            }
            return instance;
        }

        private T CreateInstance()
        {
            return (T) Activator.CreateInstance(typeof (T),
                                                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
                                                null, null, CultureInfo.InvariantCulture);
        }
    }
}