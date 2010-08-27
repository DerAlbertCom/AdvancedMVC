using System;
using System.Web.Mvc;

namespace AdvancedMVC2.ModelBinder
{
    public interface ITypedModelBinder : IModelBinder
    {
        Type BindingType();
    }
}