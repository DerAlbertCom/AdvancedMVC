using System;
using System.Linq;
using System.Web.Mvc;
using AdvancedMVC2.DomainObjects;
using AdvancedMVC2.Infrastructure.Repositories;
using Microsoft.Practices.ServiceLocation;

namespace AdvancedMVC2.ModelBinder
{
    public abstract class EntityModelBinder<T> : ITypedModelBinder where T : DomainObject
    {
        private readonly IServiceLocator serviceLocator;

        protected EntityModelBinder(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public virtual object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var repository = CreateRepository();
            var id = bindingContext.GetValue<int>("id");

            return repository.Entities.Where(e => e.Id==id).SingleOrDefault();
        }

        protected virtual IRepository<T> CreateRepository()
        {
            return serviceLocator.GetInstance<IRepository<T>>();
        }

        public virtual Type BindingType()
        {
            return typeof (T);
        }
    }

}