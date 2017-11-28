using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_GUI_CONTROLS
	{
		#region Fields

		private Int32 bASECONTROLTYPE;
		private Int32? bASECONTROLWIDTH;
		private string cATEGORY;
		private DateTime cREATED;
		private string cREATEDBY;
		private Int32? dATAELEMENTWIDTH;
		private Int32? dATATYPEMAXLENGTH;
		private Int32 iD;
		private bool iNCLUDELABEL;
		private string lABELTEXT;
		private string lOOKUPLISTCATEGORY;
		private string lOOKUPLISTCATEGORY2;
		private string lOOKUPLISTCATEGORY3;
		private string nAME;
		private string pANELNAME;
		private bool rEQUIRED;
		private Int32 sORTORDER;
		private Int32 sTDREGISTRYID;
		private string tOOLTIP;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private string uSERCONTROLID;
		private string vALIDATIONERRORMESSAGE;
		private string vALIDATIONGROUP;
		private string vALIDATIONREGULAREXPRESSION;

		#endregion

		#region Constructors

		public STD_GUI_CONTROLS()
		{
		}

		#endregion

		#region Properties

		public Int32 BASE_CONTROL_TYPE
		{
			get { return this.bASECONTROLTYPE; }
			set { this.bASECONTROLTYPE = value; }
		}

		public Int32? BASE_CONTROL_WIDTH
		{
			get { return this.bASECONTROLWIDTH; }
			set { this.bASECONTROLWIDTH = value; }
		}

		public string CATEGORY
		{
			get { return this.cATEGORY; }
			set { this.cATEGORY = value; }
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

		public Int32? DATA_ELEMENT_WIDTH
		{
			get { return this.dATAELEMENTWIDTH; }
			set { this.dATAELEMENTWIDTH = value; }
		}

		public Int32? DATA_TYPE_MAX_LENGTH
		{
			get { return this.dATATYPEMAXLENGTH; }
			set { this.dATATYPEMAXLENGTH = value; }
		}

		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}

		public bool INCLUDE_LABEL
		{
			get { return this.iNCLUDELABEL; }
			set { this.iNCLUDELABEL = value; }
		}

		public string LABEL_TEXT
		{
			get { return this.lABELTEXT; }
			set { this.lABELTEXT = value; }
		}

		public string LOOKUP_LIST_CATEGORY
		{
			get { return this.lOOKUPLISTCATEGORY; }
			set { this.lOOKUPLISTCATEGORY = value; }
		}

		public string LOOKUP_LIST_CATEGORY2
		{
			get { return this.lOOKUPLISTCATEGORY2; }
			set { this.lOOKUPLISTCATEGORY2 = value; }
		}

		public string LOOKUP_LIST_CATEGORY3
		{
			get { return this.lOOKUPLISTCATEGORY3; }
			set { this.lOOKUPLISTCATEGORY3 = value; }
		}

		public string NAME
		{
			get { return this.nAME; }
			set { this.nAME = value; }
		}

		public string PANEL_NAME
		{
			get { return this.pANELNAME; }
			set { this.pANELNAME = value; }
		}

		public bool REQUIRED
		{
			get { return this.rEQUIRED; }
			set { this.rEQUIRED = value; }
		}

		public Int32 SORT_ORDER
		{
			get { return this.sORTORDER; }
			set { this.sORTORDER = value; }
		}

		public Int32 STD_REGISTRY_ID
		{
			get { return this.sTDREGISTRYID; }
			set { this.sTDREGISTRYID = value; }
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

		public string USER_CONTROL_ID
		{
			get { return this.uSERCONTROLID; }
			set { this.uSERCONTROLID = value; }
		}

		public string VALIDATION_ERROR_MESSAGE
		{
			get { return this.vALIDATIONERRORMESSAGE; }
			set { this.vALIDATIONERRORMESSAGE = value; }
		}

		public string VALIDATION_GROUP
		{
			get { return this.vALIDATIONGROUP; }
			set { this.vALIDATIONGROUP = value; }
		}

		public string VALIDATION_REGULAR_EXPRESSION
		{
			get { return this.vALIDATIONREGULAREXPRESSION; }
			set { this.vALIDATIONREGULAREXPRESSION = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
