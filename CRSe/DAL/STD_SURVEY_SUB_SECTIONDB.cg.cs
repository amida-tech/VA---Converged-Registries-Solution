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
	public partial class STD_SURVEY_SUB_SECTIONDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public STD_SURVEY_SUB_SECTIONDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public STD_SURVEY_SUB_SECTION GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_SURVEY_SUB_SECTION_ID)
		{
			STD_SURVEY_SUB_SECTION objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_SURVEY_SUB_SECTION_getitem", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@STD_SURVEY_SUB_SECTION_ID", STD_SURVEY_SUB_SECTION_ID);

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

		public List<STD_SURVEY_SUB_SECTION> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_SURVEY_SUB_SECTION> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_SURVEY_SUB_SECTION_getitems", sConn);
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
						objReturn = myData.ToList<STD_SURVEY_SUB_SECTION>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_SURVEY_SUB_SECTION objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_SURVEY_SUB_SECTION_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@BRP_FORM_SUB_SECTION_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.BRP_FORM_SUB_SECTION_ID);
				p = new SqlParameter("@CONCLUSION", SqlDbType.VarChar, 4000);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CONCLUSION);
				p = new SqlParameter("@CREATED", SqlDbType.DateTime2, 6);
				p.Precision = 19;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATED);
				p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
				p = new SqlParameter("@INTRODUCTION", SqlDbType.VarChar, 4000);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.INTRODUCTION);
				p = new SqlParameter("@MENU_ITEM_NAME", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MENU_ITEM_NAME);
				p = new SqlParameter("@STD_SURVEY_SECTION_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_SURVEY_SECTION_ID);
				p = new SqlParameter("@STD_SURVEY_SUB_SECTION_ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_SURVEY_SUB_SECTION_ID);
				p = new SqlParameter("@STD_SURVEY_TYPE_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_SURVEY_TYPE_ID);
				p = new SqlParameter("@TITLE", SqlDbType.VarChar, 255);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TITLE);
				p = new SqlParameter("@TOOL_TIP", SqlDbType.VarChar, 255);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TOOL_TIP);
				p = new SqlParameter("@UPDATED", SqlDbType.DateTime2, 6);
				p.Precision = 19;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.UPDATED);
				p = new SqlParameter("@UPDATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.UPDATEDBY);

				LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
				int cnt = sCmd.ExecuteNonQuery();
				LogManager.LogTiming(logDetails);

				objReturn = (Int32)sCmd.Parameters["@STD_SURVEY_SUB_SECTION_ID"].Value;

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

		public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_SURVEY_SUB_SECTION_ID)
		{
			Boolean objReturn = false;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_SURVEY_SUB_SECTION_delete", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@STD_SURVEY_SUB_SECTION_ID", STD_SURVEY_SUB_SECTION_ID);
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

		public STD_SURVEY_SUB_SECTION ParseReader(DataRow row)
		{
			STD_SURVEY_SUB_SECTION objReturn = new STD_SURVEY_SUB_SECTION
			{
				BRP_FORM_SUB_SECTION_ID = (Int32?)GetNullableObject(row.Field<object>("BRP_FORM_SUB_SECTION_ID")),
				CONCLUSION = (string)GetNullableObject(row.Field<object>("CONCLUSION")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("CREATEDBY")),
				INTRODUCTION = (string)GetNullableObject(row.Field<object>("INTRODUCTION")),
				MENU_ITEM_NAME = (string)GetNullableObject(row.Field<object>("MENU_ITEM_NAME")),
				STD_SURVEY_SECTION_ID = (Int32)GetNullableObject(row.Field<object>("STD_SURVEY_SECTION_ID")),
				STD_SURVEY_SUB_SECTION_ID = (Int32)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_ID")),
				STD_SURVEY_TYPE_ID = (Int32)GetNullableObject(row.Field<object>("STD_SURVEY_TYPE_ID")),
				TITLE = (string)GetNullableObject(row.Field<object>("TITLE")),
				TOOL_TIP = (string)GetNullableObject(row.Field<object>("TOOL_TIP")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("UPDATEDBY"))
			};

			return objReturn;
		}

		public STD_SURVEY_SUB_SECTION ParseReaderCustom(DataRow row)
		{
			STD_SURVEY_SUB_SECTION objReturn = new STD_SURVEY_SUB_SECTION
			{
				BRP_FORM_SUB_SECTION_ID = (Int32?)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_BRP_FORM_SUB_SECTION_ID")),
				CONCLUSION = (string)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_CONCLUSION")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_CREATEDBY")),
				INTRODUCTION = (string)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_INTRODUCTION")),
				MENU_ITEM_NAME = (string)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_MENU_ITEM_NAME")),
				STD_SURVEY_SECTION_ID = (Int32)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_STD_SURVEY_SECTION_ID")),
				STD_SURVEY_SUB_SECTION_ID = (Int32)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_STD_SURVEY_SUB_SECTION_ID")),
				STD_SURVEY_TYPE_ID = (Int32)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_STD_SURVEY_TYPE_ID")),
				TITLE = (string)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_TITLE")),
				TOOL_TIP = (string)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_TOOL_TIP")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("STD_SURVEY_SUB_SECTION_UPDATEDBY"))
			};

			return objReturn;
		}

		#endregion
	}
}
