using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class SURVEY_NOTES
	{
		#region Fields

		private string aUTHORFIRSTNAME;
		private string aUTHORLASTNAME;
		private string aUTHORMIDDLENAME;
		private string aUTHORTITLE;
		private DateTime cREATED;
		private string cREATEDBY;
		private DateTime? eNTRYDATE;
		private DateTime? nOTEDATE;
		private Int32 nOTEID;
		private string nOTESTEXT;
		private string sTATUS;
		private Int32 sURVEYSID;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public SURVEY_NOTES()
		{
		}

		#endregion

		#region Properties

		public string AUTHOR_FIRST_NAME
		{
			get { return this.aUTHORFIRSTNAME; }
			set { this.aUTHORFIRSTNAME = value; }
		}

		public string AUTHOR_LAST_NAME
		{
			get { return this.aUTHORLASTNAME; }
			set { this.aUTHORLASTNAME = value; }
		}

		public string AUTHOR_MIDDLE_NAME
		{
			get { return this.aUTHORMIDDLENAME; }
			set { this.aUTHORMIDDLENAME = value; }
		}

		public string AUTHOR_TITLE
		{
			get { return this.aUTHORTITLE; }
			set { this.aUTHORTITLE = value; }
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

		public DateTime? ENTRY_DATE
		{
			get { return this.eNTRYDATE; }
			set { this.eNTRYDATE = value; }
		}

		public DateTime? NOTE_DATE
		{
			get { return this.nOTEDATE; }
			set { this.nOTEDATE = value; }
		}

		public Int32 NOTE_ID
		{
			get { return this.nOTEID; }
			set { this.nOTEID = value; }
		}

		public string NOTES_TEXT
		{
			get { return this.nOTESTEXT; }
			set { this.nOTESTEXT = value; }
		}

		public string STATUS
		{
			get { return this.sTATUS; }
			set { this.sTATUS = value; }
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
