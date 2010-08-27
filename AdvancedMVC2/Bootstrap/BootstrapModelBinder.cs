using System.Collections.Generic;
using System.Web.Mvc;
using AdvancedMVC2.Infrastructure.Bootstrap;
using AdvancedMVC2.ModelBinder;

namespace AdvancedMVC2.Bootstrap
{
    public class BootstrapModelBinder : IBootstrapItem
    {
        private readonly IEnumerable<ITypedModelBinder> modelBinderInfos;

        public BootstrapModelBinder(IEnumerable<ITypedModelBinder> modelBinderInfos)
        {
            this.modelBinderInfos = modelBinderInfos;
        }

        public void Execute()
        {
            foreach (var modelBinder in modelBinderInfos)
            {
                ModelBinders.Binders.Add(modelBinder.BindingType(),modelBinder);
            }
        }
    }
}