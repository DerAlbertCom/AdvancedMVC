using System.Web.Mvc;

namespace AdvancedMVC2.Validation
{
    public class PropertyMustMatchClientValidationRule : ModelClientValidationRule
    {
        public PropertyMustMatchClientValidationRule(string errorMessage, string originalId)
        {
            ErrorMessage = errorMessage;
 
            ValidationType = "propertyMustMatch";
            ValidationParameters.Add("originalId", originalId);
        }
    }
}