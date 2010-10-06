using System;
using System.Globalization;
using AdvancedMVC2.Infrastructure.Converters;

namespace AdvancedMVC2.DomainObjects
{
    public class Setting : DomainObject
    {
        private Setting()
        {
        }

        public string Name { get; private set; }
        public string Value { get; private set; }

        public void SetValue(object value)
        {
            Value = GetConvertedString(value);
            Modified();
        }

        private string GetConvertedString(object value)
        {
            return (string) Converter.Current.ChangeType(value,typeof(string), CultureInfo.InvariantCulture);
        }

        public T GetValue<T>(T defaultValue = default(T))
        {
            T converted;
            if (string.IsNullOrWhiteSpace(Value))
            {
                converted = defaultValue;
            }
            else
            {
                converted = GetConverted<T>();
            }
            return converted;
        }

        private T GetConverted<T>()
        {
            return (T) Converter.Current.ChangeType(Value,typeof(T),CultureInfo.InvariantCulture);
        }

        public void SetName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (!string.IsNullOrWhiteSpace(Name))
            {
                throw new InvalidOperationException("the Name of the Setting is already set");
            }
            Name = name;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}