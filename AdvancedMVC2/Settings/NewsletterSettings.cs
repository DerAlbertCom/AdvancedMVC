using AdvancedMVC2.Services;

namespace AdvancedMVC2.Settings
{
    public class NewsletterSettings : INewsletterSettings
    {
        private readonly SettingsEdit settings;

        public NewsletterSettings(ISettingsService service) {
            settings = new SettingsEdit("newsletter",service);
        }

        public string TemplateDirectory {
            get { return settings.Get(@"templates", @"~/Templates/Mail"); }
        }

        public string SiteName {
            get { return settings.Get(@"siteName", @"Newsletter-System"); }
        }

        public string NewsletterOwner {
            get { return settings.Get(@"owner", @""); }
        }

        public string NewsletterOwnerUrl {
            get { return settings.Get(@"ownerUrl", @""); }
        }

        public string NewsletterName {
            get { return settings.Get(@"name", @""); }
        }

        public string DefaultNewsletterName {
            get { return settings.Get(@"default", @""); }
        }

        public bool PasswordGeneration {
            get { return settings.Get(@"passwordGeneration", false); }
        }

        public int WebSiteFilter {
            get { return settings.Get(@"webSite", 0); }
        }

        public string SiteUrl {
            get { return settings.Get(@"siteUrl", @""); }
        }
    }
}