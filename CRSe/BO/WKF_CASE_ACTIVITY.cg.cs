using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class WKF_CASE_ACTIVITY
	{
		#region Fields

		private string aDDRESSLINE1;
		private string aDDRESSLINE2;
		private string aDDRESSLINE3;
		private string bESTCALLBACKTIME;
		private string cITY;
		private string cONTACTEMAIL;
		private string cONTACTNAME;
		private string cONTACTPHONE;
		private string cOUNTRY;
		private DateTime cREATED;
		private string cREATEDBY;
		private string iNFOCONVEYEDTEXT;
		private string iNFORECEIVEDTEXT;
		private string pOSTALCODE;
		private string sTATE;
		private Int32 sTDWKFACTIVITYTYPEID;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private Int32 wKFCASEACTIVITYID;
		private Int32 wKFCASEID;
        private Int32 sTDWKFACTIVITYSTSID;

		#endregion

		#region Constructors

		public WKF_CASE_ACTIVITY()
		{
		}

		#endregion

		#region Properties

		public string ADDRESS_LINE1
		{
			get { return this.aDDRESSLINE1; }
			set { this.aDDRESSLINE1 = value; }
		}

		public string ADDRESS_LINE2
		{
			get { return this.aDDRESSLINE2; }
			set { this.aDDRESSLINE2 = value; }
		}

		public string ADDRESS_LINE3
		{
			get { return this.aDDRESSLINE3; }
			set { this.aDDRESSLINE3 = value; }
		}

		public string BEST_CALL_BACK_TIME
		{
			get { return this.bESTCALLBACKTIME; }
			set { this.bESTCALLBACKTIME = value; }
		}

		public string CITY
		{
			get { return this.cITY; }
			set { this.cITY = value; }
		}

		public string CONTACT_EMAIL
		{
			get { return this.cONTACTEMAIL; }
			set { this.cONTACTEMAIL = value; }
		}

		public string CONTACT_NAME
		{
			get { return this.cONTACTNAME; }
			set { this.cONTACTNAME = value; }
		}

		public string CONTACT_PHONE
		{
			get { return this.cONTACTPHONE; }
			set { this.cONTACTPHONE = value; }
		}

		public string COUNTRY
		{
			get { return this.cOUNTRY; }
			set { this.cOUNTRY = value; }
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

		public string INFO_CONVEYED_TEXT
		{
			get { return this.iNFOCONVEYEDTEXT; }
			set { this.iNFOCONVEYEDTEXT = value; }
		}

		public string INFO_RECEIVED_TEXT
		{
			get { return this.iNFORECEIVEDTEXT; }
			set { this.iNFORECEIVEDTEXT = value; }
		}

		public string POSTAL_CODE
		{
			get { return this.pOSTALCODE; }
			set { this.pOSTALCODE = value; }
		}

		public string STATE
		{
			get { return this.sTATE; }
			set { this.sTATE = value; }
		}

		public Int32 STD_WKFACTIVITYTYPE_ID
		{
			get { return this.sTDWKFACTIVITYTYPEID; }
			set { this.sTDWKFACTIVITYTYPEID = value; }
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

		public Int32 WKF_CASE_ACTIVITY_ID
		{
			get { return this.wKFCASEACTIVITYID; }
			set { this.wKFCASEACTIVITYID = value; }
		}

		public Int32 WKF_CASE_ID
		{
			get { return this.wKFCASEID; }
			set { this.wKFCASEID = value; }
		}

        public Int32 STD_WKFACTIVITYSTS_ID
        {
            get { return this.sTDWKFACTIVITYSTSID; }
            set { this.sTDWKFACTIVITYSTSID = value; }
        }

		#endregion

		#region Methods
		#endregion
	}
}
