using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_SURVEY_SUB_SECTION
	{
		#region Fields

		private Int32? bRPFORMSUBSECTIONID;
		private string cONCLUSION;
		private DateTime cREATED;
		private string cREATEDBY;
		private string iNTRODUCTION;
		private string mENUITEMNAME;
		private Int32 sTDSURVEYSECTIONID;
		private Int32 sTDSURVEYSUBSECTIONID;
		private Int32 sTDSURVEYTYPEID;
		private string tITLE;
		private string tOOLTIP;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_SURVEY_SUB_SECTION()
		{
		}

		#endregion

		#region Properties

		public Int32? BRP_FORM_SUB_SECTION_ID
		{
			get { return this.bRPFORMSUBSECTIONID; }
			set { this.bRPFORMSUBSECTIONID = value; }
		}

		public string CONCLUSION
		{
			get { return this.cONCLUSION; }
			set { this.cONCLUSION = value; }
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

		public string INTRODUCTION
		{
			get { return this.iNTRODUCTION; }
			set { this.iNTRODUCTION = value; }
		}

		public string MENU_ITEM_NAME
		{
			get { return this.mENUITEMNAME; }
			set { this.mENUITEMNAME = value; }
		}

		public Int32 STD_SURVEY_SECTION_ID
		{
			get { return this.sTDSURVEYSECTIONID; }
			set { this.sTDSURVEYSECTIONID = value; }
		}

		public Int32 STD_SURVEY_SUB_SECTION_ID
		{
			get { return this.sTDSURVEYSUBSECTIONID; }
			set { this.sTDSURVEYSUBSECTIONID = value; }
		}

		public Int32 STD_SURVEY_TYPE_ID
		{
			get { return this.sTDSURVEYTYPEID; }
			set { this.sTDSURVEYTYPEID = value; }
		}

		public string TITLE
		{
			get { return this.tITLE; }
			set { this.tITLE = value; }
		}

		public string TOOL_TIP
		{
			get { return this.tOOLTIP; }
			set { this.tOOLTIP = value; }
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
