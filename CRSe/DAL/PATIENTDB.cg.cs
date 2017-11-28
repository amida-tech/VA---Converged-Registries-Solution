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
	public partial class PATIENTDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public PATIENTDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public PATIENT GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PATIENT_ID)
		{ 
			PATIENT objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_PATIENT_getitem", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID);

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

		public List<PATIENT> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<PATIENT> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_PATIENT_getitems", sConn);
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
						objReturn = myData.ToList<PATIENT>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, PATIENT objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_PATIENT_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@BIRTH_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.BIRTH_DATE);
				p = new SqlParameter("@CELL_PHONE", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CELL_PHONE);
				p = new SqlParameter("@CREATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.CREATED);
				p = new SqlParameter("@CREATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CREATEDBY);
				p = new SqlParameter("@DEATH_DATE", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DEATH_DATE);
				p = new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 128);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.EMAIL_ADDRESS);
				p = new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.FIRST_NAME);
				p = new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.LAST_NAME);
				p = new SqlParameter("@MIDDLE_NAME", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MIDDLE_NAME);
				p = new SqlParameter("@OEFOIF_IND", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.OEFOIF_IND);
				p = new SqlParameter("@PATIENT_ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PATIENT_ID);
				p = new SqlParameter("@PATIENTSID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PATIENTSID);
				p = new SqlParameter("@PERFERRED_ADDRESS_TYPE", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PERFERRED_ADDRESS_TYPE);
				p = new SqlParameter("@UPDATED", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.UPDATED);
				p = new SqlParameter("@UPDATEDBY", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.UPDATEDBY);
                p = new SqlParameter("@PatientICN", SqlDbType.VarChar, 30);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PatientICN);

				LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
				int cnt = sCmd.ExecuteNonQuery();
				LogManager.LogTiming(logDetails);

				objReturn = (Int32)sCmd.Parameters["@PATIENT_ID"].Value;

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

		public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PATIENT_ID)
		{
			Boolean objReturn = false;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_PATIENT_delete", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@PATIENT_ID", PATIENT_ID);
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

		public PATIENT ParseReader(DataRow row)
		{
			PATIENT objReturn = new PATIENT
			{
				BIRTH_DATE = (DateTime?)GetNullableObject(row.Field<object>("BIRTH_DATE")),
				CELL_PHONE = (string)GetNullableObject(row.Field<object>("CELL_PHONE")),
				CREATED = (DateTime?)GetNullableObject(row.Field<object>("CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("CREATEDBY")),
				DEATH_DATE = (DateTime?)GetNullableObject(row.Field<object>("DEATH_DATE")),
				EMAIL_ADDRESS = (string)GetNullableObject(row.Field<object>("EMAIL_ADDRESS")),
				FIRST_NAME = (string)GetNullableObject(row.Field<object>("FIRST_NAME")),
				LAST_NAME = (string)GetNullableObject(row.Field<object>("LAST_NAME")),
				MIDDLE_NAME = (string)GetNullableObject(row.Field<object>("MIDDLE_NAME")),
				OEFOIF_IND = (bool?)GetNullableObject(row.Field<object>("OEFOIF_IND")),
				PATIENT_ID = (Int32)GetNullableObject(row.Field<object>("PATIENT_ID")),
				PATIENTSID = (Int32?)GetNullableObject(row.Field<object>("PATIENTSID")),
				PERFERRED_ADDRESS_TYPE = (string)GetNullableObject(row.Field<object>("PERFERRED_ADDRESS_TYPE")),
				UPDATED = (DateTime?)GetNullableObject(row.Field<object>("UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("UPDATEDBY")),
                PatientICN = (string)GetNullableObject(row.Field<object>("PatientICN"))
			};

			return objReturn;
		}

		public PATIENT ParseReaderCustom(DataRow row)
		{
			PATIENT objReturn = new PATIENT
			{
				BIRTH_DATE = (DateTime?)GetNullableObject(row.Field<object>("PATIENT_BIRTH_DATE")),
				CELL_PHONE = (string)GetNullableObject(row.Field<object>("PATIENT_CELL_PHONE")),
				CREATED = (DateTime?)GetNullableObject(row.Field<object>("PATIENT_CREATED")),
				CREATEDBY = (string)GetNullableObject(row.Field<object>("PATIENT_CREATEDBY")),
				DEATH_DATE = (DateTime?)GetNullableObject(row.Field<object>("PATIENT_DEATH_DATE")),
				EMAIL_ADDRESS = (string)GetNullableObject(row.Field<object>("PATIENT_EMAIL_ADDRESS")),
				FIRST_NAME = (string)GetNullableObject(row.Field<object>("PATIENT_FIRST_NAME")),
				LAST_NAME = (string)GetNullableObject(row.Field<object>("PATIENT_LAST_NAME")),
				MIDDLE_NAME = (string)GetNullableObject(row.Field<object>("PATIENT_MIDDLE_NAME")),
				OEFOIF_IND = (bool?)GetNullableObject(row.Field<object>("PATIENT_OEFOIF_IND")),
				PATIENT_ID = (Int32)GetNullableObject(row.Field<object>("PATIENT_PATIENT_ID")),
				PATIENTSID = (Int32?)GetNullableObject(row.Field<object>("PATIENT_PATIENTSID")),
				PERFERRED_ADDRESS_TYPE = (string)GetNullableObject(row.Field<object>("PATIENT_PERFERRED_ADDRESS_TYPE")),
				UPDATED = (DateTime?)GetNullableObject(row.Field<object>("PATIENT_UPDATED")),
				UPDATEDBY = (string)GetNullableObject(row.Field<object>("PATIENT_UPDATEDBY")),
                PatientICN = (string)GetNullableObject(row.Field<object>("PATIENT_PatientICN"))
			};

			return objReturn;
		}

		#endregion
	}
}
