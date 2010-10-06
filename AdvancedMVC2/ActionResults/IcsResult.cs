using System.Web;
using System.Web.Mvc;
using AdvancedMVC2.Models;
using AdvancedMVC2.Services;

namespace AdvancedMVC2.ActionResults
{
    public class IcsResult : FileResult
    {
        public IInternetCalendar Calendar { get; set; }

        private readonly Meeting meeting;

        public IcsResult(Meeting meeting) : base("text/calendar")
        {
            this.meeting = meeting;
            FileDownloadName = "EinTermin.ics";
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            response.BinaryWrite(CreateCalendarBytes());
        }

        private byte[] CreateCalendarBytes()
        {
            return Calendar.GetIcsBytes(meeting.Date, meeting.Duration, meeting.Name, meeting.Location,
                                        meeting.Description);
        }
    }
}