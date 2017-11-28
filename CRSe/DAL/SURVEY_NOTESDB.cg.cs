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
	public partial class SURVEY_NOTESDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public SURVEY_NOTESDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public SURVEY_NOTES GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 NOTE_ID)
		{
			SURVEY_NOTES objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_SURVEY_NOTES_getitem", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@NOTE_ID", NOTE_ID);

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

		public List<SURVEY_NOTES> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<SURVEY_NOTES> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_SURVEY_NOTES_getitems", sConn);
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
						objReturn = myData.ToList<SURVEY_NOTES>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SURVEY_NOTES objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_SURVEY_NOTES_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@AUTHOR_FIRST_NAME", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.AUTHOR_FIRST_NAME);
				p = new SqlParameter("@AUTHOR_LAST_NAME", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.AUTHOR_LAST_NAME);
				p = new SqlParameter("@AUTHOR_MIDDLE_NAME", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.AUTHOR_MIDDLE_NAME);
				p = new SqlParameter("@AUTHOR_TITLE", SqlDbType.VarChar, 250);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.AUTHOR_TITLE);
				p = new SqlParameter("@CREATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.CREATED);
				p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
				p = new SqlParameter("@ENTRY_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.ENTRY_DATE);
				p = new SqlParameter("@NOTE_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.NOTE_DATE);
				p = new SqlParameter("@NOTE_ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NOTE_ID);
				p = new SqlParameter("@NOTES_TEXT", SqlDbType.VarChar, -1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NOTES_TEXT);
				p = new SqlParameter("@STATUS", SqlDbType.VarChar, 20);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STATUS);
				p = new SqlParameter("@SURVEYS_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.SURVEYS_ID);
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

				objReturn = (Int32)sCmd.Parameters["@NOTE_ID"].Value;

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

		public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 NOTE_ID)
		{
			Boolean objReturn = false;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_SURVEY_NOTES_delete", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@NOTE_ID", NOTE_ID);
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

		public SURVEY_NOTES ParseReader(DataRow row)
		{
			SURVEY_NOTES objReturn = new SURVEY_NOTES
			{
				AUTHOR_FIRST_NAME = (string)GetNullableObject(row.Field<object>("AUTHOR_FIRST_NAME")),
				AUTHOR_LAST_NAME = (string)GetNullableObject(row.Field<object>("AUTHOR_LAST_NAME")),
				AUTHOR_MIDDLE_NAME = (string)GetNullableObject(row.Field<object>("AUTHOR_MIDDLE_NAME")),
				AUTHOR_TITLE = (string)GetNullableObject(row.Field<object>("AUTHOR_TITLE")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("CREATEDBY")),
				ENTRY_DATE = (DateTime?)GetNullableObject(row.Field<object>("ENTRY_DATE")),
				NOTE_DATE = (DateTime?)GetNullableObject(row.Field<object>("NOTE_DATE")),
				NOTE_ID = (Int32)GetNullableObject(row.Field<object>("NOTE_ID")),
				NOTES_TEXT = (string)GetNullableObject(row.Field<object>("NOTES_TEXT")),
				STATUS = (string)GetNullableObject(row.Field<object>("STATUS")),
				SURVEYS_ID = (Int32)GetNullableObject(row.Field<object>("SURVEYS_ID")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("UPDATEDBY"))
			};

			return objReturn;
		}

		public SURVEY_NOTES ParseReaderCustom(DataRow row)
		{
			SURVEY_NOTES objReturn = new SURVEY_NOTES
			{
				AUTHOR_FIRST_NAME = (string)GetNullableObject(row.Field<object>("SURVEY_NOTES_AUTHOR_FIRST_NAME")),
				AUTHOR_LAST_NAME = (string)GetNullableObject(row.Field<object>("SURVEY_NOTES_AUTHOR_LAST_NAME")),
				AUTHOR_MIDDLE_NAME = (string)GetNullableObject(row.Field<object>("SURVEY_NOTES_AUTHOR_MIDDLE_NAME")),
				AUTHOR_TITLE = (string)GetNullableObject(row.Field<object>("SURVEY_NOTES_AUTHOR_TITLE")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("SURVEY_NOTES_CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("SURVEY_NOTES_CREATEDBY")),
				ENTRY_DATE = (DateTime?)GetNullableObject(row.Field<object>("SURVEY_NOTES_ENTRY_DATE")),
				NOTE_DATE = (DateTime?)GetNullableObject(row.Field<object>("SURVEY_NOTES_NOTE_DATE")),
				NOTE_ID = (Int32)GetNullableObject(row.Field<object>("SURVEY_NOTES_NOTE_ID")),
				NOTES_TEXT = (string)GetNullableObject(row.Field<object>("SURVEY_NOTES_NOTES_TEXT")),
				STATUS = (string)GetNullableObject(row.Field<object>("SURVEY_NOTES_STATUS")),
				SURVEYS_ID = (Int32)GetNullableObject(row.Field<object>("SURVEY_NOTES_SURVEYS_ID")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("SURVEY_NOTES_UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("SURVEY_NOTES_UPDATEDBY"))
			};

			return objReturn;
		}

		#endregion
	}
}
