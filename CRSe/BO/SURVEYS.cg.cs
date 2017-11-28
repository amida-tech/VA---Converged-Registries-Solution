using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class SURVEYS
	{
		#region Fields

		private string aUTHORDUZ;
		private Int32? aUTHORID;
		private DateTime cREATED;
		private string cREATEDBY;
		private Int32? pATIENTID;
		private string pROVIDERDUZ;
		private Int32? pROVIDERID;
		private Int32 sTDSURVEYTYPEID;
		private DateTime sURVEYDATE;
		private string sURVEYSTATUS;
		private Int32 sURVEYSID;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public SURVEYS()
		{
		}

		#endregion

		#region Properties

		public string AUTHOR_DUZ
		{
			get { return this.aUTHORDUZ; }
			set { this.aUTHORDUZ = value; }
		}

		public Int32? AUTHOR_ID
		{
			get { return this.aUTHORID; }
			set { this.aUTHORID = value; }
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

		public Int32? PATIENT_ID
		{
			get { return this.pATIENTID; }
			set { this.pATIENTID = value; }
		}

		public string PROVIDER_DUZ
		{
			get { return this.pROVIDERDUZ; }
			set { this.pROVIDERDUZ = value; }
		}

		public Int32? PROVIDER_ID
		{
			get { return this.pROVIDERID; }
			set { this.pROVIDERID = value; }
		}

		public Int32 STD_SURVEY_TYPE_ID
		{
			get { return this.sTDSURVEYTYPEID; }
			set { this.sTDSURVEYTYPEID = value; }
		}

		public DateTime SURVEY_DATE
		{
			get { return this.sURVEYDATE; }
			set { this.sURVEYDATE = value; }
		}

		public string SURVEY_STATUS
		{
			get { return this.sURVEYSTATUS; }
			set { this.sURVEYSTATUS = value; }
		}

		public Int32 SURVEYS_ID
		{
			get { return this.sURVEYSID; }
			set { this.sURVEYSID = value; }
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

		#endregion

		#region Methods
		#endregion
	}
}
