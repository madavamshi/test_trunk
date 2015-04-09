using L2L.ClassLibrary.Objects.Property;
using L2L.ClassLibrary.Objects.Property.Settings;
using L2L.EntLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2L.ClientAPI.ServiceOperations
{
    interface ISecureAPICall
    {
         string APIVersion();
         int? GetL2LPropertyIdForProviderUser(string propertyKey, int userId);
         void AddLeaseStarMapping(int propertyId, string propertyKey, string secondKey, bool async = false);
         int? GetLeaseStarMapping(string propertyKey, bool async = false);
         int? CreatePropertyShell(short providerID, int accountId, int managementId, string leaseStarPropertyId, string propertyName,
                                string address, string city, string state, string zip, string phone, string email,
                                byte baseProductTypeId, byte subscriptionTypeId);
         DataSet GetResponseSettings(int propertyId);
         DataSet ListPolicies(int propertyId);
         List<int> GetLeaseTerms(int propertyId, bool refreshList);
         DataSet GetAccountSettings(int propertyId, string dummyArg = null);
         L2L.ClassLibrary.Objects.Property.PropertySettings GetL2LPropertySettings(int propertyID, int? dummyArg = null);
         void UpdatePropertySettingsLeadTrackingType(int leaseStarPropertyId, byte leadTrackingTypeId);
         void GenerateAndSaveAccountPreferenceEmails(int propertyId, string propertyName, string companyName, string emailFrom);
         string GetLeadTrackingEmail(int propertyId);
         object GetProperty(int propertyId);
         BB_PropertySettings GetPropertySettingsByLeaseStarPropID(int leaseStarPropertyId);
         PropertySettings GetPropertySettings(int propId);
         IList<VerbiageTopic> GetVerbiageTopicsFor(int catId);
         IList<VerbiageKeyWord> GetVerbiageKeyWordsFor(int topicId);
         VerbiageTopic GetVerbiageTopicFor(int topicId);
         IList<CustomGroup> GetPropertyHintsAndTips(int propId);
         int? AddSettingsCategoryFor(int propertyId, string catName);
         int? AddSettingsTopicFor(int catId, string topicName, string verbText = "");
         int? AddSettingsKeyWordFor(int topicId, string keyWordName);
         int? UpdateSettingsCategoryFor(int propertyId, int catId, string catName, VerbiageCategory[] categories = null);
         int? UpdateSettingsTopicFor(int topicId, string topicName, string verbText = "");
         int? UpdateSettingsKeyWordFor(int topicId, int keyWordId, string keyWordName);
         int? DeleteSettingsCategoryFor(int propertyId, int catId);
         int? DeleteSettingsTopicFor(int catId, int topicId);
         int? DeleteSettingsKeyWordFor(int catId, int topicId);
         int? DeleteHintsAndTipsSection(int propertyId, int id);
         int? DeleteHintsAndTipsCustomField(int propertyId, int sectionId, int fieldId);
         int? UpdateLeaseTermsPropertySettings(int propId, string leaseTerms);
         int? UpdateAutoResponderSetting(AutoResponder autoResp);
         int? UpdateCallsSetting(int propertyId, DateTime callerDuration, bool clickOnCallEnabled);
         int? UpdateEmailSetting(EmailPreferences emailPref);
         int? AddPropertySettingsEmailRecipient(int propId, string email);
         int? DeletePropertySettingEmailRecipient(int propertyId, int recipientId);
         int? DeleteTourHoursSetting(int propertyId, int[] tourDays);
         int? UpdateAlertsSettings(IPropertySettings ps);
         int? SaveTourHoursSetting(int propertyId, IList<TourHours> tourHours);
         int? SaveAdminHintsAndTipsSetting(int propertyId, IList<CustomGroup> groups);
         int? UpdatePreferencePropertySettings(int propId, bool showHintsAndTipsOnAddProspect, bool showHintsAndTipsOnGuestCard);
         void SavePropertySync(int userId, PropertySync syncData);
         GuestcardSettings GetGuestcardSettings(int guestcardId);
         List<GoogleTracking> GetGuestcardTrackingCode(int propertyId);
         PropertyPreference GetPropertyPreferenceSettings(int propertyId);
         L2L.API.Shared.Interfaces.Property.IOfficeSetting GetPropertyOfficeHours(int propertyId);
         IList<CustomArea> GetPropertySupplementaryFields(int propertyId);

    }
}
