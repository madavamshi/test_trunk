using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Property
{
    public class EmailRecipient
    {
        public int PropertyID { get; set; }
        public int RecipientID { get; set; }
        public string RecipientName { get; set; }
        public string RecipientEmail { get; set; }
        public bool DefaultEmail { get; set; }
    }
}
