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
	public partial class STD_REGISTRY_CODESDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public STD_REGISTRY_CODESDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public STD_REGISTRY_CODES GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			STD_REGISTRY_CODES objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_REGISTRY_CODES_getitem", sConn);
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

		public List<STD_REGISTRY_CODES> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_REGISTRY_CODES> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_REGISTRY_CODES_getitems", sConn);
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
						objReturn = myData.ToList<STD_REGISTRY_CODES>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_REGISTRY_CODES objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_REGISTRY_CODES_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@CODE", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CODE);
				p = new SqlParameter("@CODE_TYPE", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CODE_TYPE);
				p = new SqlParameter("@COMMENTS", SqlDbType.VarChar, -1);
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
				p = new SqlParameter("@DESCRIPTION_TEXT", SqlDbType.VarChar, 500);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DESCRIPTION_TEXT);
				p = new SqlParameter("@ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ID);
				p = new SqlParameter("@INACTIVE_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.INACTIVE_DATE);
				p = new SqlParameter("@INACTIVE_FLAG", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.INACTIVE_FLAG);
				p = new SqlParameter("@NAME", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NAME);
				p = new SqlParameter("@SORT_ORDER", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.SORT_ORDER);
				p = new SqlParameter("@STD_REGISTRY_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_REGISTRY_ID);
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

				sCmd = new SqlCommand("CRS.usp_STD_REGISTRY_CODES_delete", sConn);
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

		public STD_REGISTRY_CODES ParseReader(DataRow row)
		{
			STD_REGISTRY_CODES objReturn = new STD_REGISTRY_CODES
			{
				CODE = (string)GetNullableObject(row.Field<object>("CODE")),
				CODE_TYPE = (string)GetNullableObject(row.Field<object>("CODE_TYPE")),
				COMMENTS = (string)GetNullableObject(row.Field<object>("COMMENTS")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("CREATEDBY")),
				DESCRIPTION_TEXT = (string)GetNullableObject(row.Field<object>("DESCRIPTION_TEXT")),
				ID = (Int32)GetNullableObject(row.Field<object>("ID")),
				INACTIVE_DATE = (DateTime?)GetNullableObject(row.Field<object>("INACTIVE_DATE")),
				INACTIVE_FLAG = (bool)GetNullableObject(row.Field<object>("INACTIVE_FLAG")),
				NAME = (string)GetNullableObject(row.Field<object>("NAME")),
				SORT_ORDER = (Int32?)GetNullableObject(row.Field<object>("SORT_ORDER")),
				STD_REGISTRY_ID = (Int32)GetNullableObject(row.Field<object>("STD_REGISTRY_ID")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("UPDATEDBY"))
			};

			return objReturn;
		}

		public STD_REGISTRY_CODES ParseReaderCustom(DataRow row)
		{
			STD_REGISTRY_CODES objReturn = new STD_REGISTRY_CODES
			{
				CODE = (string)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_CODE")),
				CODE_TYPE = (string)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_CODE_TYPE")),
				COMMENTS = (string)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_COMMENTS")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_CREATEDBY")),
				DESCRIPTION_TEXT = (string)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_DESCRIPTION_TEXT")),
				ID = (Int32)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_ID")),
				INACTIVE_DATE = (DateTime?)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_INACTIVE_DATE")),
				INACTIVE_FLAG = (bool)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_INACTIVE_FLAG")),
				NAME = (string)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_NAME")),
				SORT_ORDER = (Int32?)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_SORT_ORDER")),
				STD_REGISTRY_ID = (Int32)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_STD_REGISTRY_ID")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("STD_REGISTRY_CODES_UPDATEDBY"))
			};

			return objReturn;
		}

		#endregion
	}
}