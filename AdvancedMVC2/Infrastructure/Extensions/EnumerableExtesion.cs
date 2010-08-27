using System;
using System.Collections.Generic;

namespace AdvancedMVC2.Infrastructure.Extensions
{
    public static class EnumerableExtesion
    {
        public static void ForEach<T>(this IEnumerable<T> instances, Action<T> action)
        {
            foreach (var instance in instances)
            {
                action(instance);
            }
        }
    }
}