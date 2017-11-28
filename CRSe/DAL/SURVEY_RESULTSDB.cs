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
	public partial class SURVEY_RESULTSDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public List<SURVEY_RESULTS> GetItemsBySurvey(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 SURVEYS_ID)
        {
            List<SURVEY_RESULTS> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_SURVEY_RESULTS_getitemsBySurvey", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@SURVEYS_ID", SURVEYS_ID);

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
                        objReturn = myData.ToList<SURVEY_RESULTS>();
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

        public Boolean SaveAll(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, List<SURVEY_RESULTS> results)
        {
            if (results == null)
                return false;

            Boolean objReturn = false;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlParameter p = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                foreach (SURVEY_RESULTS objSave in results)
                {
                    sCmd = new SqlCommand("CRS.usp_SURVEY_RESULTS_save", sConn);
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
                    p = new SqlParameter("@RESULT_TEXT", SqlDbType.VarChar, -1);
                    p.Precision = 0;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.RESULT_TEXT);
                    p = new SqlParameter("@SELECTED_FLAG", SqlDbType.Bit, 1);
                    p.Precision = 1;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.SELECTED_FLAG);
                    p = new SqlParameter("@STD_QUESTION_CHOICE_ID", SqlDbType.Int, 4);
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.STD_QUESTION_CHOICE_ID);
                    p = new SqlParameter("@STD_QUESTION_ID", SqlDbType.Int, 4);
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.STD_QUESTION_ID);
                    p = new SqlParameter("@SURVEY_RESULT_ID", SqlDbType.Int, 4);
                    p.Direction = ParameterDirection.InputOutput;
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.SURVEY_RESULT_ID);
                    p = new SqlParameter("@SURVEYS_ID", SqlDbType.Int, 4);
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.SURVEYS_ID);
                    p = new SqlParameter("@UPDATED", SqlDbType.DateTime, 8);
                    p.Precision = 23;
                    p.Scale = 3;
                    AddParameter(ref sCmd, ref p, objSave.UPDATED);
                    p = new SqlParameter("@UPDATEDBY", SqlDbType.VarChar, 30);
                    p.Precision = 0;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.UPDATEDBY);

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

        public SURVEY_RESULTS ParseReaderComplete(DataRow row)
        {
            SURVEY_RESULTS objReturn = ParseReaderCustom(row);
            if (objReturn != null)
            {
                if (objReturn.STD_QUESTION_ID > 0)
                {
                    STD_QUESTIONDB sTD_QUESTIONDB = new STD_QUESTIONDB();
                    objReturn.STD_QUESTION = sTD_QUESTIONDB.ParseReaderCustom(row);
                }

                if (objReturn.STD_QUESTION_CHOICE_ID > 0)
                {
                    STD_QUESTION_CHOICEDB sTD_QUESTION_CHOICEDB = new STD_QUESTION_CHOICEDB();
                    objReturn.STD_QUESTION_CHOICE = sTD_QUESTION_CHOICEDB.ParseReaderCustom(row);
                }
            }

            return objReturn;
        }

		#endregion
	}
}
