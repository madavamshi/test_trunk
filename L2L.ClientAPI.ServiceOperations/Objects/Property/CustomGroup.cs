using L2L.ClassLibrary.Objects.Prospect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Property
{
    public class CustomGroup
    {
        public int CustomGroupID { get; set; }
        public string CustomGroupName { get; set; }
        public int PropertyID { get; set; }
        public int GroupOrder { get; set; }
        public int GroupPositionId { get; set; }
        public IList<LeadCustomField> CustomFields {get; set;}
    }
}
