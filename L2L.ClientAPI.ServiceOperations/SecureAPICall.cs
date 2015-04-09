using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using L2L.API.ServiceOperations;
using L2L.ClassLibrary.Objects.Property;
using L2L.EntLib;
using System.Data;
using System.Runtime.Serialization.Formatters;
using L2L.ClassLibrary.Objects.Property.Settings;
using System.Web.Security;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Collections;
namespace L2L.ClientAPI.ServiceOperations
{
    public class SecureAPICall: ISecureAPICall
    {

        HttpClient client;
        string sHeaderAuthorizationKey;

        public SecureAPICall()
        {
            FormsAuthenticationTicket formsTicket = new FormsAuthenticationTicket(System.Configuration.ConfigurationManager.AppSettings["L2L-User"], false, 30);
            string sEncryptedTicket = FormsAuthentication.Encrypt(formsTicket);
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            handler.CookieContainer.Add(new Uri(System.Configuration.ConfigurationManager.AppSettings["apiUrl"]), new Cookie(FormsAuthentication.FormsCookieName, sEncryptedTicket));
            client = new HttpClient(handler);
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["apiUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromTicks(18000000000); // Timeout 30 minutes for max time client to wait for response this can also be decreased
            sHeaderAuthorizationKey = "L2L-Authorization-Key";// System.Configuration.ConfigurationManager.AppSettings["L2LAuthorizationKey"];
        }

        //public RestClient(Uri baseUri)
        //{
        //    BaseUri = baseUri;
        //}
        //public RestClient(Uri baseUri, string token)
        //{
        //    Token = token;
        //    BaseUri = baseUri;
        //}
        // response = new HttpResponseMessage();

        //static HttpClient client = new HttpClient();

        void GetChallengeAndFormHeaderAuthorizationKey()
        {

            string sJsonResult = string.Empty;
            string[] sArdelimiter = new string[] { sDelimiter };
            string encryptedChallenge = string.Empty;

            HttpResponseMessage response = client.GetAsync("api/property/GetChallenge").Result;

            if (response.IsSuccessStatusCode)
            {
                sJsonResult = response.Content.ReadAsAsync<string>().Result;
            }
            if (sJsonResult != string.Empty)
            {
                string[] sChallengeSalt = sJsonResult.Split(sArdelimiter, StringSplitOptions.None);
                L2LEncrypt ciper = new L2LEncrypt();
                string sHashPwd = ciper.Compute(System.Configuration.ConfigurationManager.AppSettings["L2L-Pwd"], sChallengeSalt[1]);
                encryptedChallenge = EncryptChallenge(sChallengeSalt[0], System.Configuration.ConfigurationManager.AppSettings["L2L-User"], sHashPwd);
            }
            KeyValuePair<string, string> L2LAuthorizationKey = new KeyValuePair<string, string>(sHeaderAuthorizationKey, encryptedChallenge);
            if (client.DefaultRequestHeaders.Contains(L2LAuthorizationKey.Key))
                client.DefaultRequestHeaders.Remove(L2LAuthorizationKey.Key);            
            client.DefaultRequestHeaders.Add(L2LAuthorizationKey.Key, L2LAuthorizationKey.Value);
        }


        public string APIVersion()
        {
            string sTaskResult = string.Empty;
            GetChallengeAndFormHeaderAuthorizationKey();
            HttpResponseMessage response = client.GetAsync("api/property/APIVersion").Result;
            if (response.IsSuccessStatusCode)
            {
                sTaskResult = response.Content.ReadAsAsync<string>().Result;
            }
            else
                sTaskResult = response.RequestMessage.ToString();
            return sTaskResult;
        }


        public int? GetL2LPropertyIdForProviderUser(string propertyKey, int userId)
        {

            int sOutResult = int.MinValue;
            //KeyValuePair<string, string> L2LAuthorizationKey = new KeyValuePair<string, string>(sHeaderAuthorizationKey, GetChallengeAndFormAuthorizationKey());
            //if (client.DefaultRequestHeaders.Contains(L2LAuthorizationKey.Key))
            //    client.DefaultRequestHeaders.Remove(L2LAuthorizationKey.Key);
            //client.DefaultRequestHeaders.Add(L2LAuthorizationKey.Key, L2LAuthorizationKey.Value);
            GetChallengeAndFormHeaderAuthorizationKey();
            HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetPropertyId/{0}/{1}", propertyKey, userId)).Result;
            if (response.IsSuccessStatusCode)
            {
                sOutResult = response.Content.ReadAsAsync<int>().Result;
            }
            if (sOutResult != int.MinValue)
                return sOutResult;
            else
                return null;
        }

        public void AddLeaseStarMapping(int propertyId, string propertyKey, string secondKey, bool async = false)
        {
            string sOutResult = string.Empty;
            GetChallengeAndFormHeaderAuthorizationKey();
            var sContent = new StringContent("nothing as content");
            HttpResponseMessage response = client.PostAsync(String.Format("api/property/AddLeaseStarMapping/{0}/{1}/{2}/{3}", propertyId, propertyKey, secondKey, async), sContent).Result;
            if (response.IsSuccessStatusCode)
            {
                sOutResult = response.Content.ReadAsAsync<string>().Result;
            }
            else
            {
                sOutResult = response.RequestMessage.ToString();
            }
        }

        public int? GetLeaseStarMapping(string propertyKey, bool async = false)
        {
            int iOutResult = int.MinValue;
            GetChallengeAndFormHeaderAuthorizationKey();
            var sContent = new StringContent("nothing as content");
            HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetLeaseStarMapping/{0}/{1}", propertyKey, async)).Result;
            if (response.IsSuccessStatusCode)
            {
                iOutResult = response.Content.ReadAsAsync<int>().Result;
            }
            if (iOutResult != int.MinValue)
                return iOutResult;
            else
                return null;
        }

        public int? CreatePropertyShell(short providerID, int accountId, int managementId, string leaseStarPropertyId, string propertyName,
                                  string address, string city, string state, string zip, string phone, string email,
                                  byte baseProductTypeId, byte subscriptionTypeId)
        {
            return null;
        }

        public DataSet GetResponseSettings(int propertyId)
        {
            DataSet dsOut = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetResponseSettings/{0}", propertyId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    dsOut = JsonConvert.DeserializeObject<DataSet>(((JObject)oJSON).ToString());
                    return dsOut;
                }
            }
            catch (Exception ex)
            {
                new UnhandledExceptionEventArgs(ex, false);
            }
            return dsOut;
        }

        public DataSet ListPolicies(int propertyId)
        {
            DataSet dsOut = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/ListPolicies/{0}", propertyId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    // json = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result, settings);
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    dsOut = JsonConvert.DeserializeObject<DataSet>(((JObject)oJSON).ToString());
                    return dsOut;
                }
            }
            catch (Exception ex)
            {
                new UnhandledExceptionEventArgs(ex, false);
                client.CancelPendingRequests();
            }
            return dsOut;
        }

        public List<int> GetLeaseTerms(int propertyId, bool refreshList)
        {
            List<int> lTerms = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetLeaseTerms/{0}/{1}", propertyId, refreshList)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    lTerms = JsonConvert.DeserializeObject<List<int>>(((JArray)oJSON).ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return lTerms;
        }

        public DataSet GetAccountSettings(int propertyId, string dummyArg = null)
        {
            DataSet dsOut = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetAccountSettings/{0}/{1}", propertyId, dummyArg)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    dsOut = JsonConvert.DeserializeObject<DataSet>(((JObject)oJSON).ToString());
                    return dsOut;
                }
            }
            catch (Exception ex)
            {
                new UnhandledExceptionEventArgs(ex, false);
            }
            return dsOut;
        }

        public L2L.ClassLibrary.Objects.Property.PropertySettings GetL2LPropertySettings(int propertyID, int? dummyArg = null)
        {
            PropertySettings propertySettings = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = dummyArg == null ? client.GetAsync(String.Format("api/property/GetL2LPropertySettings/{0}", propertyID)).Result : client.GetAsync("api/property/GetL2LPropertySettings/" + propertyID.ToString() + "/" + dummyArg.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    //json = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result, settings);
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    propertySettings = serializer.Deserialize<PropertySettings>(((JObject)oJSON).ToString());

                    //propertySettings = JsonConvert.DeserializeObject<PropertySettings>(((JObject)oJSON).ToString());


                    string output = JsonConvert.SerializeObject(((JObject)oJSON).ToString(), Formatting.Indented, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
                    });

                    propertySettings = serializer.Deserialize<PropertySettings>(output);
                    //propertySettings = JsonConvert.DeserializeObject<PropertySettings>(output, new JsonSerializerSettings{
                    //TypeNameHandling = TypeNameHandling.All,
                    //TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple});


                    //Newtonsoft.Json.Serialization.JavaScriptSerializer() _Serialize = new JavaScriptSerializer();


                    return propertySettings;
                }

            }
            catch (Exception ex)
            {
                new UnhandledExceptionEventArgs(ex, false);
            }
            return propertySettings;
        }

        public void UpdatePropertySettingsLeadTrackingType(int leaseStarPropertyId, byte leadTrackingTypeId)
        {
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/UpdatePropertySettingsLeadTrackingType/{0}/{1}", leaseStarPropertyId, leadTrackingTypeId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    // json = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result, settings);
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                }
            }
            catch (Exception ex)
            {
                new UnhandledExceptionEventArgs(ex, false);
                client.CancelPendingRequests();
            }
            finally
            {
                client.CancelPendingRequests();
            }
        }


        public void GenerateAndSaveAccountPreferenceEmails(int propertyId, string propertyName, string companyName, string emailFrom)
        {
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GenerateAndSaveAccountPreferenceEmails/{0}/{1}/{2}/{3}", propertyId, propertyName, companyName, emailFrom)).Result;
                if (!response.IsSuccessStatusCode)
                {
                    //    // json = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result, settings);
                    //    //var oJSON = response.Content.ReadAsAsync<object>().Result;
                    //throw new UnhandledExceptionEventArgs(ex,false);
                }

            }
            catch (Exception ex)
            {
                new UnhandledExceptionEventArgs(ex, false);
            }
        }

        public string GetLeadTrackingEmail(int propertyId)
        {
            string sTaskResult = string.Empty;
            GetChallengeAndFormHeaderAuthorizationKey();
            HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetLeadTrackingEmail/{0}", propertyId)).Result;
            if (response.IsSuccessStatusCode)
            {
                sTaskResult = response.Content.ReadAsAsync<string>().Result;
            }
            else
                sTaskResult = response.RequestMessage.ToString();

            return sTaskResult;
        }

        public object GetProperty(int propertyId)
        {
            object oProperty = null;
            GetChallengeAndFormHeaderAuthorizationKey();
            HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetProperty/{0}", propertyId)).Result;
            if (response.IsSuccessStatusCode)
            {
                oProperty = response.Content.ReadAsAsync<object>().Result;
            }

            return oProperty;
        }


        public BB_PropertySettings GetPropertySettingsByLeaseStarPropID(int leaseStarPropertyId)
        {
            BB_PropertySettings propertySettings = new BB_PropertySettings();
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetPropertySettingsByLeaseStarPropID/{0}", leaseStarPropertyId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    //json = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result, settings);
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    JsonSerializerSettings configSerialize = new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                        //ObjectCreationHandling = ObjectCreationHandling.Replace
                        TypeNameHandling = TypeNameHandling.All,
                        TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
                    };
                    JsonConvert.PopulateObject(((JObject)oJSON).ToString(), propertySettings);
                    //string output = JsonConvert.SerializeObject(((JObject)oJSON).ToString(), Formatting.Indented, new JsonSerializerSettings
                    //{
                    //    TypeNameHandling = TypeNameHandling.All,
                    //    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
                    //});
                    // propertySettings = serializer.Deserialize<BB_PropertySettings>(output);
                    //propertySettings = JsonConvert.DeserializeObject<BB_PropertySettings>(output, new JsonSerializerSettings{
                    //    TypeNameHandling = TypeNameHandling.All,
                    //    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
                    //});


                    //Newtonsoft.Json.Serialization.JavaScriptSerializer() _Serialize = new JavaScriptSerializer();


                    return propertySettings;
                }

            }
            catch (Exception ex)
            {
                new UnhandledExceptionEventArgs(ex, false);
            }
            return null;
        }

        public PropertySettings GetPropertySettings(int propId)
        {
            PropertySettings propertySettings = new PropertySettings();
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetPropertySettings/{0}", propId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    //json = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result, settings);
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    //iPropertySettings = JsonConvert.DeserializeObject<L2L.ClassLibrary.Objects.Property.Settings.IPropertySettings>(((JObject)oJSON).ToString());                    
                    //JavaScriptSerializer ser = new JavaScriptSerializer();                                       
                    //var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    // propertySettings = serializer.Deserialize<PropertySettings>(text);

                    string sJSON = oJSON.ToString();
                    //propertySettings = serializer.Deserialize<PropertySettings>(sJSON);
                    //while (propertySettings.AvailableLookupTypes == null)
                    //{
                    //    if (propertySettings.AvailableLookupTypes != null)
                    //    {
                    JsonSerializerSettings configSerialize = new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                        //ObjectCreationHandling = ObjectCreationHandling.Replace
                        //TypeNameHandling = TypeNameHandling.All,
                        TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
                    };
                    JsonConvert.PopulateObject(sJSON, propertySettings, configSerialize);
                    //    }
                    //}            
                    return propertySettings;
                }

            }
            catch (Exception ex)
            {
                new UnhandledExceptionEventArgs(ex, false);
            }
            return null;
        }


        public IList<VerbiageTopic> GetVerbiageTopicsFor(int catId)
        {
            IList<VerbiageTopic> lVerbiageTopics = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetVerbiageTopicsFor/{0}", catId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    lVerbiageTopics = JsonConvert.DeserializeObject<IList<VerbiageTopic>>(((JArray)oJSON).ToString());
                }
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException();
            }
            return lVerbiageTopics;
        }

        public IList<VerbiageKeyWord> GetVerbiageKeyWordsFor(int topicId)
        {
            IList<VerbiageKeyWord> lVerbiageKeyWord = null;
            try
            {                
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetVerbiageKeyWordsFor/{0}", topicId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    lVerbiageKeyWord = JsonConvert.DeserializeObject<IList<VerbiageKeyWord>>(((JArray)oJSON).ToString());
                }
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException();
            }
            return lVerbiageKeyWord;
        }


        public VerbiageTopic GetVerbiageTopicFor(int topicId)
        {
            VerbiageTopic verbiageTopic = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();           
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetVerbiageTopicFor/{0}", topicId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    verbiageTopic = JsonConvert.DeserializeObject<VerbiageTopic>(((JObject)oJSON).ToString());
                }
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException();
            }
            return verbiageTopic;
        }

        public IList<CustomGroup> GetPropertyHintsAndTips(int propId)
        {
            IList<CustomGroup> ilCustomGroup = null;

            try
            {                
                GetChallengeAndFormHeaderAuthorizationKey();
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetPropertyHintsAndTips/{0}", propId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    ilCustomGroup = JsonConvert.DeserializeObject<IList<CustomGroup>>(((JArray)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return ilCustomGroup;
        }

        public int? AddSettingsCategoryFor(int propertyId, string catName)
        {
            int? addResult = null;
            try
            {
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                GetChallengeAndFormHeaderAuthorizationKey();
                //HttpResponseMessage response = client.GetAsync(String.Format("api/property/AddSettingsCategoryFor/{0}/{1}", propertyId,catName)).Result;
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/AddSettingsCategoryFor/{0}/{1}", propertyId, catName), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    addResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return addResult;
        }


        public int? AddSettingsTopicFor(int catId, string topicName, string verbText = "")
        {
            int? addResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                //HttpResponseMessage response = client.GetAsync(String.Format("api/property/AddSettingsCategoryFor/{0}/{1}", propertyId,catName)).Result;
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/AddSettingsTopicFor/{0}/{1}/{2}", catId, topicName, verbText), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    addResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return addResult;
        }

        /// <summary>
        /// Adding a Settings Keyword
        /// </summary>
        /// <param name="topicId"></param>
        /// <param name="keyWordName"></param>
        /// <returns></returns>
        public int? AddSettingsKeyWordFor(int topicId, string keyWordName)
        {
            int? addResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();                
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/AddSettingsKeyWordFor/{0}/{1}", topicId, keyWordName), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    addResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return addResult;
        }     


        public int? UpdateSettingsCategoryFor(int propertyId, int catId, string catName, VerbiageCategory[] categories = null)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();                
                var sContent = new StringContent("empty");
                //HttpResponseMessage response = client.PostAsJsonAsync(String.Format("api/property/UpdateSettingsCategoryFor/{0}/{1}/{2}", propertyId, catId, catName), ContentMethod()).Result;

                HttpResponseMessage response = client.PostAsync(String.Format("api/property/UpdateSettingsCategoryFor/{0}/{1}/{2}", propertyId, catId, catName), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public int? UpdateSettingsTopicFor(int topicId, string topicName, string verbText = "")
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();                
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/UpdateSettingsTopicFor/{0}/{1}/{2}", topicId, topicName, verbText), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }


        public int? UpdateSettingsKeyWordFor(int topicId, int keyWordId, string keyWordName)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();                
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/UpdateSettingsKeyWordFor/{0}/{1}/{2}", topicId, keyWordId, keyWordName), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;

        }

        public int? DeleteSettingsCategoryFor(int propertyId, int catId)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();                
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/DeleteSettingsCategoryFor/{0}/{1}", propertyId, catId), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public int? DeleteSettingsTopicFor(int catId, int topicId)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();                
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/DeleteSettingsTopicFor/{0}/{1}", catId, topicId), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public int? DeleteSettingsKeyWordFor(int catId, int topicId)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/DeleteSettingsKeyWordFor/{0}/{1}", catId, topicId), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }


        public int? DeleteHintsAndTipsSection(int propertyId, int id)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/DeleteHintsAndTipsSection/{0}/{1}", propertyId, id), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public int? DeleteHintsAndTipsCustomField(int propertyId, int sectionId, int fieldId)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/DeleteHintsAndTipsCustomField/{0}/{1}/{2}", propertyId, sectionId, fieldId), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public int? UpdateLeaseTermsPropertySettings(int propId, string leaseTerms)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/UpdateLeaseTermsPropertySettings/{0}/{1}", propId, leaseTerms), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public int? UpdateAutoResponderSetting(AutoResponder autoResp)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsJsonAsync("api/property/UpdateAutoResponderSetting", autoResp).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }



        public int? UpdateCallsSetting(int propertyId, DateTime callerDuration, bool clickOnCallEnabled)
        {
            int? responseResult = null;
            try
            {//UpdateCallsSetting/{propertyId}/{callerDuration:DateTime}/{clickOnCallEnabled}
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                var sContent = new StringContent("empty content");
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/UpdateCallsSetting/{0}/{1}/{2}", propertyId, callerDuration.Ticks, clickOnCallEnabled), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }


        public int? UpdateEmailSetting(EmailPreferences emailPref)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.PostAsJsonAsync("api/property/UpdateEmailSetting", emailPref).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }


        public int? AddPropertySettingsEmailRecipient(int propId, string email)
        {
            var sContent = new StringContent("empty content");
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/AddPropertySettingsEmailRecipient/{0}/{1}", propId, email), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }


        public int? DeletePropertySettingEmailRecipient(int propertyId, int recipientId)
        {
            var sContent = new StringContent("empty content");
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/DeletePropertySettingEmailRecipient/{0}/{1}", propertyId, recipientId), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public int? DeleteTourHoursSetting(int propertyId, int[] tourDays)
        {
            var sContent = new StringContent("empty content");
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.PostAsJsonAsync(String.Format("api/property/DeleteTourHoursSetting/{0}", propertyId), tourDays).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public int? UpdateAlertsSettings(IPropertySettings ps)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.PostAsJsonAsync(" api/property/UpdateAlertsSettings", ps).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public int? SaveTourHoursSetting(int propertyId, IList<TourHours> tourHours)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.PostAsJsonAsync(String.Format("api/property/SaveTourHoursSetting/{0}", propertyId), tourHours).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public int? SaveAdminHintsAndTipsSetting(int propertyId, IList<CustomGroup> groups)
        {
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.PostAsJsonAsync(String.Format("api/property/SaveAdminHintsAndTipsSetting/{0}", propertyId), groups).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public int? UpdatePreferencePropertySettings(int propId, bool showHintsAndTipsOnAddProspect, bool showHintsAndTipsOnGuestCard)
        {
            var sContent = new StringContent("empty");
            int? responseResult = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.PostAsync(String.Format("api/property/UpdatePreferencePropertySettings/{0}/{1}/{2}", propId, showHintsAndTipsOnAddProspect, showHintsAndTipsOnGuestCard), sContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    responseResult = JsonConvert.DeserializeObject<int>(((long)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return responseResult;
        }

        public void SavePropertySync(int userId, PropertySync syncData)
        {
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.PostAsJsonAsync(String.Format("api/property/SavePropertySync/{0}", userId), syncData).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    //JsonConvert.DeserializeObject<string>(((string)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
        }

        public GuestcardSettings GetGuestcardSettings(int guestcardId)
        {
            GuestcardSettings oGuestCardSettings = null;            
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetGuestcardSettings/{0}", guestcardId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    //JsonConvert.DeserializeObject<string>(((string)oJSON).ToString());
                    //lVerbiageTopics = JsonConvert.DeserializeObject<IList<VerbiageTopic>>(((JArray)oJSON).ToString());
                    oGuestCardSettings = JsonConvert.DeserializeObject<GuestcardSettings>(((JObject)oJSON).ToString());
                }

            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return oGuestCardSettings;
        }

        public List<GoogleTracking> GetGuestcardTrackingCode(int propertyId)
        {
            List<GoogleTracking> lGoogleTracking = null;            
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetGuestcardTrackingCode/{0}", propertyId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    lGoogleTracking = JsonConvert.DeserializeObject<List<GoogleTracking>>(((JArray)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return lGoogleTracking;
        }

        public PropertyPreference GetPropertyPreferenceSettings(int propertyId)
        {
            PropertyPreference oPropertyPreference = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetProperyPreferenceSettings/{0}", propertyId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    oPropertyPreference = JsonConvert.DeserializeObject<PropertyPreference>(((JObject)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return oPropertyPreference;
        }

        public L2L.API.Shared.Interfaces.Property.IOfficeSetting GetPropertyOfficeHours(int propertyId)
        {
            L2L.API.Shared.Interfaces.Property.IOfficeSetting oIOfficeSetting = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetPropertyOfficeHours/{0}", propertyId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    oIOfficeSetting = JsonConvert.DeserializeObject<L2L.API.Shared.Interfaces.Property.IOfficeSetting>(((JObject)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return oIOfficeSetting;
        }


        public IList<CustomArea> GetPropertySupplementaryFields(int propertyId)
        {
            IList<CustomArea> ilCustomArea = null;
            try
            {
                GetChallengeAndFormHeaderAuthorizationKey();
                //client.DefaultRequestHeaders.Add("L2L-Authorization-Key", GetChallengeAndFormAuthorizationKey());
                HttpResponseMessage response = client.GetAsync(String.Format("api/property/GetPropertySupplementaryFields/{0}", propertyId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var oJSON = response.Content.ReadAsAsync<object>().Result;
                    ilCustomArea = JsonConvert.DeserializeObject<IList<CustomArea>>(((JArray)oJSON).ToString());
                }
            }
            catch (ApplicationException ex)
            {
                throw new UnauthorizedAccessException();
            }
            return ilCustomArea;
        }




        public class RestClientException : Exception
        {
            public enum StatusEnum { ConnectionError = -2, ServerError = -3 }
            public StatusEnum Status { get; set; }
            public RestClientException(StatusEnum status, string message)
                : base(message)
            {
                Status = status;
            }
        }

        #region Cryptographic functions

        const string sDelimiter = "[@$-}";
        const int keysize = 256;
        string EncryptChallenge(string sPlainKey, string sUserName, string sPassword)
        {
            DateTime dtCreated = DateTime.UtcNow;
            string sCreatedTime = dtCreated.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            return Encrypt(sPlainKey, (sUserName + sDelimiter + sPassword));
        }
        
        string Encrypt(string Text, string Key)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(Key.Substring(0, 16));
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(Text);
            PasswordDeriveBytes password = new PasswordDeriveBytes(Key, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] Encrypted = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(Encrypted);
        }

        //public static string[] DecryptCredentials(string sEncryptedText, string sKey)
        //{
        //    string[] sArdelimiter = new string[] { sDelimiter };
        //    string sPlainText = Decrypt(sEncryptedText, sKey);
        //    string[] sCredentials = (sPlainText).Split(sArdelimiter, StringSplitOptions.None);
        //    return sCredentials;
        //}

        
        
        //public static string Decrypt(string EncryptedText, string Key)
        //{            
        //    byte[] initVectorBytes = Encoding.ASCII.GetBytes(Key);
        //    byte[] DeEncryptedText = Convert.FromBase64String(EncryptedText);

            
        //    PasswordDeriveBytes password = new PasswordDeriveBytes(Key, null);
        //    byte[] keyBytes = password.GetBytes(keysize / 8);
        //    RijndaelManaged symmetricKey = new RijndaelManaged();
        //    symmetricKey.Mode = CipherMode.CBC;
        //    ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
        //    MemoryStream memoryStream = new MemoryStream(DeEncryptedText);
        //    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        //    byte[] plainTextBytes = new byte[DeEncryptedText.Length];
        //    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        //    memoryStream.Close();
        //    cryptoStream.Close();
        //    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        //}
    
        //public static string Encode(string toEncode)
        //{
        //    byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
        //    string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
        //    return returnValue;

        //}

        //public static string Decode(string encodedData)
        //{
        //    byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
        //    string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
        //    return returnValue;
        //}

        private static string ComputeHashedCredentials(string sPlainString, string sSalt)
        {
            using (var sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(sPlainString + sSalt));
                return Convert.ToBase64String(computedHash);
            }
        }

        #endregion


    }
}
