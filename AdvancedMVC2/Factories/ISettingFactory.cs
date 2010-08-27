using AdvancedMVC2.DomainObjects;

namespace AdvancedMVC2.Factories
{
    public interface ISettingFactory
    {
        Setting Create(string name);
    }
}