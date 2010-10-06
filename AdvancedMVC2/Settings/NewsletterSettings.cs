using AdvancedMVC2.Services;

namespace AdvancedMVC2.Settings
{
    public class NewsletterSettings : INewsletterSettings
    {
        private readonly EditableSettings editableSettings;

        public NewsletterSettings(ISettingsService service) {
            editableSettings = new EditableSettings("newsletter",service);
        }

        public string TemplateDirectory {
            get { return editableSettings.Get(@"templates", @"~/Templates/Mail"); }
        }

        public string SiteName {
            get { return editableSettings.Get(@"siteName", @"Newsletter-System"); }
        }

        public string NewsletterOwner {
            get { return editableSettings.Get(@"owner", @""); }
        }

        public string NewsletterOwnerUrl {
            get { return editableSettings.Get(@"ownerUrl", @""); }
        }

        public string NewsletterName {
            get { return editableSettings.Get(@"name", @""); }
        }

        public string DefaultNewsletterName {
            get { return editableSettings.Get(@"default", @""); }
        }

        public bool PasswordGeneration {
            get { return editableSettings.Get(@"passwordGeneration", false); }
        }

        public int WebSiteFilter {
            get { return editableSettings.Get(@"webSite", 0); }
        }

        public string SiteUrl {
            get { return editableSettings.Get(@"siteUrl", @""); }
        }
    }
}