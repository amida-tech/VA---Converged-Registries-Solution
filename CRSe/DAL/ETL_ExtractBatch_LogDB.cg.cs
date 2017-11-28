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
	public partial class ETL_ExtractBatch_LogDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public ETL_ExtractBatch_LogDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public ETL_ExtractBatch_Log GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			ETL_ExtractBatch_Log objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_ETL_ExtractBatch_Log_getitem", sConn);
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

		public List<ETL_ExtractBatch_Log> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<ETL_ExtractBatch_Log> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_ETL_ExtractBatch_Log_getitems", sConn);
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
						objReturn = myData.ToList<ETL_ExtractBatch_Log>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, ETL_ExtractBatch_Log objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_ETL_ExtractBatch_Log_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@CDW_Table_View_Name", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CDW_Table_View_Name);
				p = new SqlParameter("@CountFinal", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CountFinal);
				p = new SqlParameter("@CountStage", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CountStage);
				p = new SqlParameter("@ETL_Name", SqlDbType.VarChar, 150);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ETL_Name);
				p = new SqlParameter("@ETL_StepName", SqlDbType.VarChar, 250);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ETL_StepName);
				p = new SqlParameter("@ETLBatchID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ETLBatchID);
				p = new SqlParameter("@ExtractBatchID", SqlDbType.BigInt, 8);
				p.Precision = 19;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ExtractBatchID);
				p = new SqlParameter("@ExtractDateTime", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.ExtractDateTime);
				p = new SqlParameter("@ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ID);
				p = new SqlParameter("@Registry_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Registry_ID);
				p = new SqlParameter("@UserName", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.UserName);

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

				sCmd = new SqlCommand("CRS.usp_ETL_ExtractBatch_Log_delete", sConn);
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

		public ETL_ExtractBatch_Log ParseReader(DataRow row)
		{
			ETL_ExtractBatch_Log objReturn = new ETL_ExtractBatch_Log
			{
				CDW_Table_View_Name = (string)GetNullableObject(row.Field<object>("CDW_Table_View_Name")),
				CountFinal = (Int32?)GetNullableObject(row.Field<object>("CountFinal")),
				CountStage = (Int32?)GetNullableObject(row.Field<object>("CountStage")),
				ETL_Name = (string)GetNullableObject(row.Field<object>("ETL_Name")),
				ETL_StepName = (string)GetNullableObject(row.Field<object>("ETL_StepName")),
				ETLBatchID = (Int32?)GetNullableObject(row.Field<object>("ETLBatchID")),
				ExtractBatchID = (Int64?)GetNullableObject(row.Field<object>("ExtractBatchID")),
				ExtractDateTime = (DateTime?)GetNullableObject(row.Field<object>("ExtractDateTime")),
				ID = (Int32)GetNullableObject(row.Field<object>("ID")),
				Registry_ID = (Int32?)GetNullableObject(row.Field<object>("Registry_ID")),
				UserName = (string)GetNullableObject(row.Field<object>("UserName"))
			};

			return objReturn;
		}

		public ETL_ExtractBatch_Log ParseReaderCustom(DataRow row)
		{
			ETL_ExtractBatch_Log objReturn = new ETL_ExtractBatch_Log
			{
				CDW_Table_View_Name = (string)GetNullableObject(row.Field<object>("ETL_ExtractBatch_Log_CDW_Table_View_Name")),
				CountFinal = (Int32?)GetNullableObject(row.Field<object>("ETL_ExtractBatch_Log_CountFinal")),
				CountStage = (Int32?)GetNullableObject(row.Field<object>("ETL_ExtractBatch_Log_CountStage")),
				ETL_Name = (string)GetNullableObject(row.Field<object>("ETL_ExtractBatch_Log_ETL_Name")),
				ETL_StepName = (string)GetNullableObject(row.Field<object>("ETL_ExtractBatch_Log_ETL_StepName")),
				ETLBatchID = (Int32?)GetNullableObject(row.Field<object>("ETL_ExtractBatch_Log_ETLBatchID")),
				ExtractBatchID = (Int64?)GetNullableObject(row.Field<object>("ETL_ExtractBatch_Log_ExtractBatchID")),
				ExtractDateTime = (DateTime?)GetNullableObject(row.Field<object>("ETL_ExtractBatch_Log_ExtractDateTime")),
				ID = (Int32)GetNullableObject(row.Field<object>("ETL_ExtractBatch_Log_ID")),
				Registry_ID = (Int32?)GetNullableObject(row.Field<object>("ETL_ExtractBatch_Log_Registry_ID")),
				UserName = (string)GetNullableObject(row.Field<object>("ETL_ExtractBatch_Log_UserName"))
			};

			return objReturn;
		}

		#endregion
	}
}
