using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.API.Shared.Interfaces.Property
{
    public interface IOfficeSetting : IDataPart
    {
        //int PropertyId { get; set; }
        int DayOFWeek { get; set; }
        string OpenTime { get; set; }
        string CloseTime { get; set; }
    }
}
