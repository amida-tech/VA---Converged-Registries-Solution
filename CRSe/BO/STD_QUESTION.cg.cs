using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_QUESTION
	{
		#region Fields

		private DateTime cREATED;
		private string cREATEDBY;
		private Int32 iD;
		private DateTime? iNACTIVEDATE;
		private bool iNACTIVEFLAG;
		private string qUESTIONNUMBER;
		private string qUESTIONTEXT;
		private Int32? sORTORDER;
		private Int32 sTDSURVEYTYPEID;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_QUESTION()
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

		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
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

		public string QUESTION_NUMBER
		{
			get { return this.qUESTIONNUMBER; }
			set { this.qUESTIONNUMBER = value; }
		}

		public string QUESTION_TEXT
		{
			get { return this.qUESTIONTEXT; }
			set { this.qUESTIONTEXT = value; }
		}

		public Int32? SORT_ORDER
		{
			get { return this.sORTORDER; }
			set { this.sORTORDER = value; }
		}

		public Int32 STD_SURVEY_TYPE_ID
		{
			get { return this.sTDSURVEYTYPEID; }
			set { this.sTDSURVEYTYPEID = value; }
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
