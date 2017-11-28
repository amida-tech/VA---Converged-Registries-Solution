using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class SURVEY_RESULTS
	{
		#region Fields

		private DateTime cREATED;
		private string cREATEDBY;
		private string rESULTTEXT;
		private bool sELECTEDFLAG;
		private Int32? sTDQUESTIONCHOICEID;
		private Int32 sTDQUESTIONID;
		private Int32 sURVEYRESULTID;
		private Int32 sURVEYSID;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public SURVEY_RESULTS()
		{
		}

		#endregion

		#region Properties

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

		public string RESULT_TEXT
		{
			get { return this.rESULTTEXT; }
			set { this.rESULTTEXT = value; }
		}

		public bool SELECTED_FLAG
		{
			get { return this.sELECTEDFLAG; }
			set { this.sELECTEDFLAG = value; }
		}

		public Int32? STD_QUESTION_CHOICE_ID
		{
			get { return this.sTDQUESTIONCHOICEID; }
			set { this.sTDQUESTIONCHOICEID = value; }
		}

		public Int32 STD_QUESTION_ID
		{
			get { return this.sTDQUESTIONID; }
			set { this.sTDQUESTIONID = value; }
		}

		public Int32 SURVEY_RESULT_ID
		{
			get { return this.sURVEYRESULTID; }
			set { this.sURVEYRESULTID = value; }
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
