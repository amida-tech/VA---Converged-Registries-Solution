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
	public partial class INDIVIDUAL_ADDRESSDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public INDIVIDUAL_ADDRESSDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public INDIVIDUAL_ADDRESS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ADDRESS_ID)
		{
			INDIVIDUAL_ADDRESS objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_INDIVIDUAL_ADDRESS_getitem", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@ADDRESS_ID", ADDRESS_ID);

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

		public List<INDIVIDUAL_ADDRESS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<INDIVIDUAL_ADDRESS> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_INDIVIDUAL_ADDRESS_getitems", sConn);
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
						objReturn = myData.ToList<INDIVIDUAL_ADDRESS>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, INDIVIDUAL_ADDRESS objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_INDIVIDUAL_ADDRESS_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@ACCEPTS_TXT_MSG", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ACCEPTS_TXT_MSG);
				p = new SqlParameter("@ADDRESS_ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ADDRESS_ID);
				p = new SqlParameter("@ALT_EMAIL", SqlDbType.VarChar, 128);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ALT_EMAIL);
				p = new SqlParameter("@CELL_PHONE", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CELL_PHONE);
				p = new SqlParameter("@CITY", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CITY);
				p = new SqlParameter("@COMMENTS", SqlDbType.VarChar, 1000);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.COMMENTS);
				p = new SqlParameter("@CREATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.CREATED);
				p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
				p = new SqlParameter("@EMAIL", SqlDbType.VarChar, 128);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.EMAIL);
				p = new SqlParameter("@FAX", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.FAX);
				p = new SqlParameter("@IND_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.IND_ID);
				p = new SqlParameter("@PHONE", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PHONE);
				p = new SqlParameter("@POSTAL_CODE", SqlDbType.VarChar, 10);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.POSTAL_CODE);
				p = new SqlParameter("@STD_ADDRESSTYPE_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_ADDRESSTYPE_ID);
				p = new SqlParameter("@STD_COUNTRY_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_COUNTRY_ID);
				p = new SqlParameter("@STD_STATE_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_STATE_ID);
				p = new SqlParameter("@STREET1", SqlDbType.VarChar, 256);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STREET1);
				p = new SqlParameter("@STREET2", SqlDbType.VarChar, 256);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STREET2);
				p = new SqlParameter("@STREET3", SqlDbType.VarChar, 256);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STREET3);
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

				objReturn = (Int32)sCmd.Parameters["@ADDRESS_ID"].Value;

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

		public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ADDRESS_ID)
		{
			Boolean objReturn = false;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_INDIVIDUAL_ADDRESS_delete", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@ADDRESS_ID", ADDRESS_ID);
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

		public INDIVIDUAL_ADDRESS ParseReader(DataRow row)
		{
			INDIVIDUAL_ADDRESS objReturn = new INDIVIDUAL_ADDRESS
			{
				ACCEPTS_TXT_MSG = (bool?)GetNullableObject(row.Field<object>("ACCEPTS_TXT_MSG")),
				ADDRESS_ID = (Int32)GetNullableObject(row.Field<object>("ADDRESS_ID")),
				ALT_EMAIL = (string)GetNullableObject(row.Field<object>("ALT_EMAIL")),
				CELL_PHONE = (string)GetNullableObject(row.Field<object>("CELL_PHONE")),
				CITY = (string)GetNullableObject(row.Field<object>("CITY")),
				COMMENTS = (string)GetNullableObject(row.Field<object>("COMMENTS")),
				CREATED = (DateTime?)GetNullableObject(row.Field<object>("CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("CREATEDBY")),
				EMAIL = (string)GetNullableObject(row.Field<object>("EMAIL")),
				FAX = (string)GetNullableObject(row.Field<object>("FAX")),
				IND_ID = (Int32)GetNullableObject(row.Field<object>("IND_ID")),
				PHONE = (string)GetNullableObject(row.Field<object>("PHONE")),
				POSTAL_CODE = (string)GetNullableObject(row.Field<object>("POSTAL_CODE")),
				STD_ADDRESSTYPE_ID = (Int32)GetNullableObject(row.Field<object>("STD_ADDRESSTYPE_ID")),
				STD_COUNTRY_ID = (Int32?)GetNullableObject(row.Field<object>("STD_COUNTRY_ID")),
				STD_STATE_ID = (Int32?)GetNullableObject(row.Field<object>("STD_STATE_ID")),
				STREET1 = (string)GetNullableObject(row.Field<object>("STREET1")),
				STREET2 = (string)GetNullableObject(row.Field<object>("STREET2")),
				STREET3 = (string)GetNullableObject(row.Field<object>("STREET3")),
				UPDATED = (DateTime?)GetNullableObject(row.Field<object>("UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("UPDATEDBY"))
			};

			return objReturn;
		}

		public INDIVIDUAL_ADDRESS ParseReaderCustom(DataRow row)
		{
			INDIVIDUAL_ADDRESS objReturn = new INDIVIDUAL_ADDRESS
			{
				ACCEPTS_TXT_MSG = (bool?)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_ACCEPTS_TXT_MSG")),
				ADDRESS_ID = (Int32)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_ADDRESS_ID")),
				ALT_EMAIL = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_ALT_EMAIL")),
				CELL_PHONE = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_CELL_PHONE")),
				CITY = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_CITY")),
				COMMENTS = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_COMMENTS")),
				CREATED = (DateTime?)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_CREATEDBY")),
				EMAIL = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_EMAIL")),
				FAX = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_FAX")),
				IND_ID = (Int32)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_IND_ID")),
				PHONE = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_PHONE")),
				POSTAL_CODE = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_POSTAL_CODE")),
				STD_ADDRESSTYPE_ID = (Int32)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_STD_ADDRESSTYPE_ID")),
				STD_COUNTRY_ID = (Int32?)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_STD_COUNTRY_ID")),
				STD_STATE_ID = (Int32?)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_STD_STATE_ID")),
				STREET1 = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_STREET1")),
				STREET2 = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_STREET2")),
				STREET3 = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_STREET3")),
				UPDATED = (DateTime?)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("INDIVIDUAL_ADDRESS_UPDATEDBY"))
			};

			return objReturn;
		}

		#endregion
	}
}
