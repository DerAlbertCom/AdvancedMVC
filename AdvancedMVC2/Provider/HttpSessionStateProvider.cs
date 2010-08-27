using System.Web;
using System.Web.SessionState;
using AdvancedMVC2.Infrastructure.Provider;

namespace AdvancedMVC2.Provider
{
    public class HttpSessionStateProvider : IStateProvider
    {
        private static HttpSessionState CurrentSession
        {
            get { return HttpContext.Current.Session; }
        }

        public T Get<T>(string key)
        {
            return Get(key, default(T));
        }

        public T Get<T>(string key, T defaultValue)
        {
            if (CurrentSession == null)
                return defaultValue;
            var value = CurrentSession[key];
            return (T) (value ?? defaultValue);
        }

        public void Set<T>(string key, T value)
        {
            if (CurrentSession!=null)
                CurrentSession[key] = value;
        }
    }
}