using AdvancedMVC2.DomainObjects;
using AdvancedMVC2.Services;

namespace AdvancedMVC2.Settings
{
    public class EditableSettings
    {
        private readonly string baseKey;
        private readonly ISettingsService service;

        public EditableSettings(string key, ISettingsService service)
        {
            baseKey = key;
            this.service = service;
        }

        private string CreateKey(string key)
        {
            return string.Format("{0}.{1}", baseKey, key);
        }

        public T Get<T>(string key, T defaultValue)
        {
            return GetSetting(key, defaultValue).GetValue(defaultValue);
        }

        private Setting GetSetting(string key, object defaultValue)
        {
            return service.Get(CreateKey(key),defaultValue);
        }

        public void Set<T>(string key, T value)
        {
            Setting setting = GetSetting(key, null);
            setting.SetValue(value);
        }
    }
}