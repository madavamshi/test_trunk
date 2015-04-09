using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using L2L.API.Shared.Enum.Property;
using L2L.ClassLibrary.Objects.Common;
using L2L.ClassLibrary.Objects.Property;

namespace L2L.ClassLibrary.Data.Property
{
    public class Selects //: SharedFunctions.DataHandler.SQL_Base
    {   

        //public static L2L.ClassLibrary.Objects.Property.PropertySettings PropertySettings(int propertyId)
        //{
        //    L2L.ClassLibrary.Objects.Property.PropertySettings ps = new L2L.ClassLibrary.Objects.Property.PropertySettings();
        //    DataSet ds = DynamicSproc("[PropertySettings_Get]", propertyId);
        //    DataTable dt;
        //    ps.PropertyId = propertyId;

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        dt = ds.Tables[0];
        //        ps.PropertyName = dt.Rows[0]["ComplexName"] as string;
        //        ps.AccountName = dt.Rows[0]["AccountName"] as string;
        //        ps.AccountID = Convert.ToInt32(dt.Rows[0]["AccountId"]);
        //        ps.EnableProperty = Convert.ToBoolean(dt.Rows[0]["EnableProperty"]);
        //    }
        //    if (ds.Tables[1].Rows.Count > 0)
        //    {
        //        dt = ds.Tables[1];
        //        ps.ClickOnCallEnabled = Convert.ToBoolean(dt.Rows[0]["ClickOnCallEnabled"]);
        //        ps.MultiPropertySearchEnabled = Convert.ToBoolean(dt.Rows[0]["MultiPropertySearchEnabled"]);
        //        ps.NonLeadCallerDuration = Convert.ToDateTime(dt.Rows[0]["NonLeadCallerDuration"]);
        //        ps.RequiredFieldsId = Convert.ToInt32(dt.Rows[0]["RequiredFieldsId"]);
        //        ps.LeasedLeadsFollowUpVisible = Convert.ToBoolean(dt.Rows[0]["LeasedLeadsFollowUpVisible"]);
        //        ps.DeadLeadsFollowUpVisible = Convert.ToBoolean(dt.Rows[0]["DeadLeadsFollowUpVisible"]);
        //        ps.ClearOneSiteTasks = dt.Rows[0]["ClearOneSiteTasks"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["ClearOneSiteTasks"]); // Convert.ToBoolean(dt.Rows[0]["ClearOneSiteTasks"]);
        //        ps.PetDisplayOptions = Convert.ToInt32(dt.Rows[0]["PetDisplayOption"]);
        //        ps.RentDisplayOptions = Convert.ToInt32(dt.Rows[0]["RentDisplayOptions"]);
        //        ps.IsHIPAA = dt.Rows[0]["isSecured"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["isSecured"]);
        //        ps.ShowDaysOnMarketInQuotes = dt.Rows[0]["HideDaysOnMarketInQuotes"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["HideDaysOnMarketInQuotes"]);
        //        ps.ShowBestPrice = dt.Rows[0]["ShowBestPrice"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["ShowBestPrice"]);
        //        ps.AppliedLeadsFollowUpVisible = Convert.ToBoolean(dt.Rows[0]["AppliedLeadsFollowUpVisible"]);
        //        ps.HideLeadsWithFollowUp = Convert.ToBoolean(dt.Rows[0]["HideLeadsWithFollowUp"]);
        //        ps.QuotesAndAvailabilityProviderId = Convert.ToInt32(dt.Rows[0]["QuotesAndAvailabilityProviderId"]);
        //        ps.ApplicationVendorID = Convert.ToInt32(dt.Rows[0]["ApplicationVendorId"]);

        //        ps.BaseProductType = dt.Rows[0]["BaseProductTypeId"] == DBNull.Value ? BaseProductTypes.Parking : (BaseProductTypes)Convert.ToInt32(dt.Rows[0]["BaseProductTypeId"]);
        //        ps.SubscriptionType = dt.Rows[0]["SubscriptionTypeId"] == DBNull.Value ? SubscriptionTypes.Internal : (SubscriptionTypes)Convert.ToInt32(dt.Rows[0]["SubscriptionTypeId"]);
        //        ps.LeadOwnershipModel = dt.Rows[0]["LeadOwnershipModelId"] == DBNull.Value ? LeadOwnershipModelType.Shared : (LeadOwnershipModelType)Convert.ToInt32(dt.Rows[0]["LeadOwnershipModelId"]);

        //        ps.QuotesHeader = dt.Rows[0]["QuotesHeader"] == DBNull.Value ? string.Empty : dt.Rows[0]["QuotesHeader"].ToString();
        //        ps.QuotesFooter = dt.Rows[0]["QuotesFooter"] == DBNull.Value ? string.Empty : dt.Rows[0]["QuotesFooter"].ToString();

        //        ps.CostPerMode = dt.Rows[0]["CostPerModeId"] == DBNull.Value ? CostPerModes.Basic : (CostPerModes)Convert.ToInt32(dt.Rows[0]["CostPerModeId"]);

        //        string[] lTerms = dt.Rows[0]["LeaseTerms"].ToString().Split(',');
        //        foreach (string s in lTerms)
        //        {
        //            int ti = 0;
        //            if (int.TryParse(s, out ti))
        //            {
        //                ps.LeaseTerms.Add(ti);
        //            }
        //        }

        //        ps.BrochuresEnabled = dt.Rows[0]["BrochuresEnabled"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["BrochuresEnabled"]);
        //        ps.PortalAccountEnabled = dt.Rows[0]["PortalAccountEnabled"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["PortalAccountEnabled"]);

        //        ps.AppendBrochuresToARTemplate = dt.Rows[0]["AppendBrochuresToARTemplate"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["AppendBrochuresToARTemplate"]);
        //        ps.FitBrochureToSinglePagePDF = dt.Rows[0]["FitBrochureToSinglePagePDF"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["FitBrochureToSinglePagePDF"]);

        //        ps.CreationEmailSubject = dt.Rows[0]["CreationEmailSubject"] == DBNull.Value ? string.Empty : dt.Rows[0]["CreationEmailSubject"].ToString();
        //        ps.CreationEmailContent = dt.Rows[0]["CreationEmailContent"] == DBNull.Value ? string.Empty : dt.Rows[0]["CreationEmailContent"].ToString();
        //        ps.ResetEmailSubject = dt.Rows[0]["ResetEmailSubject"] == DBNull.Value ? string.Empty : dt.Rows[0]["ResetEmailSubject"].ToString();
        //        ps.ResetEmailContent = dt.Rows[0]["ResetEmailContent"] == DBNull.Value ? string.Empty : dt.Rows[0]["ResetEmailContent"].ToString();

        //        ps.LeadTrackingType = dt.Rows[0]["LeadTrackingType"] == DBNull.Value ? LeadTrackingType.Off : (LeadTrackingType)Convert.ToInt32(dt.Rows[0]["LeadTrackingType"]);
        //        ps.LeadUpdateTypeId = dt.Rows[0]["LeadUpdateTypeId"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["LeadUpdateTypeId"]);
        //        ps.MarketSegment = dt.Rows[0]["MarketSegmentId"] == DBNull.Value ? MarketSegment.Senior : (MarketSegment)Convert.ToInt32(dt.Rows[0]["MarketSegmentId"]);
        //    }
        //    if (ds.Tables[2].Rows.Count > 0)
        //    {
        //        dt = ds.Tables[2];
        //        ps.IncludeLeasingContest = Convert.ToBoolean(dt.Rows[0]["IncludeLeasingContest"]);

        //        EmailPreferences pef = new EmailPreferences();
        //        pef.PropertyId = (int)dt.Rows[0]["PropertyID"];
        //        pef.Email = dt.Rows[0]["EmailFrom"] as string;
        //        pef.PerLeadText = Convert.ToBoolean(dt.Rows[0]["PerLeadText"]);
        //        pef.PerLeadReport = Convert.ToBoolean(dt.Rows[0]["PerLeadReport"]);
        //        pef.AutoResponse = Convert.ToBoolean(dt.Rows[0]["AutoReply"]);

        //        pef.DefaultEmailSubject = (dt.Rows[0]["DefaultEmailSubject"]) as string;
        //        pef.AutoResponseEmailSubject = (dt.Rows[0]["AutoResponseEmailSubject"]) as string;
        //        pef.AutoResponseAppointments = dt.Rows[0]["AutoResponseAppointmentsEnabled"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["AutoResponseAppointmentsEnabled"]);
        //        pef.EmailTracking = dt.Rows[0]["EmailTrackingEnabled"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["EmailTrackingEnabled"]);
        //        pef.EmailTrackingPrefix = (dt.Rows[0]["EmailTrackingPrefix"]) as string; ;
        //        pef.EmailTrackingDomain = (dt.Rows[0]["EmailTrackingDomain"]) as string; ;

        //        ps.EmailPreferences = pef;
        //    }

        //    if (ps.ApplicationVendorID != 0 && ds.Tables[3].Rows.Count > 0)
        //    {
        //        dt = ds.Tables[3];
        //        ps.ApplicationVendorName = dt.Rows[0]["QuotesAndAvailabilityProvider"] as string;
        //    }

        //    if (ds.Tables[4].Rows.Count > 0)
        //    {
        //        dt = ds.Tables[4];
        //        ps.ExternalAvailabilityURL = dt.Rows[0]["URL"] as string;
        //    }
           
        //    return ps;
        //}

        //public static List<ReportRecipient> ReportRecipients(int aPropertyID)
        //{
        //    List<ReportRecipient> rr = new List<ReportRecipient>();

        //    DataTable dt = DynamicSproc("[Property_ReportRecipients_Select]", aPropertyID).Tables[0];

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        ReportRecipient r = new ReportRecipient();
        //        r.DisplayTitle = dr["NameAndEmail"] as string;
        //        r.Email = dr["Email"] as string;
        //        r.Name = dr["Name"] as string;
        //        r.RecipientId = (int)dr["RecipientId"];
        //        r.PropertyId = (int)dr["PropertyId"];
        //        rr.Add(r);
        //    }

        //    return rr;
        //}

        //public static DataTable GetReportableAgents(int propertyId)
        //{
        //    DataSet ds = DynamicSproc("[Property_GetReportableAgents]", propertyId);

        //    return ds.Tables[0];
        //}
        //public static DataSet GetGoLiveDateData(int propertyId)
        //{
        //    DataSet ds = DynamicSproc("[BB_GetGoLiveDateData]", propertyId);

        //    return ds;
        //}

        //public static string GetManagementForTheProperty(int propertyId)
        //{
        //    DataSet ds = DynamicSproc("[GetManagementForTheProperty]", propertyId);
        //    string managementId = "0";
        //    if (ds != null)
        //        if (ds.Tables[0].Rows.Count > 0)
        //            managementId = ds.Tables[0].Rows[0]["AccountId"].ToString();
        //    return managementId;
        //}     
    }
}