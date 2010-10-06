using System;
using System.Web.Mvc;
using AdvancedMVC2.Infrastructure.Bootstrap;
using AdvancedMVC2.Validation;

namespace AdvancedMVC2.Bootstrap
{
    public class  BootstrapValidators : IBootstrapItem
    {
        public void Execute()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(PropertyMustMatchAttribute),typeof(PropertyMustMatchValidator));
        }
    }
}