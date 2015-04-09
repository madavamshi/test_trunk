using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace L2L.EntLib
{
    [EdmEntityTypeAttribute(NamespaceName = "DB927_Model", Name = "BB_PropertySettings")]
    [Serializable()]
   // [DataContractAttribute(IsReference = true)]
    public partial class BB_PropertySettings : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new BB_PropertySettings object.
        /// </summary>
        /// <param name="propertyId">Initial value of the PropertyId property.</param>
        /// <param name="nonLeadCallerDuration">Initial value of the NonLeadCallerDuration property.</param>
        /// <param name="requiredFieldsId">Initial value of the RequiredFieldsId property.</param>
        /// <param name="clickOnCallEnabled">Initial value of the ClickOnCallEnabled property.</param>
        /// <param name="multiPropertySearchEnabled">Initial value of the MultiPropertySearchEnabled property.</param>
        /// <param name="deadLeadsFollowUpVisible">Initial value of the DeadLeadsFollowUpVisible property.</param>
        /// <param name="leasedLeadsFollowUpVisible">Initial value of the LeasedLeadsFollowUpVisible property.</param>
        /// <param name="leaseTerms">Initial value of the LeaseTerms property.</param>
        /// <param name="appliedLeadsFollowUpVisible">Initial value of the AppliedLeadsFollowUpVisible property.</param>
        /// <param name="hideLeadsWithFollowUp">Initial value of the HideLeadsWithFollowUp property.</param>
        /// <param name="quotesAndAvailabilityProviderId">Initial value of the QuotesAndAvailabilityProviderId property.</param>
        /// <param name="notifierEnabled">Initial value of the NotifierEnabled property.</param>
        /// <param name="applicationVendorId">Initial value of the ApplicationVendorId property.</param>
        /// <param name="disableLeadMatching">Initial value of the DisableLeadMatching property.</param>
        /// <param name="costPerModeId">Initial value of the CostPerModeId property.</param>
        /// <param name="petDisplayOption">Initial value of the PetDisplayOption property.</param>
        /// <param name="rentDisplayOptions">Initial value of the RentDisplayOptions property.</param>
        /// <param name="leadTrackingType">Initial value of the LeadTrackingType property.</param>
        /// <param name="marketSegmentId">Initial value of the MarketSegmentId property.</param>
        /// <param name="showHintsAndTipsOnAddProspect">Initial value of the ShowHintsAndTipsOnAddProspect property.</param>
        /// <param name="showHintsAndTipsGuestCard">Initial value of the ShowHintsAndTipsGuestCard property.</param>
        public static BB_PropertySettings CreateBB_PropertySettings(global::System.Int32 propertyId, global::System.DateTime nonLeadCallerDuration, global::System.Int32 requiredFieldsId, global::System.Boolean clickOnCallEnabled, global::System.Boolean multiPropertySearchEnabled, global::System.Boolean deadLeadsFollowUpVisible, global::System.Boolean leasedLeadsFollowUpVisible, global::System.String leaseTerms, global::System.Boolean appliedLeadsFollowUpVisible, global::System.Boolean hideLeadsWithFollowUp, global::System.Int16 quotesAndAvailabilityProviderId, global::System.Boolean notifierEnabled, global::System.Int16 applicationVendorId, global::System.Boolean disableLeadMatching, global::System.Byte costPerModeId, global::System.Byte petDisplayOption, global::System.Byte rentDisplayOptions, global::System.Byte leadTrackingType, global::System.Int32 marketSegmentId, global::System.Boolean showHintsAndTipsOnAddProspect, global::System.Boolean showHintsAndTipsGuestCard)
        {
            BB_PropertySettings bB_PropertySettings = new BB_PropertySettings();
            bB_PropertySettings.PropertyId = propertyId;
            bB_PropertySettings.NonLeadCallerDuration = nonLeadCallerDuration;
            bB_PropertySettings.RequiredFieldsId = requiredFieldsId;
            bB_PropertySettings.ClickOnCallEnabled = clickOnCallEnabled;
            bB_PropertySettings.MultiPropertySearchEnabled = multiPropertySearchEnabled;
            bB_PropertySettings.DeadLeadsFollowUpVisible = deadLeadsFollowUpVisible;
            bB_PropertySettings.LeasedLeadsFollowUpVisible = leasedLeadsFollowUpVisible;
            bB_PropertySettings.LeaseTerms = leaseTerms;
            bB_PropertySettings.AppliedLeadsFollowUpVisible = appliedLeadsFollowUpVisible;
            bB_PropertySettings.HideLeadsWithFollowUp = hideLeadsWithFollowUp;
            bB_PropertySettings.QuotesAndAvailabilityProviderId = quotesAndAvailabilityProviderId;
            bB_PropertySettings.NotifierEnabled = notifierEnabled;
            bB_PropertySettings.ApplicationVendorId = applicationVendorId;
            bB_PropertySettings.DisableLeadMatching = disableLeadMatching;
            bB_PropertySettings.CostPerModeId = costPerModeId;
            bB_PropertySettings.PetDisplayOption = petDisplayOption;
            bB_PropertySettings.RentDisplayOptions = rentDisplayOptions;
            bB_PropertySettings.LeadTrackingType = leadTrackingType;
            bB_PropertySettings.MarketSegmentId = marketSegmentId;
            bB_PropertySettings.ShowHintsAndTipsOnAddProspect = showHintsAndTipsOnAddProspect;
            bB_PropertySettings.ShowHintsAndTipsGuestCard = showHintsAndTipsGuestCard;
            return bB_PropertySettings;
        }

        #endregion

        #region Primitive Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Int32 PropertyId
        {
            get
            {
                return _PropertyId;
            }
            set
            {
                if (_PropertyId != value)
                {
                    OnPropertyIdChanging(value);
                    ReportPropertyChanging("PropertyId");
                    _PropertyId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PropertyId");
                    OnPropertyIdChanged();
                }
            }
        }
        private global::System.Int32 _PropertyId;
        partial void OnPropertyIdChanging(global::System.Int32 value);
        partial void OnPropertyIdChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.DateTime NonLeadCallerDuration
        {
            get
            {
                return _NonLeadCallerDuration;
            }
            set
            {
                OnNonLeadCallerDurationChanging(value);
                ReportPropertyChanging("NonLeadCallerDuration");
                _NonLeadCallerDuration = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("NonLeadCallerDuration");
                OnNonLeadCallerDurationChanged();
            }
        }
        private global::System.DateTime _NonLeadCallerDuration;
        partial void OnNonLeadCallerDurationChanging(global::System.DateTime value);
        partial void OnNonLeadCallerDurationChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Int32 RequiredFieldsId
        {
            get
            {
                return _RequiredFieldsId;
            }
            set
            {
                OnRequiredFieldsIdChanging(value);
                ReportPropertyChanging("RequiredFieldsId");
                _RequiredFieldsId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RequiredFieldsId");
                OnRequiredFieldsIdChanged();
            }
        }
        private global::System.Int32 _RequiredFieldsId;
        partial void OnRequiredFieldsIdChanging(global::System.Int32 value);
        partial void OnRequiredFieldsIdChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Boolean ClickOnCallEnabled
        {
            get
            {
                return _ClickOnCallEnabled;
            }
            set
            {
                OnClickOnCallEnabledChanging(value);
                ReportPropertyChanging("ClickOnCallEnabled");
                _ClickOnCallEnabled = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ClickOnCallEnabled");
                OnClickOnCallEnabledChanged();
            }
        }
        private global::System.Boolean _ClickOnCallEnabled;
        partial void OnClickOnCallEnabledChanging(global::System.Boolean value);
        partial void OnClickOnCallEnabledChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Boolean MultiPropertySearchEnabled
        {
            get
            {
                return _MultiPropertySearchEnabled;
            }
            set
            {
                OnMultiPropertySearchEnabledChanging(value);
                ReportPropertyChanging("MultiPropertySearchEnabled");
                _MultiPropertySearchEnabled = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("MultiPropertySearchEnabled");
                OnMultiPropertySearchEnabledChanged();
            }
        }
        private global::System.Boolean _MultiPropertySearchEnabled;
        partial void OnMultiPropertySearchEnabledChanging(global::System.Boolean value);
        partial void OnMultiPropertySearchEnabledChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Boolean DeadLeadsFollowUpVisible
        {
            get
            {
                return _DeadLeadsFollowUpVisible;
            }
            set
            {
                OnDeadLeadsFollowUpVisibleChanging(value);
                ReportPropertyChanging("DeadLeadsFollowUpVisible");
                _DeadLeadsFollowUpVisible = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DeadLeadsFollowUpVisible");
                OnDeadLeadsFollowUpVisibleChanged();
            }
        }
        private global::System.Boolean _DeadLeadsFollowUpVisible;
        partial void OnDeadLeadsFollowUpVisibleChanging(global::System.Boolean value);
        partial void OnDeadLeadsFollowUpVisibleChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Boolean LeasedLeadsFollowUpVisible
        {
            get
            {
                return _LeasedLeadsFollowUpVisible;
            }
            set
            {
                OnLeasedLeadsFollowUpVisibleChanging(value);
                ReportPropertyChanging("LeasedLeadsFollowUpVisible");
                _LeasedLeadsFollowUpVisible = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LeasedLeadsFollowUpVisible");
                OnLeasedLeadsFollowUpVisibleChanged();
            }
        }
        private global::System.Boolean _LeasedLeadsFollowUpVisible;
        partial void OnLeasedLeadsFollowUpVisibleChanging(global::System.Boolean value);
        partial void OnLeasedLeadsFollowUpVisibleChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.String LeaseTerms
        {
            get
            {
                return _LeaseTerms;
            }
            set
            {
                OnLeaseTermsChanging(value);
                ReportPropertyChanging("LeaseTerms");
                _LeaseTerms = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LeaseTerms");
                OnLeaseTermsChanged();
            }
        }
        private global::System.String _LeaseTerms;
        partial void OnLeaseTermsChanging(global::System.String value);
        partial void OnLeaseTermsChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Boolean AppliedLeadsFollowUpVisible
        {
            get
            {
                return _AppliedLeadsFollowUpVisible;
            }
            set
            {
                OnAppliedLeadsFollowUpVisibleChanging(value);
                ReportPropertyChanging("AppliedLeadsFollowUpVisible");
                _AppliedLeadsFollowUpVisible = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AppliedLeadsFollowUpVisible");
                OnAppliedLeadsFollowUpVisibleChanged();
            }
        }
        private global::System.Boolean _AppliedLeadsFollowUpVisible;
        partial void OnAppliedLeadsFollowUpVisibleChanging(global::System.Boolean value);
        partial void OnAppliedLeadsFollowUpVisibleChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Boolean HideLeadsWithFollowUp
        {
            get
            {
                return _HideLeadsWithFollowUp;
            }
            set
            {
                OnHideLeadsWithFollowUpChanging(value);
                ReportPropertyChanging("HideLeadsWithFollowUp");
                _HideLeadsWithFollowUp = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("HideLeadsWithFollowUp");
                OnHideLeadsWithFollowUpChanged();
            }
        }
        private global::System.Boolean _HideLeadsWithFollowUp;
        partial void OnHideLeadsWithFollowUpChanging(global::System.Boolean value);
        partial void OnHideLeadsWithFollowUpChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Int16 QuotesAndAvailabilityProviderId
        {
            get
            {
                return _QuotesAndAvailabilityProviderId;
            }
            set
            {
                OnQuotesAndAvailabilityProviderIdChanging(value);
                ReportPropertyChanging("QuotesAndAvailabilityProviderId");
                _QuotesAndAvailabilityProviderId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("QuotesAndAvailabilityProviderId");
                OnQuotesAndAvailabilityProviderIdChanged();
            }
        }
        private global::System.Int16 _QuotesAndAvailabilityProviderId;
        partial void OnQuotesAndAvailabilityProviderIdChanging(global::System.Int16 value);
        partial void OnQuotesAndAvailabilityProviderIdChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Boolean NotifierEnabled
        {
            get
            {
                return _NotifierEnabled;
            }
            set
            {
                OnNotifierEnabledChanging(value);
                ReportPropertyChanging("NotifierEnabled");
                _NotifierEnabled = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("NotifierEnabled");
                OnNotifierEnabledChanged();
            }
        }
        private global::System.Boolean _NotifierEnabled;
        partial void OnNotifierEnabledChanging(global::System.Boolean value);
        partial void OnNotifierEnabledChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Int16 ApplicationVendorId
        {
            get
            {
                return _ApplicationVendorId;
            }
            set
            {
                OnApplicationVendorIdChanging(value);
                ReportPropertyChanging("ApplicationVendorId");
                _ApplicationVendorId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ApplicationVendorId");
                OnApplicationVendorIdChanged();
            }
        }
        private global::System.Int16 _ApplicationVendorId;
        partial void OnApplicationVendorIdChanging(global::System.Int16 value);
        partial void OnApplicationVendorIdChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public global::System.String QuotesHeader
        {
            get
            {
                return _QuotesHeader;
            }
            set
            {
                OnQuotesHeaderChanging(value);
                ReportPropertyChanging("QuotesHeader");
                _QuotesHeader = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("QuotesHeader");
                OnQuotesHeaderChanged();
            }
        }
        private global::System.String _QuotesHeader;
        partial void OnQuotesHeaderChanging(global::System.String value);
        partial void OnQuotesHeaderChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public global::System.String QuotesFooter
        {
            get
            {
                return _QuotesFooter;
            }
            set
            {
                OnQuotesFooterChanging(value);
                ReportPropertyChanging("QuotesFooter");
                _QuotesFooter = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("QuotesFooter");
                OnQuotesFooterChanged();
            }
        }
        private global::System.String _QuotesFooter;
        partial void OnQuotesFooterChanging(global::System.String value);
        partial void OnQuotesFooterChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Byte> LeadOwnershipModelId
        {
            get
            {
                return _LeadOwnershipModelId;
            }
            set
            {
                OnLeadOwnershipModelIdChanging(value);
                ReportPropertyChanging("LeadOwnershipModelId");
                _LeadOwnershipModelId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LeadOwnershipModelId");
                OnLeadOwnershipModelIdChanged();
            }
        }
        private Nullable<global::System.Byte> _LeadOwnershipModelId;
        partial void OnLeadOwnershipModelIdChanging(Nullable<global::System.Byte> value);
        partial void OnLeadOwnershipModelIdChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Boolean DisableLeadMatching
        {
            get
            {
                return _DisableLeadMatching;
            }
            set
            {
                OnDisableLeadMatchingChanging(value);
                ReportPropertyChanging("DisableLeadMatching");
                _DisableLeadMatching = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DisableLeadMatching");
                OnDisableLeadMatchingChanged();
            }
        }
        private global::System.Boolean _DisableLeadMatching;
        partial void OnDisableLeadMatchingChanging(global::System.Boolean value);
        partial void OnDisableLeadMatchingChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Int32> LeadUpdateTypeId
        {
            get
            {
                return _LeadUpdateTypeId;
            }
            set
            {
                OnLeadUpdateTypeIdChanging(value);
                ReportPropertyChanging("LeadUpdateTypeId");
                _LeadUpdateTypeId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LeadUpdateTypeId");
                OnLeadUpdateTypeIdChanged();
            }
        }
        private Nullable<global::System.Int32> _LeadUpdateTypeId;
        partial void OnLeadUpdateTypeIdChanging(Nullable<global::System.Int32> value);
        partial void OnLeadUpdateTypeIdChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Byte CostPerModeId
        {
            get
            {
                return _CostPerModeId;
            }
            set
            {
                OnCostPerModeIdChanging(value);
                ReportPropertyChanging("CostPerModeId");
                _CostPerModeId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CostPerModeId");
                OnCostPerModeIdChanged();
            }
        }
        private global::System.Byte _CostPerModeId;
        partial void OnCostPerModeIdChanging(global::System.Byte value);
        partial void OnCostPerModeIdChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Byte> SubscriptionTypeId
        {
            get
            {
                return _SubscriptionTypeId;
            }
            set
            {
                OnSubscriptionTypeIdChanging(value);
                ReportPropertyChanging("SubscriptionTypeId");
                _SubscriptionTypeId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SubscriptionTypeId");
                OnSubscriptionTypeIdChanged();
            }
        }
        private Nullable<global::System.Byte> _SubscriptionTypeId;
        partial void OnSubscriptionTypeIdChanging(Nullable<global::System.Byte> value);
        partial void OnSubscriptionTypeIdChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Byte> BaseProductTypeId
        {
            get
            {
                return _BaseProductTypeId;
            }
            set
            {
                OnBaseProductTypeIdChanging(value);
                ReportPropertyChanging("BaseProductTypeId");
                _BaseProductTypeId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BaseProductTypeId");
                OnBaseProductTypeIdChanged();
            }
        }
        private Nullable<global::System.Byte> _BaseProductTypeId;
        partial void OnBaseProductTypeIdChanging(Nullable<global::System.Byte> value);
        partial void OnBaseProductTypeIdChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Boolean> ClearOneSiteTasks
        {
            get
            {
                return _ClearOneSiteTasks;
            }
            set
            {
                OnClearOneSiteTasksChanging(value);
                ReportPropertyChanging("ClearOneSiteTasks");
                _ClearOneSiteTasks = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ClearOneSiteTasks");
                OnClearOneSiteTasksChanged();
            }
        }
        private Nullable<global::System.Boolean> _ClearOneSiteTasks;
        partial void OnClearOneSiteTasksChanging(Nullable<global::System.Boolean> value);
        partial void OnClearOneSiteTasksChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Boolean> HideDaysOnMarketInQuotes
        {
            get
            {
                return _HideDaysOnMarketInQuotes;
            }
            set
            {
                OnHideDaysOnMarketInQuotesChanging(value);
                ReportPropertyChanging("HideDaysOnMarketInQuotes");
                _HideDaysOnMarketInQuotes = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("HideDaysOnMarketInQuotes");
                OnHideDaysOnMarketInQuotesChanged();
            }
        }
        private Nullable<global::System.Boolean> _HideDaysOnMarketInQuotes;
        partial void OnHideDaysOnMarketInQuotesChanging(Nullable<global::System.Boolean> value);
        partial void OnHideDaysOnMarketInQuotesChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Boolean> IsConventionalxxxxx
        {
            get
            {
                return _IsConventionalxxxxx;
            }
            set
            {
                OnIsConventionalxxxxxChanging(value);
                ReportPropertyChanging("IsConventionalxxxxx");
                _IsConventionalxxxxx = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsConventionalxxxxx");
                OnIsConventionalxxxxxChanged();
            }
        }
        private Nullable<global::System.Boolean> _IsConventionalxxxxx;
        partial void OnIsConventionalxxxxxChanging(Nullable<global::System.Boolean> value);
        partial void OnIsConventionalxxxxxChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Boolean> IsSeniorxxxx
        {
            get
            {
                return _IsSeniorxxxx;
            }
            set
            {
                OnIsSeniorxxxxChanging(value);
                ReportPropertyChanging("IsSeniorxxxx");
                _IsSeniorxxxx = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsSeniorxxxx");
                OnIsSeniorxxxxChanged();
            }
        }
        private Nullable<global::System.Boolean> _IsSeniorxxxx;
        partial void OnIsSeniorxxxxChanging(Nullable<global::System.Boolean> value);
        partial void OnIsSeniorxxxxChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Boolean> IsMilitaryxxxx
        {
            get
            {
                return _IsMilitaryxxxx;
            }
            set
            {
                OnIsMilitaryxxxxChanging(value);
                ReportPropertyChanging("IsMilitaryxxxx");
                _IsMilitaryxxxx = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsMilitaryxxxx");
                OnIsMilitaryxxxxChanged();
            }
        }
        private Nullable<global::System.Boolean> _IsMilitaryxxxx;
        partial void OnIsMilitaryxxxxChanging(Nullable<global::System.Boolean> value);
        partial void OnIsMilitaryxxxxChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Boolean> IsStudentxxxx
        {
            get
            {
                return _IsStudentxxxx;
            }
            set
            {
                OnIsStudentxxxxChanging(value);
                ReportPropertyChanging("IsStudentxxxx");
                _IsStudentxxxx = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsStudentxxxx");
                OnIsStudentxxxxChanged();
            }
        }
        private Nullable<global::System.Boolean> _IsStudentxxxx;
        partial void OnIsStudentxxxxChanging(Nullable<global::System.Boolean> value);
        partial void OnIsStudentxxxxChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Boolean> ShowBestPrice
        {
            get
            {
                return _ShowBestPrice;
            }
            set
            {
                OnShowBestPriceChanging(value);
                ReportPropertyChanging("ShowBestPrice");
                _ShowBestPrice = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ShowBestPrice");
                OnShowBestPriceChanged();
            }
        }
        private Nullable<global::System.Boolean> _ShowBestPrice;
        partial void OnShowBestPriceChanging(Nullable<global::System.Boolean> value);
        partial void OnShowBestPriceChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Boolean> BrochuresEnabled
        {
            get
            {
                return _BrochuresEnabled;
            }
            set
            {
                OnBrochuresEnabledChanging(value);
                ReportPropertyChanging("BrochuresEnabled");
                _BrochuresEnabled = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BrochuresEnabled");
                OnBrochuresEnabledChanged();
            }
        }
        private Nullable<global::System.Boolean> _BrochuresEnabled;
        partial void OnBrochuresEnabledChanging(Nullable<global::System.Boolean> value);
        partial void OnBrochuresEnabledChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Boolean> PortalAccountEnabled
        {
            get
            {
                return _PortalAccountEnabled;
            }
            set
            {
                OnPortalAccountEnabledChanging(value);
                ReportPropertyChanging("PortalAccountEnabled");
                _PortalAccountEnabled = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PortalAccountEnabled");
                OnPortalAccountEnabledChanged();
            }
        }
        private Nullable<global::System.Boolean> _PortalAccountEnabled;
        partial void OnPortalAccountEnabledChanging(Nullable<global::System.Boolean> value);
        partial void OnPortalAccountEnabledChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
       // [DataMemberAttribute()]
        public Nullable<global::System.Boolean> AppendBrochuresToARTemplate
        {
            get
            {
                return _AppendBrochuresToARTemplate;
            }
            set
            {
                OnAppendBrochuresToARTemplateChanging(value);
                ReportPropertyChanging("AppendBrochuresToARTemplate");
                _AppendBrochuresToARTemplate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AppendBrochuresToARTemplate");
                OnAppendBrochuresToARTemplateChanged();
            }
        }
        private Nullable<global::System.Boolean> _AppendBrochuresToARTemplate;
        partial void OnAppendBrochuresToARTemplateChanging(Nullable<global::System.Boolean> value);
        partial void OnAppendBrochuresToARTemplateChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
       // [DataMemberAttribute()]
        public Nullable<global::System.Boolean> FitBrochureToSinglePagePDF
        {
            get
            {
                return _FitBrochureToSinglePagePDF;
            }
            set
            {
                OnFitBrochureToSinglePagePDFChanging(value);
                ReportPropertyChanging("FitBrochureToSinglePagePDF");
                _FitBrochureToSinglePagePDF = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FitBrochureToSinglePagePDF");
                OnFitBrochureToSinglePagePDFChanged();
            }
        }
        private Nullable<global::System.Boolean> _FitBrochureToSinglePagePDF;
        partial void OnFitBrochureToSinglePagePDFChanging(Nullable<global::System.Boolean> value);
        partial void OnFitBrochureToSinglePagePDFChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
       // [DataMemberAttribute()]
        public global::System.String CreationEmailSubject
        {
            get
            {
                return _CreationEmailSubject;
            }
            set
            {
                OnCreationEmailSubjectChanging(value);
                ReportPropertyChanging("CreationEmailSubject");
                _CreationEmailSubject = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("CreationEmailSubject");
                OnCreationEmailSubjectChanged();
            }
        }
        private global::System.String _CreationEmailSubject;
        partial void OnCreationEmailSubjectChanging(global::System.String value);
        partial void OnCreationEmailSubjectChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
       // [DataMemberAttribute()]
        public global::System.String CreationEmailContent
        {
            get
            {
                return _CreationEmailContent;
            }
            set
            {
                OnCreationEmailContentChanging(value);
                ReportPropertyChanging("CreationEmailContent");
                _CreationEmailContent = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("CreationEmailContent");
                OnCreationEmailContentChanged();
            }
        }
        private global::System.String _CreationEmailContent;
        partial void OnCreationEmailContentChanging(global::System.String value);
        partial void OnCreationEmailContentChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
       // [DataMemberAttribute()]
        public global::System.String ResetEmailSubject
        {
            get
            {
                return _ResetEmailSubject;
            }
            set
            {
                OnResetEmailSubjectChanging(value);
                ReportPropertyChanging("ResetEmailSubject");
                _ResetEmailSubject = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ResetEmailSubject");
                OnResetEmailSubjectChanged();
            }
        }
        private global::System.String _ResetEmailSubject;
        partial void OnResetEmailSubjectChanging(global::System.String value);
        partial void OnResetEmailSubjectChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public global::System.String ResetEmailContent
        {
            get
            {
                return _ResetEmailContent;
            }
            set
            {
                OnResetEmailContentChanging(value);
                ReportPropertyChanging("ResetEmailContent");
                _ResetEmailContent = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ResetEmailContent");
                OnResetEmailContentChanged();
            }
        }
        private global::System.String _ResetEmailContent;
        partial void OnResetEmailContentChanging(global::System.String value);
        partial void OnResetEmailContentChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Byte PetDisplayOption
        {
            get
            {
                return _PetDisplayOption;
            }
            set
            {
                OnPetDisplayOptionChanging(value);
                ReportPropertyChanging("PetDisplayOption");
                _PetDisplayOption = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PetDisplayOption");
                OnPetDisplayOptionChanged();
            }
        }
        private global::System.Byte _PetDisplayOption;
        partial void OnPetDisplayOptionChanging(global::System.Byte value);
        partial void OnPetDisplayOptionChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
       // [DataMemberAttribute()]
        public global::System.Byte RentDisplayOptions
        {
            get
            {
                return _RentDisplayOptions;
            }
            set
            {
                OnRentDisplayOptionsChanging(value);
                ReportPropertyChanging("RentDisplayOptions");
                _RentDisplayOptions = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RentDisplayOptions");
                OnRentDisplayOptionsChanged();
            }
        }
        private global::System.Byte _RentDisplayOptions;
        partial void OnRentDisplayOptionsChanging(global::System.Byte value);
        partial void OnRentDisplayOptionsChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
       // [DataMemberAttribute()]
        public global::System.Byte LeadTrackingType
        {
            get
            {
                return _LeadTrackingType;
            }
            set
            {
                OnLeadTrackingTypeChanging(value);
                ReportPropertyChanging("LeadTrackingType");
                _LeadTrackingType = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LeadTrackingType");
                OnLeadTrackingTypeChanged();
            }
        }
        private global::System.Byte _LeadTrackingType;
        partial void OnLeadTrackingTypeChanging(global::System.Byte value);
        partial void OnLeadTrackingTypeChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Int32 MarketSegmentId
        {
            get
            {
                return _MarketSegmentId;
            }
            set
            {
                OnMarketSegmentIdChanging(value);
                ReportPropertyChanging("MarketSegmentId");
                _MarketSegmentId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("MarketSegmentId");
                OnMarketSegmentIdChanged();
            }
        }
        private global::System.Int32 _MarketSegmentId;
        partial void OnMarketSegmentIdChanging(global::System.Int32 value);
        partial void OnMarketSegmentIdChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        //[DataMemberAttribute()]
        public Nullable<global::System.Boolean> IsSecured
        {
            get
            {
                return _IsSecured;
            }
            set
            {
                OnIsSecuredChanging(value);
                ReportPropertyChanging("IsSecured");
                _IsSecured = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsSecured");
                OnIsSecuredChanged();
            }
        }
        private Nullable<global::System.Boolean> _IsSecured;
        partial void OnIsSecuredChanging(Nullable<global::System.Boolean> value);
        partial void OnIsSecuredChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Boolean ShowHintsAndTipsOnAddProspect
        {
            get
            {
                return _ShowHintsAndTipsOnAddProspect;
            }
            set
            {
                OnShowHintsAndTipsOnAddProspectChanging(value);
                ReportPropertyChanging("ShowHintsAndTipsOnAddProspect");
                _ShowHintsAndTipsOnAddProspect = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ShowHintsAndTipsOnAddProspect");
                OnShowHintsAndTipsOnAddProspectChanged();
            }
        }
        private global::System.Boolean _ShowHintsAndTipsOnAddProspect;
        partial void OnShowHintsAndTipsOnAddProspectChanging(global::System.Boolean value);
        partial void OnShowHintsAndTipsOnAddProspectChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        //[DataMemberAttribute()]
        public global::System.Boolean ShowHintsAndTipsGuestCard
        {
            get
            {
                return _ShowHintsAndTipsGuestCard;
            }
            set
            {
                OnShowHintsAndTipsGuestCardChanging(value);
                ReportPropertyChanging("ShowHintsAndTipsGuestCard");
                _ShowHintsAndTipsGuestCard = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ShowHintsAndTipsGuestCard");
                OnShowHintsAndTipsGuestCardChanged();
            }
        }
        private global::System.Boolean _ShowHintsAndTipsGuestCard;
        partial void OnShowHintsAndTipsGuestCardChanging(global::System.Boolean value);
        partial void OnShowHintsAndTipsGuestCardChanged();

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        //[DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DB927_Model", "FK_BB_PropertySettings_BB_PropertySettings", "BB_PropertySettings1")]
        public BB_PropertySettings BB_PropertySettings1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<BB_PropertySettings>("DB927_Model.FK_BB_PropertySettings_BB_PropertySettings", "BB_PropertySettings1").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<BB_PropertySettings>("DB927_Model.FK_BB_PropertySettings_BB_PropertySettings", "BB_PropertySettings1").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        //[DataMemberAttribute()]
        public EntityReference<BB_PropertySettings> BB_PropertySettings1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<BB_PropertySettings>("DB927_Model.FK_BB_PropertySettings_BB_PropertySettings", "BB_PropertySettings1");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<BB_PropertySettings>("DB927_Model.FK_BB_PropertySettings_BB_PropertySettings", "BB_PropertySettings1", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        //[DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DB927_Model", "FK_BB_PropertySettings_BB_PropertySettings", "BB_PropertySettings")]
        public BB_PropertySettings BB_PropertySettings2
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<BB_PropertySettings>("DB927_Model.FK_BB_PropertySettings_BB_PropertySettings", "BB_PropertySettings").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<BB_PropertySettings>("DB927_Model.FK_BB_PropertySettings_BB_PropertySettings", "BB_PropertySettings").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
       // [DataMemberAttribute()]
        public EntityReference<BB_PropertySettings> BB_PropertySettings2Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<BB_PropertySettings>("DB927_Model.FK_BB_PropertySettings_BB_PropertySettings", "BB_PropertySettings");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<BB_PropertySettings>("DB927_Model.FK_BB_PropertySettings_BB_PropertySettings", "BB_PropertySettings", value);
                }
            }
        }

        #endregion

    }
}
