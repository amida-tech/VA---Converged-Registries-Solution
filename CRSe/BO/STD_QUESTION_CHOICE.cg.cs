using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_QUESTION_CHOICE
	{
		#region Fields

		private string cHOICENAME;
		private Int32? cHOICESORTORDER;
		private string cHOICETEXT;
		private DateTime cREATED;
		private string cREATEDBY;
		private DateTime? iNACTIVEDATE;
		private bool iNACTIVEFLAG;
		private Int32 sTDQUESTIONCHOICEID;
		private Int32 sTDQUESTIONID;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_QUESTION_CHOICE()
		{
		}

		#endregion

		#region Properties

		public string CHOICE_NAME
		{
			get { return this.cHOICENAME; }
			set { this.cHOICENAME = value; }
		}

		public Int32? CHOICE_SORT_ORDER
		{
			get { return this.cHOICESORTORDER; }
			set { this.cHOICESORTORDER = value; }
		}

		public string CHOICE_TEXT
		{
			get { return this.cHOICETEXT; }
			set { this.cHOICETEXT = value; }
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

		public Int32 STD_QUESTION_CHOICE_ID
		{
			get { return this.sTDQUESTIONCHOICEID; }
			set { this.sTDQUESTIONCHOICEID = value; }
		}

		public Int32 STD_QUESTION_ID
		{
			get { return this.sTDQUESTIONID; }
			set { this.sTDQUESTIONID = value; }
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
