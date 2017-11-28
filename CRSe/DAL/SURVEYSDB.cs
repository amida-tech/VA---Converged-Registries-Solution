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
	public partial class SURVEYSDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public List<SURVEYS> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<SURVEYS> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_SURVEYS_getitemsByRegistry", sConn);
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
                        objReturn = myData.ToList<SURVEYS>();
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

        public SURVEYS ParseReaderComplete(DataRow row)
        {
            SURVEYS objReturn = ParseReaderCustom(row);

            if (objReturn != null)
            {
                if (objReturn.PATIENT_ID > 0)
                {
                    PATIENTDB pATIENTDB = new PATIENTDB();
                    objReturn.PATIENT = pATIENTDB.ParseReaderCustom(row);
                }

                if (objReturn.STD_SURVEY_TYPE_ID > 0)
                {
                    STD_SURVEY_TYPEDB sTD_SURVEY_TYPEDB = new STD_SURVEY_TYPEDB();
                    objReturn.STD_SURVEY_TYPE = sTD_SURVEY_TYPEDB.ParseReaderCustom(row);
                }

                if (objReturn.PROVIDER_ID > 0)
                {
                    SStaff_SStaffDB sStaff_SStaffDB = new SStaff_SStaffDB();
                    objReturn.SStaff_SStaff = sStaff_SStaffDB.ParseReaderCustom(row);
                }
            }

            return objReturn;
        }

		#endregion
	}
}
