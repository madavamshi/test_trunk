using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using L2L.ClassLibrary.Objects.Site;
using LibProp = L2L.ClassLibrary.Objects.Property;

namespace L2L.ClassLibrary.Data.LookupList
{
    public class Selects //: SharedFunctions.DataHandler.SQL_Base
    {
        //public static DataSet GetLookupList(int l2lPropertyId, bool? activeOnly, List<string> entityList, List<int> listTypes, List<int> listIds)
        //{
        //    List<SqlParameter> sParams = new List<SqlParameter>();
        //    sParams.Add(new SqlParameter("@PropertyId", SqlDbType.Int));

        //    sParams[0].Value = l2lPropertyId;
        //    int i = 1;
        //    if (activeOnly.HasValue)
        //    {
        //        sParams.Add(new SqlParameter("@IsActive", SqlDbType.Bit));
        //        sParams[i].Value = activeOnly.Value ? 1 : 0;

        //        i++;
        //    }

        //    if (listTypes != null && listTypes.Count > 0)
        //    {
        //        DataTable dt = new DataTable("ListTypes");
        //        dt.Columns.Add("ID", typeof(int));
        //        for (int j = 0; j < listTypes.Count; j++)
        //        {
        //            DataRow dr = dt.NewRow();
        //            dr[0] = listTypes[j];
        //            dt.Rows.Add(dr);
        //        }
        //        sParams.Add(new SqlParameter("@ListTypes", SqlDbType.Structured));
        //        sParams[i].Value = dt;
        //        i++;
        //    }

        //    if (listIds != null && listIds.Count > 0)
        //    {
        //        DataTable dt = new DataTable("ListIds");
        //        dt.Columns.Add("ID", typeof(int));
        //        for (int j = 0; j < listIds.Count; j++)
        //        {
        //            DataRow dr = dt.NewRow();
        //            dr[0] = listIds[j];
        //            dt.Rows.Add(dr);
        //        }
        //        sParams.Add(new SqlParameter("@ListIds", SqlDbType.Structured));
        //        sParams[i].Value = dt;
        //        i++;
        //    }

        //    if (entityList != null && entityList.Count > 0)
        //    {
        //        DataTable dt = new DataTable("Entities");
        //        dt.Columns.Add("Param", typeof(string));
        //        for (int j = 0; j < entityList.Count; j++)
        //        {
        //            DataRow dr = dt.NewRow();
        //            dr[0] = entityList[j];
        //            dt.Rows.Add(dr);
        //        }
        //        sParams.Add(new SqlParameter("@LookupParts", SqlDbType.Structured));
        //        sParams[i].Value = dt;
        //    }

        //    DataSet ds = GetDataSet("LookupListsAndTypes_Get", sParams.ToArray());
        //    return ds;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l2lPropertyId"></param>
        /// <param name="activeOnly"></param>
        /// <param name="entityList">Current possbile values: LookupListType, LookupList, PropertyLookupListTypes, PropertyLookupLists, LookupDefaultList</param>
        /// <param name="listTypes"></param>
        /// <param name="listIds"></param>
        /// <returns></returns>
        //public static LibProp.LookupListContainer GetLookupListObjects(int l2lPropertyId, bool? activeOnly, List<string> entityList, List<int> listTypes, List<int> listIds)
        //{
        //    LibProp.LookupListContainer container = new LibProp.LookupListContainer()
        //    {
        //        LookupListTypeEntries = null,
        //        LookupListEntries = null,
        //        PropertyLookupListTypes = null,
        //        PropertyLookupLists = null,
        //        LookupDefaultListEntries = null
        //    };

        //    DataSet ds = GetLookupList(l2lPropertyId, activeOnly, entityList, listTypes, listIds);
        //    if (ds == null || ds.Tables.Count == 0)
        //        throw new Exception("No lookup settings were found");

        //    int currentTableIndex = 0;

        //    if (entityList.Contains("LookupListType"))
        //    {
        //        container.LookupListTypeEntries = new List<LibProp.LookupListType>();

        //        foreach (DataRow dr in ds.Tables[currentTableIndex].Rows)
        //        {
        //            LibProp.LookupListType llt = new LibProp.LookupListType();
        //            llt.Id = Convert.ToInt32(dr["ListTypeId"]);
        //            llt.ListType = dr["ListType"].ToString();
        //            llt.DisplayTitle = dr["DisplayTitle"].ToString();
        //            llt.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //            llt.IsSecured = Convert.ToBoolean(dr["IsSecured"]);
        //            container.LookupListTypeEntries.Add(llt);
        //        }

        //        currentTableIndex++;
        //    }

        //    if (entityList.Contains("LookupList"))
        //    {
        //        container.LookupListEntries = new List<LibProp.LookupListSetup>();

        //        foreach (DataRow dr in ds.Tables[currentTableIndex].Rows)
        //        {
        //            LibProp.LookupListSetup ll = new LibProp.LookupListSetup();
        //            ll.ListId = Convert.ToInt32(dr["ListId"]);
        //            ll.ListDesc = dr["ListDescription"].ToString();
        //            ll.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //            container.LookupListEntries.Add(ll);
        //        }

        //        currentTableIndex++;
        //    }

        //    if (entityList.Contains("PropertyLookupLists"))
        //    {
        //        container.PropertyLookupListTypes = new List<LibProp.PropertyLookupListType>();
        //        container.PropertyLookupLists = new List<LibProp.PropertyLookupList>();

        //        foreach (DataRow dr in ds.Tables[currentTableIndex].Rows)
        //        {
        //            LibProp.PropertyLookupListType pll = new LibProp.PropertyLookupListType();
        //            pll.ListTypeId = Convert.ToInt32(dr["ListTypeId"]);
        //            pll.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //            pll.IsDefault = Convert.ToBoolean(dr["IsDefault"]);
        //            pll.ListType = dr["ListType"].ToString();
        //            pll.CustomFieldTypeId = Convert.ToInt32(dr["CustomFieldTypeId"]);
        //            pll.DisplayTitle = dr["DisplayTitle"].ToString();
        //            pll.IsReadOnly = Convert.ToBoolean(dr["IsReadOnly"]);
        //            pll.IsSecured = Convert.ToBoolean(dr["IsSecured"]);
        //            container.PropertyLookupListTypes.Add(pll);
        //        }

        //        currentTableIndex++;

        //        foreach (DataRow dr in ds.Tables[currentTableIndex].Rows)
        //        {
        //            LibProp.PropertyLookupList pll = new LibProp.PropertyLookupList();
        //            pll.ListTypeId = Convert.ToInt32(dr["ListTypeId"]);
        //            pll.ListId = Convert.ToInt32(dr["ListId"]);
        //            pll.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //            pll.ListDescription = dr["ListDescription"].ToString();
        //            pll.SortOrder = dr["SortOrder"] != DBNull.Value ? Convert.ToInt32(dr["SortOrder"]) : 1;
        //            container.PropertyLookupLists.Add(pll);
        //        }

        //        currentTableIndex++;
        //    }

        //    if (entityList.Contains("LookupDefaultList"))
        //    {
        //        container.LookupDefaultListEntries = new List<LibProp.LookupDefaultList>();

        //        foreach (DataRow dr in ds.Tables[currentTableIndex].Rows)
        //        {
        //            LibProp.LookupDefaultList dl = new LibProp.LookupDefaultList();
        //            dl.ListTypeId = Convert.ToInt32(dr["ListTypeId"]);
        //            dl.ListId = Convert.ToInt32(dr["ListId"]);
        //            dl.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //            container.LookupDefaultListEntries.Add(dl);
        //        }

        //        currentTableIndex++;
        //    }

        //    return container;
        //}

        //public static List<LibProp.ListOption> GetAdminLookupListObjects(int propertyId, int listTypeId)
        //{
        //    List<LibProp.ListOption> options = new List<LibProp.ListOption>();

        //    List<SqlParameter> sParams = new List<SqlParameter>();
        //    sParams.Add(new SqlParameter("@PropertyId", SqlDbType.Int));
        //    sParams.Add(new SqlParameter("@ListTypeId", SqlDbType.Int));
        //    sParams[0].Value = propertyId;
        //    sParams[1].Value = listTypeId;

        //    DataSet ds = GetDataSet("LookupListsAndTypes_GetAdmin", sParams.ToArray());
        //    if (ds != null && ds.Tables.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            options.Add(new LibProp.ListOption()
        //            {
        //                ListId = Convert.ToInt32(dr["ListId"].ToString()),
        //                ListDescription = dr["ListDescription"].ToString(),
        //                IsActive = Convert.ToBoolean(dr["IsActive"].ToString()),
        //                IsDefault = Convert.ToBoolean(dr["IsDefault"].ToString()),
        //                SortOrder = Convert.ToInt32(dr["SortOrder"].ToString())
        //            });
        //        }
        //    }

        //    return options;
        //}
   
        //public static bool PropertyLookupListTypeIsDefault(int propertyId, int listTypeId)
        //{
        //    List<SqlParameter> sParams = new List<SqlParameter>();
        //    sParams.Add(new SqlParameter("@PropertyId", SqlDbType.Int));
        //    sParams.Add(new SqlParameter("@ListTypeId", SqlDbType.Int));
        //    sParams[0].Value = propertyId;
        //    sParams[1].Value = listTypeId;
        //    return Convert.ToBoolean(ExecuteScalar("PropertyLookupListType_IsDefault", sParams.ToArray()));
        //}

        //public static bool LookupListTypeIsSecured(int listTypeId)
        //{
        //    List<SqlParameter> sParams = new List<SqlParameter>();
        //    sParams.Add(new SqlParameter("@ListTypeId", SqlDbType.Int));
        //    sParams[0].Value = listTypeId;
        //    return Convert.ToBoolean(ExecuteScalar("LookupListType_IsSecure", sParams.ToArray()));
        //}

        //public static List<LibProp.LookupListSetup> GetSecuredLookupLists(List<int> listIds)
        //{
        //    List<LibProp.LookupListSetup> lists = new List<LibProp.LookupListSetup>();

        //    List<SqlParameter> sParams = new List<SqlParameter>();
        //    sParams.Add(new SqlParameter("@ListIds", SqlDbType.Structured));
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Id", typeof(int));
        //    foreach (int list in listIds)
        //        dt.Rows.Add(list);
        //    sParams[0].Value = dt;

        //    DataSet ds = GetDataSet("LookupList_Get", sParams.ToArray());
        //    if (ds != null)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            LibProp.LookupListSetup ll = new LibProp.LookupListSetup();
        //            ll.ListId = Convert.ToInt32(dr["ListId"]);
        //            ll.ListDesc = dr["ListDescription"].ToString();
        //            ll.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //            lists.Add(ll);
        //        }
        //    }

        //    return lists;
        //}
     

        //public static DataSet MapLookupList(int propertyId, DataTable dtList, DataTable dtRelation)
        //{
        //    List<SqlParameter> sParams = new List<SqlParameter>();
        //    sParams.Add(new SqlParameter("@PropertyId", SqlDbType.Int));

        //    sParams[0].Value = propertyId;
        //    int i = 1;
        //    if (dtList != null && dtList.Rows.Count > 0)
        //    {
        //        sParams.Add(new SqlParameter("@ListStrings", SqlDbType.Structured));
        //        sParams[i].Value = dtList;
        //        i++;
        //    }

        //    if (dtRelation != null && dtRelation.Rows.Count > 0)
        //    {
        //        sParams.Add(new SqlParameter("@RelationStrings", SqlDbType.Structured));
        //        sParams[i].Value = dtRelation;
        //    }

        //    DataSet ds = GetDataSet("LookupListId_Get", sParams.ToArray());


        //    return ds;
        //}

        // Not sure if this method should site here??
        //public static List<DefaultPageSetting> GetDefaultPageSettingLists()
        //{
        //    List<LibProp.LookupListSetup> lists = new List<LibProp.LookupListSetup>();
        //    DataTable dt = new DataTable();
        //    DataSet ds = GetDataSet("GetDefaultPageSettings");
        //    List<DefaultPageSetting> pageList = new List<DefaultPageSetting>();
        //    if (ds != null)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            pageList.Add(new DefaultPageSetting()
        //            {
        //                Id = (dr.Table.Columns.Contains("DefaultPageSettingId") && dr["DefaultPageSettingId"] != DBNull.Value) ? Convert.ToInt32(dr["DefaultPageSettingId"]) : 1,
        //                DisplayName = (dr.Table.Columns.Contains("DisplayName") && dr["DisplayName"] != DBNull.Value) ? dr["DisplayName"].ToString() : string.Empty,
        //                Controller = (dr.Table.Columns.Contains("Controller") && dr["Controller"] != DBNull.Value) ? dr["Controller"].ToString() : string.Empty,
        //                Action = (dr.Table.Columns.Contains("Action") && dr["Action"] != DBNull.Value) ? dr["Action"].ToString() : string.Empty,
        //                RouteParameter = (dr.Table.Columns.Contains("RouteParameter") && dr["RouteParameter"] != DBNull.Value) ? dr["RouteParameter"].ToString() : string.Empty
        //            }
        //            );
        //        }
        //    }
        //    return pageList;
        //}
    }

}
