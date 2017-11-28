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
	public partial class STD_GUI_CONTROLSDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public STD_GUI_CONTROLSDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public STD_GUI_CONTROLS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			STD_GUI_CONTROLS objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_GUI_CONTROLS_getitem", sConn);
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

		public List<STD_GUI_CONTROLS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_GUI_CONTROLS> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_GUI_CONTROLS_getitems", sConn);
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
						objReturn = myData.ToList<STD_GUI_CONTROLS>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_GUI_CONTROLS objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_STD_GUI_CONTROLS_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@BASE_CONTROL_TYPE", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.BASE_CONTROL_TYPE);
				p = new SqlParameter("@BASE_CONTROL_WIDTH", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.BASE_CONTROL_WIDTH);
				p = new SqlParameter("@CATEGORY", SqlDbType.VarChar, 400);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CATEGORY);
				p = new SqlParameter("@CREATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.CREATED);
				p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
				p = new SqlParameter("@DATA_ELEMENT_WIDTH", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DATA_ELEMENT_WIDTH);
				p = new SqlParameter("@DATA_TYPE_MAX_LENGTH", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DATA_TYPE_MAX_LENGTH);
				p = new SqlParameter("@ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ID);
				p = new SqlParameter("@INCLUDE_LABEL", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.INCLUDE_LABEL);
				p = new SqlParameter("@LABEL_TEXT", SqlDbType.VarChar, 1000);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.LABEL_TEXT);
				p = new SqlParameter("@LOOKUP_LIST_CATEGORY", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.LOOKUP_LIST_CATEGORY);
				p = new SqlParameter("@LOOKUP_LIST_CATEGORY2", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.LOOKUP_LIST_CATEGORY2);
				p = new SqlParameter("@LOOKUP_LIST_CATEGORY3", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.LOOKUP_LIST_CATEGORY3);
				p = new SqlParameter("@NAME", SqlDbType.VarChar, 400);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NAME);
				p = new SqlParameter("@PANEL_NAME", SqlDbType.VarChar, 400);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PANEL_NAME);
				p = new SqlParameter("@REQUIRED", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.REQUIRED);
				p = new SqlParameter("@SORT_ORDER", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.SORT_ORDER);
				p = new SqlParameter("@STD_REGISTRY_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.STD_REGISTRY_ID);
				p = new SqlParameter("@TOOL_TIP", SqlDbType.VarChar, 500);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TOOL_TIP);
				p = new SqlParameter("@UPDATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.UPDATED);
				p = new SqlParameter("@UPDATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.UPDATEDBY);
				p = new SqlParameter("@USER_CONTROL_ID", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.USER_CONTROL_ID);
				p = new SqlParameter("@VALIDATION_ERROR_MESSAGE", SqlDbType.VarChar, 500);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.VALIDATION_ERROR_MESSAGE);
				p = new SqlParameter("@VALIDATION_GROUP", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.VALIDATION_GROUP);
				p = new SqlParameter("@VALIDATION_REGULAR_EXPRESSION", SqlDbType.VarChar, 500);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.VALIDATION_REGULAR_EXPRESSION);

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

				sCmd = new SqlCommand("CRS.usp_STD_GUI_CONTROLS_delete", sConn);
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

		public STD_GUI_CONTROLS ParseReader(DataRow row)
		{
			STD_GUI_CONTROLS objReturn = new STD_GUI_CONTROLS
			{
				BASE_CONTROL_TYPE = (Int32)GetNullableObject(row.Field<object>("BASE_CONTROL_TYPE")),
				BASE_CONTROL_WIDTH = (Int32?)GetNullableObject(row.Field<object>("BASE_CONTROL_WIDTH")),
				CATEGORY = (string)GetNullableObject(row.Field<object>("CATEGORY")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("CREATEDBY")),
				DATA_ELEMENT_WIDTH = (Int32?)GetNullableObject(row.Field<object>("DATA_ELEMENT_WIDTH")),
				DATA_TYPE_MAX_LENGTH = (Int32?)GetNullableObject(row.Field<object>("DATA_TYPE_MAX_LENGTH")),
				ID = (Int32)GetNullableObject(row.Field<object>("ID")),
				INCLUDE_LABEL = (bool)GetNullableObject(row.Field<object>("INCLUDE_LABEL")),
				LABEL_TEXT = (string)GetNullableObject(row.Field<object>("LABEL_TEXT")),
				LOOKUP_LIST_CATEGORY = (string)GetNullableObject(row.Field<object>("LOOKUP_LIST_CATEGORY")),
				LOOKUP_LIST_CATEGORY2 = (string)GetNullableObject(row.Field<object>("LOOKUP_LIST_CATEGORY2")),
				LOOKUP_LIST_CATEGORY3 = (string)GetNullableObject(row.Field<object>("LOOKUP_LIST_CATEGORY3")),
				NAME = (string)GetNullableObject(row.Field<object>("NAME")),
				PANEL_NAME = (string)GetNullableObject(row.Field<object>("PANEL_NAME")),
				REQUIRED = (bool)GetNullableObject(row.Field<object>("REQUIRED")),
				SORT_ORDER = (Int32)GetNullableObject(row.Field<object>("SORT_ORDER")),
				STD_REGISTRY_ID = (Int32)GetNullableObject(row.Field<object>("STD_REGISTRY_ID")),
				TOOL_TIP = (string)GetNullableObject(row.Field<object>("TOOL_TIP")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("UPDATEDBY")),
				USER_CONTROL_ID = (string)GetNullableObject(row.Field<object>("USER_CONTROL_ID")),
				VALIDATION_ERROR_MESSAGE = (string)GetNullableObject(row.Field<object>("VALIDATION_ERROR_MESSAGE")),
				VALIDATION_GROUP = (string)GetNullableObject(row.Field<object>("VALIDATION_GROUP")),
				VALIDATION_REGULAR_EXPRESSION = (string)GetNullableObject(row.Field<object>("VALIDATION_REGULAR_EXPRESSION"))
			};

			return objReturn;
		}

		public STD_GUI_CONTROLS ParseReaderCustom(DataRow row)
		{
			STD_GUI_CONTROLS objReturn = new STD_GUI_CONTROLS
			{
				BASE_CONTROL_TYPE = (Int32)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_BASE_CONTROL_TYPE")),
				BASE_CONTROL_WIDTH = (Int32?)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_BASE_CONTROL_WIDTH")),
				CATEGORY = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_CATEGORY")),
				CREATED = (DateTime)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_CREATEDBY")),
				DATA_ELEMENT_WIDTH = (Int32?)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_DATA_ELEMENT_WIDTH")),
				DATA_TYPE_MAX_LENGTH = (Int32?)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_DATA_TYPE_MAX_LENGTH")),
				ID = (Int32)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_ID")),
				INCLUDE_LABEL = (bool)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_INCLUDE_LABEL")),
				LABEL_TEXT = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_LABEL_TEXT")),
				LOOKUP_LIST_CATEGORY = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_LOOKUP_LIST_CATEGORY")),
				LOOKUP_LIST_CATEGORY2 = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_LOOKUP_LIST_CATEGORY2")),
				LOOKUP_LIST_CATEGORY3 = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_LOOKUP_LIST_CATEGORY3")),
				NAME = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_NAME")),
				PANEL_NAME = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_PANEL_NAME")),
				REQUIRED = (bool)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_REQUIRED")),
				SORT_ORDER = (Int32)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_SORT_ORDER")),
				STD_REGISTRY_ID = (Int32)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_STD_REGISTRY_ID")),
				TOOL_TIP = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_TOOL_TIP")),
				UPDATED = (DateTime)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_UPDATEDBY")),
				USER_CONTROL_ID = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_USER_CONTROL_ID")),
				VALIDATION_ERROR_MESSAGE = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_VALIDATION_ERROR_MESSAGE")),
				VALIDATION_GROUP = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_VALIDATION_GROUP")),
				VALIDATION_REGULAR_EXPRESSION = (string)GetNullableObject(row.Field<object>("STD_GUI_CONTROLS_VALIDATION_REGULAR_EXPRESSION"))
			};

			return objReturn;
		}

		#endregion
	}
}
