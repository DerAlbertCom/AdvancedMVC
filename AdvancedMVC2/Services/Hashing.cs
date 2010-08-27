using System;
using System.Security.Cryptography;
using System.Text;
using AdvancedMVC2.Settings;

namespace AdvancedMVC2.Services
{
    public class Hashing : IHashing
    {
        private readonly IHashingSettings settings;

        public Hashing(IHashingSettings settings)
        {
            this.settings = settings;
        }

        public string CreateHash(string text, string saltForHash)
        {
            var sha1Provider = new SHA1CryptoServiceProvider();

            byte[] data = Encoding.Default.GetBytes(text + settings.Salt + saltForHash);

            return ConvertToString(sha1Provider.ComputeHash(data));
        }

        private static string ConvertToString(byte[] hash)
        {
            var result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                string temp = Convert.ToString(hash[i], 16).ToUpperInvariant();
                if (temp.Length == 1)
                {
                    temp = @"0" + temp;
                }
                result.Append(temp);
            }
            return result.ToString();
        }
    }
}