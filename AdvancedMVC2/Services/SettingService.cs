using System.Linq;
using AdvancedMVC2.DomainObjects;
using AdvancedMVC2.Factories;
using AdvancedMVC2.Infrastructure.Repositories;

namespace AdvancedMVC2.Services
{
    public sealed class SettingService : ISettingsService
    {
        private readonly ISettingFactory factory;
        private readonly IRepository<Setting> repository;


        public SettingService(IRepository<Setting> repository
                              , ISettingFactory factory
            )
        {
            this.factory = factory;
            this.repository = repository;
        }

        private Setting GetSettingForKey(string key)
        {
            return repository.Entities.Where(e => e.Name == key).SingleOrDefault();
        }

        public Setting Get(string key, object defaultValue)
        {
            Setting setting = GetSettingForKey(key);

            if (setting == null)
            {
                setting = CreateSetting(key, defaultValue);
            }
            return setting;
        }

        private Setting CreateSetting(string key, object defaultValue)
        {
            Setting setting = factory.Create(key);
            if (defaultValue != null)
            {
                setting.SetValue(defaultValue);
            }
            repository.Add(setting);
            return setting;
        }
    }
}