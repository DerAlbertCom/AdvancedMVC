using System;

namespace AdvancedMVC2.Models
{
    public class Meeting
    {
        public Meeting()
        {
            
        }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}