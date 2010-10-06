using AdvancedMVC2.Services;

namespace AdvancedMVC2.Settings
{
    public class HashingSettings : IHashingSettings
    {
        private readonly EditableSettings editableSettings;

        public HashingSettings(ISettingsService service)
        {
            editableSettings = new EditableSettings("hashing", service);
        }

        public string Salt {
            get { return editableSettings.Get(@"salt", @"gesalzen"); }
        }
    }
}