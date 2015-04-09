using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Property
{
    public class CustomArea
    {
        public int AreaId { get; set; } //GroupPositionId
        public string AreaName { get; set; }
        public IList<CustomGroup> CustomGroups { get; set; }
    }
}
