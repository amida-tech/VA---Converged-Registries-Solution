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
	public partial class SStaff_SStaffDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors

		public SStaff_SStaffDB()
		{
		}

		#endregion

		#region Properties
		#endregion

		#region Methods

		public SStaff_SStaff GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 Provider_ID)
		{
			SStaff_SStaff objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_SStaff_SStaff_getitem", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@Provider_ID", Provider_ID);

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

		public List<SStaff_SStaff> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<SStaff_SStaff> objReturn = null;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlDataAdapter sAdapter = null;
			DataSet objTemp = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_SStaff_SStaff_getitems", sConn);
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
						objReturn = myData.ToList<SStaff_SStaff>();
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

		public Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SStaff_SStaff objSave)
		{
			Int32 objReturn = 0;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;
			SqlParameter p = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_SStaff_SStaff_save", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

				p = new SqlParameter("@City", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.City);
				p = new SqlParameter("@CommercialPhone", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CommercialPhone);
				p = new SqlParameter("@CreatedByStaffSID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.CreatedByStaffSID);
				p = new SqlParameter("@DEA", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DEA);
				p = new SqlParameter("@Degree", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Degree);
				p = new SqlParameter("@DelegateOfStaffIEN", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DelegateOfStaffIEN);
				p = new SqlParameter("@DelegateOfStaffSID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DelegateOfStaffSID);
				p = new SqlParameter("@DelegationDate", SqlDbType.Date, 3);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DelegationDate);
				p = new SqlParameter("@DelegationLevel", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DelegationLevel);
				p = new SqlParameter("@DigitalPager", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.DigitalPager);
				p = new SqlParameter("@ElectronicSignatureCodeFlag", SqlDbType.Char, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ElectronicSignatureCodeFlag);
				p = new SqlParameter("@EmailAddress", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.EmailAddress);
				p = new SqlParameter("@EnteredDate", SqlDbType.Date, 3);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.EnteredDate);
				p = new SqlParameter("@ETLBatchID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ETLBatchID);
				p = new SqlParameter("@FaxNumber", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.FaxNumber);
				p = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.FirstName);
				p = new SqlParameter("@Gender", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Gender);
				p = new SqlParameter("@HINQEmployeeNumberFlag", SqlDbType.Char, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.HINQEmployeeNumberFlag);
				p = new SqlParameter("@HomePhone", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.HomePhone);
				p = new SqlParameter("@InactivationDate", SqlDbType.Date, 3);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.InactivationDate);
				p = new SqlParameter("@LastEditedDateTime", SqlDbType.SmallDateTime, 4);
				p.Precision = 16;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.LastEditedDateTime);
				p = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.LastName);
				p = new SqlParameter("@LastSignonDateTime", SqlDbType.SmallDateTime, 4);
				p.Precision = 16;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.LastSignonDateTime);
				p = new SqlParameter("@LastUsedTerminalType", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.LastUsedTerminalType);
				p = new SqlParameter("@MailCode", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MailCode);
				p = new SqlParameter("@MiddleName", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.MiddleName);
				p = new SqlParameter("@NetworkUsername", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NetworkUsername);
				p = new SqlParameter("@NPI", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NPI);
				p = new SqlParameter("@NPIAuthorizedReleaseFlag", SqlDbType.Char, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.NPIAuthorizedReleaseFlag);
				p = new SqlParameter("@OfficePhone", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.OfficePhone);
				p = new SqlParameter("@OpCode", SqlDbType.Char, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.OpCode);
				p = new SqlParameter("@PACFlag", SqlDbType.Char, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PACFlag);
				p = new SqlParameter("@Phone3", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Phone3);
				p = new SqlParameter("@Phone4", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Phone4);
				p = new SqlParameter("@PositionTitle", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.PositionTitle);
				p = new SqlParameter("@Provider_ID", SqlDbType.Int, 4);
				p.Direction = ParameterDirection.InputOutput;
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Provider_ID);
				p = new SqlParameter("@ProviderClass", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ProviderClass);
				p = new SqlParameter("@ProviderClassSID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ProviderClassSID);
				p = new SqlParameter("@ProviderScheduleType", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ProviderScheduleType);
				p = new SqlParameter("@Room", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Room);
				p = new SqlParameter("@ServiceComputationDate", SqlDbType.Date, 3);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ServiceComputationDate);
				p = new SqlParameter("@ServiceSection", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ServiceSection);
				p = new SqlParameter("@ServiceSectionSID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ServiceSectionSID);
				p = new SqlParameter("@ServiceType", SqlDbType.Char, 1);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ServiceType);
				p = new SqlParameter("@SignatureBlockName", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.SignatureBlockName);
				p = new SqlParameter("@SignatureBlockTitle", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.SignatureBlockTitle);
				p = new SqlParameter("@SocialWorkerImmediateSupervisorStaffSID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.SocialWorkerImmediateSupervisorStaffSID);
				p = new SqlParameter("@SocialWorkerPositionTitle", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.SocialWorkerPositionTitle);
				p = new SqlParameter("@Sta3n", SqlDbType.SmallInt, 2);
				p.Precision = 5;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.Sta3n);
				p = new SqlParameter("@StaffIEN", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.StaffIEN);
				p = new SqlParameter("@StaffName", SqlDbType.VarChar, 100);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.StaffName);
				p = new SqlParameter("@StaffNamePrefix", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.StaffNamePrefix);
				p = new SqlParameter("@StaffNameSuffix", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.StaffNameSuffix);
				p = new SqlParameter("@StaffSID", SqlDbType.Int, 4);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.StaffSID);
				p = new SqlParameter("@StateName", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.StateName);
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
				p = new SqlParameter("@SupplyEmployee", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.SupplyEmployee);
				p = new SqlParameter("@TemporaryAddress1", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TemporaryAddress1);
				p = new SqlParameter("@TemporaryAddress2", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TemporaryAddress2);
				p = new SqlParameter("@TemporaryAddress3", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TemporaryAddress3);
				p = new SqlParameter("@TemporaryAddressEndDate", SqlDbType.Date, 3);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TemporaryAddressEndDate);
				p = new SqlParameter("@TemporaryAddressStartDate", SqlDbType.Date, 3);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TemporaryAddressStartDate);
				p = new SqlParameter("@TemporaryCity", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TemporaryCity);
				p = new SqlParameter("@TemporaryStateName", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TemporaryStateName);
				p = new SqlParameter("@TemporaryZipCode", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TemporaryZipCode);
				p = new SqlParameter("@TerminationDate", SqlDbType.Date, 3);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TerminationDate);
				p = new SqlParameter("@TerminationReason", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.TerminationReason);
				p = new SqlParameter("@VANumber", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.VANumber);
				p = new SqlParameter("@VerifyCodeLastChangedDate", SqlDbType.Date, 3);
				p.Precision = 10;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.VerifyCodeLastChangedDate);
				p = new SqlParameter("@VistaCreateDate", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.VistaCreateDate);
				p = new SqlParameter("@VistaEditDate", SqlDbType.DateTime, 8);
				p.Precision = 23;
				p.Scale = 3;
				AddParameter(ref sCmd, ref p, objSave.VistaEditDate);
				p = new SqlParameter("@VoicePager", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.VoicePager);
				p = new SqlParameter("@ZipCode", SqlDbType.VarChar, 50);
				p.Precision = 0;
				p.Scale = 0;
				AddParameter(ref sCmd, ref p, objSave.ZipCode);

				LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
				int cnt = sCmd.ExecuteNonQuery();
				LogManager.LogTiming(logDetails);

				objReturn = (Int32)sCmd.Parameters["@Provider_ID"].Value;

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

		public Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 Provider_ID)
		{
			Boolean objReturn = false;

			SqlConnection sConn = null;
			SqlCommand sCmd = null;

			try
			{
				sConn = new SqlConnection(SqlConnectionString);

				sConn.Open();

				sCmd = new SqlCommand("CRS.usp_SStaff_SStaff_delete", sConn);
				sCmd.CommandTimeout = SqlCommandTimeout;
				sCmd.CommandType = CommandType.StoredProcedure;
				sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
				sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
				sCmd.Parameters.AddWithValue("@Provider_ID", Provider_ID);
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

		public SStaff_SStaff ParseReader(DataRow row)
		{
			SStaff_SStaff objReturn = new SStaff_SStaff
			{
				City = (string)GetNullableObject(row.Field<object>("City")),
				CommercialPhone = (string)GetNullableObject(row.Field<object>("CommercialPhone")),
				CreatedByStaffSID = (Int32?)GetNullableObject(row.Field<object>("CreatedByStaffSID")),
				DEA = (string)GetNullableObject(row.Field<object>("DEA")),
				Degree = (string)GetNullableObject(row.Field<object>("Degree")),
				DelegateOfStaffIEN = (string)GetNullableObject(row.Field<object>("DelegateOfStaffIEN")),
				DelegateOfStaffSID = (Int32?)GetNullableObject(row.Field<object>("DelegateOfStaffSID")),
				DelegationDate = (DateTime?)GetNullableObject(row.Field<object>("DelegationDate")),
				DelegationLevel = (string)GetNullableObject(row.Field<object>("DelegationLevel")),
				DigitalPager = (string)GetNullableObject(row.Field<object>("DigitalPager")),
				ElectronicSignatureCodeFlag = (string)GetNullableObject(row.Field<object>("ElectronicSignatureCodeFlag")),
				EmailAddress = (string)GetNullableObject(row.Field<object>("EmailAddress")),
				EnteredDate = (DateTime?)GetNullableObject(row.Field<object>("EnteredDate")),
				ETLBatchID = (Int32?)GetNullableObject(row.Field<object>("ETLBatchID")),
				FaxNumber = (string)GetNullableObject(row.Field<object>("FaxNumber")),
				FirstName = (string)GetNullableObject(row.Field<object>("FirstName")),
				Gender = (string)GetNullableObject(row.Field<object>("Gender")),
				HINQEmployeeNumberFlag = (string)GetNullableObject(row.Field<object>("HINQEmployeeNumberFlag")),
				HomePhone = (string)GetNullableObject(row.Field<object>("HomePhone")),
				InactivationDate = (DateTime?)GetNullableObject(row.Field<object>("InactivationDate")),
				LastEditedDateTime = (DateTime?)GetNullableObject(row.Field<object>("LastEditedDateTime")),
				LastName = (string)GetNullableObject(row.Field<object>("LastName")),
				LastSignonDateTime = (DateTime?)GetNullableObject(row.Field<object>("LastSignonDateTime")),
				LastUsedTerminalType = (string)GetNullableObject(row.Field<object>("LastUsedTerminalType")),
				MailCode = (string)GetNullableObject(row.Field<object>("MailCode")),
				MiddleName = (string)GetNullableObject(row.Field<object>("MiddleName")),
				NetworkUsername = (string)GetNullableObject(row.Field<object>("NetworkUsername")),
				NPI = (string)GetNullableObject(row.Field<object>("NPI")),
				NPIAuthorizedReleaseFlag = (string)GetNullableObject(row.Field<object>("NPIAuthorizedReleaseFlag")),
				OfficePhone = (string)GetNullableObject(row.Field<object>("OfficePhone")),
				OpCode = (string)GetNullableObject(row.Field<object>("OpCode")),
				PACFlag = (string)GetNullableObject(row.Field<object>("PACFlag")),
				Phone3 = (string)GetNullableObject(row.Field<object>("Phone3")),
				Phone4 = (string)GetNullableObject(row.Field<object>("Phone4")),
				PositionTitle = (string)GetNullableObject(row.Field<object>("PositionTitle")),
				Provider_ID = (Int32)GetNullableObject(row.Field<object>("Provider_ID")),
				ProviderClass = (string)GetNullableObject(row.Field<object>("ProviderClass")),
				ProviderClassSID = (Int32?)GetNullableObject(row.Field<object>("ProviderClassSID")),
				ProviderScheduleType = (string)GetNullableObject(row.Field<object>("ProviderScheduleType")),
				Room = (string)GetNullableObject(row.Field<object>("Room")),
				ServiceComputationDate = (DateTime?)GetNullableObject(row.Field<object>("ServiceComputationDate")),
				ServiceSection = (string)GetNullableObject(row.Field<object>("ServiceSection")),
				ServiceSectionSID = (Int32?)GetNullableObject(row.Field<object>("ServiceSectionSID")),
				ServiceType = (string)GetNullableObject(row.Field<object>("ServiceType")),
				SignatureBlockName = (string)GetNullableObject(row.Field<object>("SignatureBlockName")),
				SignatureBlockTitle = (string)GetNullableObject(row.Field<object>("SignatureBlockTitle")),
				SocialWorkerImmediateSupervisorStaffSID = (Int32?)GetNullableObject(row.Field<object>("SocialWorkerImmediateSupervisorStaffSID")),
				SocialWorkerPositionTitle = (string)GetNullableObject(row.Field<object>("SocialWorkerPositionTitle")),
				Sta3n = (Int16?)GetNullableObject(row.Field<object>("Sta3n")),
				StaffIEN = (string)GetNullableObject(row.Field<object>("StaffIEN")),
				StaffName = (string)GetNullableObject(row.Field<object>("StaffName")),
				StaffNamePrefix = (string)GetNullableObject(row.Field<object>("StaffNamePrefix")),
				StaffNameSuffix = (string)GetNullableObject(row.Field<object>("StaffNameSuffix")),
				StaffSID = (Int32?)GetNullableObject(row.Field<object>("StaffSID")),
				StateName = (string)GetNullableObject(row.Field<object>("StateName")),
				StreetAddress1 = (string)GetNullableObject(row.Field<object>("StreetAddress1")),
				StreetAddress2 = (string)GetNullableObject(row.Field<object>("StreetAddress2")),
				StreetAddress3 = (string)GetNullableObject(row.Field<object>("StreetAddress3")),
				SupplyEmployee = (string)GetNullableObject(row.Field<object>("SupplyEmployee")),
				TemporaryAddress1 = (string)GetNullableObject(row.Field<object>("TemporaryAddress1")),
				TemporaryAddress2 = (string)GetNullableObject(row.Field<object>("TemporaryAddress2")),
				TemporaryAddress3 = (string)GetNullableObject(row.Field<object>("TemporaryAddress3")),
				TemporaryAddressEndDate = (DateTime?)GetNullableObject(row.Field<object>("TemporaryAddressEndDate")),
				TemporaryAddressStartDate = (DateTime?)GetNullableObject(row.Field<object>("TemporaryAddressStartDate")),
				TemporaryCity = (string)GetNullableObject(row.Field<object>("TemporaryCity")),
				TemporaryStateName = (string)GetNullableObject(row.Field<object>("TemporaryStateName")),
				TemporaryZipCode = (string)GetNullableObject(row.Field<object>("TemporaryZipCode")),
				TerminationDate = (DateTime?)GetNullableObject(row.Field<object>("TerminationDate")),
				TerminationReason = (string)GetNullableObject(row.Field<object>("TerminationReason")),
				VANumber = (string)GetNullableObject(row.Field<object>("VANumber")),
				VerifyCodeLastChangedDate = (DateTime?)GetNullableObject(row.Field<object>("VerifyCodeLastChangedDate")),
				VistaCreateDate = (DateTime?)GetNullableObject(row.Field<object>("VistaCreateDate")),
				VistaEditDate = (DateTime?)GetNullableObject(row.Field<object>("VistaEditDate")),
				VoicePager = (string)GetNullableObject(row.Field<object>("VoicePager")),
				ZipCode = (string)GetNullableObject(row.Field<object>("ZipCode"))
			};

			return objReturn;
		}

		public SStaff_SStaff ParseReaderCustom(DataRow row)
		{
			SStaff_SStaff objReturn = new SStaff_SStaff
			{
				City = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_City")),
				CommercialPhone = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_CommercialPhone")),
				CreatedByStaffSID = (Int32?)GetNullableObject(row.Field<object>("SStaff_SStaff_CreatedByStaffSID")),
				DEA = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_DEA")),
				Degree = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_Degree")),
				DelegateOfStaffIEN = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_DelegateOfStaffIEN")),
				DelegateOfStaffSID = (Int32?)GetNullableObject(row.Field<object>("SStaff_SStaff_DelegateOfStaffSID")),
				DelegationDate = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_DelegationDate")),
				DelegationLevel = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_DelegationLevel")),
				DigitalPager = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_DigitalPager")),
				ElectronicSignatureCodeFlag = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_ElectronicSignatureCodeFlag")),
				EmailAddress = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_EmailAddress")),
				EnteredDate = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_EnteredDate")),
				ETLBatchID = (Int32?)GetNullableObject(row.Field<object>("SStaff_SStaff_ETLBatchID")),
				FaxNumber = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_FaxNumber")),
				FirstName = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_FirstName")),
				Gender = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_Gender")),
				HINQEmployeeNumberFlag = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_HINQEmployeeNumberFlag")),
				HomePhone = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_HomePhone")),
				InactivationDate = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_InactivationDate")),
				LastEditedDateTime = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_LastEditedDateTime")),
				LastName = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_LastName")),
				LastSignonDateTime = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_LastSignonDateTime")),
				LastUsedTerminalType = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_LastUsedTerminalType")),
				MailCode = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_MailCode")),
				MiddleName = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_MiddleName")),
				NetworkUsername = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_NetworkUsername")),
				NPI = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_NPI")),
				NPIAuthorizedReleaseFlag = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_NPIAuthorizedReleaseFlag")),
				OfficePhone = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_OfficePhone")),
				OpCode = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_OpCode")),
				PACFlag = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_PACFlag")),
				Phone3 = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_Phone3")),
				Phone4 = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_Phone4")),
				PositionTitle = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_PositionTitle")),
				Provider_ID = (Int32)GetNullableObject(row.Field<object>("SStaff_SStaff_Provider_ID")),
				ProviderClass = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_ProviderClass")),
				ProviderClassSID = (Int32?)GetNullableObject(row.Field<object>("SStaff_SStaff_ProviderClassSID")),
				ProviderScheduleType = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_ProviderScheduleType")),
				Room = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_Room")),
				ServiceComputationDate = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_ServiceComputationDate")),
				ServiceSection = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_ServiceSection")),
				ServiceSectionSID = (Int32?)GetNullableObject(row.Field<object>("SStaff_SStaff_ServiceSectionSID")),
				ServiceType = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_ServiceType")),
				SignatureBlockName = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_SignatureBlockName")),
				SignatureBlockTitle = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_SignatureBlockTitle")),
				SocialWorkerImmediateSupervisorStaffSID = (Int32?)GetNullableObject(row.Field<object>("SStaff_SStaff_SocialWorkerImmediateSupervisorStaffSID")),
				SocialWorkerPositionTitle = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_SocialWorkerPositionTitle")),
				Sta3n = (Int16?)GetNullableObject(row.Field<object>("SStaff_SStaff_Sta3n")),
				StaffIEN = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_StaffIEN")),
				StaffName = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_StaffName")),
				StaffNamePrefix = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_StaffNamePrefix")),
				StaffNameSuffix = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_StaffNameSuffix")),
				StaffSID = (Int32?)GetNullableObject(row.Field<object>("SStaff_SStaff_StaffSID")),
				StateName = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_StateName")),
				StreetAddress1 = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_StreetAddress1")),
				StreetAddress2 = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_StreetAddress2")),
				StreetAddress3 = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_StreetAddress3")),
				SupplyEmployee = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_SupplyEmployee")),
				TemporaryAddress1 = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_TemporaryAddress1")),
				TemporaryAddress2 = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_TemporaryAddress2")),
				TemporaryAddress3 = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_TemporaryAddress3")),
				TemporaryAddressEndDate = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_TemporaryAddressEndDate")),
				TemporaryAddressStartDate = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_TemporaryAddressStartDate")),
				TemporaryCity = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_TemporaryCity")),
				TemporaryStateName = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_TemporaryStateName")),
				TemporaryZipCode = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_TemporaryZipCode")),
				TerminationDate = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_TerminationDate")),
				TerminationReason = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_TerminationReason")),
				VANumber = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_VANumber")),
				VerifyCodeLastChangedDate = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_VerifyCodeLastChangedDate")),
				VistaCreateDate = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_VistaCreateDate")),
				VistaEditDate = (DateTime?)GetNullableObject(row.Field<object>("SStaff_SStaff_VistaEditDate")),
				VoicePager = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_VoicePager")),
				ZipCode = (string)GetNullableObject(row.Field<object>("SStaff_SStaff_ZipCode"))
			};

			return objReturn;
		}

		#endregion
	}
}
