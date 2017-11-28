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
	public partial class BCCCR_BCR_ALLDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public BCCCR_BCR_ALLDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public BCCCR_BCR_ALL GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			BCCCR_BCR_ALL objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_BCCCR_BCR_ALL_getitem", sConn);
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

		public List<BCCCR_BCR_ALL> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<BCCCR_BCR_ALL> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_BCCCR_BCR_ALL_getitems", sConn);
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
						objReturn = myData.ToList<BCCCR_BCR_ALL>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, BCCCR_BCR_ALL objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_BCCCR_BCR_ALL_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@Age", SqlDbType.Decimal, 9);
				p.Precision = 18;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Age);
				p = new SqlParameter("@BIRADScore", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.BIRADScore);
				p = new SqlParameter("@City", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.City);
				p = new SqlParameter("@CombatFlag", SqlDbType.Char, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CombatFlag);
				p = new SqlParameter("@DateNextMammogramDue", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DateNextMammogramDue);
				p = new SqlParameter("@DateOfBirth", SqlDbType.Date, 3);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DateOfBirth);
				p = new SqlParameter("@DateOFMostRecentMammogram", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DateOFMostRecentMammogram);
				p = new SqlParameter("@DateOfMostRecentMammogramExclusionHealthFactor", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DateOfMostRecentMammogramExclusionHealthFactor);
				p = new SqlParameter("@DateOfMostRecentMammogramResult", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DateOfMostRecentMammogramResult);
				p = new SqlParameter("@DateOfMostRecentMammogramScreenFreq", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DateOfMostRecentMammogramScreenFreq);
				p = new SqlParameter("@DateOfMostRecentNexusClinicEncounter", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DateOfMostRecentNexusClinicEncounter);
				p = new SqlParameter("@DateOfMostRecentNexusClinicFormerEncounter", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DateOfMostRecentNexusClinicFormerEncounter);
				p = new SqlParameter("@DateOfMostRecentPrimaryCareEncounter", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DateOfMostRecentPrimaryCareEncounter);
				p = new SqlParameter("@DateOfMostRecentWomensHealthEncounter", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DateOfMostRecentWomensHealthEncounter);
				p = new SqlParameter("@DateOfMostRRecentNexusClinicPriorEncounter", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DateOfMostRRecentNexusClinicPriorEncounter);
				p = new SqlParameter("@DateOfNextAppointment", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.DateOfNextAppointment);
				p = new SqlParameter("@DateProcessed", SqlDbType.VarChar, 12);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DateProcessed);
				p = new SqlParameter("@Deceased", SqlDbType.Char, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Deceased);
				p = new SqlParameter("@Ethnicity", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Ethnicity);
				p = new SqlParameter("@Gender", SqlDbType.Char, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Gender);
				p = new SqlParameter("@HadBilateralMastectomy", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.HadBilateralMastectomy);
				p = new SqlParameter("@HadHysterectomy", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.HadHysterectomy);
				p = new SqlParameter("@HasATerminalHealthFactor", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.HasATerminalHealthFactor);
				p = new SqlParameter("@HasMammogramExclusionHealthFactor", SqlDbType.Bit, 1);
				p.Precision = 1;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.HasMammogramExclusionHealthFactor);
				p = new SqlParameter("@HomeSta3N", SqlDbType.BigInt, 8);
				p.Precision = 19;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.HomeSta3N);
				p = new SqlParameter("@ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ID);
				p = new SqlParameter("@ISOEFOIF", SqlDbType.SmallInt, 2);
				p.Precision = 5;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ISOEFOIF);
				p = new SqlParameter("@LocationNameOfNextAppointment", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.LocationNameOfNextAppointment);
				p = new SqlParameter("@MammogramComplianceText", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MammogramComplianceText);
				p = new SqlParameter("@MammogramMostRecentScreenFreq", SqlDbType.VarChar, 5);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MammogramMostRecentScreenFreq);
				p = new SqlParameter("@MammogramMostrecentScreenFreqHF", SqlDbType.VarChar, 40);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MammogramMostrecentScreenFreqHF);
				p = new SqlParameter("@MammogramScreeningComplianceText", SqlDbType.VarChar, 5);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MammogramScreeningComplianceText);
				p = new SqlParameter("@MonthSID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MonthSID);
				p = new SqlParameter("@MostRecentMammogramDiagnosticCode", SqlDbType.Decimal, 13);
				p.Precision = 28;
				p.Scale = 6;
				AddParameter(ref sCmd, ref p, objSave.MostRecentMammogramDiagnosticCode);
				p = new SqlParameter("@MostRecentMammogramProcedure", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MostRecentMammogramProcedure);
				p = new SqlParameter("@MostRecentMammogramSource", SqlDbType.VarChar, 15);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MostRecentMammogramSource);
				p = new SqlParameter("@NumberOfCancerDiagnosis", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NumberOfCancerDiagnosis);
				p = new SqlParameter("@NumberOfNexusClinicEncounters", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NumberOfNexusClinicEncounters);
				p = new SqlParameter("@NumberOfNexusClinicFormerEncounters", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NumberOfNexusClinicFormerEncounters);
				p = new SqlParameter("@NumberOfNexusClinicPriorEncounters", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NumberOfNexusClinicPriorEncounters);
				p = new SqlParameter("@NumberOfPrimaryCareEncounters", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NumberOfPrimaryCareEncounters);
				p = new SqlParameter("@NumberOfTerminalCADDiagnosis", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NumberOfTerminalCADDiagnosis);
				p = new SqlParameter("@NumberOfWomensHealthEncounters", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NumberOfWomensHealthEncounters);
				p = new SqlParameter("@PatientFirstName", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PatientFirstName);
				p = new SqlParameter("@PatientICN", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PatientICN);
				p = new SqlParameter("@PatientIEN", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PatientIEN);
				p = new SqlParameter("@PatientLastName", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PatientLastName);
				p = new SqlParameter("@PatientSID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PatientSID);
				p = new SqlParameter("@PatientSSN", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PatientSSN);
				p = new SqlParameter("@PCMMStaffName", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PCMMStaffName);
				p = new SqlParameter("@PCMMStaffSID", SqlDbType.BigInt, 8);
				p.Precision = 19;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PCMMStaffSID);
				p = new SqlParameter("@PCMMTeam", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PCMMTeam);
				p = new SqlParameter("@PCMMTeamSID", SqlDbType.BigInt, 8);
				p.Precision = 19;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PCMMTeamSID);
				p = new SqlParameter("@PhoneCellular", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PhoneCellular);
				p = new SqlParameter("@PhoneResidence", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PhoneResidence);
				p = new SqlParameter("@PhoneWork", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PhoneWork);
				p = new SqlParameter("@Race", SqlDbType.VarChar, 45);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Race);
				p = new SqlParameter("@Region", SqlDbType.SmallInt, 2);
				p.Precision = 5;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Region);
				p = new SqlParameter("@Sta3n", SqlDbType.SmallInt, 2);
				p.Precision = 5;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Sta3n);
				p = new SqlParameter("@State", SqlDbType.VarChar, 30);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.State);
				p = new SqlParameter("@StreetAddress1", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.StreetAddress1);
				p = new SqlParameter("@StreetAddress2", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.StreetAddress2);
				p = new SqlParameter("@StreetAddress3", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.StreetAddress3);
				p = new SqlParameter("@VAID", SqlDbType.VarChar, 5);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.VAID);
				p = new SqlParameter("@VeteranFlag", SqlDbType.Char, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.VeteranFlag);
				p = new SqlParameter("@VISN", SqlDbType.SmallInt, 2);
				p.Precision = 5;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.VISN);
				p = new SqlParameter("@WomensHealthVisitStatus", SqlDbType.VarChar, 25);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.WomensHealthVisitStatus);
				p = new SqlParameter("@Zip", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Zip);

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

				sCmd = new SqlCommand("CRS.usp_BCCCR_BCR_ALL_delete", sConn);
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

		public BCCCR_BCR_ALL ParseReader(DataRow row)
		{
			BCCCR_BCR_ALL objReturn = new BCCCR_BCR_ALL
			{
				Age = (decimal?)GetNullableObject(row.Field<object>("Age")),
				BIRADScore = (Int32?)GetNullableObject(row.Field<object>("BIRADScore")),
				City = (string)GetNullableObject(row.Field<object>("City")),
				CombatFlag = (string)GetNullableObject(row.Field<object>("CombatFlag")),
				DateNextMammogramDue = (DateTime?)GetNullableObject(row.Field<object>("DateNextMammogramDue")),
				DateOfBirth = (DateTime?)GetNullableObject(row.Field<object>("DateOfBirth")),
				DateOFMostRecentMammogram = (DateTime?)GetNullableObject(row.Field<object>("DateOFMostRecentMammogram")),
				DateOfMostRecentMammogramExclusionHealthFactor = (DateTime?)GetNullableObject(row.Field<object>("DateOfMostRecentMammogramExclusionHealthFactor")),
				DateOfMostRecentMammogramResult = (DateTime?)GetNullableObject(row.Field<object>("DateOfMostRecentMammogramResult")),
				DateOfMostRecentMammogramScreenFreq = (DateTime?)GetNullableObject(row.Field<object>("DateOfMostRecentMammogramScreenFreq")),
				DateOfMostRecentNexusClinicEncounter = (DateTime?)GetNullableObject(row.Field<object>("DateOfMostRecentNexusClinicEncounter")),
				DateOfMostRecentNexusClinicFormerEncounter = (DateTime?)GetNullableObject(row.Field<object>("DateOfMostRecentNexusClinicFormerEncounter")),
				DateOfMostRecentPrimaryCareEncounter = (DateTime?)GetNullableObject(row.Field<object>("DateOfMostRecentPrimaryCareEncounter")),
				DateOfMostRecentWomensHealthEncounter = (DateTime?)GetNullableObject(row.Field<object>("DateOfMostRecentWomensHealthEncounter")),
				DateOfMostRRecentNexusClinicPriorEncounter = (DateTime?)GetNullableObject(row.Field<object>("DateOfMostRRecentNexusClinicPriorEncounter")),
				DateOfNextAppointment = (DateTime?)GetNullableObject(row.Field<object>("DateOfNextAppointment")),
				DateProcessed = (string)GetNullableObject(row.Field<object>("DateProcessed")),
				Deceased = (string)GetNullableObject(row.Field<object>("Deceased")),
				Ethnicity = (string)GetNullableObject(row.Field<object>("Ethnicity")),
				Gender = (string)GetNullableObject(row.Field<object>("Gender")),
				HadBilateralMastectomy = (bool?)GetNullableObject(row.Field<object>("HadBilateralMastectomy")),
				HadHysterectomy = (bool?)GetNullableObject(row.Field<object>("HadHysterectomy")),
				HasATerminalHealthFactor = (bool?)GetNullableObject(row.Field<object>("HasATerminalHealthFactor")),
				HasMammogramExclusionHealthFactor = (bool?)GetNullableObject(row.Field<object>("HasMammogramExclusionHealthFactor")),
				HomeSta3N = (Int64?)GetNullableObject(row.Field<object>("HomeSta3N")),
				ID = (Int32)GetNullableObject(row.Field<object>("ID")),
				ISOEFOIF = (Int16?)GetNullableObject(row.Field<object>("ISOEFOIF")),
				LocationNameOfNextAppointment = (string)GetNullableObject(row.Field<object>("LocationNameOfNextAppointment")),
				MammogramComplianceText = (string)GetNullableObject(row.Field<object>("MammogramComplianceText")),
				MammogramMostRecentScreenFreq = (string)GetNullableObject(row.Field<object>("MammogramMostRecentScreenFreq")),
				MammogramMostrecentScreenFreqHF = (string)GetNullableObject(row.Field<object>("MammogramMostrecentScreenFreqHF")),
				MammogramScreeningComplianceText = (string)GetNullableObject(row.Field<object>("MammogramScreeningComplianceText")),
				MonthSID = (Int32?)GetNullableObject(row.Field<object>("MonthSID")),
				MostRecentMammogramDiagnosticCode = (decimal?)GetNullableObject(row.Field<object>("MostRecentMammogramDiagnosticCode")),
				MostRecentMammogramProcedure = (string)GetNullableObject(row.Field<object>("MostRecentMammogramProcedure")),
				MostRecentMammogramSource = (string)GetNullableObject(row.Field<object>("MostRecentMammogramSource")),
				NumberOfCancerDiagnosis = (Int32?)GetNullableObject(row.Field<object>("NumberOfCancerDiagnosis")),
				NumberOfNexusClinicEncounters = (Int32?)GetNullableObject(row.Field<object>("NumberOfNexusClinicEncounters")),
				NumberOfNexusClinicFormerEncounters = (Int32?)GetNullableObject(row.Field<object>("NumberOfNexusClinicFormerEncounters")),
				NumberOfNexusClinicPriorEncounters = (Int32?)GetNullableObject(row.Field<object>("NumberOfNexusClinicPriorEncounters")),
				NumberOfPrimaryCareEncounters = (Int32?)GetNullableObject(row.Field<object>("NumberOfPrimaryCareEncounters")),
				NumberOfTerminalCADDiagnosis = (Int32?)GetNullableObject(row.Field<object>("NumberOfTerminalCADDiagnosis")),
				NumberOfWomensHealthEncounters = (Int32?)GetNullableObject(row.Field<object>("NumberOfWomensHealthEncounters")),
				PatientFirstName = (string)GetNullableObject(row.Field<object>("PatientFirstName")),
				PatientICN = (string)GetNullableObject(row.Field<object>("PatientICN")),
				PatientIEN = (string)GetNullableObject(row.Field<object>("PatientIEN")),
				PatientLastName = (string)GetNullableObject(row.Field<object>("PatientLastName")),
				PatientSID = (Int32)GetNullableObject(row.Field<object>("PatientSID")),
				PatientSSN = (string)GetNullableObject(row.Field<object>("PatientSSN")),
				PCMMStaffName = (string)GetNullableObject(row.Field<object>("PCMMStaffName")),
				PCMMStaffSID = (Int64?)GetNullableObject(row.Field<object>("PCMMStaffSID")),
				PCMMTeam = (string)GetNullableObject(row.Field<object>("PCMMTeam")),
				PCMMTeamSID = (Int64?)GetNullableObject(row.Field<object>("PCMMTeamSID")),
				PhoneCellular = (string)GetNullableObject(row.Field<object>("PhoneCellular")),
				PhoneResidence = (string)GetNullableObject(row.Field<object>("PhoneResidence")),
				PhoneWork = (string)GetNullableObject(row.Field<object>("PhoneWork")),
				Race = (string)GetNullableObject(row.Field<object>("Race")),
				Region = (Int16?)GetNullableObject(row.Field<object>("Region")),
				Sta3n = (Int16)GetNullableObject(row.Field<object>("Sta3n")),
				State = (string)GetNullableObject(row.Field<object>("State")),
				StreetAddress1 = (string)GetNullableObject(row.Field<object>("StreetAddress1")),
				StreetAddress2 = (string)GetNullableObject(row.Field<object>("StreetAddress2")),
				StreetAddress3 = (string)GetNullableObject(row.Field<object>("StreetAddress3")),
				VAID = (string)GetNullableObject(row.Field<object>("VAID")),
				VeteranFlag = (string)GetNullableObject(row.Field<object>("VeteranFlag")),
				VISN = (Int16)GetNullableObject(row.Field<object>("VISN")),
				WomensHealthVisitStatus = (string)GetNullableObject(row.Field<object>("WomensHealthVisitStatus")),
				Zip = (string)GetNullableObject(row.Field<object>("Zip"))
			};

            if (!string.IsNullOrEmpty(objReturn.PatientLastName) && !string.IsNullOrEmpty(objReturn.PatientFirstName))
                objReturn.PatientName = objReturn.PatientLastName + ", " + objReturn.PatientFirstName;
            else if (!string.IsNullOrEmpty(objReturn.PatientLastName))
                objReturn.PatientName = objReturn.PatientLastName;
            else if (!string.IsNullOrEmpty(objReturn.PatientFirstName))
                objReturn.PatientName = objReturn.PatientFirstName;
            else
                objReturn.PatientName = string.Empty;

			return objReturn;
		}

		public BCCCR_BCR_ALL ParseReaderCustom(DataRow row)
		{
			BCCCR_BCR_ALL objReturn = new BCCCR_BCR_ALL
			{
				Age = (decimal?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_Age")),
				BIRADScore = (Int32?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_BIRADScore")),
				City = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_City")),
				CombatFlag = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_CombatFlag")),
				DateNextMammogramDue = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateNextMammogramDue")),
				DateOfBirth = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateOfBirth")),
				DateOFMostRecentMammogram = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateOFMostRecentMammogram")),
				DateOfMostRecentMammogramExclusionHealthFactor = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateOfMostRecentMammogramExclusionHealthFactor")),
				DateOfMostRecentMammogramResult = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateOfMostRecentMammogramResult")),
				DateOfMostRecentMammogramScreenFreq = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateOfMostRecentMammogramScreenFreq")),
				DateOfMostRecentNexusClinicEncounter = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateOfMostRecentNexusClinicEncounter")),
				DateOfMostRecentNexusClinicFormerEncounter = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateOfMostRecentNexusClinicFormerEncounter")),
				DateOfMostRecentPrimaryCareEncounter = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateOfMostRecentPrimaryCareEncounter")),
				DateOfMostRecentWomensHealthEncounter = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateOfMostRecentWomensHealthEncounter")),
				DateOfMostRRecentNexusClinicPriorEncounter = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateOfMostRRecentNexusClinicPriorEncounter")),
				DateOfNextAppointment = (DateTime?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateOfNextAppointment")),
				DateProcessed = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_DateProcessed")),
				Deceased = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_Deceased")),
				Ethnicity = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_Ethnicity")),
				Gender = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_Gender")),
				HadBilateralMastectomy = (bool?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_HadBilateralMastectomy")),
				HadHysterectomy = (bool?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_HadHysterectomy")),
				HasATerminalHealthFactor = (bool?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_HasATerminalHealthFactor")),
				HasMammogramExclusionHealthFactor = (bool?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_HasMammogramExclusionHealthFactor")),
				HomeSta3N = (Int64?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_HomeSta3N")),
				ID = (Int32)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_ID")),
				ISOEFOIF = (Int16?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_ISOEFOIF")),
				LocationNameOfNextAppointment = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_LocationNameOfNextAppointment")),
				MammogramComplianceText = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_MammogramComplianceText")),
				MammogramMostRecentScreenFreq = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_MammogramMostRecentScreenFreq")),
				MammogramMostrecentScreenFreqHF = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_MammogramMostrecentScreenFreqHF")),
				MammogramScreeningComplianceText = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_MammogramScreeningComplianceText")),
				MonthSID = (Int32?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_MonthSID")),
				MostRecentMammogramDiagnosticCode = (decimal?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_MostRecentMammogramDiagnosticCode")),
				MostRecentMammogramProcedure = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_MostRecentMammogramProcedure")),
				MostRecentMammogramSource = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_MostRecentMammogramSource")),
				NumberOfCancerDiagnosis = (Int32?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_NumberOfCancerDiagnosis")),
				NumberOfNexusClinicEncounters = (Int32?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_NumberOfNexusClinicEncounters")),
				NumberOfNexusClinicFormerEncounters = (Int32?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_NumberOfNexusClinicFormerEncounters")),
				NumberOfNexusClinicPriorEncounters = (Int32?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_NumberOfNexusClinicPriorEncounters")),
				NumberOfPrimaryCareEncounters = (Int32?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_NumberOfPrimaryCareEncounters")),
				NumberOfTerminalCADDiagnosis = (Int32?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_NumberOfTerminalCADDiagnosis")),
				NumberOfWomensHealthEncounters = (Int32?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_NumberOfWomensHealthEncounters")),
				PatientFirstName = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PatientFirstName")),
				PatientICN = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PatientICN")),
				PatientIEN = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PatientIEN")),
				PatientLastName = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PatientLastName")),
				PatientSID = (Int32)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PatientSID")),
				PatientSSN = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PatientSSN")),
				PCMMStaffName = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PCMMStaffName")),
				PCMMStaffSID = (Int64?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PCMMStaffSID")),
				PCMMTeam = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PCMMTeam")),
				PCMMTeamSID = (Int64?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PCMMTeamSID")),
				PhoneCellular = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PhoneCellular")),
				PhoneResidence = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PhoneResidence")),
				PhoneWork = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_PhoneWork")),
				Race = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_Race")),
				Region = (Int16?)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_Region")),
				Sta3n = (Int16)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_Sta3n")),
				State = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_State")),
				StreetAddress1 = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_StreetAddress1")),
				StreetAddress2 = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_StreetAddress2")),
				StreetAddress3 = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_StreetAddress3")),
				VAID = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_VAID")),
				VeteranFlag = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_VeteranFlag")),
				VISN = (Int16)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_VISN")),
				WomensHealthVisitStatus = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_WomensHealthVisitStatus")),
				Zip = (string)GetNullableObject(row.Field<object>("BCCCR_BCR_ALL_Zip"))
			};

			return objReturn;
		}

		#endregion
	}
}
