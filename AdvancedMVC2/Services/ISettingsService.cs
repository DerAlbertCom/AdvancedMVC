using AdvancedMVC2.DomainObjects;

namespace AdvancedMVC2.Services
{
    public interface ISettingsService
    {
        Setting Get(string key, object defaultValue);
    }
}