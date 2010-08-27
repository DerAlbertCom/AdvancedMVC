namespace AdvancedMVC2.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string text)
        {
            return text == null || string.IsNullOrEmpty(text.Trim());
        }
    }
}