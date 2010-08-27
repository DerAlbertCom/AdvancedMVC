using AdvancedMVC2.DomainObjects;
using Microsoft.Practices.ServiceLocation;

namespace AdvancedMVC2.ModelBinder
{
    public class WebUserModelBinder : EntityModelBinder<WebUser>
    {
        public WebUserModelBinder(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }
    }
}