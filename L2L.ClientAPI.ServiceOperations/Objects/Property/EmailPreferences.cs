using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Property
{
    public class EmailPreferences
    {
        public EmailPreferences()
        {
        }

        public int PropertyId { get; set; }

        public int AccountID { get; set; }

        public string Email { get; set; }

        public bool PerLeadReport { get; set; }

        public bool PerLeadText { get; set; }

        public bool AutoResponse { get; set; }

        public bool AutoResponseAppointments { get; set; }

        public string DefaultEmailSubject { get; set; }

        public string AutoResponseEmailSubject { get; set; }

        public string EmailTrackingPrefix { get; set; }

        public string EmailTrackingDomain { get; set; }

        public bool EmailTracking { get; set; }

        public EmailFormat EmailFormat { get; set; }

        public byte IncludeOriginalMessage { get; set; }

        public byte IncludeSpecials { get; set; }

        public string IntroParagraph { get; set; }

        public string Specials { get; set; }

        public string Footer { get; set; }

        public byte AutoRespond { get; set; }

        /*

     //   public List<L2L.ClassLibrary.Objects.MISC.TextMessagingDetail> TextMessagingDetails = new List<L2L.ClassLibrary.Objects.MISC.TextMessagingDetail>();
     //   public System.Collections.Generic.List<ReportRecipient> ReportRecipients = new System.Collections.Generic.List<ReportRecipient>();
        public EmailPreferences(int propertyId)
        {
            Fill(propertyId);
        }
        public void Fill(int aPropertyId)
        {
            EmailPreferences nMe = EmailPreferences.Load(aPropertyId);
            this.PropertyId = nMe.PropertyId;
            this.Email = nMe.Email;
            this.PerLeadReport = nMe.PerLeadReport;
            this.PerLeadText = nMe.PerLeadText;

       //     this.TextMessagingDetails = nMe.TextMessagingDetails;
        //    this.ReportRecipients = nMe.ReportRecipients;
        }

        public static EmailPreferences Load(int aPropertyId)
        {
            return L2L.ClassLibrary.Data.Property.Selects.EmailPreferences(aPropertyId);
        }
        */
    }

    public class ReportRecipient
    {
        public int PropertyId { get; set; }

        public int RecipientId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string DisplayTitle { get; set; }

        public static System.Collections.Generic.List<ReportRecipient> RetrieveFromDB(int aPropertyId)
        {
            //return L2L.ClassLibrary.Data.Property.Selects.ReportRecipients(aPropertyId);
            return new List<ReportRecipient>();
        }
    }
}