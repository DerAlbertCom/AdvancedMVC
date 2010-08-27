using AdvancedMVC2.DomainObjects;

namespace AdvancedMVC2.Factories
{
    public class SettingFactory : FactoryBase<Setting>, ISettingFactory
    {
        public Setting Create(string name)
        {
            var setting = CreateEntity();
            setting.SetName(name);
            return setting;
        }
    }
}