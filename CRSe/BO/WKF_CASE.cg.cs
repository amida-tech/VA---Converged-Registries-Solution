using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class WKF_CASE
	{
		#region Fields

		private DateTime? cASEDUEDATE;
		private string cASENUMBER;
		private DateTime? cASESTARTDATE;
		private DateTime cREATED;
		private string cREATEDBY;
		private Int32? pARENTCASEID;
		private Int32 pATIENTID;
		private Int32? rEFERRALID;
		private Int32 sTDWKFCASETYPEID;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private Int32 wKFCASEID;
        private Int32 sTDWKFCASESTSID;

		#endregion

		#region Constructors

		public WKF_CASE()
		{
		}

		#endregion

		#region Properties

		public DateTime? CASE_DUE_DATE
		{
			get { return this.cASEDUEDATE; }
			set { this.cASEDUEDATE = value; }
		}

		public string CASE_NUMBER
		{
			get { return this.cASENUMBER; }
			set { this.cASENUMBER = value; }
		}

		public DateTime? CASE_START_DATE
		{
			get { return this.cASESTARTDATE; }
			set { this.cASESTARTDATE = value; }
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

		public Int32? PARENT_CASE_ID
		{
			get { return this.pARENTCASEID; }
			set { this.pARENTCASEID = value; }
		}

		public Int32 PATIENT_ID
		{
			get { return this.pATIENTID; }
			set { this.pATIENTID = value; }
		}

		public Int32? REFERRAL_ID
		{
			get { return this.rEFERRALID; }
			set { this.rEFERRALID = value; }
		}

		public Int32 STD_WKFCASETYPE_ID
		{
			get { return this.sTDWKFCASETYPEID; }
			set { this.sTDWKFCASETYPEID = value; }
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

		public Int32 WKF_CASE_ID
		{
			get { return this.wKFCASEID; }
			set { this.wKFCASEID = value; }
		}

        public Int32 STD_WKFCASESTS_ID
        {
            get { return this.sTDWKFCASESTSID; }
            set { this.sTDWKFCASESTSID = value; }
        }

		#endregion

		#region Methods
		#endregion
	}
}
