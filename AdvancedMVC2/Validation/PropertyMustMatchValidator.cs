using System;
using System.Linq;
using System.Web.Mvc;

namespace AdvancedMVC2.Validation
{
    public class PropertyMustMatchValidator : DataAnnotationsModelValidator<PropertyMustMatchAttribute>
    {
        public PropertyMustMatchValidator(ModelMetadata metadata, ControllerContext context, PropertyMustMatchAttribute attribute) : base(metadata, context, attribute)
        {
        }

        public override System.Collections.Generic.IEnumerable<ModelValidationResult> Validate(object instance)
        {
            if (!object.Equals(Metadata.Model, GetValueFromProperty(instance, Attribute.OriginalProperty)))
            {
                yield return new ModelValidationResult { Message = GetErrorMessage()};
            }
        }

        private string GetErrorMessage()
        {
            string originalDisplayName = GetOriginalDisplayName();
            return string.Format(Attribute.ErrorMessage, originalDisplayName, Metadata.GetDisplayName());
        }

        private string GetOriginalDisplayName()
        {
            var containerMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => null, Metadata.ContainerType);
            return containerMetadata.Properties
                .Where(s => s.PropertyName == Attribute.OriginalProperty)
                .Single().GetDisplayName();
        }

        private object GetValueFromProperty(object instance, string propertyName)
        {
            return instance.GetType().GetProperty(propertyName).GetValue(instance, null);
        }

        public override System.Collections.Generic.IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            string originalId = GetFullHtmlFieldId(Attribute.OriginalProperty);
            yield return new PropertyMustMatchClientValidationRule(GetErrorMessage(), originalId);
        }

        private string GetFullHtmlFieldId(string partialFieldName)
        {
            var viewContext = (ViewContext)ControllerContext;
            return viewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(partialFieldName);
        }
    }
}