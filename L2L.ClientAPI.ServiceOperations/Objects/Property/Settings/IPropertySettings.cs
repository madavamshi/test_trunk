using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2L.ClassLibrary.Objects.Property.Settings
{
    public interface IPropertySettings
    {
        int PropertyId { get; set; }
        VerbiageSettings PropVerbiageSetting { get; set; }
        AutoResponder AutoResponderEmailSetting { get; set; }
        List<int> LeaseTerms { get; set; }
        IList<GuestcardSettings> GuestCardSettings { get; set; }
        EmailPreferences EmailAccountPreferences { get; set; }
        double NonLeadCallerDurationSeconds { get; set; }
        bool ClickOnCallEnabled { get; set; }
        IList<EmailRecipient> EmailRecipients { get; set; }
        IEnumerable<PhoneCarrier> PhoneCarriers { get; set; }
        TextRecipient PropertyTextRecipient { get; set; }
        bool LeasedLeadsFollowUpVisible { get; set; }
        bool DeadLeadsFollowUpVisible { get; set; }
        IList<TourHours> TourHours { get; set; }
        IList<Tuple<int, string>> CustomFieldTypes { get; set; }
        PropertyPreference PropPreference { get; set; }
    }
}
