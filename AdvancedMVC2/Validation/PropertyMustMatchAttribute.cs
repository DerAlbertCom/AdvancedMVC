using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace AdvancedMVC2.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class PropertyMustMatchAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "'{0}' and '{1}' do not match.";

        private readonly string originalProperty;


        public string OriginalProperty
        {
            get { return originalProperty; }
        }

        public PropertyMustMatchAttribute(string originalProperty)
            : base(DefaultErrorMessage)
        {
            this.originalProperty = originalProperty;
        }

        public override bool IsValid(object instance)
        {
            throw new NotImplementedException("you must register PropertyMustMatchValidator");
        }
    }
}