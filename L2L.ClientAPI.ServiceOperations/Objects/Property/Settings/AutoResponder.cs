using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Property.Settings
{
    public class AutoResponder
    {
        public int AccountID { get; set; }
        public int PropertyID { get; set; }
        public byte AutoRespond { get; set; }
        public byte IncludeOriginalMessage { get; set; }
        public byte IncludeSpecials { get; set; }
        public string IntroParagraph { get; set; }
        public string Specials { get; set; }
        public string Footer { get; set; }
    }
}
