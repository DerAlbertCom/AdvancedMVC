using System;
using System.Drawing;
using System.Web.Mvc;

namespace AdvancedMVC2.ModelBinder
{
    public class SizeModelBinder : ITypedModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.GetValueResult(bindingContext.ModelName);
//            return Converter.Current.ConvertTo(value.AttemptedValue, typeof(Size), value.Culture);
            return null;
        }

        public Type BindingType()
        {
            return typeof (Size);
        }
    }
}