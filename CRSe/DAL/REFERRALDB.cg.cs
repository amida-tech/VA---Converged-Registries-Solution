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
	public partial class REFERRALDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public REFERRALDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public REFERRAL GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 REFERRAL_ID)
		{
			REFERRAL objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_REFERRAL_getitem", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@REFERRAL_ID", REFERRAL_ID);

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

		public List<REFERRAL> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<REFERRAL> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_REFERRAL_getitems", sConn);
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
						objReturn = myData.ToList<REFERRAL>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, REFERRAL objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_REFERRAL_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@COMMENT_TEXT", SqlDbType.VarChar, 4000);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.COMMENT_TEXT);
				p = new SqlParameter("@CREATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.CREATED);
				p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
				p = new SqlParameter("@CREATEDSOURCE", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATEDSOURCE);
				p = new SqlParameter("@DUPLICATE_FLAG", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DUPLICATE_FLAG);
				p = new SqlParameter("@PATIENT_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PATIENT_ID);
				p = new SqlParameter("@PROVIDER_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PROVIDER_ID);
				p = new SqlParameter("@REFERRAL_CLASS_TEXT", SqlDbType.VarChar, 4000);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.REFERRAL_CLASS_TEXT);
				p = new SqlParameter("@REFERRAL_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.REFERRAL_DATE);
				p = new SqlParameter("@REFERRAL_ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.REFERRAL_ID);
				p = new SqlParameter("@REVIEW_BY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.REVIEW_BY);
				p = new SqlParameter("@REVIEW_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.REVIEW_DATE);
				p = new SqlParameter("@STD_REFERRALSTS_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_REFERRALSTS_ID);
				p = new SqlParameter("@STD_REGISTRY_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_REGISTRY_ID);
				p = new SqlParameter("@STD_REMINDERCLASS_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_REMINDERCLASS_ID);
				p = new SqlParameter("@UPDATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.UPDATED);
				p = new SqlParameter("@UPDATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.UPDATEDBY);
				p = new SqlParameter("@UPDATEDSOURCE", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.UPDATEDSOURCE);

				LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
				int cnt = sCmd.ExecuteNonQuery();
				LogManager.LogTiming(logDetails);

				objReturn = (Int32)sCmd.Parameters["@REFERRAL_ID"].Value;

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

		public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 REFERRAL_ID)
		{
			Boolean objReturn = false;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_REFERRAL_delete", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@REFERRAL_ID", REFERRAL_ID);
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

		public REFERRAL ParseReader(DataRow row)
		{
			REFERRAL objReturn = new REFERRAL
			{
				COMMENT_TEXT = (string)GetNullableObject(row.Field<object>("COMMENT_TEXT")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("CREATEDBY")),
				CREATEDSOURCE = (string)GetNullableObject(row.Field<object>("CREATEDSOURCE")),
				DUPLICATE_FLAG = (bool)GetNullableObject(row.Field<object>("DUPLICATE_FLAG")),
				PATIENT_ID = (Int32)GetNullableObject(row.Field<object>("PATIENT_ID")),
				PROVIDER_ID = (Int32?)GetNullableObject(row.Field<object>("PROVIDER_ID")),
				REFERRAL_CLASS_TEXT = (string)GetNullableObject(row.Field<object>("REFERRAL_CLASS_TEXT")),
				REFERRAL_DATE = (DateTime?)GetNullableObject(row.Field<object>("REFERRAL_DATE")),
				REFERRAL_ID = (Int32)GetNullableObject(row.Field<object>("REFERRAL_ID")),
				REVIEW_BY = (string)GetNullableObject(row.Field<object>("REVIEW_BY")),
				REVIEW_DATE = (DateTime?)GetNullableObject(row.Field<object>("REVIEW_DATE")),
				STD_REFERRALSTS_ID = (Int32)GetNullableObject(row.Field<object>("STD_REFERRALSTS_ID")),
				STD_REGISTRY_ID = (Int32)GetNullableObject(row.Field<object>("STD_REGISTRY_ID")),
				STD_REMINDERCLASS_ID = (Int32?)GetNullableObject(row.Field<object>("STD_REMINDERCLASS_ID")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("UPDATEDBY")),
				UPDATEDSOURCE = (string)GetNullableObject(row.Field<object>("UPDATEDSOURCE"))
			};

			return objReturn;
		}

		public REFERRAL ParseReaderCustom(DataRow row)
		{
			REFERRAL objReturn = new REFERRAL
			{
				COMMENT_TEXT = (string)GetNullableObject(row.Field<object>("REFERRAL_COMMENT_TEXT")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("REFERRAL_CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("REFERRAL_CREATEDBY")),
				CREATEDSOURCE = (string)GetNullableObject(row.Field<object>("REFERRAL_CREATEDSOURCE")),
				DUPLICATE_FLAG = (bool)GetNullableObject(row.Field<object>("REFERRAL_DUPLICATE_FLAG")),
				PATIENT_ID = (Int32)GetNullableObject(row.Field<object>("REFERRAL_PATIENT_ID")),
				PROVIDER_ID = (Int32?)GetNullableObject(row.Field<object>("REFERRAL_PROVIDER_ID")),
				REFERRAL_CLASS_TEXT = (string)GetNullableObject(row.Field<object>("REFERRAL_REFERRAL_CLASS_TEXT")),
				REFERRAL_DATE = (DateTime?)GetNullableObject(row.Field<object>("REFERRAL_REFERRAL_DATE")),
				REFERRAL_ID = (Int32)GetNullableObject(row.Field<object>("REFERRAL_REFERRAL_ID")),
				REVIEW_BY = (string)GetNullableObject(row.Field<object>("REFERRAL_REVIEW_BY")),
				REVIEW_DATE = (DateTime?)GetNullableObject(row.Field<object>("REFERRAL_REVIEW_DATE")),
				STD_REFERRALSTS_ID = (Int32)GetNullableObject(row.Field<object>("REFERRAL_STD_REFERRALSTS_ID")),
				STD_REGISTRY_ID = (Int32)GetNullableObject(row.Field<object>("REFERRAL_STD_REGISTRY_ID")),
				STD_REMINDERCLASS_ID = (Int32?)GetNullableObject(row.Field<object>("REFERRAL_STD_REMINDERCLASS_ID")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("REFERRAL_UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("REFERRAL_UPDATEDBY")),
				UPDATEDSOURCE = (string)GetNullableObject(row.Field<object>("REFERRAL_UPDATEDSOURCE"))
			};

			return objReturn;
		}

		#endregion
	}
}
