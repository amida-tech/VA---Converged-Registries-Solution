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
    public partial class SPATIENTDB : DBUtils
    {
        #region Fields
        #endregion

        #region Constructors

        public SPATIENTDB()
        {
        }

        #endregion

        #region Properties
        #endregion

        #region Methods

        public SPATIENT GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PK_ID)
        {
            SPATIENT objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_SPATIENT_getitem", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@PK_ID", PK_ID);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
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

        public List<SPATIENT> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<SPATIENT> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_SPATIENT_getitems", sConn);
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

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
                {
                    var myData = objTemp.Tables[0].AsEnumerable().Select(r => ParseReader(r));
                    if (myData != null)
                    {
                        objReturn = myData.ToList<SPATIENT>();
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

        public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SPATIENT objSave)
        {
            Int32 objReturn = 0;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlParameter p = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_SPATIENT_save", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

                p = new SqlParameter("@AddressChangeInstitutionIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.AddressChangeInstitutionIEN);
                p = new SqlParameter("@AddressChangeInstitutionSID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.AddressChangeInstitutionSID);
                p = new SqlParameter("@AddressChangeStaffIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.AddressChangeStaffIEN);
                p = new SqlParameter("@AddressChangeStaffSID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.AddressChangeStaffSID);
                p = new SqlParameter("@Age", SqlDbType.Decimal, 9);
                p.Precision = 18;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Age);
                p = new SqlParameter("@BadAddressIndicator", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.BadAddressIndicator);
                p = new SqlParameter("@CDDeterminingInstitutionIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.CDDeterminingInstitutionIEN);
                p = new SqlParameter("@City", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.City);
                p = new SqlParameter("@CombatFromVistaDate", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.CombatFromVistaDate);
                p = new SqlParameter("@CombatToVistaDate", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.CombatToVistaDate);
                p = new SqlParameter("@ConfidentialAddressActiveFlag", SqlDbType.Char, 1);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.ConfidentialAddressActiveFlag);
                p = new SqlParameter("@Country", SqlDbType.VarChar, 100);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Country);
                p = new SqlParameter("@CountryIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.CountryIEN);
                p = new SqlParameter("@CountrySID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.CountrySID);
                p = new SqlParameter("@County", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.County);
                p = new SqlParameter("@Created", SqlDbType.DateTime, 8);
                p.Precision = 23;
                p.Scale = 3;
                AddParameter(ref sCmd, ref p, objSave.Created);
                p = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 30);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.CreatedBy);
                p = new SqlParameter("@CurrentMeansTestStatusIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.CurrentMeansTestStatusIEN);
                p = new SqlParameter("@DateOfBirth", SqlDbType.Date, 3);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.DateOfBirth);
                p = new SqlParameter("@DateOfBirthText", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.DateOfBirthText);
                p = new SqlParameter("@DateOfDeath", SqlDbType.Date, 3);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.DateOfDeath);
                p = new SqlParameter("@DateOfDeathText", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.DateOfDeathText);
                p = new SqlParameter("@Deceased", SqlDbType.Char, 1);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Deceased);
                p = new SqlParameter("@DEFAULT_RECORD", SqlDbType.Bit, 1);
                p.Precision = 1;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.DEFAULT_RECORD);
                p = new SqlParameter("@Eligibility", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Eligibility);
                p = new SqlParameter("@EligibilityIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.EligibilityIEN);
                p = new SqlParameter("@EligibilitySID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.EligibilitySID);
                p = new SqlParameter("@EligibilityStatus", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.EligibilityStatus);
                p = new SqlParameter("@EligibilityVACode", SqlDbType.Decimal, 9);
                p.Precision = 18;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.EligibilityVACode);
                p = new SqlParameter("@EligibilityVerificationSource", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.EligibilityVerificationSource);
                p = new SqlParameter("@EmailAddress", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.EmailAddress);
                p = new SqlParameter("@EnteredIntoFileDate", SqlDbType.Date, 3);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.EnteredIntoFileDate);
                p = new SqlParameter("@EnteredIntoFileDateTransformSID", SqlDbType.BigInt, 8);
                p.Precision = 19;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.EnteredIntoFileDateTransformSID);
                p = new SqlParameter("@EnteredIntoFileVistaErrorDate", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.EnteredIntoFileVistaErrorDate);
                p = new SqlParameter("@ETLBatchID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.ETLBatchID);
                p = new SqlParameter("@ExcludeFromFacilityDirectoryFlag", SqlDbType.Char, 1);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.ExcludeFromFacilityDirectoryFlag);
                p = new SqlParameter("@Gender", SqlDbType.Char, 1);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Gender);
                p = new SqlParameter("@GISAddressType", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISAddressType);
                p = new SqlParameter("@GISAddressUpdatedDate", SqlDbType.Date, 3);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISAddressUpdatedDate);
                p = new SqlParameter("@GISCongressDistrict", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISCongressDistrict);
                p = new SqlParameter("@GISFIPSCode", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISFIPSCode);
                p = new SqlParameter("@GISLocatorName", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISLocatorName);
                p = new SqlParameter("@GISMarket", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISMarket);
                p = new SqlParameter("@GISMatchedAddress", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISMatchedAddress);
                p = new SqlParameter("@GISMatchMethodCode", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISMatchMethodCode);
                p = new SqlParameter("@GISMatchScore", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISMatchScore);
                p = new SqlParameter("@GISMatchStatusCode", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISMatchStatusCode);
                p = new SqlParameter("@GISPatientAddressLatitude", SqlDbType.Float, 8);
                p.Precision = 53;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISPatientAddressLatitude);
                p = new SqlParameter("@GISPatientAddressLongitude", SqlDbType.Float, 8);
                p.Precision = 53;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISPatientAddressLongitude);
                p = new SqlParameter("@GISSector", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISSector);
                p = new SqlParameter("@GISStreetSide", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISStreetSide);
                p = new SqlParameter("@GISSubmarket", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISSubmarket);
                p = new SqlParameter("@GISURH", SqlDbType.Char, 1);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.GISURH);
                p = new SqlParameter("@InsuranceCoverageFlag", SqlDbType.Char, 1);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.InsuranceCoverageFlag);
                p = new SqlParameter("@LastServiceEntryDate", SqlDbType.Date, 3);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.LastServiceEntryDate);
                p = new SqlParameter("@LastServiceEntryDateTransformSID", SqlDbType.BigInt, 8);
                p.Precision = 19;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.LastServiceEntryDateTransformSID);
                p = new SqlParameter("@LastServiceEntryVistaErrorDate", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.LastServiceEntryVistaErrorDate);
                p = new SqlParameter("@LastServiceSeparationDate", SqlDbType.Date, 3);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.LastServiceSeparationDate);
                p = new SqlParameter("@LastServiceSeparationDateTransformSID", SqlDbType.BigInt, 8);
                p.Precision = 19;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.LastServiceSeparationDateTransformSID);
                p = new SqlParameter("@LastServiceSeparationVistaErrorDate", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.LastServiceSeparationVistaErrorDate);
                p = new SqlParameter("@MaritalStatus", SqlDbType.VarChar, 25);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.MaritalStatus);
                p = new SqlParameter("@MaritalStatusIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.MaritalStatusIEN);
                p = new SqlParameter("@MaritalStatusSID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.MaritalStatusSID);
                p = new SqlParameter("@MedicaidNumber", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.MedicaidNumber);
                p = new SqlParameter("@MothersMaidenName", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.MothersMaidenName);
                p = new SqlParameter("@OEF_OIF_IND", SqlDbType.Bit, 1);
                p.Precision = 1;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.OEF_OIF_IND);
                p = new SqlParameter("@OpCode", SqlDbType.Char, 1);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.OpCode);
                p = new SqlParameter("@Patient_ID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Patient_ID);
                p = new SqlParameter("@PatientFirstName", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PatientFirstName);
                p = new SqlParameter("@PatientICN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PatientICN);
                p = new SqlParameter("@PatientICNChecksum", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PatientICNChecksum);
                p = new SqlParameter("@PatientIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PatientIEN);
                p = new SqlParameter("@PatientLastName", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PatientLastName);
                p = new SqlParameter("@PatientName", SqlDbType.VarChar, 100);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PatientName);
                p = new SqlParameter("@PatientSID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PatientSID);
                p = new SqlParameter("@PatientSSN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PatientSSN);
                p = new SqlParameter("@PercentServiceConnect", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PercentServiceConnect);
                p = new SqlParameter("@PeriodOfService", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PeriodOfService);
                p = new SqlParameter("@PeriodOfServiceIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PeriodOfServiceIEN);
                p = new SqlParameter("@PeriodOfServiceSID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PeriodOfServiceSID);
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
                p = new SqlParameter("@PK_ID", SqlDbType.Int, 4);
                p.Direction = ParameterDirection.InputOutput;
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PK_ID);
                p = new SqlParameter("@PostalCode", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PostalCode);
                p = new SqlParameter("@POWLocationIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.POWLocationIEN);
                p = new SqlParameter("@PreferredInstitutionIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PreferredInstitutionIEN);
                p = new SqlParameter("@Province", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Province);
                p = new SqlParameter("@PseudoSSNFlag", SqlDbType.Char, 1);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PseudoSSNFlag);
                p = new SqlParameter("@PurpleHeartInstitutionIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.PurpleHeartInstitutionIEN);
                p = new SqlParameter("@Race", SqlDbType.VarChar, 45);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Race);
                p = new SqlParameter("@RaceIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.RaceIEN);
                p = new SqlParameter("@RaceSID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.RaceSID);
                p = new SqlParameter("@Religion", SqlDbType.VarChar, 30);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Religion);
                p = new SqlParameter("@ReligionIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.ReligionIEN);
                p = new SqlParameter("@ReligionSID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.ReligionSID);
                p = new SqlParameter("@RoomBedIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.RoomBedIEN);
                p = new SqlParameter("@ScrSSN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.ScrSSN);
                p = new SqlParameter("@SensitiveFlag", SqlDbType.Char, 1);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.SensitiveFlag);
                p = new SqlParameter("@Sta3n", SqlDbType.SmallInt, 2);
                p.Precision = 5;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Sta3n);
                p = new SqlParameter("@State", SqlDbType.VarChar, 30);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.State);
                p = new SqlParameter("@StateIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.StateIEN);
                p = new SqlParameter("@StateSID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.StateSID);
                p = new SqlParameter("@STD_COMBATLOCATION_ID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.STD_COMBATLOCATION_ID);
                p = new SqlParameter("@STD_ENTHNICITY_ID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.STD_ENTHNICITY_ID);
                p = new SqlParameter("@STD_GENDER_ID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.STD_GENDER_ID);
                p = new SqlParameter("@STD_MARITALSTATUS_ID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.STD_MARITALSTATUS_ID);
                p = new SqlParameter("@STD_RACE_ID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.STD_RACE_ID);
                p = new SqlParameter("@STD_SERVICEBRANCH_ID", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.STD_SERVICEBRANCH_ID);
                p = new SqlParameter("@StdRegistryId", SqlDbType.Int, 4);
                p.Precision = 10;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.StdRegistryId);
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
                p = new SqlParameter("@TemporaryAddressChangeInstitutionIEN", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.TemporaryAddressChangeInstitutionIEN);
                p = new SqlParameter("@Updatedate", SqlDbType.DateTime, 8);
                p.Precision = 23;
                p.Scale = 3;
                AddParameter(ref sCmd, ref p, objSave.Updatedate);
                p = new SqlParameter("@UpdatedBy", SqlDbType.VarChar, 30);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.UpdatedBy);
                p = new SqlParameter("@VeteranFlag", SqlDbType.Char, 1);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.VeteranFlag);
                p = new SqlParameter("@VistaCreateDate", SqlDbType.DateTime, 8);
                p.Precision = 23;
                p.Scale = 3;
                AddParameter(ref sCmd, ref p, objSave.VistaCreateDate);
                p = new SqlParameter("@VistaEditDate", SqlDbType.DateTime, 8);
                p.Precision = 23;
                p.Scale = 3;
                AddParameter(ref sCmd, ref p, objSave.VistaEditDate);
                p = new SqlParameter("@Zip", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Zip);
                p = new SqlParameter("@Zip4", SqlDbType.VarChar, 50);
                p.Precision = 0;
                p.Scale = 0;
                AddParameter(ref sCmd, ref p, objSave.Zip4);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                int cnt = sCmd.ExecuteNonQuery();
                LogManager.LogTiming(logDetails);

                objReturn = (Int32)sCmd.Parameters["@PK_ID"].Value;

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

        public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PK_ID)
        {
            Boolean objReturn = false;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_SPATIENT_delete", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@PK_ID", PK_ID);
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

        public SPATIENT ParseReader(DataRow row)
        {
            SPATIENT objReturn = new SPATIENT
            {
                AddressChangeInstitutionIEN = (string)GetNullableObject(row.Field<object>("AddressChangeInstitutionIEN")),
                AddressChangeInstitutionSID = (Int32?)GetNullableObject(row.Field<object>("AddressChangeInstitutionSID")),
                AddressChangeStaffIEN = (string)GetNullableObject(row.Field<object>("AddressChangeStaffIEN")),
                AddressChangeStaffSID = (Int32?)GetNullableObject(row.Field<object>("AddressChangeStaffSID")),
                Age = (decimal?)GetNullableObject(row.Field<object>("Age")),
                BadAddressIndicator = (string)GetNullableObject(row.Field<object>("BadAddressIndicator")),
                CDDeterminingInstitutionIEN = (string)GetNullableObject(row.Field<object>("CDDeterminingInstitutionIEN")),
                City = (string)GetNullableObject(row.Field<object>("City")),
                CombatFromVistaDate = (string)GetNullableObject(row.Field<object>("CombatFromVistaDate")),
                CombatToVistaDate = (string)GetNullableObject(row.Field<object>("CombatToVistaDate")),
                ConfidentialAddressActiveFlag = (string)GetNullableObject(row.Field<object>("ConfidentialAddressActiveFlag")),
                Country = (string)GetNullableObject(row.Field<object>("Country")),
                CountryIEN = (string)GetNullableObject(row.Field<object>("CountryIEN")),
                CountrySID = (Int32?)GetNullableObject(row.Field<object>("CountrySID")),
                County = (string)GetNullableObject(row.Field<object>("County")),
                Created = (DateTime?)GetNullableObject(row.Field<object>("Created")),
                CreatedBy = (string)GetNullableObject(row.Field<object>("CreatedBy")),
                CurrentMeansTestStatusIEN = (string)GetNullableObject(row.Field<object>("CurrentMeansTestStatusIEN")),
                DateOfBirth = (DateTime?)GetNullableObject(row.Field<object>("DateOfBirth")),
                DateOfBirthText = (string)GetNullableObject(row.Field<object>("DateOfBirthText")),
                DateOfDeath = (DateTime?)GetNullableObject(row.Field<object>("DateOfDeath")),
                DateOfDeathText = (string)GetNullableObject(row.Field<object>("DateOfDeathText")),
                Deceased = (string)GetNullableObject(row.Field<object>("Deceased")),
                DEFAULT_RECORD = (bool?)GetNullableObject(row.Field<object>("DEFAULT_RECORD")),
                Eligibility = (string)GetNullableObject(row.Field<object>("Eligibility")),
                EligibilityIEN = (string)GetNullableObject(row.Field<object>("EligibilityIEN")),
                EligibilitySID = (Int32?)GetNullableObject(row.Field<object>("EligibilitySID")),
                EligibilityStatus = (string)GetNullableObject(row.Field<object>("EligibilityStatus")),
                EligibilityVACode = (decimal?)GetNullableObject(row.Field<object>("EligibilityVACode")),
                EligibilityVerificationSource = (string)GetNullableObject(row.Field<object>("EligibilityVerificationSource")),
                EmailAddress = (string)GetNullableObject(row.Field<object>("EmailAddress")),
                EnteredIntoFileDate = (DateTime?)GetNullableObject(row.Field<object>("EnteredIntoFileDate")),
                EnteredIntoFileDateTransformSID = (Int64?)GetNullableObject(row.Field<object>("EnteredIntoFileDateTransformSID")),
                EnteredIntoFileVistaErrorDate = (string)GetNullableObject(row.Field<object>("EnteredIntoFileVistaErrorDate")),
                ETLBatchID = (Int32?)GetNullableObject(row.Field<object>("ETLBatchID")),
                ExcludeFromFacilityDirectoryFlag = (string)GetNullableObject(row.Field<object>("ExcludeFromFacilityDirectoryFlag")),
                Gender = (string)GetNullableObject(row.Field<object>("Gender")),
                GISAddressType = (string)GetNullableObject(row.Field<object>("GISAddressType")),
                GISAddressUpdatedDate = (DateTime?)GetNullableObject(row.Field<object>("GISAddressUpdatedDate")),
                GISCongressDistrict = (string)GetNullableObject(row.Field<object>("GISCongressDistrict")),
                GISFIPSCode = (string)GetNullableObject(row.Field<object>("GISFIPSCode")),
                GISLocatorName = (string)GetNullableObject(row.Field<object>("GISLocatorName")),
                GISMarket = (string)GetNullableObject(row.Field<object>("GISMarket")),
                GISMatchedAddress = (string)GetNullableObject(row.Field<object>("GISMatchedAddress")),
                GISMatchMethodCode = (string)GetNullableObject(row.Field<object>("GISMatchMethodCode")),
                GISMatchScore = (Int32?)GetNullableObject(row.Field<object>("GISMatchScore")),
                GISMatchStatusCode = (string)GetNullableObject(row.Field<object>("GISMatchStatusCode")),
                GISPatientAddressLatitude = (double?)GetNullableObject(row.Field<object>("GISPatientAddressLatitude")),
                GISPatientAddressLongitude = (double?)GetNullableObject(row.Field<object>("GISPatientAddressLongitude")),
                GISSector = (string)GetNullableObject(row.Field<object>("GISSector")),
                GISStreetSide = (string)GetNullableObject(row.Field<object>("GISStreetSide")),
                GISSubmarket = (string)GetNullableObject(row.Field<object>("GISSubmarket")),
                GISURH = (string)GetNullableObject(row.Field<object>("GISURH")),
                InsuranceCoverageFlag = (string)GetNullableObject(row.Field<object>("InsuranceCoverageFlag")),
                LastServiceEntryDate = (DateTime?)GetNullableObject(row.Field<object>("LastServiceEntryDate")),
                LastServiceEntryDateTransformSID = (Int64?)GetNullableObject(row.Field<object>("LastServiceEntryDateTransformSID")),
                LastServiceEntryVistaErrorDate = (string)GetNullableObject(row.Field<object>("LastServiceEntryVistaErrorDate")),
                LastServiceSeparationDate = (DateTime?)GetNullableObject(row.Field<object>("LastServiceSeparationDate")),
                LastServiceSeparationDateTransformSID = (Int64?)GetNullableObject(row.Field<object>("LastServiceSeparationDateTransformSID")),
                LastServiceSeparationVistaErrorDate = (string)GetNullableObject(row.Field<object>("LastServiceSeparationVistaErrorDate")),
                MaritalStatus = (string)GetNullableObject(row.Field<object>("MaritalStatus")),
                MaritalStatusIEN = (string)GetNullableObject(row.Field<object>("MaritalStatusIEN")),
                MaritalStatusSID = (Int32?)GetNullableObject(row.Field<object>("MaritalStatusSID")),
                MedicaidNumber = (string)GetNullableObject(row.Field<object>("MedicaidNumber")),
                MothersMaidenName = (string)GetNullableObject(row.Field<object>("MothersMaidenName")),
                OEF_OIF_IND = (bool?)GetNullableObject(row.Field<object>("OEF_OIF_IND")),
                OpCode = (string)GetNullableObject(row.Field<object>("OpCode")),
                Patient_ID = (Int32?)GetNullableObject(row.Field<object>("Patient_ID")),
                PatientFirstName = (string)GetNullableObject(row.Field<object>("PatientFirstName")),
                PatientICN = (string)GetNullableObject(row.Field<object>("PatientICN")),
                PatientICNChecksum = (string)GetNullableObject(row.Field<object>("PatientICNChecksum")),
                PatientIEN = (string)GetNullableObject(row.Field<object>("PatientIEN")),
                PatientLastName = (string)GetNullableObject(row.Field<object>("PatientLastName")),
                PatientName = (string)GetNullableObject(row.Field<object>("PatientName")),
                PatientSID = (Int32?)GetNullableObject(row.Field<object>("PatientSID")),
                PatientSSN = (string)GetNullableObject(row.Field<object>("PatientSSN")),
                PercentServiceConnect = (Int32?)GetNullableObject(row.Field<object>("PercentServiceConnect")),
                PeriodOfService = (string)GetNullableObject(row.Field<object>("PeriodOfService")),
                PeriodOfServiceIEN = (string)GetNullableObject(row.Field<object>("PeriodOfServiceIEN")),
                PeriodOfServiceSID = (Int32?)GetNullableObject(row.Field<object>("PeriodOfServiceSID")),
                PhoneCellular = (string)GetNullableObject(row.Field<object>("PhoneCellular")),
                PhoneResidence = (string)GetNullableObject(row.Field<object>("PhoneResidence")),
                PhoneWork = (string)GetNullableObject(row.Field<object>("PhoneWork")),
                PK_ID = (Int32)GetNullableObject(row.Field<object>("PK_ID")),
                PostalCode = (string)GetNullableObject(row.Field<object>("PostalCode")),
                POWLocationIEN = (string)GetNullableObject(row.Field<object>("POWLocationIEN")),
                PreferredInstitutionIEN = (string)GetNullableObject(row.Field<object>("PreferredInstitutionIEN")),
                Province = (string)GetNullableObject(row.Field<object>("Province")),
                PseudoSSNFlag = (string)GetNullableObject(row.Field<object>("PseudoSSNFlag")),
                PurpleHeartInstitutionIEN = (string)GetNullableObject(row.Field<object>("PurpleHeartInstitutionIEN")),
                Race = (string)GetNullableObject(row.Field<object>("Race")),
                RaceIEN = (string)GetNullableObject(row.Field<object>("RaceIEN")),
                RaceSID = (Int32?)GetNullableObject(row.Field<object>("RaceSID")),
                Religion = (string)GetNullableObject(row.Field<object>("Religion")),
                ReligionIEN = (string)GetNullableObject(row.Field<object>("ReligionIEN")),
                ReligionSID = (Int32?)GetNullableObject(row.Field<object>("ReligionSID")),
                RoomBedIEN = (string)GetNullableObject(row.Field<object>("RoomBedIEN")),
                ScrSSN = (string)GetNullableObject(row.Field<object>("ScrSSN")),
                SensitiveFlag = (string)GetNullableObject(row.Field<object>("SensitiveFlag")),
                Sta3n = (Int16?)GetNullableObject(row.Field<object>("Sta3n")),
                State = (string)GetNullableObject(row.Field<object>("State")),
                StateIEN = (string)GetNullableObject(row.Field<object>("StateIEN")),
                StateSID = (Int32?)GetNullableObject(row.Field<object>("StateSID")),
                STD_COMBATLOCATION_ID = (Int32?)GetNullableObject(row.Field<object>("STD_COMBATLOCATION_ID")),
                STD_ENTHNICITY_ID = (Int32?)GetNullableObject(row.Field<object>("STD_ENTHNICITY_ID")),
                STD_GENDER_ID = (Int32?)GetNullableObject(row.Field<object>("STD_GENDER_ID")),
                STD_MARITALSTATUS_ID = (Int32?)GetNullableObject(row.Field<object>("STD_MARITALSTATUS_ID")),
                STD_RACE_ID = (Int32?)GetNullableObject(row.Field<object>("STD_RACE_ID")),
                STD_SERVICEBRANCH_ID = (Int32?)GetNullableObject(row.Field<object>("STD_SERVICEBRANCH_ID")),
                StdRegistryId = (Int32?)GetNullableObject(row.Field<object>("StdRegistryId")),
                StreetAddress1 = (string)GetNullableObject(row.Field<object>("StreetAddress1")),
                StreetAddress2 = (string)GetNullableObject(row.Field<object>("StreetAddress2")),
                StreetAddress3 = (string)GetNullableObject(row.Field<object>("StreetAddress3")),
                TemporaryAddressChangeInstitutionIEN = (string)GetNullableObject(row.Field<object>("TemporaryAddressChangeInstitutionIEN")),
                Updatedate = (DateTime?)GetNullableObject(row.Field<object>("Updatedate")),
                UpdatedBy = (string)GetNullableObject(row.Field<object>("UpdatedBy")),
                VeteranFlag = (string)GetNullableObject(row.Field<object>("VeteranFlag")),
                VistaCreateDate = (DateTime?)GetNullableObject(row.Field<object>("VistaCreateDate")),
                VistaEditDate = (DateTime?)GetNullableObject(row.Field<object>("VistaEditDate")),
                Zip = (string)GetNullableObject(row.Field<object>("Zip")),
                Zip4 = (string)GetNullableObject(row.Field<object>("Zip4"))
            };

            return objReturn;
        }

        public SPATIENT ParseReaderCustom(DataRow row)
        {
            SPATIENT objReturn = new SPATIENT
            {
                AddressChangeInstitutionIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_AddressChangeInstitutionIEN")),
                AddressChangeInstitutionSID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_AddressChangeInstitutionSID")),
                AddressChangeStaffIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_AddressChangeStaffIEN")),
                AddressChangeStaffSID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_AddressChangeStaffSID")),
                Age = (decimal?)GetNullableObject(row.Field<object>("SPATIENT_Age")),
                BadAddressIndicator = (string)GetNullableObject(row.Field<object>("SPATIENT_BadAddressIndicator")),
                CDDeterminingInstitutionIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_CDDeterminingInstitutionIEN")),
                City = (string)GetNullableObject(row.Field<object>("SPATIENT_City")),
                CombatFromVistaDate = (string)GetNullableObject(row.Field<object>("SPATIENT_CombatFromVistaDate")),
                CombatToVistaDate = (string)GetNullableObject(row.Field<object>("SPATIENT_CombatToVistaDate")),
                ConfidentialAddressActiveFlag = (string)GetNullableObject(row.Field<object>("SPATIENT_ConfidentialAddressActiveFlag")),
                Country = (string)GetNullableObject(row.Field<object>("SPATIENT_Country")),
                CountryIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_CountryIEN")),
                CountrySID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_CountrySID")),
                County = (string)GetNullableObject(row.Field<object>("SPATIENT_County")),
                Created = (DateTime?)GetNullableObject(row.Field<object>("SPATIENT_Created")),
                CreatedBy = (string)GetNullableObject(row.Field<object>("SPATIENT_CreatedBy")),
                CurrentMeansTestStatusIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_CurrentMeansTestStatusIEN")),
                DateOfBirth = (DateTime?)GetNullableObject(row.Field<object>("SPATIENT_DateOfBirth")),
                DateOfBirthText = (string)GetNullableObject(row.Field<object>("SPATIENT_DateOfBirthText")),
                DateOfDeath = (DateTime?)GetNullableObject(row.Field<object>("SPATIENT_DateOfDeath")),
                DateOfDeathText = (string)GetNullableObject(row.Field<object>("SPATIENT_DateOfDeathText")),
                Deceased = (string)GetNullableObject(row.Field<object>("SPATIENT_Deceased")),
                DEFAULT_RECORD = (bool?)GetNullableObject(row.Field<object>("SPATIENT_DEFAULT_RECORD")),
                Eligibility = (string)GetNullableObject(row.Field<object>("SPATIENT_Eligibility")),
                EligibilityIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_EligibilityIEN")),
                EligibilitySID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_EligibilitySID")),
                EligibilityStatus = (string)GetNullableObject(row.Field<object>("SPATIENT_EligibilityStatus")),
                EligibilityVACode = (decimal?)GetNullableObject(row.Field<object>("SPATIENT_EligibilityVACode")),
                EligibilityVerificationSource = (string)GetNullableObject(row.Field<object>("SPATIENT_EligibilityVerificationSource")),
                EmailAddress = (string)GetNullableObject(row.Field<object>("SPATIENT_EmailAddress")),
                EnteredIntoFileDate = (DateTime?)GetNullableObject(row.Field<object>("SPATIENT_EnteredIntoFileDate")),
                EnteredIntoFileDateTransformSID = (Int64?)GetNullableObject(row.Field<object>("SPATIENT_EnteredIntoFileDateTransformSID")),
                EnteredIntoFileVistaErrorDate = (string)GetNullableObject(row.Field<object>("SPATIENT_EnteredIntoFileVistaErrorDate")),
                ETLBatchID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_ETLBatchID")),
                ExcludeFromFacilityDirectoryFlag = (string)GetNullableObject(row.Field<object>("SPATIENT_ExcludeFromFacilityDirectoryFlag")),
                Gender = (string)GetNullableObject(row.Field<object>("SPATIENT_Gender")),
                GISAddressType = (string)GetNullableObject(row.Field<object>("SPATIENT_GISAddressType")),
                GISAddressUpdatedDate = (DateTime?)GetNullableObject(row.Field<object>("SPATIENT_GISAddressUpdatedDate")),
                GISCongressDistrict = (string)GetNullableObject(row.Field<object>("SPATIENT_GISCongressDistrict")),
                GISFIPSCode = (string)GetNullableObject(row.Field<object>("SPATIENT_GISFIPSCode")),
                GISLocatorName = (string)GetNullableObject(row.Field<object>("SPATIENT_GISLocatorName")),
                GISMarket = (string)GetNullableObject(row.Field<object>("SPATIENT_GISMarket")),
                GISMatchedAddress = (string)GetNullableObject(row.Field<object>("SPATIENT_GISMatchedAddress")),
                GISMatchMethodCode = (string)GetNullableObject(row.Field<object>("SPATIENT_GISMatchMethodCode")),
                GISMatchScore = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_GISMatchScore")),
                GISMatchStatusCode = (string)GetNullableObject(row.Field<object>("SPATIENT_GISMatchStatusCode")),
                GISPatientAddressLatitude = (double?)GetNullableObject(row.Field<object>("SPATIENT_GISPatientAddressLatitude")),
                GISPatientAddressLongitude = (double?)GetNullableObject(row.Field<object>("SPATIENT_GISPatientAddressLongitude")),
                GISSector = (string)GetNullableObject(row.Field<object>("SPATIENT_GISSector")),
                GISStreetSide = (string)GetNullableObject(row.Field<object>("SPATIENT_GISStreetSide")),
                GISSubmarket = (string)GetNullableObject(row.Field<object>("SPATIENT_GISSubmarket")),
                GISURH = (string)GetNullableObject(row.Field<object>("SPATIENT_GISURH")),
                InsuranceCoverageFlag = (string)GetNullableObject(row.Field<object>("SPATIENT_InsuranceCoverageFlag")),
                LastServiceEntryDate = (DateTime?)GetNullableObject(row.Field<object>("SPATIENT_LastServiceEntryDate")),
                LastServiceEntryDateTransformSID = (Int64?)GetNullableObject(row.Field<object>("SPATIENT_LastServiceEntryDateTransformSID")),
                LastServiceEntryVistaErrorDate = (string)GetNullableObject(row.Field<object>("SPATIENT_LastServiceEntryVistaErrorDate")),
                LastServiceSeparationDate = (DateTime?)GetNullableObject(row.Field<object>("SPATIENT_LastServiceSeparationDate")),
                LastServiceSeparationDateTransformSID = (Int64?)GetNullableObject(row.Field<object>("SPATIENT_LastServiceSeparationDateTransformSID")),
                LastServiceSeparationVistaErrorDate = (string)GetNullableObject(row.Field<object>("SPATIENT_LastServiceSeparationVistaErrorDate")),
                MaritalStatus = (string)GetNullableObject(row.Field<object>("SPATIENT_MaritalStatus")),
                MaritalStatusIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_MaritalStatusIEN")),
                MaritalStatusSID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_MaritalStatusSID")),
                MedicaidNumber = (string)GetNullableObject(row.Field<object>("SPATIENT_MedicaidNumber")),
                MothersMaidenName = (string)GetNullableObject(row.Field<object>("SPATIENT_MothersMaidenName")),
                OEF_OIF_IND = (bool?)GetNullableObject(row.Field<object>("SPATIENT_OEF_OIF_IND")),
                OpCode = (string)GetNullableObject(row.Field<object>("SPATIENT_OpCode")),
                Patient_ID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_Patient_ID")),
                PatientFirstName = (string)GetNullableObject(row.Field<object>("SPATIENT_PatientFirstName")),
                PatientICN = (string)GetNullableObject(row.Field<object>("SPATIENT_PatientICN")),
                PatientICNChecksum = (string)GetNullableObject(row.Field<object>("SPATIENT_PatientICNChecksum")),
                PatientIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_PatientIEN")),
                PatientLastName = (string)GetNullableObject(row.Field<object>("SPATIENT_PatientLastName")),
                PatientName = (string)GetNullableObject(row.Field<object>("SPATIENT_PatientName")),
                PatientSID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_PatientSID")),
                PatientSSN = (string)GetNullableObject(row.Field<object>("SPATIENT_PatientSSN")),
                PercentServiceConnect = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_PercentServiceConnect")),
                PeriodOfService = (string)GetNullableObject(row.Field<object>("SPATIENT_PeriodOfService")),
                PeriodOfServiceIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_PeriodOfServiceIEN")),
                PeriodOfServiceSID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_PeriodOfServiceSID")),
                PhoneCellular = (string)GetNullableObject(row.Field<object>("SPATIENT_PhoneCellular")),
                PhoneResidence = (string)GetNullableObject(row.Field<object>("SPATIENT_PhoneResidence")),
                PhoneWork = (string)GetNullableObject(row.Field<object>("SPATIENT_PhoneWork")),
                PK_ID = (Int32)GetNullableObject(row.Field<object>("SPATIENT_PK_ID")),
                PostalCode = (string)GetNullableObject(row.Field<object>("SPATIENT_PostalCode")),
                POWLocationIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_POWLocationIEN")),
                PreferredInstitutionIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_PreferredInstitutionIEN")),
                Province = (string)GetNullableObject(row.Field<object>("SPATIENT_Province")),
                PseudoSSNFlag = (string)GetNullableObject(row.Field<object>("SPATIENT_PseudoSSNFlag")),
                PurpleHeartInstitutionIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_PurpleHeartInstitutionIEN")),
                Race = (string)GetNullableObject(row.Field<object>("SPATIENT_Race")),
                RaceIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_RaceIEN")),
                RaceSID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_RaceSID")),
                Religion = (string)GetNullableObject(row.Field<object>("SPATIENT_Religion")),
                ReligionIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_ReligionIEN")),
                ReligionSID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_ReligionSID")),
                RoomBedIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_RoomBedIEN")),
                ScrSSN = (string)GetNullableObject(row.Field<object>("SPATIENT_ScrSSN")),
                SensitiveFlag = (string)GetNullableObject(row.Field<object>("SPATIENT_SensitiveFlag")),
                Sta3n = (Int16?)GetNullableObject(row.Field<object>("SPATIENT_Sta3n")),
                State = (string)GetNullableObject(row.Field<object>("SPATIENT_State")),
                StateIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_StateIEN")),
                StateSID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_StateSID")),
                STD_COMBATLOCATION_ID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_STD_COMBATLOCATION_ID")),
                STD_ENTHNICITY_ID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_STD_ENTHNICITY_ID")),
                STD_GENDER_ID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_STD_GENDER_ID")),
                STD_MARITALSTATUS_ID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_STD_MARITALSTATUS_ID")),
                STD_RACE_ID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_STD_RACE_ID")),
                STD_SERVICEBRANCH_ID = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_STD_SERVICEBRANCH_ID")),
                StdRegistryId = (Int32?)GetNullableObject(row.Field<object>("SPATIENT_StdRegistryId")),
                StreetAddress1 = (string)GetNullableObject(row.Field<object>("SPATIENT_StreetAddress1")),
                StreetAddress2 = (string)GetNullableObject(row.Field<object>("SPATIENT_StreetAddress2")),
                StreetAddress3 = (string)GetNullableObject(row.Field<object>("SPATIENT_StreetAddress3")),
                TemporaryAddressChangeInstitutionIEN = (string)GetNullableObject(row.Field<object>("SPATIENT_TemporaryAddressChangeInstitutionIEN")),
                Updatedate = (DateTime?)GetNullableObject(row.Field<object>("SPATIENT_Updatedate")),
                UpdatedBy = (string)GetNullableObject(row.Field<object>("SPATIENT_UpdatedBy")),
                VeteranFlag = (string)GetNullableObject(row.Field<object>("SPATIENT_VeteranFlag")),
                VistaCreateDate = (DateTime?)GetNullableObject(row.Field<object>("SPATIENT_VistaCreateDate")),
                VistaEditDate = (DateTime?)GetNullableObject(row.Field<object>("SPATIENT_VistaEditDate")),
                Zip = (string)GetNullableObject(row.Field<object>("SPATIENT_Zip")),
                Zip4 = (string)GetNullableObject(row.Field<object>("SPATIENT_Zip4"))
            };

            return objReturn;
        }

        #endregion
    }
}
