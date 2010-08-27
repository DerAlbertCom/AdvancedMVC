namespace AdvancedMVC2.Services
{
    public interface IHashing
    {
        string CreateHash(string text, string saltForHash);
    }
}