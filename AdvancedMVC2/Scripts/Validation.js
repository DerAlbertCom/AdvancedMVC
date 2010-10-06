
Sys.Mvc.ValidatorRegistry.validators.propertyMustMatch = function (rule) {
    var originalId = rule.ValidationParameters.originalId;
    var message = rule.ErrorMessage;

    return function (value, context) {

        var thisField = context.fieldContext.elements[0];
        var otherField = $get(originalId, thisField.form);

        if (otherField.value != value) {
            return false;
        }

        return true;

    };
}; 