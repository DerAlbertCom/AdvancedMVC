using System;
using System.Globalization;
using AdvancedMVC2.Security;
using AdvancedMVC2.Services;

namespace AdvancedMVC2.DomainObjects
{
    public class WebUser : DomainObject
    {
        private WebUser()
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            PasswordHash = string.Empty;
            Role = Roles.User;
            Confirmed = false;
            Active = false;
        }
        public string Username { get; private set; }

        public string EMail { get; private set; }

        public string PasswordHash { get; private set; }
        public bool Confirmed { get; private set; }
        public bool Active { get; private set; }

        public int BounceCount { get; private set; }
        public DateTime? LastLogin { get; private set; }
        public Guid? ConfirmationKey { get; private set; }
        public string Role { get; private set; }

        public bool IsAnonymousUser
        {
            get { return Role == Roles.Anonym; }
        }

        public void SetEMailAddress(string emailAddress)
        {
            emailAddress = emailAddress.ToLower();
            if (string.CompareOrdinal(EMail, emailAddress) != 0)
            {
                EMail = emailAddress;
                Modified();
            }
        }

        public void SetPassword(string password, IHashing hashing)
        {
            PasswordHash = HashPasswordWithUserSalt(password, hashing);
            Modified();
        }

        public bool ChangePassword(string oldPassword, string newPassword, IHashing textHashing)
        {
            if (PasswordIsValid(oldPassword, textHashing))
            {
                SetPassword(newPassword, textHashing);
                return true;
            }
            return false;
        }

        public bool PasswordIsValid(string password, IHashing hashing)
        {
            return string.Compare(HashPasswordWithUserSalt(password, hashing), PasswordHash) == 0;
        }

        private string HashPasswordWithUserSalt(string password, IHashing hashing)
        {
            return hashing.CreateHash(password, GetUserSalt());
        }

        private string GetUserSalt()
        {
            return (Created.Second*Created.DayOfYear).ToString();
        }

        public void MailHasBounced()
        {
            BounceCount++;
            Modified();
        }

        public bool UserHashIsValid(string userHash, IHashing hashing)
        {
            return userHash == GetWebUserHash(hashing);
        }

        public string GetWebUserHash(IHashing hashing)
        {
            string identity = string.Format(CultureInfo.InvariantCulture, @"{0}{1}", Id, Username);
            return HashPasswordWithUserSalt(identity, hashing).Substring(0, 8);
        }

        public void Activate()
        {
            Active = true;
            ClearConfirmationKey();
            Modified();
        }

        public void ConfirmUser()
        {
            Confirmed = true;
            Activate();
        }

        public void Deactivate()
        {
            Active = false;
            ClearConfirmationKey();
            Modified();
        }

        public void ClearConfirmationKey()
        {
            ConfirmationKey = null;
            Modified();
        }

        public void EnsureConfirmationKey()
        {
            if (ConfirmationKey.HasValue)
            {
                return;
            }
            ConfirmationKey = Guid.NewGuid();
        }

        public void PromoteToAdministrator()
        {
            Role = Roles.Administrator;
            Modified();
        }

        public void LoggedIn()
        {
            LastLogin = DateTime.UtcNow;
            Modified();
        }

        public bool ConfirmationKeyIsValid(Guid confirmationKey)
        {
            bool isValid = false;
            if (ConfirmationKey.HasValue)
            {
                isValid = ConfirmationKey.Value == confirmationKey;
            }
            return isValid;
        }

        public void SetUsername(string userName)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                Username = userName;
                return;
            }
            throw new InvalidOperationException("Username is already set");
        }

        public void MakeAnonUser()
        {
            Role = Roles.Anonym;
        }
    }
}