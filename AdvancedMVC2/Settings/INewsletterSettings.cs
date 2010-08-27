namespace AdvancedMVC2.Settings
{
    public interface INewsletterSettings
    {
        string TemplateDirectory { get; }
        string SiteName { get; }
        string NewsletterOwner { get; }
        string NewsletterOwnerUrl { get; }
        string NewsletterName { get; }
        string DefaultNewsletterName { get; }
        bool PasswordGeneration { get; }
        int WebSiteFilter { get; }
        string SiteUrl { get; }
    }
}