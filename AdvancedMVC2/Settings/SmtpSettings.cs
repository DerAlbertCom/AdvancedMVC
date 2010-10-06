using AdvancedMVC2.Services;

namespace AdvancedMVC2.Settings
{
    public class SmtpSettings : ISmtpSettings
    {
        private readonly EditableSettings editableSettings;

        public SmtpSettings(ISettingsService settings)
        {
            this.editableSettings = new EditableSettings("smtp", settings);
        }

        public string SmtpService {
            get { return editableSettings.Get(@"server", @"localhost"); }
        }

        public int SmtpPort {
            get { return editableSettings.Get(@"port", 25); }
        }

        public string SmtpUsername {
            get { return editableSettings.Get(@"username", @""); }
        }

        public string SmtpPassword {
            get { return editableSettings.Get(@"password", @""); }
        }

        public string SmtpFrom {
            get { return editableSettings.Get(@"from", @""); }
        }
    }
}