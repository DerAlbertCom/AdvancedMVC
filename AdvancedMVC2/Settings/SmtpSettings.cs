using AdvancedMVC2.Services;

namespace AdvancedMVC2.Settings
{
    public class SmtpSettings : ISmtpSettings
    {
        private readonly SettingsEdit settings;

        public SmtpSettings(ISettingsService settings)
        {
            this.settings = new SettingsEdit("smtp", settings);
        }

        public string SmtpService {
            get { return settings.Get(@"server", @"localhost"); }
        }

        public int SmtpPort {
            get { return settings.Get(@"port", 25); }
        }

        public string SmtpUsername {
            get { return settings.Get(@"username", @""); }
        }

        public string SmtpPassword {
            get { return settings.Get(@"password", @""); }
        }

        public string SmtpFrom {
            get { return settings.Get(@"from", @""); }
        }
    }
}