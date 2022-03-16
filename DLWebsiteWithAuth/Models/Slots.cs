using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWebsiteWithAuth
{
    public class Slots
    {
        public DateTime Slot { get; set; }
        public bool Active { get; set; }
        public int DayNumber { get; set; }
        public int HourNumber { get; set; }
        public int MinuteNumber { get; set; }
        public int id { get; set; }
        public string department { get; set; }
    }
}