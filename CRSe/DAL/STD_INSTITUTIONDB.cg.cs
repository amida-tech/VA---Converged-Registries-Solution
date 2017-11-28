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

		public STD_INSTITUTIONDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public STD_INSTITUTION GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
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

				sCmd = new SqlCommand("CRS.usp_STD_INSTITUTION_getitem", sConn);
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

				if (objTemp != null  && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
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

		public List<STD_INSTITUTION> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
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

				sCmd = new SqlCommand("CRS.usp_STD_INSTITUTION_getitems", sConn);
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

				if (objTemp != null  && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
				{
					var myData = objTemp.Tables[0].AsEnumerable().Select(r => ParseReader(r));
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_INSTITUTION objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_INSTITUTION_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@ACTIVATIONDATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.ACTIVATIONDATE);
				p = new SqlParameter("@AGENCY_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.AGENCY_ID);
				p = new SqlParameter("@CREATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.CREATED);
				p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
				p = new SqlParameter("@DEACTIVATIONDATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DEACTIVATIONDATE);
				p = new SqlParameter("@ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ID);
				p = new SqlParameter("@IS_ACTIVE", SqlDbType.VarChar, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.IS_ACTIVE);
				p = new SqlParameter("@MAILINGADDRESSLINE1", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MAILINGADDRESSLINE1);
				p = new SqlParameter("@MAILINGADDRESSLINE2", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MAILINGADDRESSLINE2);
				p = new SqlParameter("@MAILINGADDRESSLINE3", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MAILINGADDRESSLINE3);
				p = new SqlParameter("@MAILINGCITY", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MAILINGCITY);
				p = new SqlParameter("@MAILINGCOUNTRY_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MAILINGCOUNTRY_ID);
				p = new SqlParameter("@MAILINGCOUNTY_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MAILINGCOUNTY_ID);
				p = new SqlParameter("@MAILINGPOSTALCODE", SqlDbType.VarChar, 15);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MAILINGPOSTALCODE);
				p = new SqlParameter("@MAILINGSTATE_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MAILINGSTATE_ID);
				p = new SqlParameter("@MFN_ZEG_RECIPIENT", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MFN_ZEG_RECIPIENT);
				p = new SqlParameter("@NAME", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NAME);
				p = new SqlParameter("@PARENT_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PARENT_ID);
				p = new SqlParameter("@REALIGNEDFROM_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.REALIGNEDFROM_ID);
				p = new SqlParameter("@REALIGNEDTO_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.REALIGNEDTO_ID);
				p = new SqlParameter("@STATIONNUMBER", SqlDbType.VarChar, 10);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STATIONNUMBER);
				p = new SqlParameter("@STD_FACILITYTYPE_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_FACILITYTYPE_ID);
				p = new SqlParameter("@STREETADDRESSLINE1", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STREETADDRESSLINE1);
				p = new SqlParameter("@STREETADDRESSLINE2", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STREETADDRESSLINE2);
				p = new SqlParameter("@STREETADDRESSLINE3", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STREETADDRESSLINE3);
				p = new SqlParameter("@STREETCITY", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STREETCITY);
				p = new SqlParameter("@STREETCOUNTRY_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STREETCOUNTRY_ID);
				p = new SqlParameter("@STREETCOUNTY_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STREETCOUNTY_ID);
				p = new SqlParameter("@STREETPOSTALCODE", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STREETPOSTALCODE);
				p = new SqlParameter("@STREETSTATE_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STREETSTATE_ID);
				p = new SqlParameter("@UPDATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.UPDATED);
				p = new SqlParameter("@UPDATEDBY", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.UPDATEDBY);
				p = new SqlParameter("@VISN_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.VISN_ID);
				p = new SqlParameter("@VISTANAME", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.VISTANAME);

				LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
				int cnt = sCmd.ExecuteNonQuery();
				LogManager.LogTiming(logDetails);

				objReturn = (Int32)sCmd.Parameters["@ID"].Value;

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

		public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			Boolean objReturn = false;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_INSTITUTION_delete", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@ID", ID);
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

		public STD_INSTITUTION ParseReader(DataRow row)
		{
			STD_INSTITUTION objReturn = new STD_INSTITUTION
			{
				ACTIVATIONDATE = (DateTime?)GetNullableObject(row.Field<object>("ACTIVATIONDATE")),
				AGENCY_ID = (Int32?)GetNullableObject(row.Field<object>("AGENCY_ID")),
				CREATED = (DateTime?)GetNullableObject(row.Field<object>("CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("CREATEDBY")),
				DEACTIVATIONDATE = (DateTime?)GetNullableObject(row.Field<object>("DEACTIVATIONDATE")),
				ID = (Int32)GetNullableObject(row.Field<object>("ID")),
				IS_ACTIVE = (string)GetNullableObject(row.Field<object>("IS_ACTIVE")),
				MAILINGADDRESSLINE1 = (string)GetNullableObject(row.Field<object>("MAILINGADDRESSLINE1")),
				MAILINGADDRESSLINE2 = (string)GetNullableObject(row.Field<object>("MAILINGADDRESSLINE2")),
				MAILINGADDRESSLINE3 = (string)GetNullableObject(row.Field<object>("MAILINGADDRESSLINE3")),
				MAILINGCITY = (string)GetNullableObject(row.Field<object>("MAILINGCITY")),
				MAILINGCOUNTRY_ID = (Int32?)GetNullableObject(row.Field<object>("MAILINGCOUNTRY_ID")),
				MAILINGCOUNTY_ID = (Int32?)GetNullableObject(row.Field<object>("MAILINGCOUNTY_ID")),
				MAILINGPOSTALCODE = (string)GetNullableObject(row.Field<object>("MAILINGPOSTALCODE")),
				MAILINGSTATE_ID = (Int32?)GetNullableObject(row.Field<object>("MAILINGSTATE_ID")),
				MFN_ZEG_RECIPIENT = (string)GetNullableObject(row.Field<object>("MFN_ZEG_RECIPIENT")),
				NAME = (string)GetNullableObject(row.Field<object>("NAME")),
				PARENT_ID = (Int32?)GetNullableObject(row.Field<object>("PARENT_ID")),
				REALIGNEDFROM_ID = (Int32?)GetNullableObject(row.Field<object>("REALIGNEDFROM_ID")),
				REALIGNEDTO_ID = (Int32?)GetNullableObject(row.Field<object>("REALIGNEDTO_ID")),
				STATIONNUMBER = (string)GetNullableObject(row.Field<object>("STATIONNUMBER")),
				STD_FACILITYTYPE_ID = (Int32)GetNullableObject(row.Field<object>("STD_FACILITYTYPE_ID")),
				STREETADDRESSLINE1 = (string)GetNullableObject(row.Field<object>("STREETADDRESSLINE1")),
				STREETADDRESSLINE2 = (string)GetNullableObject(row.Field<object>("STREETADDRESSLINE2")),
				STREETADDRESSLINE3 = (string)GetNullableObject(row.Field<object>("STREETADDRESSLINE3")),
				STREETCITY = (string)GetNullableObject(row.Field<object>("STREETCITY")),
				STREETCOUNTRY_ID = (Int32?)GetNullableObject(row.Field<object>("STREETCOUNTRY_ID")),
				STREETCOUNTY_ID = (Int32?)GetNullableObject(row.Field<object>("STREETCOUNTY_ID")),
				STREETPOSTALCODE = (string)GetNullableObject(row.Field<object>("STREETPOSTALCODE")),
				STREETSTATE_ID = (Int32?)GetNullableObject(row.Field<object>("STREETSTATE_ID")),
				UPDATED = (DateTime?)GetNullableObject(row.Field<object>("UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("UPDATEDBY")),
				VISN_ID = (Int32?)GetNullableObject(row.Field<object>("VISN_ID")),
				VISTANAME = (string)GetNullableObject(row.Field<object>("VISTANAME"))
			};

			return objReturn;
		}

		public STD_INSTITUTION ParseReaderCustom(DataRow row)
		{
			STD_INSTITUTION objReturn = new STD_INSTITUTION
			{
				ACTIVATIONDATE = (DateTime?)GetNullableObject(row.Field<object>("STD_INSTITUTION_ACTIVATIONDATE")),
				AGENCY_ID = (Int32?)GetNullableObject(row.Field<object>("STD_INSTITUTION_AGENCY_ID")),
				CREATED = (DateTime?)GetNullableObject(row.Field<object>("STD_INSTITUTION_CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_CREATEDBY")),
				DEACTIVATIONDATE = (DateTime?)GetNullableObject(row.Field<object>("STD_INSTITUTION_DEACTIVATIONDATE")),
				ID = (Int32)GetNullableObject(row.Field<object>("STD_INSTITUTION_ID")),
				IS_ACTIVE = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_IS_ACTIVE")),
				MAILINGADDRESSLINE1 = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_MAILINGADDRESSLINE1")),
				MAILINGADDRESSLINE2 = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_MAILINGADDRESSLINE2")),
				MAILINGADDRESSLINE3 = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_MAILINGADDRESSLINE3")),
				MAILINGCITY = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_MAILINGCITY")),
				MAILINGCOUNTRY_ID = (Int32?)GetNullableObject(row.Field<object>("STD_INSTITUTION_MAILINGCOUNTRY_ID")),
				MAILINGCOUNTY_ID = (Int32?)GetNullableObject(row.Field<object>("STD_INSTITUTION_MAILINGCOUNTY_ID")),
				MAILINGPOSTALCODE = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_MAILINGPOSTALCODE")),
				MAILINGSTATE_ID = (Int32?)GetNullableObject(row.Field<object>("STD_INSTITUTION_MAILINGSTATE_ID")),
				MFN_ZEG_RECIPIENT = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_MFN_ZEG_RECIPIENT")),
				NAME = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_NAME")),
				PARENT_ID = (Int32?)GetNullableObject(row.Field<object>("STD_INSTITUTION_PARENT_ID")),
				REALIGNEDFROM_ID = (Int32?)GetNullableObject(row.Field<object>("STD_INSTITUTION_REALIGNEDFROM_ID")),
				REALIGNEDTO_ID = (Int32?)GetNullableObject(row.Field<object>("STD_INSTITUTION_REALIGNEDTO_ID")),
				STATIONNUMBER = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_STATIONNUMBER")),
				STD_FACILITYTYPE_ID = (Int32)GetNullableObject(row.Field<object>("STD_INSTITUTION_STD_FACILITYTYPE_ID")),
				STREETADDRESSLINE1 = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_STREETADDRESSLINE1")),
				STREETADDRESSLINE2 = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_STREETADDRESSLINE2")),
				STREETADDRESSLINE3 = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_STREETADDRESSLINE3")),
				STREETCITY = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_STREETCITY")),
				STREETCOUNTRY_ID = (Int32?)GetNullableObject(row.Field<object>("STD_INSTITUTION_STREETCOUNTRY_ID")),
				STREETCOUNTY_ID = (Int32?)GetNullableObject(row.Field<object>("STD_INSTITUTION_STREETCOUNTY_ID")),
				STREETPOSTALCODE = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_STREETPOSTALCODE")),
				STREETSTATE_ID = (Int32?)GetNullableObject(row.Field<object>("STD_INSTITUTION_STREETSTATE_ID")),
				UPDATED = (DateTime?)GetNullableObject(row.Field<object>("STD_INSTITUTION_UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_UPDATEDBY")),
				VISN_ID = (Int32?)GetNullableObject(row.Field<object>("STD_INSTITUTION_VISN_ID")),
				VISTANAME = (string)GetNullableObject(row.Field<object>("STD_INSTITUTION_VISTANAME"))
			};

			return objReturn;
		}

		#endregion
	}
}
