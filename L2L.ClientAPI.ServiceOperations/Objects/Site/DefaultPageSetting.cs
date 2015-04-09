using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Site
{
     public class DefaultPageSetting
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string RouteParameter { get; set; }
    }
}
