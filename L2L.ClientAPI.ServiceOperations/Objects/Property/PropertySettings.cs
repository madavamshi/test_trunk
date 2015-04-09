using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using L2L.ClassLibrary.Objects.Common;
using System.Data;
using L2L.ClassLibrary.Objects.Property.Settings;
using L2L.API.Shared.Enum.Property;

namespace L2L.ClassLibrary.Objects.Property
{
    public sealed class PropertySettings : IPropertySettings
    {
        public PropertySettings(int propertyId)
        {
            Fill(propertyId);
        }


        public PropertySettings()
        {
            LeaseTerms = new List<int>();
        }

        public int LeadUpdateTypeId
        { get; set; }

        public BaseProductTypes1 BaseProductType
        { get; set; }

        public SubscriptionTypes1 SubscriptionType
        { get; set; }

        public int PropertyId
        { get; set; }

        public string PropertyName
        { get; set; }

        public int AccountID
        { get; set; }

        public string AccountName
        { get; set; }

        public bool EnableProperty
        { get; set; }

        public int QuotesAndAvailabilityProviderId
        { get; set; }

        public string ExternalAvailabilityURL
        { get; set; }

        public DateTime NonLeadCallerDuration
        { get; set; }

        public List<int> LeaseTerms
        { get; set; }

        public string QuotesHeader
        { get; set; }

        public string QuotesFooter
        { get; set; }

        public bool ShowDaysOnMarketInQuotes
        { get; set; }

        public bool ShowBestPrice
        { get; set; }

        public L2L.ClassLibrary.Objects.Common.LeadOwnershipModelType1 LeadOwnershipModel
        { get; set; }

        public VerbiageSettings PropVerbiageSetting { get; set; }
        public AutoResponder AutoResponderEmailSetting { get; set; }
        public IList<GuestcardSettings> GuestCardSettings { get; set; }
        public EmailPreferences EmailAccountPreferences { get; set; }
        public IList<EmailRecipient> EmailRecipients { get; set; }
        public IEnumerable<PhoneCarrier> PhoneCarriers { get; set; }
        public TextRecipient PropertyTextRecipient { get; set; }
        public IList<TourHours> TourHours { get; set; }
        public IList<Tuple<int, string>> CustomFieldTypes { get; set; }

        public PropertyPreference PropPreference { get; set; }


        public double NonLeadCallerDurationSeconds
        {
            get
            {
                DateTime dflt = new DateTime(1900, 1, 1);
                double secondCount = 0;
                if (!(dflt.AddHours(1) < NonLeadCallerDuration || dflt.AddHours(-1) > NonLeadCallerDuration))
                {
                    secondCount = (NonLeadCallerDuration - dflt).TotalSeconds;
                }
                return secondCount;
            }
            set
            {
                DateTime dflt = new DateTime(1900, 1, 1);
                NonLeadCallerDuration = dflt.AddSeconds(value);
            }
        }

        public int RequiredFieldsId
        { get; set; }

        public bool ClickOnCallEnabled
        { get; set; }

        public bool MultiPropertySearchEnabled
        { get; set; }

        public bool IncludeLeasingContest
        { get; set; }

        public bool LeasedLeadsFollowUpVisible
        { get; set; }

        public bool ClearOneSiteTasks
        { get; set; }

        public int PetDisplayOptions
        { get; set; }

        public int RentDisplayOptions
        { get; set; }

        public bool IsHIPAA
        { get; set; }

        public bool DeadLeadsFollowUpVisible
        { get; set; }

        public bool AppliedLeadsFollowUpVisible
        { get; set; }

        public bool HideLeadsWithFollowUp
        { get; set; }

        public int ApplicationVendorID
        { get; set; }

        public string ApplicationVendorName
        { get; set; }

        public L2L.ClassLibrary.Objects.Common.CostPerModes1 CostPerMode
        { get; set; }

        public bool BrochuresEnabled
        { get; set; }

        public bool PortalAccountEnabled
        { get; set; }

        public bool AppendBrochuresToARTemplate
        { get; set; }

        public bool FitBrochureToSinglePagePDF
        { get; set; }

        public string GetLeaseTermsString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int ix in LeaseTerms)
            {
                sb.AppendFormat("{0},", ix);
            }

            return sb.ToString().TrimEnd(',');
        }

        public bool QuotesEnabled()
        {
            return QuotesAndAvailabilityProviderId > 0;
        }

        public bool NonLeadCallerFilterEnabled
        {
            get
            {
                return NonLeadCallerDuration.Second > 0;
            }
        }

        private EmailPreferences _EmailPreferences;

        /// <summary>
        /// populated at access time .. if not accessed then not populated!
        /// </summary>
        public EmailPreferences EmailPreferences
        {
            get
            {
                return _EmailPreferences;
            }
            set { _EmailPreferences = value; }
        }

        private string _CreationEmailSubject;
        public string CreationEmailSubject
        {
            get
            {

                return (string.IsNullOrEmpty(_CreationEmailSubject))?"Your application status ":_CreationEmailSubject;
            }
            set
            {
                _CreationEmailSubject = value;
            }
        }

        private string _CreationEmailContent;
        public string CreationEmailContent
        {
            get
            {
                return (string.IsNullOrEmpty(_CreationEmailContent)) ?
@"Thank you for considering us! 
I have created an online account for you to view your quote, apply for an apartment and even lease your apartment online at any time using the user name and password provided below. Once you sign on, you must change your password for security reasons.  

To get started click the link below."

//Sincerely, 
//Leasing Staff" 
        : _CreationEmailContent;
            }
            set
            {
                _CreationEmailContent = value;
            }
        }
        private string _ResetEmailSubject;
        public string ResetEmailSubject { 
            get
            {
                return (string.IsNullOrEmpty(_ResetEmailSubject)) ? @"Your password is reset " : _ResetEmailSubject;
            }
            set
            {
                _ResetEmailSubject = value;
            }
        }
        private string _ResetEmailContent;
        public string ResetEmailContent
        {
            get
            {
                return (string.IsNullOrEmpty(_ResetEmailContent)) ?
@"
Your password has been reset! Once you sign on you must change your password for security reasons.

Use your user name and password below to resume your online experience."
//
//Sincerely,
//Leasing Staff" 
            : _ResetEmailContent;

            }
            set
            {
                _ResetEmailContent = value;
            }
        }
        private Common.LeadTrackingType1 _LeadTrackingType;
        public Common.LeadTrackingType1 LeadTrackingType
        {
            get { return _LeadTrackingType; }
            set { _LeadTrackingType = value; }
        }
        //public bool EmailAvailabilityEnabled { get; set; }


        public void Fill(int propertyId)
        {
            PropertySettings nMe = PropertySettings.Load(propertyId);
            this.LeaseTerms = new List<int>();
            this.PropertyId = nMe.PropertyId;
            this.PropertyName = nMe.PropertyName;
            this.AccountID = nMe.AccountID;
            this.EnableProperty = nMe.EnableProperty;
            this.NonLeadCallerDuration = nMe.NonLeadCallerDuration;
            this.RequiredFieldsId = nMe.RequiredFieldsId;
            this.ClickOnCallEnabled = nMe.ClickOnCallEnabled;
            this.MultiPropertySearchEnabled = nMe.MultiPropertySearchEnabled;
            this.IncludeLeasingContest = nMe.IncludeLeasingContest;
            this.EmailPreferences = nMe.EmailPreferences;
            this.AccountName = nMe.AccountName;
            this.LeasedLeadsFollowUpVisible = nMe.LeasedLeadsFollowUpVisible;
            this.DeadLeadsFollowUpVisible = nMe.DeadLeadsFollowUpVisible;
            this.AppliedLeadsFollowUpVisible = nMe.AppliedLeadsFollowUpVisible;
            this.HideLeadsWithFollowUp = nMe.HideLeadsWithFollowUp;
            this.LeaseTerms = nMe.LeaseTerms;
            this.QuotesAndAvailabilityProviderId = nMe.QuotesAndAvailabilityProviderId;
            this.ApplicationVendorID = nMe.ApplicationVendorID;
            this.ApplicationVendorName = nMe.ApplicationVendorName;
            this.QuotesHeader = nMe.QuotesHeader;
            this.QuotesFooter = nMe.QuotesFooter;
            this.ExternalAvailabilityURL = nMe.ExternalAvailabilityURL;
            this.LeadOwnershipModel = nMe.LeadOwnershipModel;
            this.CostPerMode = nMe.CostPerMode;
            this.BaseProductType = nMe.BaseProductType;
            this.SubscriptionType = nMe.SubscriptionType;
            this.ShowDaysOnMarketInQuotes = nMe.ShowDaysOnMarketInQuotes;
            this.ShowBestPrice = nMe.ShowBestPrice;
            this.BrochuresEnabled = nMe.BrochuresEnabled;
            this.PortalAccountEnabled = nMe.PortalAccountEnabled;
            this.AppendBrochuresToARTemplate = nMe.AppendBrochuresToARTemplate;
            this.FitBrochureToSinglePagePDF = nMe.FitBrochureToSinglePagePDF;
            this.PetDisplayOptions = nMe.PetDisplayOptions;
            this.RentDisplayOptions = nMe.RentDisplayOptions;
            this.CreationEmailSubject = nMe.CreationEmailSubject;
            this.CreationEmailContent = nMe.CreationEmailContent;
            this.ResetEmailSubject = nMe.ResetEmailSubject;
            this.ResetEmailContent = nMe.ResetEmailContent;
            this.LeadTrackingType = nMe.LeadTrackingType;
            this.LeadUpdateTypeId = nMe.LeadUpdateTypeId;
            //this.EmailAvailabilityEnabled = nMe.EmailAvailabilityEnabled;
            this.MarketSegment = nMe.MarketSegment;
            this.IsHIPAA = nMe.IsHIPAA;
        }

        public static PropertySettings Load(int propertyId)
        {
            //return L2L.ClassLibrary.Data.Property.Selects.PropertySettings(propertyId);
            return new PropertySettings();
        }

        #region Guestcard Field LookupTypes
        List<PropertyLookupTypeSetting> _AvailableLookupTypes;
        public List<PropertyLookupTypeSetting> AvailableLookupTypes
        {
            get
            {
                if (_AvailableLookupTypes == null)
                {
                    _AvailableLookupTypes = new List<PropertyLookupTypeSetting>();
                    LoadAvailableLookupTypes();
                }
                return _AvailableLookupTypes;
            }
        }

        private void LoadAvailableLookupTypes()
        {
            List<string> lstEntity = new List<string>();
            lstEntity.Add("PropertyLookupLists");
            if (PropertyId <= 0) return;

            //DataSet ds = L2L.ClassLibrary.Data.LookupList.Selects.GetLookupList(PropertyId, null, lstEntity, null, null);

            //if (ds != null && ds.Tables.Count >= 2)
            //{
            //    DataTable dtTypes = ds.Tables[0];
            //    DataTable dtList = ds.Tables[1];

            //    foreach (DataRow dr in dtTypes.Rows)
            //    {
            //        PropertyLookupTypeSetting plt = new PropertyLookupTypeSetting()
            //        {
            //            ListTypeId = Convert.ToInt32(dr["ListTypeId"]),
            //            DisplayTitle = dr["DisplayTitle"].ToString(),
            //            FieldTypeId = Convert.ToInt32(dr["CustomFieldTypeId"]),
            //            IsReadOnly = Convert.ToBoolean(dr["IsReadOnly"]),
            //            ListValues = new List<LookupListSetup>()
            //        };

            //        DataRow[] drColl = dtList.Select("ListTypeId = " + plt.ListTypeId.ToString());

            //        foreach (DataRow drList in drColl)
            //        {
            //            LookupListSetup ll = new LookupListSetup();
            //            ll.ListId = Convert.ToInt32(drList["ListId"]);
            //            ll.ListDesc = drList["ListDescription"].ToString();
            //            ll.IsActive = Convert.ToBoolean(drList["IsActive"]);
            //            //more
            //            plt.ListValues.Add(ll);
            //        }
            //        _AvailableLookupTypes.Add(plt);
            //    }
            //}
        }
        #endregion

        public MarketSegment MarketSegment { get; set; }
    }

    public class PropertyLookupTypeSetting
    {
        public int ListTypeId { get; set; }
        public string DisplayTitle { get; set; }
        public int FieldTypeId { get; set; }
        public bool IsReadOnly { get; set; }
        public List<LookupListSetup> ListValues { get; set; }
    }

    public class LookupListSetup
    {
        public int ListId { get; set; }
        public string ListDesc { get; set; }
        public bool IsActive { get; set; }
    }

    public class LookupDefaultList
    {
        public int ListTypeId { get; set; }
        public int ListId { get; set; }
        public bool IsActive { get; set; }
    }

    public class LookupListType
    {
        public int Id { get; set; }
        public string ListType { get; set; }
        public string DisplayTitle { get; set; }
        public bool IsActive { get; set; }
        public bool IsSecured { get; set; }
    }

    public class PropertyLookupListType
    {
        public int ListTypeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        public string ListType { get; set; }
        public int CustomFieldTypeId { get; set; }
        public string DisplayTitle { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsSecured { get; set; }
    }

    public class PropertyLookupList
    {
        public int ListTypeId { get; set; }
        public int ListId { get; set; }
        public bool IsActive { get; set; }
        public string ListDescription { get; set; }
        public int SortOrder { get; set; }
    }

    /// <summary>
    /// Due to the unique way this data is queried from the DB, any of these properties may be null when returned. Unfortunately the 
    /// objects that are populated are coupled to the dynamic inputs.
    /// </summary>
    public class LookupListContainer
    {
        public List<LookupListType> LookupListTypeEntries { get; set; }
        public List<LookupListSetup> LookupListEntries { get; set; }
        public List<PropertyLookupListType> PropertyLookupListTypes { get; set; }
        public List<PropertyLookupList> PropertyLookupLists { get; set; }
        public List<LookupDefaultList> LookupDefaultListEntries { get; set; }
    }

    public class ListOption
    {
        public int ListId { get; set; }
        public string ListDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
    }

    public class PropertyTrackingInfo
    {
        public int PropertyId { get; set; }
        public string LeadEmail { get; set; }
    }
    public class PropertyGoLiveData
    {
        public int PropertyId { get; set; }
    }

	public class PropertySync
    {
        public string ClientPropId { get; set; }
        public string Company { get; set; }
        public int L2LPropertyId { get; set; }
        public string SourceDisplayName { get; set; }
       // public int PropertySyncId { get; set; }
    }
	
     
}