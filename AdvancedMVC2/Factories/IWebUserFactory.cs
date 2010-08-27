using AdvancedMVC2.DomainObjects;

namespace AdvancedMVC2.Factories
{
    public interface IWebUserFactory
    {
        WebUser Create(string userName, string eMail);
        WebUser CreateAnonymousUser();
    }
}