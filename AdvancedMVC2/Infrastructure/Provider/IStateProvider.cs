namespace AdvancedMVC2.Infrastructure.Provider
{
    public interface IStateProvider
    {
        T Get<T>(string key);
        T Get<T>(string key, T defaultValue);
        void Set<T>(string key, T value);
    }
}