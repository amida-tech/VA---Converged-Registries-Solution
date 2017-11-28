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
	public partial class USERSDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public USERSDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public USERS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ID)
		{
			USERS objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_USERS_getitem", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@USER_ID", USER_ID);

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

		public List<USERS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<USERS> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_USERS_getitems", sConn);
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
						objReturn = myData.ToList<USERS>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, USERS objSave)
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

				sCmd = new SqlCommand("CRS.usp_USERS_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@ACCOUNT_EXPIRE_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.ACCOUNT_EXPIRE_DATE);
				p = new SqlParameter("@ACCOUNT_LOCK_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.ACCOUNT_LOCK_DATE);
				p = new SqlParameter("@AGREEMENT_SIGNATURE_CODE", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.AGREEMENT_SIGNATURE_CODE);
				p = new SqlParameter("@CREATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.CREATED);
				p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
                p = new SqlParameter("@DEFAULT_REGISTRY_ID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.DEFAULT_REGISTRY_ID);
				p = new SqlParameter("@Domain", SqlDbType.VarChar, 63);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Domain);
				p = new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 128);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.EMAIL_ADDRESS);
				p = new SqlParameter("@EMPLOYEE_NUMBER", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.EMPLOYEE_NUMBER);
				p = new SqlParameter("@FAX_NUMBER", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.FAX_NUMBER);
				p = new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.FIRST_NAME);
				p = new SqlParameter("@FULL_NAME", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.FULL_NAME);
				p = new SqlParameter("@INACTIVE_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.INACTIVE_DATE);
				p = new SqlParameter("@INACTIVE_FLAG", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.INACTIVE_FLAG);
				p = new SqlParameter("@INITIAL_LOGIN_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.INITIAL_LOGIN_DATE);
				p = new SqlParameter("@JOB_TITLE", SqlDbType.VarChar, 80);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.JOB_TITLE);
				p = new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 40);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.LAST_NAME);
				p = new SqlParameter("@MAIDEN_NAME", SqlDbType.VarChar, 40);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MAIDEN_NAME);
				p = new SqlParameter("@MIDDLE_NAME", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MIDDLE_NAME);
				p = new SqlParameter("@NUMBER_OF_LOGIN_ATTEMPTS", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NUMBER_OF_LOGIN_ATTEMPTS);
				p = new SqlParameter("@PASSWORD", SqlDbType.VarChar, 128);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PASSWORD);
				p = new SqlParameter("@PASSWORD_CHANGE_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.PASSWORD_CHANGE_DATE);
				p = new SqlParameter("@PASSWORD_CREATE_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.PASSWORD_CREATE_DATE);
				p = new SqlParameter("@PASSWORD_EXPIRE_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.PASSWORD_EXPIRE_DATE);
				p = new SqlParameter("@SIGNATURE_VERIFIED_IND", SqlDbType.VarChar, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.SIGNATURE_VERIFIED_IND);
				p = new SqlParameter("@TELEPHONE_NUMBER", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TELEPHONE_NUMBER);
				p = new SqlParameter("@UPDATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.UPDATED);
				p = new SqlParameter("@UPDATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.UPDATEDBY);
				p = new SqlParameter("@USER_ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.USER_ID);
				p = new SqlParameter("@USERNAME", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.USERNAME);
                p = new SqlParameter("@RECEIVE_EMAIL", SqlDbType.Bit, 1);
                p.Precision = 1;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.RECEIVE_EMAIL);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

				LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
				//int cnt = sCmd.ExecuteNonQuery();
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

				objReturn = (Int32)sCmd.Parameters["@USER_ID"].Value;

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

		public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ID)
		{
			Boolean objReturn = false;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_USERS_delete", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@USER_ID", USER_ID);
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

		public USERS ParseReader(DataRow row)
		{
			USERS objReturn = new USERS
			{
				ACCOUNT_EXPIRE_DATE = (DateTime?)GetNullableObject(row.Field<object>("ACCOUNT_EXPIRE_DATE")),
				ACCOUNT_LOCK_DATE = (DateTime?)GetNullableObject(row.Field<object>("ACCOUNT_LOCK_DATE")),
				AGREEMENT_SIGNATURE_CODE = (string)GetNullableObject(row.Field<object>("AGREEMENT_SIGNATURE_CODE")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("CREATEDBY")),
                DEFAULT_REGISTRY_ID = (Int32?)GetNullableObject(row.Field<object>("DEFAULT_REGISTRY_ID")),
                Domain = (string)GetNullableObject(row.Field<object>("Domain")),
				EMAIL_ADDRESS = (string)GetNullableObject(row.Field<object>("EMAIL_ADDRESS")),
				EMPLOYEE_NUMBER = (string)GetNullableObject(row.Field<object>("EMPLOYEE_NUMBER")),
				FAX_NUMBER = (string)GetNullableObject(row.Field<object>("FAX_NUMBER")),
				FIRST_NAME = (string)GetNullableObject(row.Field<object>("FIRST_NAME")),
				FULL_NAME = (string)GetNullableObject(row.Field<object>("FULL_NAME")),
				INACTIVE_DATE = (DateTime?)GetNullableObject(row.Field<object>("INACTIVE_DATE")),
				INACTIVE_FLAG = (bool)GetNullableObject(row.Field<object>("INACTIVE_FLAG")),
				INITIAL_LOGIN_DATE = (DateTime?)GetNullableObject(row.Field<object>("INITIAL_LOGIN_DATE")),
				JOB_TITLE = (string)GetNullableObject(row.Field<object>("JOB_TITLE")),
				LAST_NAME = (string)GetNullableObject(row.Field<object>("LAST_NAME")),
				MAIDEN_NAME = (string)GetNullableObject(row.Field<object>("MAIDEN_NAME")),
				MIDDLE_NAME = (string)GetNullableObject(row.Field<object>("MIDDLE_NAME")),
				NUMBER_OF_LOGIN_ATTEMPTS = (Int32?)GetNullableObject(row.Field<object>("NUMBER_OF_LOGIN_ATTEMPTS")),
				PASSWORD = (string)GetNullableObject(row.Field<object>("PASSWORD")),
				PASSWORD_CHANGE_DATE = (DateTime?)GetNullableObject(row.Field<object>("PASSWORD_CHANGE_DATE")),
				PASSWORD_CREATE_DATE = (DateTime?)GetNullableObject(row.Field<object>("PASSWORD_CREATE_DATE")),
				PASSWORD_EXPIRE_DATE = (DateTime?)GetNullableObject(row.Field<object>("PASSWORD_EXPIRE_DATE")),
				SIGNATURE_VERIFIED_IND = (string)GetNullableObject(row.Field<object>("SIGNATURE_VERIFIED_IND")),
				TELEPHONE_NUMBER = (string)GetNullableObject(row.Field<object>("TELEPHONE_NUMBER")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("UPDATEDBY")),
				USER_ID = (Int32)GetNullableObject(row.Field<object>("USER_ID")),
				USERNAME = (string)GetNullableObject(row.Field<object>("USERNAME")),
                RECEIVE_EMAIL = (bool?)GetNullableObject(row.Field<object>("RECEIVE_EMAIL"))
			};

			return objReturn;
		}

		public USERS ParseReaderCustom(DataRow row)
		{
			USERS objReturn = new USERS
			{
				ACCOUNT_EXPIRE_DATE = (DateTime?)GetNullableObject(row.Field<object>("USERS_ACCOUNT_EXPIRE_DATE")),
				ACCOUNT_LOCK_DATE = (DateTime?)GetNullableObject(row.Field<object>("USERS_ACCOUNT_LOCK_DATE")),
				AGREEMENT_SIGNATURE_CODE = (string)GetNullableObject(row.Field<object>("USERS_AGREEMENT_SIGNATURE_CODE")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("USERS_CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("USERS_CREATEDBY")),
                DEFAULT_REGISTRY_ID = (Int32?)GetNullableObject(row.Field<object>("USERS_DEFAULT_REGISTRY_ID")),
				Domain = (string)GetNullableObject(row.Field<object>("USERS_Domain")),
				EMAIL_ADDRESS = (string)GetNullableObject(row.Field<object>("USERS_EMAIL_ADDRESS")),
				EMPLOYEE_NUMBER = (string)GetNullableObject(row.Field<object>("USERS_EMPLOYEE_NUMBER")),
				FAX_NUMBER = (string)GetNullableObject(row.Field<object>("USERS_FAX_NUMBER")),
				FIRST_NAME = (string)GetNullableObject(row.Field<object>("USERS_FIRST_NAME")),
				FULL_NAME = (string)GetNullableObject(row.Field<object>("USERS_FULL_NAME")),
				INACTIVE_DATE = (DateTime?)GetNullableObject(row.Field<object>("USERS_INACTIVE_DATE")),
				INACTIVE_FLAG = (bool)GetNullableObject(row.Field<object>("USERS_INACTIVE_FLAG")),
				INITIAL_LOGIN_DATE = (DateTime?)GetNullableObject(row.Field<object>("USERS_INITIAL_LOGIN_DATE")),
				JOB_TITLE = (string)GetNullableObject(row.Field<object>("USERS_JOB_TITLE")),
				LAST_NAME = (string)GetNullableObject(row.Field<object>("USERS_LAST_NAME")),
				MAIDEN_NAME = (string)GetNullableObject(row.Field<object>("USERS_MAIDEN_NAME")),
				MIDDLE_NAME = (string)GetNullableObject(row.Field<object>("USERS_MIDDLE_NAME")),
				NUMBER_OF_LOGIN_ATTEMPTS = (Int32?)GetNullableObject(row.Field<object>("USERS_NUMBER_OF_LOGIN_ATTEMPTS")),
				PASSWORD = (string)GetNullableObject(row.Field<object>("USERS_PASSWORD")),
				PASSWORD_CHANGE_DATE = (DateTime?)GetNullableObject(row.Field<object>("USERS_PASSWORD_CHANGE_DATE")),
				PASSWORD_CREATE_DATE = (DateTime?)GetNullableObject(row.Field<object>("USERS_PASSWORD_CREATE_DATE")),
				PASSWORD_EXPIRE_DATE = (DateTime?)GetNullableObject(row.Field<object>("USERS_PASSWORD_EXPIRE_DATE")),
				SIGNATURE_VERIFIED_IND = (string)GetNullableObject(row.Field<object>("USERS_SIGNATURE_VERIFIED_IND")),
				TELEPHONE_NUMBER = (string)GetNullableObject(row.Field<object>("USERS_TELEPHONE_NUMBER")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("USERS_UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("USERS_UPDATEDBY")),
				USER_ID = (Int32)GetNullableObject(row.Field<object>("USERS_USER_ID")),
				USERNAME = (string)GetNullableObject(row.Field<object>("USERS_USERNAME")),
                RECEIVE_EMAIL = (bool?)GetNullableObject(row.Field<object>("USERS_RECEIVE_EMAIL"))
			};

			return objReturn;
		}

		#endregion
	}
}
