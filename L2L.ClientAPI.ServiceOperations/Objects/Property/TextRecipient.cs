using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Property
{
    public class TextRecipient
    {
        public int TextMessageID { get; set; }
        public string Phone { get; set; }
        public string Provider { get; set; }
        public string  TextProvider {get; set;}
        public string CarrierName {get; set;}
        public byte CarrierID { get; set; }
    }
}
