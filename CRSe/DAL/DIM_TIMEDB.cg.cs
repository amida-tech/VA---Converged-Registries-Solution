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
	public partial class DIM_TIMEDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public DIM_TIMEDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public DIM_TIME GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DateTime PK_Date)
		{
			DIM_TIME objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_DIM_TIME_getitem", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@PK_Date", PK_Date);

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

		public List<DIM_TIME> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<DIM_TIME> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_DIM_TIME_getitems", sConn);
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
						objReturn = myData.ToList<DIM_TIME>();
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

		public DateTime Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DIM_TIME objSave)
		{
			DateTime objReturn = DateTime.MinValue;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_DIM_TIME_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@Calendar_Year", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Calendar_Year);
				p = new SqlParameter("@Date_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Date_Name);
				p = new SqlParameter("@Day_Of_Month", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Day_Of_Month);
				p = new SqlParameter("@Day_Of_Month_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Day_Of_Month_Name);
				p = new SqlParameter("@Day_Of_Quarter", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Day_Of_Quarter);
				p = new SqlParameter("@Day_Of_Quarter_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Day_Of_Quarter_Name);
				p = new SqlParameter("@Day_Of_Year", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Day_Of_Year);
				p = new SqlParameter("@Day_Of_Year_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Day_Of_Year_Name);
				p = new SqlParameter("@EPRPQuarter", SqlDbType.Char, 6);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.EPRPQuarter);
				p = new SqlParameter("@Fiscal_Day", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Day);
				p = new SqlParameter("@Fiscal_Day_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Day_Name);
				p = new SqlParameter("@Fiscal_Day_Of_Month", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Day_Of_Month);
				p = new SqlParameter("@Fiscal_Day_Of_Month_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Day_Of_Month_Name);
				p = new SqlParameter("@Fiscal_Day_Of_Quarter", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Day_Of_Quarter);
				p = new SqlParameter("@Fiscal_Day_Of_Quarter_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Day_Of_Quarter_Name);
				p = new SqlParameter("@Fiscal_Day_Of_Year", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Day_Of_Year);
				p = new SqlParameter("@Fiscal_Day_Of_Year_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Day_Of_Year_Name);
				p = new SqlParameter("@Fiscal_Month", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Month);
				p = new SqlParameter("@Fiscal_Month_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Month_Name);
				p = new SqlParameter("@Fiscal_Month_Of_Quarter", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Month_Of_Quarter);
				p = new SqlParameter("@Fiscal_Month_Of_Quarter_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Month_Of_Quarter_Name);
				p = new SqlParameter("@Fiscal_Month_Of_Year", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Month_Of_Year);
				p = new SqlParameter("@Fiscal_Month_Of_Year_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Month_Of_Year_Name);
				p = new SqlParameter("@Fiscal_Quarter", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Quarter);
				p = new SqlParameter("@Fiscal_Quarter_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Quarter_Name);
				p = new SqlParameter("@Fiscal_Quarter_Of_Year", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Quarter_Of_Year);
				p = new SqlParameter("@Fiscal_Quarter_Of_Year_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Quarter_Of_Year_Name);
				p = new SqlParameter("@Fiscal_Year", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Year);
				p = new SqlParameter("@Fiscal_Year_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Fiscal_Year_Name);
				p = new SqlParameter("@FiscalQuarterID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.FiscalQuarterID);
				p = new SqlParameter("@FiscalYear", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.FiscalYear);
				p = new SqlParameter("@FYQuarter", SqlDbType.Char, 6);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.FYQuarter);
				p = new SqlParameter("@Month", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.Month);
				p = new SqlParameter("@Month_ID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Month_ID);
				p = new SqlParameter("@Month_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Month_Name);
				p = new SqlParameter("@Month_Of_Quarter", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Month_Of_Quarter);
				p = new SqlParameter("@Month_Of_Quarter_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Month_Of_Quarter_Name);
				p = new SqlParameter("@Month_Of_Year", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Month_Of_Year);
				p = new SqlParameter("@Month_Of_Year_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Month_Of_Year_Name);
				p = new SqlParameter("@Month_Short_Name", SqlDbType.Char, 3);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Month_Short_Name);
				p = new SqlParameter("@PK_Date", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.PK_Date);
				p = new SqlParameter("@Quarter", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.Quarter);
				p = new SqlParameter("@Quarter_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Quarter_Name);
				p = new SqlParameter("@Quarter_Of_Year", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Quarter_Of_Year);
				p = new SqlParameter("@Quarter_Of_Year_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Quarter_Of_Year_Name);
				p = new SqlParameter("@Year", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.Year);
				p = new SqlParameter("@Year_Name", SqlDbType.NVarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Year_Name);

				LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
				int cnt = sCmd.ExecuteNonQuery();
				LogManager.LogTiming(logDetails);

				objReturn = (DateTime)sCmd.Parameters["@PK_Date"].Value;

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

		public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DateTime PK_Date)
		{
			Boolean objReturn = false;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_DIM_TIME_delete", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@PK_Date", PK_Date);
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

		public DIM_TIME ParseReader(DataRow row)
		{
			DIM_TIME objReturn = new DIM_TIME
			{
				Calendar_Year = (Int32?)GetNullableObject(row.Field<object>("Calendar_Year")),
				Date_Name = (string)GetNullableObject(row.Field<object>("Date_Name")),
				Day_Of_Month = (Int32?)GetNullableObject(row.Field<object>("Day_Of_Month")),
				Day_Of_Month_Name = (string)GetNullableObject(row.Field<object>("Day_Of_Month_Name")),
				Day_Of_Quarter = (Int32?)GetNullableObject(row.Field<object>("Day_Of_Quarter")),
				Day_Of_Quarter_Name = (string)GetNullableObject(row.Field<object>("Day_Of_Quarter_Name")),
				Day_Of_Year = (Int32?)GetNullableObject(row.Field<object>("Day_Of_Year")),
				Day_Of_Year_Name = (string)GetNullableObject(row.Field<object>("Day_Of_Year_Name")),
				EPRPQuarter = (string)GetNullableObject(row.Field<object>("EPRPQuarter")),
				Fiscal_Day = (DateTime?)GetNullableObject(row.Field<object>("Fiscal_Day")),
				Fiscal_Day_Name = (string)GetNullableObject(row.Field<object>("Fiscal_Day_Name")),
				Fiscal_Day_Of_Month = (Int32?)GetNullableObject(row.Field<object>("Fiscal_Day_Of_Month")),
				Fiscal_Day_Of_Month_Name = (string)GetNullableObject(row.Field<object>("Fiscal_Day_Of_Month_Name")),
				Fiscal_Day_Of_Quarter = (Int32?)GetNullableObject(row.Field<object>("Fiscal_Day_Of_Quarter")),
				Fiscal_Day_Of_Quarter_Name = (string)GetNullableObject(row.Field<object>("Fiscal_Day_Of_Quarter_Name")),
				Fiscal_Day_Of_Year = (Int32?)GetNullableObject(row.Field<object>("Fiscal_Day_Of_Year")),
				Fiscal_Day_Of_Year_Name = (string)GetNullableObject(row.Field<object>("Fiscal_Day_Of_Year_Name")),
				Fiscal_Month = (DateTime?)GetNullableObject(row.Field<object>("Fiscal_Month")),
				Fiscal_Month_Name = (string)GetNullableObject(row.Field<object>("Fiscal_Month_Name")),
				Fiscal_Month_Of_Quarter = (Int32?)GetNullableObject(row.Field<object>("Fiscal_Month_Of_Quarter")),
				Fiscal_Month_Of_Quarter_Name = (string)GetNullableObject(row.Field<object>("Fiscal_Month_Of_Quarter_Name")),
				Fiscal_Month_Of_Year = (Int32?)GetNullableObject(row.Field<object>("Fiscal_Month_Of_Year")),
				Fiscal_Month_Of_Year_Name = (string)GetNullableObject(row.Field<object>("Fiscal_Month_Of_Year_Name")),
				Fiscal_Quarter = (DateTime?)GetNullableObject(row.Field<object>("Fiscal_Quarter")),
				Fiscal_Quarter_Name = (string)GetNullableObject(row.Field<object>("Fiscal_Quarter_Name")),
				Fiscal_Quarter_Of_Year = (Int32?)GetNullableObject(row.Field<object>("Fiscal_Quarter_Of_Year")),
				Fiscal_Quarter_Of_Year_Name = (string)GetNullableObject(row.Field<object>("Fiscal_Quarter_Of_Year_Name")),
				Fiscal_Year = (DateTime?)GetNullableObject(row.Field<object>("Fiscal_Year")),
				Fiscal_Year_Name = (string)GetNullableObject(row.Field<object>("Fiscal_Year_Name")),
				FiscalQuarterID = (Int32?)GetNullableObject(row.Field<object>("FiscalQuarterID")),
				FiscalYear = (Int32?)GetNullableObject(row.Field<object>("FiscalYear")),
				FYQuarter = (string)GetNullableObject(row.Field<object>("FYQuarter")),
				Month = (DateTime?)GetNullableObject(row.Field<object>("Month")),
				Month_ID = (Int32?)GetNullableObject(row.Field<object>("Month_ID")),
				Month_Name = (string)GetNullableObject(row.Field<object>("Month_Name")),
				Month_Of_Quarter = (Int32?)GetNullableObject(row.Field<object>("Month_Of_Quarter")),
				Month_Of_Quarter_Name = (string)GetNullableObject(row.Field<object>("Month_Of_Quarter_Name")),
				Month_Of_Year = (Int32?)GetNullableObject(row.Field<object>("Month_Of_Year")),
				Month_Of_Year_Name = (string)GetNullableObject(row.Field<object>("Month_Of_Year_Name")),
				Month_Short_Name = (string)GetNullableObject(row.Field<object>("Month_Short_Name")),
				PK_Date = (DateTime)GetNullableObject(row.Field<object>("PK_Date")),
				Quarter = (DateTime?)GetNullableObject(row.Field<object>("Quarter")),
				Quarter_Name = (string)GetNullableObject(row.Field<object>("Quarter_Name")),
				Quarter_Of_Year = (Int32?)GetNullableObject(row.Field<object>("Quarter_Of_Year")),
				Quarter_Of_Year_Name = (string)GetNullableObject(row.Field<object>("Quarter_Of_Year_Name")),
				Year = (DateTime?)GetNullableObject(row.Field<object>("Year")),
				Year_Name = (string)GetNullableObject(row.Field<object>("Year_Name"))
			};

			return objReturn;
		}

		public DIM_TIME ParseReaderCustom(DataRow row)
		{
			DIM_TIME objReturn = new DIM_TIME
			{
				Calendar_Year = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Calendar_Year")),
				Date_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Date_Name")),
				Day_Of_Month = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Day_Of_Month")),
				Day_Of_Month_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Day_Of_Month_Name")),
				Day_Of_Quarter = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Day_Of_Quarter")),
				Day_Of_Quarter_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Day_Of_Quarter_Name")),
				Day_Of_Year = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Day_Of_Year")),
				Day_Of_Year_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Day_Of_Year_Name")),
				EPRPQuarter = (string)GetNullableObject(row.Field<object>("DIM_TIME_EPRPQuarter")),
				Fiscal_Day = (DateTime?)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Day")),
				Fiscal_Day_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Day_Name")),
				Fiscal_Day_Of_Month = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Day_Of_Month")),
				Fiscal_Day_Of_Month_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Day_Of_Month_Name")),
				Fiscal_Day_Of_Quarter = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Day_Of_Quarter")),
				Fiscal_Day_Of_Quarter_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Day_Of_Quarter_Name")),
				Fiscal_Day_Of_Year = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Day_Of_Year")),
				Fiscal_Day_Of_Year_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Day_Of_Year_Name")),
				Fiscal_Month = (DateTime?)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Month")),
				Fiscal_Month_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Month_Name")),
				Fiscal_Month_Of_Quarter = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Month_Of_Quarter")),
				Fiscal_Month_Of_Quarter_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Month_Of_Quarter_Name")),
				Fiscal_Month_Of_Year = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Month_Of_Year")),
				Fiscal_Month_Of_Year_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Month_Of_Year_Name")),
				Fiscal_Quarter = (DateTime?)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Quarter")),
				Fiscal_Quarter_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Quarter_Name")),
				Fiscal_Quarter_Of_Year = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Quarter_Of_Year")),
				Fiscal_Quarter_Of_Year_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Quarter_Of_Year_Name")),
				Fiscal_Year = (DateTime?)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Year")),
				Fiscal_Year_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Fiscal_Year_Name")),
				FiscalQuarterID = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_FiscalQuarterID")),
				FiscalYear = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_FiscalYear")),
				FYQuarter = (string)GetNullableObject(row.Field<object>("DIM_TIME_FYQuarter")),
				Month = (DateTime?)GetNullableObject(row.Field<object>("DIM_TIME_Month")),
				Month_ID = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Month_ID")),
				Month_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Month_Name")),
				Month_Of_Quarter = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Month_Of_Quarter")),
				Month_Of_Quarter_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Month_Of_Quarter_Name")),
				Month_Of_Year = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Month_Of_Year")),
				Month_Of_Year_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Month_Of_Year_Name")),
				Month_Short_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Month_Short_Name")),
				PK_Date = (DateTime)GetNullableObject(row.Field<object>("DIM_TIME_PK_Date")),
				Quarter = (DateTime?)GetNullableObject(row.Field<object>("DIM_TIME_Quarter")),
				Quarter_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Quarter_Name")),
				Quarter_Of_Year = (Int32?)GetNullableObject(row.Field<object>("DIM_TIME_Quarter_Of_Year")),
				Quarter_Of_Year_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Quarter_Of_Year_Name")),
				Year = (DateTime?)GetNullableObject(row.Field<object>("DIM_TIME_Year")),
				Year_Name = (string)GetNullableObject(row.Field<object>("DIM_TIME_Year_Name"))
			};

			return objReturn;
		}

		#endregion
	}
}
