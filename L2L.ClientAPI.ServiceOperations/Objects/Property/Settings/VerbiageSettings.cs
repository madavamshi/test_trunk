using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Property.Settings
{
    public class VerbiageSettings
    {
        public IList<VerbiageCategory> Categories { get; set; }
        public IList<VerbiageTopic> Topics { get; set; }
        public IList<VerbiageKeyWord> KeyWords { get; set; }
    }
}
