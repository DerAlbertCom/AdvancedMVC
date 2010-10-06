using System;
using System.Drawing;
using System.Web.Mvc;
using AdvancedMVC2.Infrastructure.Converters;

namespace AdvancedMVC2.ModelBinder
{
    public class SizeModelBinder : ITypedModelBinder
    {
        private readonly SizeTypeConverter converter;

        public SizeModelBinder()
        {
            this.converter = new SizeTypeConverter();
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {            
            var value = bindingContext.GetValueResult(bindingContext.ModelName);
            return converter.ConvertTo(null, value.Culture, value.AttemptedValue, typeof (Size));
        }

        public Type BindingType()
        {
            return typeof (Size);
        }
    }
}