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
    public partial class STD_INSTITUTIONDB : DBUtils
    {
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        public STD_INSTITUTION GetItemComplete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
        {
            STD_INSTITUTION objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_STD_INSTITUTION_getitemComplete", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@ID", ID);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
                {
                    objReturn = ParseReaderComplete(objTemp.Tables[0].Rows[0]);
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

        public List<STD_INSTITUTION> GetFacs(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_INSTITUTION> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.BCCCR_usp_Get_Fac", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                //sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                //sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
                {
                    var myData = objTemp.Tables[0].AsEnumerable().Select(r => ParseFacs(r));
                    if (myData != null)
                    {
                        objReturn = myData.ToList<STD_INSTITUTION>();
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

        public STD_INSTITUTION ParseFacs(DataRow row)
        {
            STD_INSTITUTION objReturn = new STD_INSTITUTION
            {
                FACID = (Int32)GetNullableObject(row.Field<object>("FACID")),
                FACTEXT = (string)GetNullableObject(row.Field<object>("FACTEXT")),
                STA3N = (string)GetNullableObject(row.Field<object>("STA3N")),
                VISNSID = (Int32)GetNullableObject(row.Field<object>("VISNID")),
                VISNTEXT = (string)GetNullableObject(row.Field<object>("VISNTEXT"))
            };

            return objReturn;
        }

        public STD_INSTITUTION ParseReaderComplete(DataRow row)
        {
            STD_INSTITUTION objReturn = ParseReaderCustom(row);

            if (objReturn != null)
            {
                if (objReturn.STD_FACILITYTYPE_ID > 0)
                {
                    STD_FACILITYTYPEDB sTD_FACILITYTYPEDB = new STD_FACILITYTYPEDB();
                    objReturn.STD_FACILITYTYPE = sTD_FACILITYTYPEDB.ParseReaderCustom(row);
                }

                if (objReturn.STREETSTATE_ID != null && objReturn.STREETSTATE_ID.Value > 0)
                {
                    STD_STATEDB sTD_STATEDB = new STD_STATEDB();
                    objReturn.STREETSTATE = sTD_STATEDB.ParseReaderCustom(row);
                }

                if (objReturn.VISN_ID != null && objReturn.VISN_ID.Value > 0)
                {
                    objReturn.VISN = new STD_INSTITUTION
                    {
                        ACTIVATIONDATE = (DateTime?)GetNullableObject(row.Field<object>("VISN_ACTIVATIONDATE")),
                        AGENCY_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_AGENCY_ID")),
                        CREATED = (DateTime?)GetNullableObject(row.Field<object>("VISN_CREATED")),
                        CREATEDBY = (string)GetNullableObject(row.Field<object>("VISN_CREATEDBY")),
                        DEACTIVATIONDATE = (DateTime?)GetNullableObject(row.Field<object>("VISN_DEACTIVATIONDATE")),
                        ID = (Int32)GetNullableObject(row.Field<object>("VISN_ID")),
                        IS_ACTIVE = (string)GetNullableObject(row.Field<object>("VISN_IS_ACTIVE")),
                        MAILINGADDRESSLINE1 = (string)GetNullableObject(row.Field<object>("VISN_MAILINGADDRESSLINE1")),
                        MAILINGADDRESSLINE2 = (string)GetNullableObject(row.Field<object>("VISN_MAILINGADDRESSLINE2")),
                        MAILINGADDRESSLINE3 = (string)GetNullableObject(row.Field<object>("VISN_MAILINGADDRESSLINE3")),
                        MAILINGCITY = (string)GetNullableObject(row.Field<object>("VISN_MAILINGCITY")),
                        MAILINGCOUNTRY_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_MAILINGCOUNTRY_ID")),
                        MAILINGCOUNTY_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_MAILINGCOUNTY_ID")),
                        MAILINGPOSTALCODE = (string)GetNullableObject(row.Field<object>("VISN_MAILINGPOSTALCODE")),
                        MAILINGSTATE_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_MAILINGSTATE_ID")),
                        MFN_ZEG_RECIPIENT = (string)GetNullableObject(row.Field<object>("VISN_MFN_ZEG_RECIPIENT")),
                        NAME = (string)GetNullableObject(row.Field<object>("VISN_NAME")),
                        PARENT_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_PARENT_ID")),
                        REALIGNEDFROM_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_REALIGNEDFROM_ID")),
                        REALIGNEDTO_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_REALIGNEDTO_ID")),
                        STATIONNUMBER = (string)GetNullableObject(row.Field<object>("VISN_STATIONNUMBER")),
                        STD_FACILITYTYPE_ID = (Int32)GetNullableObject(row.Field<object>("VISN_STD_FACILITYTYPE_ID")),
                        STREETADDRESSLINE1 = (string)GetNullableObject(row.Field<object>("VISN_STREETADDRESSLINE1")),
                        STREETADDRESSLINE2 = (string)GetNullableObject(row.Field<object>("VISN_STREETADDRESSLINE2")),
                        STREETADDRESSLINE3 = (string)GetNullableObject(row.Field<object>("VISN_STREETADDRESSLINE3")),
                        STREETCITY = (string)GetNullableObject(row.Field<object>("VISN_STREETCITY")),
                        STREETCOUNTRY_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_STREETCOUNTRY_ID")),
                        STREETCOUNTY_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_STREETCOUNTY_ID")),
                        STREETPOSTALCODE = (string)GetNullableObject(row.Field<object>("VISN_STREETPOSTALCODE")),
                        STREETSTATE_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_STREETSTATE_ID")),
                        UPDATED = (DateTime?)GetNullableObject(row.Field<object>("VISN_UPDATED")),
                        UPDATEDBY = (string)GetNullableObject(row.Field<object>("VISN_UPDATEDBY")),
                        VISN_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_VISN_ID")),
                        VISTANAME = (string)GetNullableObject(row.Field<object>("VISN_VISTANAME"))
                    };
                }
            }

            return objReturn;
        }

        #endregion
    }
}
