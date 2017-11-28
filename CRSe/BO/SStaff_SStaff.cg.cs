using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class SStaff_SStaff
	{
		#region Fields

		private string city;
		private string commercialPhone;
		private Int32? createdByStaffSID;
		private string dEA;
		private string degree;
		private string delegateOfStaffIEN;
		private Int32? delegateOfStaffSID;
		private DateTime? delegationDate;
		private string delegationLevel;
		private string digitalPager;
		private string electronicSignatureCodeFlag;
		private string emailAddress;
		private DateTime? enteredDate;
		private Int32? eTLBatchID;
		private string faxNumber;
		private string firstName;
		private string gender;
		private string hINQEmployeeNumberFlag;
		private string homePhone;
		private DateTime? inactivationDate;
		private DateTime? lastEditedDateTime;
		private string lastName;
		private DateTime? lastSignonDateTime;
		private string lastUsedTerminalType;
		private string mailCode;
		private string middleName;
		private string networkUsername;
		private string nPI;
		private string nPIAuthorizedReleaseFlag;
		private string officePhone;
		private string opCode;
		private string pACFlag;
		private string phone3;
		private string phone4;
		private string positionTitle;
		private Int32 providerID;
		private string providerClass;
		private Int32? providerClassSID;
		private string providerScheduleType;
		private string room;
		private DateTime? serviceComputationDate;
		private string serviceSection;
		private Int32? serviceSectionSID;
		private string serviceType;
		private string signatureBlockName;
		private string signatureBlockTitle;
		private Int32? socialWorkerImmediateSupervisorStaffSID;
		private string socialWorkerPositionTitle;
		private Int16? sta3n;
		private string staffIEN;
		private string staffName;
		private string staffNamePrefix;
		private string staffNameSuffix;
		private Int32? staffSID;
		private string stateName;
		private string streetAddress1;
		private string streetAddress2;
		private string streetAddress3;
		private string supplyEmployee;
		private string temporaryAddress1;
		private string temporaryAddress2;
		private string temporaryAddress3;
		private DateTime? temporaryAddressEndDate;
		private DateTime? temporaryAddressStartDate;
		private string temporaryCity;
		private string temporaryStateName;
		private string temporaryZipCode;
		private DateTime? terminationDate;
		private string terminationReason;
		private string vANumber;
		private DateTime? verifyCodeLastChangedDate;
		private DateTime? vistaCreateDate;
		private DateTime? vistaEditDate;
		private string voicePager;
		private string zipCode;

		#endregion

		#region Constructors

		public SStaff_SStaff()
		{
		}

		#endregion

		#region Properties

		public string City
		{
			get { return this.city; }
			set { this.city = value; }
		}

		public string CommercialPhone
		{
			get { return this.commercialPhone; }
			set { this.commercialPhone = value; }
		}

		public Int32? CreatedByStaffSID
		{
			get { return this.createdByStaffSID; }
			set { this.createdByStaffSID = value; }
		}

		public string DEA
		{
			get { return this.dEA; }
			set { this.dEA = value; }
		}

		public string Degree
		{
			get { return this.degree; }
			set { this.degree = value; }
		}

		public string DelegateOfStaffIEN
		{
			get { return this.delegateOfStaffIEN; }
			set { this.delegateOfStaffIEN = value; }
		}

		public Int32? DelegateOfStaffSID
		{
			get { return this.delegateOfStaffSID; }
			set { this.delegateOfStaffSID = value; }
		}

		public DateTime? DelegationDate
		{
			get { return this.delegationDate; }
			set { this.delegationDate = value; }
		}

		public string DelegationLevel
		{
			get { return this.delegationLevel; }
			set { this.delegationLevel = value; }
		}

		public string DigitalPager
		{
			get { return this.digitalPager; }
			set { this.digitalPager = value; }
		}

		public string ElectronicSignatureCodeFlag
		{
			get { return this.electronicSignatureCodeFlag; }
			set { this.electronicSignatureCodeFlag = value; }
		}

		public string EmailAddress
		{
			get { return this.emailAddress; }
			set { this.emailAddress = value; }
		}

		public DateTime? EnteredDate
		{
			get { return this.enteredDate; }
			set { this.enteredDate = value; }
		}

		public Int32? ETLBatchID
		{
			get { return this.eTLBatchID; }
			set { this.eTLBatchID = value; }
		}

		public string FaxNumber
		{
			get { return this.faxNumber; }
			set { this.faxNumber = value; }
		}

		public string FirstName
		{
			get { return this.firstName; }
			set { this.firstName = value; }
		}

		public string Gender
		{
			get { return this.gender; }
			set { this.gender = value; }
		}

		public string HINQEmployeeNumberFlag
		{
			get { return this.hINQEmployeeNumberFlag; }
			set { this.hINQEmployeeNumberFlag = value; }
		}

		public string HomePhone
		{
			get { return this.homePhone; }
			set { this.homePhone = value; }
		}

		public DateTime? InactivationDate
		{
			get { return this.inactivationDate; }
			set { this.inactivationDate = value; }
		}

		public DateTime? LastEditedDateTime
		{
			get { return this.lastEditedDateTime; }
			set { this.lastEditedDateTime = value; }
		}

		public string LastName
		{
			get { return this.lastName; }
			set { this.lastName = value; }
		}

		public DateTime? LastSignonDateTime
		{
			get { return this.lastSignonDateTime; }
			set { this.lastSignonDateTime = value; }
		}

		public string LastUsedTerminalType
		{
			get { return this.lastUsedTerminalType; }
			set { this.lastUsedTerminalType = value; }
		}

		public string MailCode
		{
			get { return this.mailCode; }
			set { this.mailCode = value; }
		}

		public string MiddleName
		{
			get { return this.middleName; }
			set { this.middleName = value; }
		}

		public string NetworkUsername
		{
			get { return this.networkUsername; }
			set { this.networkUsername = value; }
		}

		public string NPI
		{
			get { return this.nPI; }
			set { this.nPI = value; }
		}

		public string NPIAuthorizedReleaseFlag
		{
			get { return this.nPIAuthorizedReleaseFlag; }
			set { this.nPIAuthorizedReleaseFlag = value; }
		}

		public string OfficePhone
		{
			get { return this.officePhone; }
			set { this.officePhone = value; }
		}

		public string OpCode
		{
			get { return this.opCode; }
			set { this.opCode = value; }
		}

		public string PACFlag
		{
			get { return this.pACFlag; }
			set { this.pACFlag = value; }
		}

		public string Phone3
		{
			get { return this.phone3; }
			set { this.phone3 = value; }
		}

		public string Phone4
		{
			get { return this.phone4; }
			set { this.phone4 = value; }
		}

		public string PositionTitle
		{
			get { return this.positionTitle; }
			set { this.positionTitle = value; }
		}

		public Int32 Provider_ID
		{
			get { return this.providerID; }
			set { this.providerID = value; }
		}

		public string ProviderClass
		{
			get { return this.providerClass; }
			set { this.providerClass = value; }
		}

		public Int32? ProviderClassSID
		{
			get { return this.providerClassSID; }
			set { this.providerClassSID = value; }
		}

		public string ProviderScheduleType
		{
			get { return this.providerScheduleType; }
			set { this.providerScheduleType = value; }
		}

		public string Room
		{
			get { return this.room; }
			set { this.room = value; }
		}

		public DateTime? ServiceComputationDate
		{
			get { return this.serviceComputationDate; }
			set { this.serviceComputationDate = value; }
		}

		public string ServiceSection
		{
			get { return this.serviceSection; }
			set { this.serviceSection = value; }
		}

		public Int32? ServiceSectionSID
		{
			get { return this.serviceSectionSID; }
			set { this.serviceSectionSID = value; }
		}

		public string ServiceType
		{
			get { return this.serviceType; }
			set { this.serviceType = value; }
		}

		public string SignatureBlockName
		{
			get { return this.signatureBlockName; }
			set { this.signatureBlockName = value; }
		}

		public string SignatureBlockTitle
		{
			get { return this.signatureBlockTitle; }
			set { this.signatureBlockTitle = value; }
		}

		public Int32? SocialWorkerImmediateSupervisorStaffSID
		{
			get { return this.socialWorkerImmediateSupervisorStaffSID; }
			set { this.socialWorkerImmediateSupervisorStaffSID = value; }
		}

		public string SocialWorkerPositionTitle
		{
			get { return this.socialWorkerPositionTitle; }
			set { this.socialWorkerPositionTitle = value; }
		}

		public Int16? Sta3n
		{
			get { return this.sta3n; }
			set { this.sta3n = value; }
		}

		public string StaffIEN
		{
			get { return this.staffIEN; }
			set { this.staffIEN = value; }
		}

		public string StaffName
		{
			get { return this.staffName; }
			set { this.staffName = value; }
		}

		public string StaffNamePrefix
		{
			get { return this.staffNamePrefix; }
			set { this.staffNamePrefix = value; }
		}

		public string StaffNameSuffix
		{
			get { return this.staffNameSuffix; }
			set { this.staffNameSuffix = value; }
		}

		public Int32? StaffSID
		{
			get { return this.staffSID; }
			set { this.staffSID = value; }
		}

		public string StateName
		{
			get { return this.stateName; }
			set { this.stateName = value; }
		}

		public string StreetAddress1
		{
			get { return this.streetAddress1; }
			set { this.streetAddress1 = value; }
		}

		public string StreetAddress2
		{
			get { return this.streetAddress2; }
			set { this.streetAddress2 = value; }
		}

		public string StreetAddress3
		{
			get { return this.streetAddress3; }
			set { this.streetAddress3 = value; }
		}

		public string SupplyEmployee
		{
			get { return this.supplyEmployee; }
			set { this.supplyEmployee = value; }
		}

		public string TemporaryAddress1
		{
			get { return this.temporaryAddress1; }
			set { this.temporaryAddress1 = value; }
		}

		public string TemporaryAddress2
		{
			get { return this.temporaryAddress2; }
			set { this.temporaryAddress2 = value; }
		}

		public string TemporaryAddress3
		{
			get { return this.temporaryAddress3; }
			set { this.temporaryAddress3 = value; }
		}

		public DateTime? TemporaryAddressEndDate
		{
			get { return this.temporaryAddressEndDate; }
			set { this.temporaryAddressEndDate = value; }
		}

		public DateTime? TemporaryAddressStartDate
		{
			get { return this.temporaryAddressStartDate; }
			set { this.temporaryAddressStartDate = value; }
		}

		public string TemporaryCity
		{
			get { return this.temporaryCity; }
			set { this.temporaryCity = value; }
		}

		public string TemporaryStateName
		{
			get { return this.temporaryStateName; }
			set { this.temporaryStateName = value; }
		}

		public string TemporaryZipCode
		{
			get { return this.temporaryZipCode; }
			set { this.temporaryZipCode = value; }
		}

		public DateTime? TerminationDate
		{
			get { return this.terminationDate; }
			set { this.terminationDate = value; }
		}

		public string TerminationReason
		{
			get { return this.terminationReason; }
			set { this.terminationReason = value; }
		}

		public string VANumber
		{
			get { return this.vANumber; }
			set { this.vANumber = value; }
		}

		public DateTime? VerifyCodeLastChangedDate
		{
			get { return this.verifyCodeLastChangedDate; }
			set { this.verifyCodeLastChangedDate = value; }
		}

		public DateTime? VistaCreateDate
		{
			get { return this.vistaCreateDate; }
			set { this.vistaCreateDate = value; }
		}

		public DateTime? VistaEditDate
		{
			get { return this.vistaEditDate; }
			set { this.vistaEditDate = value; }
		}

		public string VoicePager
		{
			get { return this.voicePager; }
			set { this.voicePager = value; }
		}

		public string ZipCode
		{
			get { return this.zipCode; }
			set { this.zipCode = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
