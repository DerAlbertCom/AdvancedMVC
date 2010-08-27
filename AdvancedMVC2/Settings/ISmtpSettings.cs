namespace AdvancedMVC2.Settings
{
    public interface ISmtpSettings
    {
        string SmtpService { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; }
        string SmtpPassword { get; }
        string SmtpFrom { get; }
    }
}