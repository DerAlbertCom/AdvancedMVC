using AdvancedMVC2.Services;

namespace AdvancedMVC2.Settings
{
    public class HashingSettings : IHashingSettings
    {
        private readonly SettingsEdit settings;

        public HashingSettings(ISettingsService service)
        {
            settings = new SettingsEdit("hashing", service);
        }

        public string Salt {
            get { return settings.Get(@"salt", @"gesalzen"); }
        }
    }
}