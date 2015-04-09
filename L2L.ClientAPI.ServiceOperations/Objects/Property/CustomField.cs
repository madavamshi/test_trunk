using L2L.API.Shared.Enum.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Property
{
    public class CustomField
    {
        public int CustomFieldID { get; set; }
        public string CustomFieldName { get; set; }
        public CustomFieldDataType DataType { get; set; }
        public int SortOrder { get; set; }
    }
}
