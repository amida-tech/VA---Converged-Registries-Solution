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
	public partial class REGISTRY_CORE_DATADB : DBUtils
	{
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        public REGISTRY_CORE_DATA GetItemByRegistryCore(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CORE_TYPE_ID)
        {
            REGISTRY_CORE_DATA objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_REGISTRY_CORE_DATA_getitemByRegistryCore", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@CORE_TYPE_ID", CORE_TYPE_ID);

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

        public List<REGISTRY_CORE_DATA> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<REGISTRY_CORE_DATA> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_REGISTRY_CORE_DATA_getitemsByRegistry", sConn);
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
                        objReturn = myData.ToList<REGISTRY_CORE_DATA>();
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

        public Boolean SaveList(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, List<REGISTRY_CORE_DATA> cohorts)
        {
            Boolean objReturn = false;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlParameter p = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                foreach (REGISTRY_CORE_DATA objSave in cohorts)
                {
                    sCmd = new SqlCommand("CRS.usp_REGISTRY_CORE_DATA_save", sConn);
                    sCmd.CommandTimeout = SqlCommandTimeout;
                    sCmd.CommandType = CommandType.StoredProcedure;
                    sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                    sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

                    p = new SqlParameter("@COMMENT", SqlDbType.VarChar, -1);
                    p.Precision = 0;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.COMMENT);
                    p = new SqlParameter("@CREATED", SqlDbType.DateTime, 8);
                    p.Precision = 23;
                    p.Scale = 3;
                    AddParameter(ref sCmd, ref p, objSave.CREATED);
                    p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 30);
                    p.Precision = 0;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
                    p = new SqlParameter("@CORE_DATA_ID", SqlDbType.Int, 4);
                    p.Direction = ParameterDirection.InputOutput;
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.CORE_DATA_ID);
                    p = new SqlParameter("@CORE_TYPE_ID", SqlDbType.Int, 4);
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.CORE_TYPE_ID);
                    p = new SqlParameter("@STD_REGISTRY_ID", SqlDbType.Int, 4);
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.STD_REGISTRY_ID);
                    p = new SqlParameter("@VALUE", SqlDbType.VarChar, 1000);
                    p.Precision = 0;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.VALUE);
                    p = new SqlParameter("@SELECTED_FLAG", SqlDbType.Bit, 1);
                    p.Precision = 1;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.SELECTED_FLAG);
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

                    objReturn = true;
                }

                sConn.Close();
            }
            catch (Exception ex)
            {
                objReturn = false;
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

        public REGISTRY_CORE_DATA ParseReaderComplete(DataRow row)
        {
            REGISTRY_CORE_DATA objReturn = ParseReaderCustom(row);

            if (objReturn != null)
            {
                if (objReturn.CORE_TYPE_ID > 0)
                {
                    STD_REGISTRY_CORE_TYPESDB sTD_REGISTRY_CORE_TYPESDB = new STD_REGISTRY_CORE_TYPESDB();
                    objReturn.STD_REGISTRY_CORE_TYPES = sTD_REGISTRY_CORE_TYPESDB.ParseReaderCustom(row);
                }
            }

            return objReturn;
        }

        #endregion
	}
}
