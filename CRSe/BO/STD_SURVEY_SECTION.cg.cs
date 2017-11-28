using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_SURVEY_SECTION
	{
		#region Fields

		private Int32? bRPFORMSECTIONID;
		private string cONCLUSION;
		private DateTime cREATED;
		private string cREATEDBY;
		private string dESCRIPTION;
		private string iNTRODUCTION;
		private Int32? lINENUMBER;
		private string mENUITEMNAME;
		private string nOTES;
		private Int32 sTDSURVEYSECTIONID;
		private Int32 sTDSURVEYTYPEID;
		private string tITLE;
		private string tOOLTIP;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_SURVEY_SECTION()
		{
		}

		#endregion

		#region Properties

		public Int32? BRP_FORM_SECTION_ID
		{
			get { return this.bRPFORMSECTIONID; }
			set { this.bRPFORMSECTIONID = value; }
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

		public string DESCRIPTION
		{
			get { return this.dESCRIPTION; }
			set { this.dESCRIPTION = value; }
		}

		public string INTRODUCTION
		{
			get { return this.iNTRODUCTION; }
			set { this.iNTRODUCTION = value; }
		}

		public Int32? LINE_NUMBER
		{
			get { return this.lINENUMBER; }
			set { this.lINENUMBER = value; }
		}

		public string MENU_ITEM_NAME
		{
			get { return this.mENUITEMNAME; }
			set { this.mENUITEMNAME = value; }
		}

		public string NOTES
		{
			get { return this.nOTES; }
			set { this.nOTES = value; }
		}

		public Int32 STD_SURVEY_SECTION_ID
		{
			get { return this.sTDSURVEYSECTIONID; }
			set { this.sTDSURVEYSECTIONID = value; }
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
