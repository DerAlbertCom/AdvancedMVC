using System.Web.Mvc;

namespace AdvancedMVC2.ModelBinder
{
    public static class ModelBindingContextExtensions
    {
        public static T GetValue<T>(this ModelBindingContext bindingContext, string valueName)
        {
            return (T) bindingContext.ValueProvider.GetValue(valueName).ConvertTo(typeof (T));
        }
        public static ValueProviderResult GetValueResult(this ModelBindingContext bindingContext, string valueName)
        {
            return bindingContext.ValueProvider.GetValue(valueName);
        }
    }
}