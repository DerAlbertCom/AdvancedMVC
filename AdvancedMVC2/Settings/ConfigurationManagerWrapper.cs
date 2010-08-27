using System.Configuration;

namespace AdvancedMVC2.Settings
{
    public class ConfigurationManagerWrapper : IConfigurationManager
    {
        public ConnectionStringSettingsCollection ConnectionStrings {
            get { return ConfigurationManager.ConnectionStrings; }
        }
    }
}