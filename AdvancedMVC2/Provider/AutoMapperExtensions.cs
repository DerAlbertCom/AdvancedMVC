using System.Collections;
using System.Collections.Generic;
using AdvancedMVC2.DomainObjects;
using AutoMapper;

namespace AdvancedMVC2.Provider
{
    public static class AutoMapperExtensions
    {
        public static TDestination MapTo<TDestination>(this DomainObject source)
        {
            return (TDestination) Mapper.Map(source, source.GetType(), typeof (TDestination));
        }

        public static TDestination MapTo<TDestination>(this object source)
        {
            return (TDestination) Mapper.Map(source, source.GetType(), typeof (TDestination));
        }

        public static IEnumerable<TDestination> MapTo<TDestination>(this IEnumerable source)
        {
            return (IEnumerable<TDestination>) Mapper.Map(source, source.GetType(), typeof (IEnumerable<TDestination>));
        }
    }
}