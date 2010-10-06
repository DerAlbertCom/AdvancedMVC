using System;
using System.Text;
using AdvancedMVC2.Infrastructure.Extensions;

namespace AdvancedMVC2.Services
{
    public class InternetCalendar : IInternetCalendar
    {
        private string GetICSString(DateTime date, int duration, string name, string location, string shortDescription)
        {
            var sb = new StringBuilder();
            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("VERSION:1.0");
            sb.AppendLine("BEGIN:VEVENT");
            sb.AppendFormat("DTSTART:{0}", GetFormattedTime(date));
            sb.AppendLine();
            sb.AppendFormat("DTEND:{0}", GetFormattedTime(date.AddMinutes(duration)));
            sb.AppendLine();
            sb.AppendFormat("SUMMARY:{0}", name);
            sb.AppendLine();
            sb.AppendFormat("LOCATION:{0}", location);
            sb.AppendLine();
            string description = shortDescription;
            if (description.IsEmpty())
            {
                description = name;
            }
            sb.AppendFormat("DESCRIPTION:{0}", description.Replace(Environment.NewLine, " "));
            sb.AppendLine();
            sb.AppendLine("END:VEVENT");
            sb.AppendLine("END:VCALENDAR");
            return sb.ToString();
        }

        public byte[] GetIcsBytes(DateTime date, int duration, string name, string location, string shortDescription)
        {
            return Encoding.UTF8.GetBytes(GetICSString(date, duration, name, location, shortDescription));
        }

        private static string GetFormattedTime(DateTime date)
        {
            return date.ToUniversalTime().ToString("yyyyMMdd\\THHmm00\\Z");
        }
    }
}