using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class REFERRAL
	{
		#region Fields

		private string cOMMENTTEXT;
		private DateTime cREATED;
		private string cREATEDBY;
		private string cREATEDSOURCE;
		private bool dUPLICATEFLAG;
		private Int32 pATIENTID;
		private Int32? pROVIDERID;
		private string rEFERRALCLASSTEXT;
		private DateTime? rEFERRALDATE;
		private Int32 rEFERRALID;
		private string rEVIEWBY;
		private DateTime? rEVIEWDATE;
		private Int32 sTDREFERRALSTSID;
		private Int32 sTDREGISTRYID;
		private Int32? sTDREMINDERCLASSID;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private string uPDATEDSOURCE;

		#endregion

		#region Constructors

		public REFERRAL()
		{
		}

		#endregion

		#region Properties

		public string COMMENT_TEXT
		{
			get { return this.cOMMENTTEXT; }
			set { this.cOMMENTTEXT = value; }
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

		public string CREATEDSOURCE
		{
			get { return this.cREATEDSOURCE; }
			set { this.cREATEDSOURCE = value; }
		}

		public bool DUPLICATE_FLAG
		{
			get { return this.dUPLICATEFLAG; }
			set { this.dUPLICATEFLAG = value; }
		}

		public Int32 PATIENT_ID
		{
			get { return this.pATIENTID; }
			set { this.pATIENTID = value; }
		}

		public Int32? PROVIDER_ID
		{
            get { return this.pROVIDERID; }
            set { this.pROVIDERID = value; }
		}

		public string REFERRAL_CLASS_TEXT
		{
			get { return this.rEFERRALCLASSTEXT; }
			set { this.rEFERRALCLASSTEXT = value; }
		}

		public DateTime? REFERRAL_DATE
		{
			get { return this.rEFERRALDATE; }
			set { this.rEFERRALDATE = value; }
		}

		public Int32 REFERRAL_ID
		{
			get { return this.rEFERRALID; }
			set { this.rEFERRALID = value; }
		}

		public string REVIEW_BY
		{
			get { return this.rEVIEWBY; }
			set { this.rEVIEWBY = value; }
		}

		public DateTime? REVIEW_DATE
		{
			get { return this.rEVIEWDATE; }
			set { this.rEVIEWDATE = value; }
		}

		public Int32 STD_REFERRALSTS_ID
		{
			get { return this.sTDREFERRALSTSID; }
			set { this.sTDREFERRALSTSID = value; }
		}

		public Int32 STD_REGISTRY_ID
		{
			get { return this.sTDREGISTRYID; }
			set { this.sTDREGISTRYID = value; }
		}

		public Int32? STD_REMINDERCLASS_ID
		{
			get { return this.sTDREMINDERCLASSID; }
			set { this.sTDREMINDERCLASSID = value; }
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

		public string UPDATEDSOURCE
		{
			get { return this.uPDATEDSOURCE; }
			set { this.uPDATEDSOURCE = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
