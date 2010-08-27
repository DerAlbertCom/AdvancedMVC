using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedMVC2.Infrastructure.Bootstrap
{
    public class Bootstrapper
    {
        private readonly List<Type> items;

        private Bootstrapper()
        {
            items = new List<Type>();
        }

        public static Bootstrapper Start()
        {
            return new Bootstrapper();
        }

        public Bootstrapper With<T>() where T : IBootstrapItem
        {
            if (items.Contains(typeof (T)))
            {
                throw new ArgumentException(string.Format("the type {0} is already added", typeof (T)));
            }
            items.Add(typeof (T));
            return this;
        }

        public void Execute()
        {
            foreach (var bootstrapItem in items.Select(CreateInstance))
            {
                bootstrapItem.Execute();
            }
        }

        private static IBootstrapItem CreateInstance(Type type)
        {
            try
            {
                return (IBootstrapItem) ServiceLocator.Current.GetInstance(type);
            }
            catch (NullReferenceException)
            {
                return (IBootstrapItem) Activator.CreateInstance(type);
            }
        }
    }
}