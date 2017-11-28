using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CRSe.CRS.BLL;
using CRSe.CRS.BO;

namespace CRSe.CRS.DAL
{
    public partial class USER_ROLESDB : DBUtils
    {
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        public USER_ROLES GetItemByUserIdRoleId(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ID, Int32 STD_ROLE_ID)
        {
            USER_ROLES objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_USER_ROLES_getitemByUserIdRoleId", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@USER_ID", USER_ID);
                sCmd.Parameters.AddWithValue("@STD_ROLE_ID", STD_ROLE_ID);

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

        public USER_ROLES GetItemByUserRole(string Username, string RoleName)
        {
            USER_ROLES objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_USER_ROLES_getitemByUserRole", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@USERNAME", Username);
                sCmd.Parameters.AddWithValue("@ROLENAME", RoleName);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
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
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
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

        public string[] GetRoles(string Username)
        {
            string[] objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataReader sReader = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_USER_ROLES_getrolesByUser", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@USERNAME", Username);
                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
                sReader = sCmd.ExecuteReader();
                LogManager.LogTiming(logDetails);

                if (sReader != null && sReader.HasRows)
                {
                    while (sReader.Read())
                    {
                        AddToArray(ref objReturn, sReader.GetString(0));
                    }
                }

                sReader.Close();
                sConn.Close();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
                throw ex;
            }
            finally
            {
                if (sReader != null)
                {
                    if (!sReader.IsClosed) { sReader.Close(); }
                    sReader.Dispose();
                    sReader = null;
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

        public List<USER_ROLES> GetItemsByUser(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ID)
        {
            List<USER_ROLES> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_USER_ROLES_getitemsByUser", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@USER_ID", USER_ID);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
                {
                    var myData = objTemp.Tables[0].AsEnumerable().Select(r => ParseReaderComplete(CURRENT_USER, CURRENT_REGISTRY_ID, r));
                    if (myData != null)
                    {
                        objReturn = myData.ToList<USER_ROLES>();
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

        public List<USER_ROLES> GetItemsByUser(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string Username)
        {
            List<USER_ROLES> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_USER_ROLES_getitemsByUsername", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@Username", Username);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
                {
                    var myData = objTemp.Tables[0].AsEnumerable().Select(r => ParseReaderComplete(CURRENT_USER, CURRENT_REGISTRY_ID, r));
                    if (myData != null)
                    {
                        objReturn = myData.ToList<USER_ROLES>();
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

        public Boolean DeleteByUserRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ID, Int32 STD_REGISTRY_ID)
        {
            Boolean objReturn = false;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_USER_ROLES_deleteByUserRegistry", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@USER_ID", USER_ID);
                sCmd.Parameters.AddWithValue("@STD_REGISTRY_ID", STD_REGISTRY_ID);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                int cnt = sCmd.ExecuteNonQuery();
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

        public Boolean SaveAll(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, List<USER_ROLES> USER_ROLES)
        {
            if (USER_ROLES == null)
                return false;

            Boolean objReturn = false;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlParameter p = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                foreach (USER_ROLES objSave in USER_ROLES)
                {
                    sCmd = new SqlCommand("CRS.usp_USER_ROLES_save", sConn);
                    sCmd.CommandTimeout = SqlCommandTimeout;
                    sCmd.CommandType = CommandType.StoredProcedure;
                    sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                    sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

                    p = new SqlParameter("@CREATED", SqlDbType.DateTime, 8);
                    p.Precision = 23;
                    p.Scale = 3;
                    AddParameter(ref sCmd, ref p, objSave.CREATED);
                    p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 30);
                    p.Precision = 0;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
                    p = new SqlParameter("@INACTIVE_DATE", SqlDbType.DateTime, 8);
                    p.Precision = 23;
                    p.Scale = 3;
                    AddParameter(ref sCmd, ref p, objSave.INACTIVE_DATE);
                    p = new SqlParameter("@INACTIVE_FLAG", SqlDbType.Bit, 1);
                    p.Precision = 1;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.INACTIVE_FLAG);
                    p = new SqlParameter("@STD_ROLE_ID", SqlDbType.Int, 4);
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.STD_ROLE_ID);
                    p = new SqlParameter("@UPDATED", SqlDbType.DateTime, 8);
                    p.Precision = 23;
                    p.Scale = 3;
                    AddParameter(ref sCmd, ref p, objSave.UPDATED);
                    p = new SqlParameter("@UPDATEDBY", SqlDbType.VarChar, 30);
                    p.Precision = 0;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.UPDATEDBY);
                    p = new SqlParameter("@USER_ID", SqlDbType.Int, 4);
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.USER_ID);
                    p = new SqlParameter("@USER_ROLE_ID", SqlDbType.Int, 4);
                    p.Direction = ParameterDirection.InputOutput;
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.USER_ROLE_ID);

                    LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                    int cnt = sCmd.ExecuteNonQuery();
                    LogManager.LogTiming(logDetails);
                }

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

        public USER_ROLES ParseReaderComplete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DataRow row)
        {
            USER_ROLES objReturn = ParseReaderCustom(row);

            if (objReturn != null)
            {
                STD_ROLEDB sTD_ROLEDB = new STD_ROLEDB();
                objReturn.STD_ROLE = sTD_ROLEDB.ParseReaderCustom(row);
            }

            return objReturn;
        }

        public List<string> GetRoleByRegistryId(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<string> objReturn = new List<string>();

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataReader sReader = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_USER_ROLES_getitemByRegistryIdUsername", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sReader = sCmd.ExecuteReader();
                LogManager.LogTiming(logDetails);

                if (sReader != null && sReader.HasRows)
                {
                    while (sReader.Read())
                    {
                        string item = sReader[0].ToString();
                        objReturn.Add(item);
                    }
                }

                sConn.Close();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
                throw ex;
            }
            finally
            {
                if (sReader != null)
                {
                    if (!sReader.IsClosed) { sReader.Close(); }
                    sReader.Dispose();
                    sReader = null;
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

        #endregion
    }
}
