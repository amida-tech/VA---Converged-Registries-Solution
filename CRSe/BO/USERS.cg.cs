using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class USERS
	{
		#region Fields

		private DateTime? aCCOUNTEXPIREDATE;
		private DateTime? aCCOUNTLOCKDATE;
		private string aGREEMENTSIGNATURECODE;
		private DateTime cREATED;
		private string cREATEDBY;
        private Int32? dEFAULTREGISTRYID;
		private string domain;
		private string eMAILADDRESS;
		private string eMPLOYEENUMBER;
		private string fAXNUMBER;
		private string fIRSTNAME;
		private string fULLNAME;
		private DateTime? iNACTIVEDATE;
		private bool iNACTIVEFLAG;
		private DateTime? iNITIALLOGINDATE;
		private string jOBTITLE;
		private string lASTNAME;
		private string mAIDENNAME;
		private string mIDDLENAME;
		private Int32? nUMBEROFLOGINATTEMPTS;
		private string pASSWORD;
		private DateTime? pASSWORDCHANGEDATE;
		private DateTime? pASSWORDCREATEDATE;
		private DateTime? pASSWORDEXPIREDATE;
		private string sIGNATUREVERIFIEDIND;
		private string tELEPHONENUMBER;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private Int32 uSERID;
		private string uSERNAME;
        private bool? rECEIVEEMAIL;

		#endregion

		#region Constructors

		public USERS()
		{
		}

		#endregion

		#region Properties

		public DateTime? ACCOUNT_EXPIRE_DATE
		{
			get { return this.aCCOUNTEXPIREDATE; }
			set { this.aCCOUNTEXPIREDATE = value; }
		}

		public DateTime? ACCOUNT_LOCK_DATE
		{
			get { return this.aCCOUNTLOCKDATE; }
			set { this.aCCOUNTLOCKDATE = value; }
		}

		public string AGREEMENT_SIGNATURE_CODE
		{
			get { return this.aGREEMENTSIGNATURECODE; }
			set { this.aGREEMENTSIGNATURECODE = value; }
		}

		public DateTime CREATED
		{
			get { return this.cREATED; }
			set { this.cREATED = value; }
		}

		public string CREATEDBY
		{
			get { return this.cREATEDBY; }
			set { this.cREATEDBY = value; }
		}

        public Int32? DEFAULT_REGISTRY_ID
        {
            get { return this.dEFAULTREGISTRYID; }
            set { this.dEFAULTREGISTRYID = value; }
        }

		public string Domain
		{
			get { return this.domain; }
			set { this.domain = value; }
		}

		public string EMAIL_ADDRESS
		{
			get { return this.eMAILADDRESS; }
			set { this.eMAILADDRESS = value; }
		}

		public string EMPLOYEE_NUMBER
		{
			get { return this.eMPLOYEENUMBER; }
			set { this.eMPLOYEENUMBER = value; }
		}

		public string FAX_NUMBER
		{
			get { return this.fAXNUMBER; }
			set { this.fAXNUMBER = value; }
		}

		public string FIRST_NAME
		{
			get { return this.fIRSTNAME; }
			set { this.fIRSTNAME = value; }
		}

		public string FULL_NAME
		{
			get { return this.fULLNAME; }
			set { this.fULLNAME = value; }
		}

		public DateTime? INACTIVE_DATE
		{
			get { return this.iNACTIVEDATE; }
			set { this.iNACTIVEDATE = value; }
		}

		public bool INACTIVE_FLAG
		{
			get { return this.iNACTIVEFLAG; }
			set { this.iNACTIVEFLAG = value; }
		}

		public DateTime? INITIAL_LOGIN_DATE
		{
			get { return this.iNITIALLOGINDATE; }
			set { this.iNITIALLOGINDATE = value; }
		}

		public string JOB_TITLE
		{
			get { return this.jOBTITLE; }
			set { this.jOBTITLE = value; }
		}

		public string LAST_NAME
		{
			get { return this.lASTNAME; }
			set { this.lASTNAME = value; }
		}

		public string MAIDEN_NAME
		{
			get { return this.mAIDENNAME; }
			set { this.mAIDENNAME = value; }
		}

		public string MIDDLE_NAME
		{
			get { return this.mIDDLENAME; }
			set { this.mIDDLENAME = value; }
		}

		public Int32? NUMBER_OF_LOGIN_ATTEMPTS
		{
			get { return this.nUMBEROFLOGINATTEMPTS; }
			set { this.nUMBEROFLOGINATTEMPTS = value; }
		}

		public string PASSWORD
		{
			get { return this.pASSWORD; }
			set { this.pASSWORD = value; }
		}

		public DateTime? PASSWORD_CHANGE_DATE
		{
			get { return this.pASSWORDCHANGEDATE; }
			set { this.pASSWORDCHANGEDATE = value; }
		}

		public DateTime? PASSWORD_CREATE_DATE
		{
			get { return this.pASSWORDCREATEDATE; }
			set { this.pASSWORDCREATEDATE = value; }
		}

		public DateTime? PASSWORD_EXPIRE_DATE
		{
			get { return this.pASSWORDEXPIREDATE; }
			set { this.pASSWORDEXPIREDATE = value; }
		}

		public string SIGNATURE_VERIFIED_IND
		{
			get { return this.sIGNATUREVERIFIEDIND; }
			set { this.sIGNATUREVERIFIEDIND = value; }
		}

		public string TELEPHONE_NUMBER
		{
			get { return this.tELEPHONENUMBER; }
			set { this.tELEPHONENUMBER = value; }
		}

		public DateTime UPDATED
		{
			get { return this.uPDATED; }
			set { this.uPDATED = value; }
		}

		public string UPDATEDBY
		{
			get { return this.uPDATEDBY; }
			set { this.uPDATEDBY = value; }
		}

		public Int32 USER_ID
		{
			get { return this.uSERID; }
			set { this.uSERID = value; }
		}

		public string USERNAME
		{
			get { return this.uSERNAME; }
			set { this.uSERNAME = value; }
		}

        public bool? RECEIVE_EMAIL
        {
            get { return this.rECEIVEEMAIL; }
            set { this.rECEIVEEMAIL = value; }
        }

		#endregion

		#region Methods
		#endregion
	}
}
