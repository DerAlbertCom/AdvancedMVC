using System;
using System.Collections.Generic;
using AdvancedMVC2.DomainObjects;
using AdvancedMVC2.Security;

namespace AdvancedMVC2.Factories
{
    public class WebUserFactory : FactoryBase<WebUser>, IWebUserFactory
    {
        private readonly List<string> blockUsernames = new List<string>();

        public WebUserFactory()
        {
            blockUsernames.Add(Roles.Anonym.ToLowerInvariant());
        }

        public WebUser Create(string userName, string eMail)
        {
            if (UsernameNotAllowed(userName))
            {
                throw new ArgumentException("userName",string.Format("Username {0} not allowed",userName));
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("userName");
            }

            if (string.IsNullOrWhiteSpace(eMail))
            {
                throw new ArgumentNullException("eMail");
            }

            userName = userName.Trim();
            eMail = eMail.Trim();

            var webUser = CreateEntity();
            webUser.SetUsername(userName);
            webUser.SetEMailAddress(eMail);
            webUser.EnsureConfirmationKey();
            return webUser;
        }

        private bool UsernameNotAllowed(string userName)
        {
            return blockUsernames.Contains(userName.ToLowerInvariant());
        }

        public WebUser CreateAnonymousUser()
        {
            var webUser = CreateEntity();
            webUser.SetUsername(Roles.Anonym);
            webUser.SetEMailAddress("anon@email");
            webUser.EnsureConfirmationKey();
            webUser.MakeAnonUser();
            return webUser;
        }
    }
}