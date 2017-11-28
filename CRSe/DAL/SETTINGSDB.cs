using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using CRSe.CRS.BLL;
using CRSe.CRS.BO;

namespace CRSe.CRS.DAL
{
	public partial class SETTINGSDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public SETTINGS GetItemByRegistryName(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string NAME)
        {
            SETTINGS objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_SETTINGS_getitemByRegistryName", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@NAME", NAME);

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

        public SETTINGS GetItemHomePage()
        {
            SETTINGS objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_SETTINGS_getitemHomePage", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;

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

        public bool SaveAll(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, AppSettings appSettings)
        {
            bool objReturn = true;

            if (appSettings != null)
            {
                foreach (PropertyInfo pi in appSettings.GetType().GetProperties())
                {
                    SETTINGS objSave = GetItemByRegistryName(CURRENT_USER, CURRENT_REGISTRY_ID, pi.Name);
                    if (objSave == null)
                    {
                        objSave = new SETTINGS();
                        objSave.CREATED = DateTime.Now;
                        objSave.CREATEDBY = CURRENT_USER;
                    }

                    objSave.UPDATED = DateTime.Now;
                    objSave.UPDATEDBY = CURRENT_USER;
                    objSave.STD_REGISTRY_ID = CURRENT_REGISTRY_ID;
                    objSave.NAME = pi.Name;
                    objSave.VALUE = pi.GetValue(appSettings).ToString();

                    objSave.CRS_SETTINGS_ID = Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
                    if (objSave.CRS_SETTINGS_ID <= 0) objReturn = false;
                }
            }

            return objReturn;
        }

		#endregion
	}
}
