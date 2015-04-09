using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using L2L.API.Shared.Enum.HostedGuestcard;

namespace L2L.ClassLibrary.Objects.Property.Settings
{
    

    
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }  

    }
    public class Template 
    {
        public EnclosingTemplateType Type { get; set; }
        public int TemplateId { get; set; }
        public string HTMLTemplate { get; set; }
    }


    public class GuestcardSettings
    {
        public int GuestcardId { get; set; }
        public string ComplexName { get; set; }
        public int PropertyId { get; set; }
        public Address Address { get; set; }        

        public ContactFormType ContactFormType { get; set; }
        public string SourceName { get; set; }
        public int SourceId { get; set; }

        public Template HostedGuestcardTemplate { get; set; }
        public Template AutoResponseTemplate { get; set; }//not used for now
        public bool IncludeAutoResponse { get; set; }


    }

    public class GoogleTracking
    {
        public bool DisplayOnThankYouOnly { get; set; }
        public string Script { get; set; }
    }
}
