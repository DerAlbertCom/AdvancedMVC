using System;
using System.Globalization;

namespace AdvancedMVC2.Infrastructure.Converters
{
    public interface IConverter
    {
        object ChangeType(object value, Type resultType, CultureInfo culture);
        object ChangeType(object value, Type resultType);
    }
}