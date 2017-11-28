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
    public partial class ETLDB : DBUtils
    {
        #region Fields
        #endregion

        #region Constructors

        public ETLDB()
        {
        }

        #endregion

        #region Properties
        #endregion

        #region Methods

        public List<SPATIENT> CDW_GetData(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, RegistryWizard registryWizard)
        {
            List<SPATIENT> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(EtlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRSE.CDW_GETData_Wizard", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@StdRegistryId", registryWizard.StdRegistryId);
                sCmd.Parameters.AddWithValue("@CombatLocation", registryWizard.CombatLocIds);
                sCmd.Parameters.AddWithValue("@Ethnicity", registryWizard.EthnicityIds);
                sCmd.Parameters.AddWithValue("@Gender", registryWizard.GenderIds);

                if (registryWizard.OEFOIFLocation == null)
                    sCmd.Parameters.AddWithValue("@OEFOIF", DBNull.Value);
                else if (registryWizard.OEFOIFLocation.Value)
                    sCmd.Parameters.AddWithValue("@OEFOIF", "1");
                else
                    sCmd.Parameters.AddWithValue("@OEFOIF", "0");

                sCmd.Parameters.AddWithValue("@Race", registryWizard.RaceIds);
                sCmd.Parameters.AddWithValue("@ServiceBranch", registryWizard.ServiceIds);
                sCmd.Parameters.AddWithValue("@MaritalStatus", registryWizard.MaritalStatusIds);
                sCmd.Parameters.AddWithValue("@DOBMin", registryWizard.DOBMin);
                sCmd.Parameters.AddWithValue("@DOBMax", registryWizard.DOBMax);
                sCmd.Parameters.AddWithValue("@UserName", registryWizard.Username);
                sCmd.Parameters.AddWithValue("@Count", registryWizard.Count);

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

        public Int32 CDW_GetCount(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, RegistryWizard registryWizard)
        {
            Int32 objReturn = 0;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataReader sReader = null;

            try
            {
                sConn = new SqlConnection(EtlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRSE.CDW_GETData_Wizard", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@StdRegistryId", registryWizard.StdRegistryId);
                sCmd.Parameters.AddWithValue("@CombatLocation", registryWizard.CombatLocIds);
                sCmd.Parameters.AddWithValue("@Ethnicity", registryWizard.EthnicityIds);
                sCmd.Parameters.AddWithValue("@Gender", registryWizard.GenderIds);

                if (registryWizard.OEFOIFLocation == null)
                    sCmd.Parameters.AddWithValue("@OEFOIF", DBNull.Value);
                else if (registryWizard.OEFOIFLocation.Value)
                    sCmd.Parameters.AddWithValue("@OEFOIF", "1");
                else
                    sCmd.Parameters.AddWithValue("@OEFOIF", "0");

                sCmd.Parameters.AddWithValue("@Race", registryWizard.RaceIds);
                sCmd.Parameters.AddWithValue("@ServiceBranch", registryWizard.ServiceIds);
                sCmd.Parameters.AddWithValue("@MaritalStatus", registryWizard.MaritalStatusIds);
                sCmd.Parameters.AddWithValue("@DOBMin", registryWizard.DOBMin);
                sCmd.Parameters.AddWithValue("@DOBMax", registryWizard.DOBMax);
                sCmd.Parameters.AddWithValue("@UserName", registryWizard.Username);
                sCmd.Parameters.AddWithValue("@Count", registryWizard.Count);
                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sReader = sCmd.ExecuteReader();
                LogManager.LogTiming(logDetails);

                if (sReader != null && sReader.HasRows)
                {
                    sReader.Read();
                    objReturn = (Int32)GetNullableObject(sReader[0]);
                }

                sReader.Close();
                sConn.Close();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }
            finally
            {
                if (sReader != null)
                {
                    if (!sReader.IsClosed) { sReader.Close(); }
                    sReader.Dispose();
                    sReader = null;
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

        public Int32 CDW_SaveData(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, List<SPATIENT> objList)
        {
            Int32 objReturn = 0;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlParameter p = null;

            try
            {
                if (objList != null)
                {
                    sConn = new SqlConnection(SqlConnectionString);

                    sConn.Open();

                    foreach (SPATIENT objSave in objList)
                    {
                        sCmd = new SqlCommand("CRS.usp_CDW_SaveData", sConn);
                        sCmd.CommandTimeout = SqlCommandTimeout;
                        sCmd.CommandType = CommandType.StoredProcedure;
                        sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                        sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

                        //Same parameters as what are used in SPATIENT.Save

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

                        objReturn++;
                    }

                    sConn.Close();
                }
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
            SPATIENTDB sPATIENTDB = new SPATIENTDB();
            SPATIENT objReturn = sPATIENTDB.ParseReader(row);

            return objReturn;
        }

        #endregion
    }
}
