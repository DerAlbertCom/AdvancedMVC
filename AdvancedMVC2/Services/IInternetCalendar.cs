using System;

namespace AdvancedMVC2.Services
{
    public interface IInternetCalendar
    {
        byte[] GetIcsBytes(DateTime date, int duration, string name, string location, string shortDescription);
    }
}