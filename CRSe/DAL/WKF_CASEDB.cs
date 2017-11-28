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
	public partial class WKF_CASEDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public List<WKF_CASE> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<WKF_CASE> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_WKF_CASE_getitemsByRegistry", sConn);
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
                        objReturn = myData.ToList<WKF_CASE>();
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

        public Boolean UpdateStatus(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_ID, Int32 STD_WKFCASESTS_ID)
        {
            Boolean objReturn = false;
            WKF_CASEDB objDB = new WKF_CASEDB();

            SqlConnection sConn = null;
            SqlCommand sCmd = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_WKF_CASE_updateStatus", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@WKF_CASE_ID", WKF_CASE_ID);
                sCmd.Parameters.AddWithValue("@STD_WKFCASESTS_ID", STD_WKFCASESTS_ID);

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

        public WKF_CASE ParseReaderComplete(DataRow row)
        {
            WKF_CASE objReturn = ParseReaderCustom(row);

            if (objReturn != null)
            {
                if (objReturn.PATIENT_ID > 0)
                {
                    PATIENTDB pATIENTDB = new PATIENTDB();
                    objReturn.PATIENT = pATIENTDB.ParseReaderCustom(row);
                }

                if (objReturn.STD_WKFCASETYPE_ID > 0)
                {
                    STD_WKFCASETYPEDB sTD_WKFCASETYPEDB = new STD_WKFCASETYPEDB();
                    objReturn.STD_WKFCASETYPE = sTD_WKFCASETYPEDB.ParseReaderCustom(row);
                }

                if (objReturn.STD_WKFCASESTS_ID > 0)
                {
                    STD_WKFCASESTSDB sTD_WKFCASESTSDB = new STD_WKFCASESTSDB();
                    objReturn.STD_WKFCASESTS = sTD_WKFCASESTSDB.ParseReaderCustom(row);
                }

                if (objReturn.REFERRAL_ID > 0)
                {
                    REFERRALDB rEFERRALDB = new REFERRALDB();
                    objReturn.REFERRAL = rEFERRALDB.ParseReaderCustom(row);
                }
            }

            return objReturn;
        }

		#endregion
	}
}
