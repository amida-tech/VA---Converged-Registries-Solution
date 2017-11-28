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
	public partial class REGISTRY_COHORT_DATADB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public REGISTRY_COHORT_DATA GetItemByRegistryCohort(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_REGISTRY_COHORT_TYPE_ID)
        {
            REGISTRY_COHORT_DATA objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_REGISTRY_COHORT_DATA_getitemByRegistryCohort", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@STD_REGISTRY_COHORT_TYPE_ID", STD_REGISTRY_COHORT_TYPE_ID);

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

        public List<REGISTRY_COHORT_DATA> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<REGISTRY_COHORT_DATA> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_REGISTRY_COHORT_DATA_getitemsByRegistry", sConn);
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
                        objReturn = myData.ToList<REGISTRY_COHORT_DATA>();
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

        public List<REGISTRY_COHORT_DATA> GetItemsSelectedByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<REGISTRY_COHORT_DATA> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_REGISTRY_COHORT_DATA_getitemsSelectedByRegistry", sConn);
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
                        objReturn = myData.ToList<REGISTRY_COHORT_DATA>();
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

        public List<REGISTRY_COHORT_DATA> GetCdwFields(Int32 REGISTRY_ID)
        {
            List<REGISTRY_COHORT_DATA> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.GetCDW_Fields", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@StdRegistryId", REGISTRY_ID);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
                {
                    var myData = objTemp.Tables[0].AsEnumerable().Select(r => ParseReaderCdw(r));
                    if (myData != null)
                    {
                        objReturn = myData.ToList<REGISTRY_COHORT_DATA>();
                    }
                }

                sConn.Close();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, REGISTRY_ID);
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

        public Int32 GetPreviewCount(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, RegistryWizard registryWizard)
        {
            Int32 objReturn = 0;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataReader sReader = null;

            try
            {
                sConn = new SqlConnection(EtlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRSE.CDW_GETData_Wizard", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@StdRegistryId", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@CombatLocation", registryWizard.CombatLocIds);
                sCmd.Parameters.AddWithValue("@Ethnicity", registryWizard.EthnicityIds);
                sCmd.Parameters.AddWithValue("@Gender", registryWizard.GenderIds);

                if (registryWizard.OEFOIFLocation != null && registryWizard.OEFOIFLocation.Value)
                    sCmd.Parameters.AddWithValue("@OEFOIF", 1);
                else
                    sCmd.Parameters.AddWithValue("@OEFOIF", DBNull.Value);

                sCmd.Parameters.AddWithValue("@Race", registryWizard.RaceIds);
                sCmd.Parameters.AddWithValue("@ServiceBranch", registryWizard.ServiceIds);
                sCmd.Parameters.AddWithValue("@MaritalStatus", registryWizard.MaritalStatusIds);
                sCmd.Parameters.AddWithValue("@DOBMin", registryWizard.DOBMin);
                sCmd.Parameters.AddWithValue("@DOBMax", registryWizard.DOBMax);
                sCmd.Parameters.AddWithValue("@UserName", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@Count", 1);
                sCmd.Parameters.AddWithValue("@ICD9", registryWizard.ICD9);
                sCmd.Parameters.AddWithValue("@ICD10", registryWizard.ICD10);
                sCmd.Parameters.AddWithValue("@HealthFactorType", registryWizard.HealthFactorType);
                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sReader = sCmd.ExecuteReader();
                LogManager.LogTiming(logDetails);

                if (sReader != null && sReader.HasRows)
                {
                    sReader.Read();
                    objReturn = (Int32)GetNullableObject(sReader["Record_Count"]);
                    sReader.Close();
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

        public Boolean SaveList(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, List<REGISTRY_COHORT_DATA> cohorts)
        {
            Boolean objReturn = false;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlParameter p = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                foreach (REGISTRY_COHORT_DATA objSave in cohorts)
                {
                    sCmd = new SqlCommand("CRS.usp_REGISTRY_COHORT_DATA_save", sConn);
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
                    p = new SqlParameter("@ID", SqlDbType.Int, 4);
                    p.Direction = ParameterDirection.InputOutput;
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.ID);
                    p = new SqlParameter("@STD_REGISTRY_COHORT_TYPE_ID", SqlDbType.Int, 4);
                    p.Precision = 10;
                    p.Scale = 0;
                    AddParameter(ref sCmd, ref p, objSave.STD_REGISTRY_COHORT_TYPE_ID);
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

        public Boolean PopulateRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, RegistryWizard registryWizard)
        {
            Boolean objReturn = false;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.RegWiz_PopulateRegistry", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@StdRegistryId", registryWizard.StdRegistryId);
                sCmd.Parameters.AddWithValue("@CombatLocIds", registryWizard.CombatLocIds);
                sCmd.Parameters.AddWithValue("@EthnicityIds", registryWizard.EthnicityIds);
                sCmd.Parameters.AddWithValue("@GenderIds", registryWizard.GenderIds);
                sCmd.Parameters.AddWithValue("@OEFOIFLocationIds", DBNull.Value); //registryWizard.OEFOIFLocation);
                sCmd.Parameters.AddWithValue("@RaceIds", registryWizard.RaceIds);
                sCmd.Parameters.AddWithValue("@ServiceIds", registryWizard.ServiceIds);
                sCmd.Parameters.AddWithValue("@DOBMin", registryWizard.DOBMin);
                sCmd.Parameters.AddWithValue("@DOBMax", registryWizard.DOBMax);
                sCmd.Parameters.AddWithValue("@UserName", registryWizard.Username);

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

        public REGISTRY_COHORT_DATA ParseReaderComplete(DataRow row)
        {
            REGISTRY_COHORT_DATA objReturn = ParseReaderCustom(row);

            if (objReturn != null)
            {
                if (objReturn.STD_REGISTRY_COHORT_TYPE_ID > 0)
                {
                    STD_REGISTRY_COHORT_TYPESDB sTD_REGISTRY_COHORT_TYPESDB = new STD_REGISTRY_COHORT_TYPESDB();
                    objReturn.STD_REGISTRY_COHORT_TYPES = sTD_REGISTRY_COHORT_TYPESDB.ParseReaderCustom(row);
                }
            }

            return objReturn;
        }

        public REGISTRY_COHORT_DATA ParseReaderCdw(DataRow row)
        {
            REGISTRY_COHORT_DATA objReturn = new REGISTRY_COHORT_DATA();
            objReturn.VALUE = (string)GetNullableObject(row.Field<object>("VALUE"));
            objReturn.SELECTED_FLAG = (Boolean)GetNullableObject(row.Field<object>("SELECTED_FLAG"));

            objReturn.STD_REGISTRY_COHORT_TYPES = new STD_REGISTRY_COHORT_TYPES();
            objReturn.STD_REGISTRY_COHORT_TYPES.NAME = (string)GetNullableObject(row.Field<object>("NAME"));
            objReturn.STD_REGISTRY_COHORT_TYPES.TABLE_NAME = (string)GetNullableObject(row.Field<object>("TABLE_NAME"));

            return objReturn;
        }

		#endregion
	}
}
