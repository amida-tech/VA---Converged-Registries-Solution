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
	public partial class STD_QUESTION_CHOICEDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public STD_QUESTION_CHOICEDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public STD_QUESTION_CHOICE GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_QUESTION_CHOICE_ID)
		{
			STD_QUESTION_CHOICE objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_QUESTION_CHOICE_getitem", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@STD_QUESTION_CHOICE_ID", STD_QUESTION_CHOICE_ID);

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

		public List<STD_QUESTION_CHOICE> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_QUESTION_CHOICE> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_QUESTION_CHOICE_getitems", sConn);
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
						objReturn = myData.ToList<STD_QUESTION_CHOICE>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_QUESTION_CHOICE objSave)
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

				sCmd = new SqlCommand("CRS.usp_STD_QUESTION_CHOICE_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@CHOICE_NAME", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CHOICE_NAME);
				p = new SqlParameter("@CHOICE_SORT_ORDER", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CHOICE_SORT_ORDER);
				p = new SqlParameter("@CHOICE_TEXT", SqlDbType.VarChar, 4000);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CHOICE_TEXT);
				p = new SqlParameter("@CREATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.CREATED);
				p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
				p = new SqlParameter("@INACTIVE_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.INACTIVE_DATE);
				p = new SqlParameter("@INACTIVE_FLAG", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.INACTIVE_FLAG);
				p = new SqlParameter("@STD_QUESTION_CHOICE_ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_QUESTION_CHOICE_ID);
				p = new SqlParameter("@STD_QUESTION_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_QUESTION_ID);
				p = new SqlParameter("@UPDATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.UPDATED);
				p = new SqlParameter("@UPDATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.UPDATEDBY);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

				LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                //int cnt = sCmd.ExecuteNonQuery();
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

				objReturn = (Int32)sCmd.Parameters["@STD_QUESTION_CHOICE_ID"].Value;

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

		public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_QUESTION_CHOICE_ID)
		{
			Boolean objReturn = false;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_QUESTION_CHOICE_delete", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@STD_QUESTION_CHOICE_ID", STD_QUESTION_CHOICE_ID);
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

		public STD_QUESTION_CHOICE ParseReader(DataRow row)
		{
			STD_QUESTION_CHOICE objReturn = new STD_QUESTION_CHOICE
			{
				CHOICE_NAME = (string)GetNullableObject(row.Field<object>("CHOICE_NAME")),
				CHOICE_SORT_ORDER = (Int32?)GetNullableObject(row.Field<object>("CHOICE_SORT_ORDER")),
				CHOICE_TEXT = (string)GetNullableObject(row.Field<object>("CHOICE_TEXT")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("CREATEDBY")),
				INACTIVE_DATE = (DateTime?)GetNullableObject(row.Field<object>("INACTIVE_DATE")),
				INACTIVE_FLAG = (bool)GetNullableObject(row.Field<object>("INACTIVE_FLAG")),
				STD_QUESTION_CHOICE_ID = (Int32)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_ID")),
				STD_QUESTION_ID = (Int32)GetNullableObject(row.Field<object>("STD_QUESTION_ID")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("UPDATEDBY"))
			};

			return objReturn;
		}

		public STD_QUESTION_CHOICE ParseReaderCustom(DataRow row)
		{
			STD_QUESTION_CHOICE objReturn = new STD_QUESTION_CHOICE
			{
				CHOICE_NAME = (string)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_CHOICE_NAME")),
				CHOICE_SORT_ORDER = (Int32?)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_CHOICE_SORT_ORDER")),
				CHOICE_TEXT = (string)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_CHOICE_TEXT")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_CREATEDBY")),
				INACTIVE_DATE = (DateTime?)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_INACTIVE_DATE")),
				INACTIVE_FLAG = (bool)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_INACTIVE_FLAG")),
				STD_QUESTION_CHOICE_ID = (Int32)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_STD_QUESTION_CHOICE_ID")),
				STD_QUESTION_ID = (Int32)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_STD_QUESTION_ID")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("STD_QUESTION_CHOICE_UPDATEDBY"))
			};

			return objReturn;
		}

		#endregion
	}
}
