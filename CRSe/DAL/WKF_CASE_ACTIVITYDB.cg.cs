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
	public partial class WKF_CASE_ACTIVITYDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public WKF_CASE_ACTIVITYDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public WKF_CASE_ACTIVITY GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_ACTIVITY_ID)
		{
			WKF_CASE_ACTIVITY objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_WKF_CASE_ACTIVITY_getitem", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@WKF_CASE_ACTIVITY_ID", WKF_CASE_ACTIVITY_ID);

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

		public List<WKF_CASE_ACTIVITY> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<WKF_CASE_ACTIVITY> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_WKF_CASE_ACTIVITY_getitems", sConn);
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
						objReturn = myData.ToList<WKF_CASE_ACTIVITY>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, WKF_CASE_ACTIVITY objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_WKF_CASE_ACTIVITY_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@ADDRESS_LINE1", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ADDRESS_LINE1);
				p = new SqlParameter("@ADDRESS_LINE2", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ADDRESS_LINE2);
				p = new SqlParameter("@ADDRESS_LINE3", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ADDRESS_LINE3);
				p = new SqlParameter("@BEST_CALL_BACK_TIME", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.BEST_CALL_BACK_TIME);
				p = new SqlParameter("@CITY", SqlDbType.VarChar, 60);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CITY);
				p = new SqlParameter("@CONTACT_EMAIL", SqlDbType.VarChar, 255);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CONTACT_EMAIL);
				p = new SqlParameter("@CONTACT_NAME", SqlDbType.VarChar, 255);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CONTACT_NAME);
				p = new SqlParameter("@CONTACT_PHONE", SqlDbType.VarChar, 255);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CONTACT_PHONE);
				p = new SqlParameter("@COUNTRY", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.COUNTRY);
				p = new SqlParameter("@CREATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.CREATED);
				p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
				p = new SqlParameter("@INFO_CONVEYED_TEXT", SqlDbType.VarChar, -1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.INFO_CONVEYED_TEXT);
				p = new SqlParameter("@INFO_RECEIVED_TEXT", SqlDbType.VarChar, -1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.INFO_RECEIVED_TEXT);
				p = new SqlParameter("@POSTAL_CODE", SqlDbType.VarChar, 10);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.POSTAL_CODE);
				p = new SqlParameter("@STATE", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STATE);
				p = new SqlParameter("@STD_WKFACTIVITYTYPE_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_WKFACTIVITYTYPE_ID);
				p = new SqlParameter("@UPDATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.UPDATED);
				p = new SqlParameter("@UPDATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.UPDATEDBY);
				p = new SqlParameter("@WKF_CASE_ACTIVITY_ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.WKF_CASE_ACTIVITY_ID);
				p = new SqlParameter("@WKF_CASE_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.WKF_CASE_ID);
                p = new SqlParameter("@STD_WKFACTIVITYSTS_ID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.STD_WKFACTIVITYSTS_ID);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

				LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                //int cnt = sCmd.ExecuteNonQuery();
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

				objReturn = (Int32)sCmd.Parameters["@WKF_CASE_ACTIVITY_ID"].Value;

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

		public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_ACTIVITY_ID)
		{
			Boolean objReturn = false;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_WKF_CASE_ACTIVITY_delete", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@WKF_CASE_ACTIVITY_ID", WKF_CASE_ACTIVITY_ID);
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

		public WKF_CASE_ACTIVITY ParseReader(DataRow row)
		{
			WKF_CASE_ACTIVITY objReturn = new WKF_CASE_ACTIVITY
			{
				ADDRESS_LINE1 = (string)GetNullableObject(row.Field<object>("ADDRESS_LINE1")),
				ADDRESS_LINE2 = (string)GetNullableObject(row.Field<object>("ADDRESS_LINE2")),
				ADDRESS_LINE3 = (string)GetNullableObject(row.Field<object>("ADDRESS_LINE3")),
				BEST_CALL_BACK_TIME = (string)GetNullableObject(row.Field<object>("BEST_CALL_BACK_TIME")),
				CITY = (string)GetNullableObject(row.Field<object>("CITY")),
				CONTACT_EMAIL = (string)GetNullableObject(row.Field<object>("CONTACT_EMAIL")),
				CONTACT_NAME = (string)GetNullableObject(row.Field<object>("CONTACT_NAME")),
				CONTACT_PHONE = (string)GetNullableObject(row.Field<object>("CONTACT_PHONE")),
				COUNTRY = (string)GetNullableObject(row.Field<object>("COUNTRY")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("CREATEDBY")),
				INFO_CONVEYED_TEXT = (string)GetNullableObject(row.Field<object>("INFO_CONVEYED_TEXT")),
				INFO_RECEIVED_TEXT = (string)GetNullableObject(row.Field<object>("INFO_RECEIVED_TEXT")),
				POSTAL_CODE = (string)GetNullableObject(row.Field<object>("POSTAL_CODE")),
				STATE = (string)GetNullableObject(row.Field<object>("STATE")),
				STD_WKFACTIVITYTYPE_ID = (Int32)GetNullableObject(row.Field<object>("STD_WKFACTIVITYTYPE_ID")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("UPDATEDBY")),
				WKF_CASE_ACTIVITY_ID = (Int32)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_ID")),
				WKF_CASE_ID = (Int32)GetNullableObject(row.Field<object>("WKF_CASE_ID")),
                STD_WKFACTIVITYSTS_ID = (Int32)GetNullableObject(row.Field<object>("STD_WKFACTIVITYSTS_ID"))
			};

			return objReturn;
		}

		public WKF_CASE_ACTIVITY ParseReaderCustom(DataRow row)
		{
			WKF_CASE_ACTIVITY objReturn = new WKF_CASE_ACTIVITY
			{
				ADDRESS_LINE1 = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_ADDRESS_LINE1")),
				ADDRESS_LINE2 = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_ADDRESS_LINE2")),
				ADDRESS_LINE3 = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_ADDRESS_LINE3")),
				BEST_CALL_BACK_TIME = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_BEST_CALL_BACK_TIME")),
				CITY = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_CITY")),
				CONTACT_EMAIL = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_CONTACT_EMAIL")),
				CONTACT_NAME = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_CONTACT_NAME")),
				CONTACT_PHONE = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_CONTACT_PHONE")),
				COUNTRY = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_COUNTRY")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_CREATEDBY")),
				INFO_CONVEYED_TEXT = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_INFO_CONVEYED_TEXT")),
				INFO_RECEIVED_TEXT = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_INFO_RECEIVED_TEXT")),
				POSTAL_CODE = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_POSTAL_CODE")),
				STATE = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_STATE")),
				STD_WKFACTIVITYTYPE_ID = (Int32)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_STD_WKFACTIVITYTYPE_ID")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_UPDATEDBY")),
				WKF_CASE_ACTIVITY_ID = (Int32)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_WKF_CASE_ACTIVITY_ID")),
				WKF_CASE_ID = (Int32)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_WKF_CASE_ID")),
                STD_WKFACTIVITYSTS_ID = (Int32)GetNullableObject(row.Field<object>("WKF_CASE_ACTIVITY_STD_WKFACTIVITYSTS_ID"))
			};

			return objReturn;
		}

		#endregion
	}
}
