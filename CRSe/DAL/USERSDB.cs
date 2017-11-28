using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using CRSe.CRS.BLL;
using CRSe.CRS.BO;
using System.Text.RegularExpressions;

namespace CRSe.CRS.DAL
{
	public partial class USERSDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public void UpdateUser()
        {
        }

        public List<DomainUser> GetActiveDirectory(DomainNames domainNames, string searchString)
        {
            List<DomainUser> objReturn = null;

            DirectoryEntry rootEntry = null;
            DirectorySearcher searcher = null;
            SearchResultCollection queryResults = null;

            try
            {
                rootEntry = new DirectoryEntry("GC://DC=va,DC=gov");
                searcher = new DirectorySearcher(rootEntry);

                searcher.PropertiesToLoad.Add("distinguishedName");
                searcher.PropertiesToLoad.Add("sAMAccountName");
                searcher.PropertiesToLoad.Add("givenName");
                //searcher.PropertiesToLoad.Add("middleName");//Property doesn't exist
                searcher.PropertiesToLoad.Add("sn");
                //searcher.PropertiesToLoad.Add("maidenName");//Property doesn't exist
                searcher.PropertiesToLoad.Add("mail");
                //searcher.PropertiesToLoad.Add("employeeNumber");//Property doesn't exist
                searcher.PropertiesToLoad.Add("title");
                searcher.PropertiesToLoad.Add("telephoneNumber");
                searcher.PropertiesToLoad.Add("facsimileTelephoneNumber");

                //searcher.ServerTimeLimit = new TimeSpan(0, 0, 30);
                //searcher.ClientTimeout = new TimeSpan(0, 10, 0);

                //Validate searchString (LDAP Injection )
                
                string whitelist = "^[a-zA-Z0-9-,. ]+$";
                Regex pattern = new Regex(whitelist);

                if (!pattern.IsMatch(searchString))
                    throw new Exception("Invalid Search Criteria");

                //Filter results by last name and/or first name and must have username
                searcher.Filter = "(&(anr=" + searchString + ")(sAMAccountName=*)(objectCategory=person))";

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
                queryResults = searcher.FindAll();
                LogManager.LogTiming(logDetails);

                //If there is a better way to bind AD Results to a Grid 
                //we should implement it.  This loop seems to take up a 
                //majority of the time in this process.
                if (queryResults != null && queryResults.Count > 0)
                {
                    objReturn = new List<DomainUser>();

                    foreach (SearchResult searchResult in queryResults)
                    {
                        string username = string.Empty;
                        string domainName = string.Empty;
                        string accountName = string.Empty;

                        if (searchResult.Properties.Contains("distinguishedName"))
                        {
                            domainName = domainNames.FindByDistinguishedName(searchResult.Properties["distinguishedName"][0].ToString());
                        }

                        if (searchResult.Properties.Contains("sAMAccountName"))
                        {
                            accountName = searchResult.Properties["sAMAccountName"][0].ToString().ToUpper();
                        }

                        username = domainName + "\\" + accountName;

                        DomainUser user = new DomainUser(searchResult);
                        user.Username = username;
                        objReturn.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
                throw ex;
            }
            finally
            {
                if (queryResults != null)
                {
                    queryResults.Dispose();
                    queryResults = null;
                }

                if (searcher != null)
                {
                    searcher.Dispose();
                    searcher = null;
                }

                if (rootEntry != null)
                {
                    rootEntry.Close();
                    rootEntry.Dispose();
                    rootEntry = null;
                }
            }

            return objReturn;
        }

        public USERS GetItemByName(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username)
        {
            USERS objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_USERS_getitemByName", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@USERNAME", username);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
                {
                    objReturn = ParseReader(objTemp.Tables[0].Rows[0]);
                }

                sConn.Close();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }
            finally
            {
                if (sAdapter != null)
                {
                    sAdapter.Dispose();
                    sAdapter = null;
                }
                if (sCmd != null)
                {
                    sCmd.Dispose();
                    sCmd = null;
                }
                if (sConn != null)
                {
                    if (sConn.State != ConnectionState.Closed) { sConn.Close(); }
                    sConn.Dispose();
                    sConn = null;
                }
            }

            return objReturn;
        }

        public List<USERS> GetItemsByUser(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<USERS> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_USERS_getitemsByUser", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
                {
                    var myData = objTemp.Tables[0].AsEnumerable().Select(r => ParseReader(r));
                    if (myData != null)
                    {
                        objReturn = myData.ToList<USERS>();
                    }
                }

                sConn.Close();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }
            finally
            {
                if (sAdapter != null)
                {
                    sAdapter.Dispose();
                    sAdapter = null;
                }
                if (sCmd != null)
                {
                    sCmd.Dispose();
                    sCmd = null;
                }
                if (sConn != null)
                {
                    if (sConn.State != ConnectionState.Closed) { sConn.Close(); }
                    sConn.Dispose();
                    sConn = null;
                }
            }

            return objReturn;
        }

        public List<USERS> GetSystemUsers(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<USERS> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_USERS_getitemsSystemUsers", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
                {
                    var myData = objTemp.Tables[0].AsEnumerable().Select(r => ParseReaderComplete(r));
                    if (myData != null)
                    {
                        objReturn = myData.ToList<USERS>();
                    }
                }

                sConn.Close();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }
            finally
            {
                if (sAdapter != null)
                {
                    sAdapter.Dispose();
                    sAdapter = null;
                }
                if (sCmd != null)
                {
                    sCmd.Dispose();
                    sCmd = null;
                }
                if (sConn != null)
                {
                    if (sConn.State != ConnectionState.Closed) { sConn.Close(); }
                    sConn.Dispose();
                    sConn = null;
                }
            }

            return objReturn;
        }

        public Boolean SetDefaultRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Boolean IS_DEFAULT)
        {
            Boolean objReturn = false;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_USERS_setDefaultRegistry", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@IS_DEFAULT", IS_DEFAULT);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sCmd.ExecuteNonQuery();
                LogManager.LogTiming(logDetails);

                objReturn = true;

                sConn.Close();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }
            finally
            {
                if (sCmd != null)
                {
                    sCmd.Dispose();
                    sCmd = null;
                }
                if (sConn != null)
                {
                    if (sConn.State != ConnectionState.Closed) { sConn.Close(); }
                    sConn.Dispose();
                    sConn = null;
                }
            }

            return objReturn;
        }

        public USERS ParseReaderComplete(DataRow row)
        {
            USERS user = ParseReaderCustom(row);
            if (user != null)
            {
                USER_ROLESDB uSER_ROLESDB = new USER_ROLESDB();
                USER_ROLES userRole = uSER_ROLESDB.ParseReaderCustom(row);
                if (userRole != null)
                {
                    STD_ROLEDB sTD_ROLEDB = new STD_ROLEDB();
                    userRole.STD_ROLE = sTD_ROLEDB.ParseReaderCustom(row);
                }
                user.USER_ROLES = new List<USER_ROLES>();
                user.USER_ROLES.Add(userRole);
            }

            return user;
        }

		#endregion
	}
}
