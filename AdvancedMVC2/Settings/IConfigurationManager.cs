using System.Configuration;

namespace AdvancedMVC2.Settings
{
    public interface IConfigurationManager
    {
        ConnectionStringSettingsCollection ConnectionStrings { get; }
    }
}