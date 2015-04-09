using L2L.API.Shared.Enum.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Property.Settings
{
    public class TourHours
    {
        public int PropertyID { get; set; }
        public TourDayOfWeek DayOfTour { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public bool IsClosed { get; set; }
        public byte NumberOfAppts { get; set; }
    }
}
