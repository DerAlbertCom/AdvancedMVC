using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Microsoft.Practices.ServiceLocation;

namespace AdvancedMVC2.Infrastructure.Converters
{
    public class Converter : IConverter
    {
        private static IConverter converter;
        private static readonly object ConverterLock = new object();

        public static IConverter Current
        {
            get
            {
                if (converter == null)

                {
                    lock (ConverterLock)
                    {
                        if (converter == null)
                        {
                            converter = ServiceLocator.Current.GetInstance<IConverter>();
                        }
                    }
                }
                return converter;
            }
        }

        private readonly IEnumerable<TypeConverter> typeConverters;

        public Converter(IEnumerable<TypeConverter> typeConverters)
        {
            this.typeConverters = typeConverters;
        }

        public object ChangeType(object value, Type resultType, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            foreach (var typeConverter in typeConverters)
            {
                if (typeConverter.CanConvertFrom(value.GetType()) && typeConverter.CanConvertTo(resultType))
                {
                    return typeConverter.ConvertTo(null, culture, value, resultType);
                }
            }
            return Convert.ChangeType(value, resultType, culture);
        }

        public object ChangeType(object value, Type resultType)
        {
            return ChangeType(value, resultType, CultureInfo.CurrentCulture);
        }
    }
}