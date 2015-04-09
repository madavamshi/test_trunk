using L2L.ClassLibrary.Objects.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Prospect
{
    public class LeadCustomField : CustomField
    {
        public int LeadCustomDataId { get; set; }
        public int LeadId { get; set; }
        public string Value { get; set; }
    }
}
