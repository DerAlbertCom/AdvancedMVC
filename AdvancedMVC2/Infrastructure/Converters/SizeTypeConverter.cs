using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace AdvancedMVC2.Infrastructure.Converters
{
    public class SizeTypeConverter : TypeConverter
    {
        private readonly List<Type> convertableTypes = new List<Type>();

        public SizeTypeConverter()
        {
            convertableTypes.Add(typeof (string));
            convertableTypes.Add(typeof (Size));
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
        {
            return convertableTypes.Contains(sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return convertableTypes.Contains(destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
                                         Type destinationType)
        {
            if (value.GetType() == destinationType)
            {
                return value;
            }
            if (destinationType == typeof (string))
            {
                return SizeToString((Size) value, culture);
            }
            return StringToSize((string) value, culture);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture,
                                           object value)
        {
            if (value is Size)
            {
                return SizeToString((Size) value, culture);
            }
            return StringToSize((string) value, culture);
        }

        private object StringToSize(string value, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new Size(0, 0);
            }
            value = RemoveSpaces(value);
            var values = value.Split('x');
            int width = Convert.ToInt32(values[0]);
            int height = Convert.ToInt32(values[1]);
            return new Size(width, height);
        }

        private string RemoveSpaces(string value)
        {
            return value.Replace(" ", "").Trim();
        }

        private object SizeToString(Size value, CultureInfo culture)
        {
            return string.Format(culture, "{0}{2}{1}", value.Width, value.Height, "x");
        }
    }
}