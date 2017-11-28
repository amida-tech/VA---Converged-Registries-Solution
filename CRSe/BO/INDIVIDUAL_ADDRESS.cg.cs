using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class INDIVIDUAL_ADDRESS
	{
		#region Fields

		private bool? aCCEPTSTXTMSG;
		private Int32 aDDRESSID;
		private string aLTEMAIL;
		private string cELLPHONE;
		private string cITY;
		private string cOMMENTS;
		private DateTime? cREATED;
		private string cREATEDBY;
		private string eMAIL;
		private string fAX;
		private Int32 iNDID;
		private string pHONE;
		private string pOSTALCODE;
		private Int32 sTDADDRESSTYPEID;
		private Int32? sTDCOUNTRYID;
		private Int32? sTDSTATEID;
		private string sTREET1;
		private string sTREET2;
		private string sTREET3;
		private DateTime? uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public INDIVIDUAL_ADDRESS()
		{
		}

		#endregion

		#region Properties

		public bool? ACCEPTS_TXT_MSG
		{
			get { return this.aCCEPTSTXTMSG; }
			set { this.aCCEPTSTXTMSG = value; }
		}

		public Int32 ADDRESS_ID
		{
			get { return this.aDDRESSID; }
			set { this.aDDRESSID = value; }
		}

		public string ALT_EMAIL
		{
			get { return this.aLTEMAIL; }
			set { this.aLTEMAIL = value; }
		}

		public string CELL_PHONE
		{
			get { return this.cELLPHONE; }
			set { this.cELLPHONE = value; }
		}

		public string CITY
		{
			get { return this.cITY; }
			set { this.cITY = value; }
		}

		public string COMMENTS
		{
			get { return this.cOMMENTS; }
			set { this.cOMMENTS = value; }
		}

		public DateTime? CREATED
		{
			get { return this.cREATED; }
			set { this.cREATED = value; }
		}

		public string CREATEDBY
		{
			get { return this.cREATEDBY; }
			set { this.cREATEDBY = value; }
		}

		public string EMAIL
		{
			get { return this.eMAIL; }
			set { this.eMAIL = value; }
		}

		public string FAX
		{
			get { return this.fAX; }
			set { this.fAX = value; }
		}

		public Int32 IND_ID
		{
			get { return this.iNDID; }
			set { this.iNDID = value; }
		}

		public string PHONE
		{
			get { return this.pHONE; }
			set { this.pHONE = value; }
		}

		public string POSTAL_CODE
		{
			get { return this.pOSTALCODE; }
			set { this.pOSTALCODE = value; }
		}

		public Int32 STD_ADDRESSTYPE_ID
		{
			get { return this.sTDADDRESSTYPEID; }
			set { this.sTDADDRESSTYPEID = value; }
		}

		public Int32? STD_COUNTRY_ID
		{
			get { return this.sTDCOUNTRYID; }
			set { this.sTDCOUNTRYID = value; }
		}

		public Int32? STD_STATE_ID
		{
			get { return this.sTDSTATEID; }
			set { this.sTDSTATEID = value; }
		}

		public string STREET1
		{
			get { return this.sTREET1; }
			set { this.sTREET1 = value; }
		}

		public string STREET2
		{
			get { return this.sTREET2; }
			set { this.sTREET2 = value; }
		}

		public string STREET3
		{
			get { return this.sTREET3; }
			set { this.sTREET3 = value; }
		}

		public DateTime? UPDATED
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
