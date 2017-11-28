using System;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CRSe.CRS.BLL;
using CRSe.CRS.BO;
using CRSe.ReportService;

namespace CRSe.CRS.DAL
{
    public partial class ReportDB : DBUtils
    {
        #region Fields

        private ReportingService2010 rsMain = null;

        #endregion

        #region Constructors

        public ReportDB()
        {
            if (rsMain == null)
                rsMain = new ReportingService2010() { Url = ReportServiceUrl, Timeout = 300000, Credentials = System.Net.CredentialCache.DefaultCredentials };
        }

        #endregion

        #region Properties
        #endregion

        #region Methods

        public void Dispose()
        {
            if (rsMain != null)
            {
                rsMain.Dispose();
                rsMain = null;
            }
        }

        public bool AddSystemAdmin(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username)
        {
            bool objReturn = false;
            
            try
            {
                if (rsMain == null)
                    rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);

                Role[] roles = rsMain.ListRoles("System", string.Empty);
                if (roles != null)
                {
                    bool foundUser = false;

                    Policy[] policies = rsMain.GetSystemPolicies();
                    if (policies != null)
                    {
                        foreach (Policy policy in policies)
                        {
                            if (policy.GroupUserName.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                            {
                                foundUser = true;
                                policy.Roles = roles;
                                break;
                            }
                        }
                    }

                    if (!foundUser)
                    {
                        Policy policy = new Policy();
                        policy.GroupUserName = username;
                        policy.Roles = roles;
                        AddToArray(ref policies, policy);
                    }

                    rsMain.SetSystemPolicies(policies);
                    objReturn = true;
                }

                LogManager.LogTiming(logDetails);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        public bool AddSystemUser(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username)
        {
            bool objReturn = false;

            try
            {
                if (rsMain == null)
                    rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);

                Role[] roles = rsMain.ListRoles("System", string.Empty);
                if (roles != null)
                {
                    Role[] updatedRoles = roles.Where(role => role.Name != "System Administrator").ToArray<Role>();
                    if (updatedRoles != null)
                    {
                        bool foundUser = false;

                        Policy[] policies = rsMain.GetSystemPolicies();
                        if (policies != null)
                        {
                            foreach (Policy policy in policies)
                            {
                                if (policy.GroupUserName.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    foundUser = true;
                                    policy.Roles = updatedRoles;
                                    break;
                                }
                            }
                        }

                        if (!foundUser)
                        {
                            Policy policy = new Policy();
                            policy.GroupUserName = username;
                            policy.Roles = updatedRoles;
                            AddToArray(ref policies, policy);
                        }

                        rsMain.SetSystemPolicies(policies);
                        objReturn = true;
                    }
                }

                LogManager.LogTiming(logDetails);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        public bool AddItemAdmin(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username, string itemPath)
        {
            bool objReturn = false;

            try
            {
                if (rsMain == null)
                    rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                if (itemPath == "/" || CheckItemExists("Folder", itemPath))
                {
                    LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);

                    Role[] roles = rsMain.ListRoles("Catalog", string.Empty);
                    if (roles != null)
                    {
                        bool foundUser = false;
                        bool inheritParent = false;

                        Policy[] policies = rsMain.GetPolicies(itemPath, out inheritParent);
                        if (policies != null)
                        {
                            foreach (Policy policy in policies)
                            {
                                if (policy.GroupUserName.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    foundUser = true;
                                    policy.Roles = roles;
                                    break;
                                }
                            }
                        }

                        if (!foundUser)
                        {
                            Policy policy = new Policy();
                            policy.GroupUserName = username;
                            policy.Roles = roles;
                            AddToArray(ref policies, policy);
                        }

                        rsMain.SetPolicies(itemPath, policies);
                        objReturn = true;
                    }
                    
                    LogManager.LogTiming(logDetails);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        public bool AddItemUpdate(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username, string itemPath)
        {
            bool objReturn = false;

            try
            {
                if (rsMain == null)
                    rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                if (itemPath == "/" || CheckItemExists("Folder", itemPath))
                {
                    LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);

                    Role[] roles = rsMain.ListRoles("Catalog", string.Empty);
                    if (roles != null)
                    {
                        Role[] updatedRoles = roles.Where(role => role.Name != "Content Manager" && role.Name != "Publisher").ToArray<Role>();
                        bool foundUser = false;
                        bool inheritParent = false;

                        Policy[] policies = rsMain.GetPolicies(itemPath, out inheritParent);
                        if (policies != null)
                        {
                            foreach (Policy policy in policies)
                            {
                                if (policy.GroupUserName.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    foundUser = true;
                                    policy.Roles = updatedRoles;
                                    break;
                                }
                            }
                        }

                        if (!foundUser)
                        {
                            Policy policy = new Policy();
                            policy.GroupUserName = username;
                            policy.Roles = updatedRoles;
                            AddToArray(ref policies, policy);
                        }

                        rsMain.SetPolicies(itemPath, policies);
                        objReturn = true;
                    }

                    LogManager.LogTiming(logDetails);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        public bool AddItemReadOnly(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username, string itemPath)
        {
            bool objReturn = false;

            try
            {
                if (rsMain == null)
                    rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                if (itemPath == "/" || CheckItemExists("Folder", itemPath))
                {
                    LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);

                    Role[] roles = rsMain.ListRoles("Catalog", string.Empty);
                    if (roles != null)
                    {
                        Role[] updatedRoles = roles.Where(role => role.Name == "Browser").ToArray<Role>();
                        bool foundUser = false;
                        bool inheritParent = false;

                        Policy[] policies = rsMain.GetPolicies(itemPath, out inheritParent);
                        if (policies != null)
                        {
                            foreach (Policy policy in policies)
                            {
                                if (policy.GroupUserName.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    foundUser = true;
                                    policy.Roles = updatedRoles;
                                    break;
                                }
                            }
                        }

                        if (!foundUser)
                        {
                            Policy policy = new Policy();
                            policy.GroupUserName = username;
                            policy.Roles = updatedRoles;
                            AddToArray(ref policies, policy);
                        }

                        rsMain.SetPolicies(itemPath, policies);
                        objReturn = true;
                    }

                    LogManager.LogTiming(logDetails);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        public bool AddItemMyReports(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username, string itemPath)
        {
            bool objReturn = false;

            try
            {
                if (rsMain == null)
                    rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                if (itemPath == "/" || CheckItemExists("Folder", itemPath))
                {
                    LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);

                    Role[] roles = rsMain.ListRoles("Catalog", string.Empty);
                    if (roles != null)
                    {
                        Role[] updatedRoles = roles.Where(role => role.Name == "My Reports").ToArray<Role>();
                        bool foundUser = false;
                        bool inheritParent = false;

                        Policy[] policies = rsMain.GetPolicies(itemPath, out inheritParent);
                        if (policies != null)
                        {
                            foreach (Policy policy in policies)
                            {
                                if (policy.GroupUserName.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    foundUser = true;
                                    policy.Roles = updatedRoles;
                                    break;
                                }
                            }
                        }

                        if (!foundUser)
                        {
                            Policy policy = new Policy();
                            policy.GroupUserName = username;
                            policy.Roles = updatedRoles;
                            AddToArray(ref policies, policy);
                        }

                        rsMain.SetPolicies(itemPath, policies);
                        objReturn = true;
                    }

                    LogManager.LogTiming(logDetails);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        public bool RemovePrivileges(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username, string itemPath)
        {
            bool objReturn = false;

            try
            {
                if (rsMain == null)
                    rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                if (itemPath == "/" || CheckItemExists("Folder", itemPath))
                {
                    LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);

                    bool inheritParent = false;

                    Policy[] policies = rsMain.GetPolicies(itemPath, out inheritParent);
                    Policy[] updatedPolicies = policies.Where(policy => policy.GroupUserName.ToUpper() != username.ToUpper()).ToArray<Policy>();

                    rsMain.SetPolicies(itemPath, updatedPolicies);
                    objReturn = true;

                    LogManager.LogTiming(logDetails);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        public bool UpdateItemProperties(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string itemPath, string description)
        {
            bool objReturn = false;

            try
            {
                if (rsMain == null)
                    rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);

                Property[] props = null;

                Property prop = new Property();
                prop.Name = "Description";
                prop.Value = description;
                AddToArray(ref props, prop);

                rsMain.SetProperties(itemPath, props);
                objReturn = true;

                LogManager.LogTiming(logDetails);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        public bool CreateDataSet(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string name, string parent)
        {
            bool objReturn = false;
            XmlSerializer serializer = null;
            SharedDataSet dataSet = null;
            MemoryStream stream = null;

            try
            {
                if (!CheckItemExists("DataSet", parent + "/" + name))
                {
                    if (rsMain == null)
                        rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                    serializer = new XmlSerializer(typeof(SharedDataSet));
                    dataSet = new SharedDataSet(CURRENT_REGISTRY_ID);
                    stream = new MemoryStream();

                    serializer.Serialize(stream, dataSet);

                    byte[] definition = stream.ToArray();
                    Warning[] warnings = null;

                    LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                    CatalogItem item = rsMain.CreateCatalogItem("DataSet", name, parent, false, definition, null, out warnings);
                    LogManager.LogTiming(logDetails);

                    if (item != null)
                        objReturn = true;
                }
                else
                    objReturn = true;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                    stream = null;
                }
            }

            return objReturn;
        }

        public string CreateFolder(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string folderName)
        {
            string objReturn = string.Empty;
            CatalogItem objTemp = null;

            try
            {
                if (rsMain == null)
                    rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                if (!CheckItemExists("Folder", "/Reports/" + folderName))
                {
                    LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                    objTemp = rsMain.CreateFolder(folderName, "/Reports", null);
                    LogManager.LogTiming(logDetails);

                    if (objTemp != null)
                        objReturn = "/Reports/" + folderName;
                }
                else
                    objReturn = "/Reports/" + folderName;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        public List<ReportItem> GetReports(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string folderName)
        {
            List<ReportItem> objReturn = null;
            CatalogItem[] objTemp = null;

            try
            {
                if (rsMain == null)
                    rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                if (CheckItemExists("Folder", folderName))
                {
                    LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                    objTemp = rsMain.FindItems(folderName, 
                        BooleanOperatorEnum.And, 
                        null,
                        new SearchCondition[] 
                        { 
                            new SearchCondition { Name = "Type", Values = new string[] { "Report" } }
                        });
                    LogManager.LogTiming(logDetails);
                }

                if (objTemp != null)
                {
                    objReturn = new List<ReportItem>();
                    foreach (CatalogItem item in objTemp)
                    {
                        ReportItem reportItem = new ReportItem(item);
                        reportItem.ReportStore = folderName.Replace("/Reports/", "");
                        if (reportItem.ReportStore == CURRENT_USER.ToUpper().Replace("\\", "_"))
                            reportItem.ReportStore = "Personal";
                        objReturn.Add(reportItem);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }

            return objReturn;
        }

        private bool CheckItemExists(string typeName, string itemName)
        {
            if (string.IsNullOrEmpty(itemName))
                return false;

            bool objReturn = false;

            try
            {
                string root = "/";

                if (itemName == "/Reports")
                {
                    itemName = itemName.Replace("/", "");
                }
                else if (itemName.Contains("/"))
                {
                    root = itemName.Substring(0, itemName.LastIndexOf("/"));
                    itemName = itemName.Replace(root, "").Replace("/", "");
                }

                if (rsMain == null)
                    rsMain = new ReportingService2010() { Url = ReportServiceUrl, Credentials = System.Net.CredentialCache.DefaultCredentials };

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);

                CatalogItem[] items = rsMain.FindItems(root,
                    BooleanOperatorEnum.And,
                    null,
                    new SearchCondition[] 
                    { 
                        new SearchCondition { Name = "Type", Values = new string[] { typeName }, Condition = ConditionEnum.Equals, ConditionSpecified = true }, 
                        new SearchCondition { Name = "Name", Values = new string[] { itemName }, Condition = ConditionEnum.Equals, ConditionSpecified = true } 
                    });

                if (items != null && items.Count() > 0)
                    objReturn = true;

                LogManager.LogTiming(logDetails);
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
                throw ex;
            }

            return objReturn;
        }

        #endregion
    }
}