using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_INSTITUTION
	{
		#region Fields

		private DateTime? aCTIVATIONDATE;
		private Int32? aGENCYID;
		private DateTime? cREATED;
		private string cREATEDBY;
		private DateTime? dEACTIVATIONDATE;
		private Int32 iD;
		private string iSACTIVE;
		private string mAILINGADDRESSLINE1;
		private string mAILINGADDRESSLINE2;
		private string mAILINGADDRESSLINE3;
		private string mAILINGCITY;
		private Int32? mAILINGCOUNTRYID;
		private Int32? mAILINGCOUNTYID;
		private string mAILINGPOSTALCODE;
		private Int32? mAILINGSTATEID;
		private string mFNZEGRECIPIENT;
		private string nAME;
		private Int32? pARENTID;
		private Int32? rEALIGNEDFROMID;
		private Int32? rEALIGNEDTOID;
		private string sTATIONNUMBER;
		private Int32 sTDFACILITYTYPEID;
		private string sTREETADDRESSLINE1;
		private string sTREETADDRESSLINE2;
		private string sTREETADDRESSLINE3;
		private string sTREETCITY;
		private Int32? sTREETCOUNTRYID;
		private Int32? sTREETCOUNTYID;
		private string sTREETPOSTALCODE;
		private Int32? sTREETSTATEID;
		private DateTime? uPDATED;
		private string uPDATEDBY;
		private Int32? vISNID;
		private string vISTANAME;

		#endregion

		#region Constructors

		public STD_INSTITUTION()
		{
		}

		#endregion

		#region Properties

		public DateTime? ACTIVATIONDATE
		{
			get { return this.aCTIVATIONDATE; }
			set { this.aCTIVATIONDATE = value; }
		}

		public Int32? AGENCY_ID
		{
			get { return this.aGENCYID; }
			set { this.aGENCYID = value; }
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

		public DateTime? DEACTIVATIONDATE
		{
			get { return this.dEACTIVATIONDATE; }
			set { this.dEACTIVATIONDATE = value; }
		}

		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}

		public string IS_ACTIVE
		{
			get { return this.iSACTIVE; }
			set { this.iSACTIVE = value; }
		}

		public string MAILINGADDRESSLINE1
		{
			get { return this.mAILINGADDRESSLINE1; }
			set { this.mAILINGADDRESSLINE1 = value; }
		}

		public string MAILINGADDRESSLINE2
		{
			get { return this.mAILINGADDRESSLINE2; }
			set { this.mAILINGADDRESSLINE2 = value; }
		}

		public string MAILINGADDRESSLINE3
		{
			get { return this.mAILINGADDRESSLINE3; }
			set { this.mAILINGADDRESSLINE3 = value; }
		}

		public string MAILINGCITY
		{
			get { return this.mAILINGCITY; }
			set { this.mAILINGCITY = value; }
		}

		public Int32? MAILINGCOUNTRY_ID
		{
			get { return this.mAILINGCOUNTRYID; }
			set { this.mAILINGCOUNTRYID = value; }
		}

		public Int32? MAILINGCOUNTY_ID
		{
			get { return this.mAILINGCOUNTYID; }
			set { this.mAILINGCOUNTYID = value; }
		}

		public string MAILINGPOSTALCODE
		{
			get { return this.mAILINGPOSTALCODE; }
			set { this.mAILINGPOSTALCODE = value; }
		}

		public Int32? MAILINGSTATE_ID
		{
			get { return this.mAILINGSTATEID; }
			set { this.mAILINGSTATEID = value; }
		}

		public string MFN_ZEG_RECIPIENT
		{
			get { return this.mFNZEGRECIPIENT; }
			set { this.mFNZEGRECIPIENT = value; }
		}

		public string NAME
		{
			get { return this.nAME; }
			set { this.nAME = value; }
		}

		public Int32? PARENT_ID
		{
			get { return this.pARENTID; }
			set { this.pARENTID = value; }
		}

		public Int32? REALIGNEDFROM_ID
		{
			get { return this.rEALIGNEDFROMID; }
			set { this.rEALIGNEDFROMID = value; }
		}

		public Int32? REALIGNEDTO_ID
		{
			get { return this.rEALIGNEDTOID; }
			set { this.rEALIGNEDTOID = value; }
		}

		public string STATIONNUMBER
		{
			get { return this.sTATIONNUMBER; }
			set { this.sTATIONNUMBER = value; }
		}

		public Int32 STD_FACILITYTYPE_ID
		{
			get { return this.sTDFACILITYTYPEID; }
			set { this.sTDFACILITYTYPEID = value; }
		}

		public string STREETADDRESSLINE1
		{
			get { return this.sTREETADDRESSLINE1; }
			set { this.sTREETADDRESSLINE1 = value; }
		}

		public string STREETADDRESSLINE2
		{
			get { return this.sTREETADDRESSLINE2; }
			set { this.sTREETADDRESSLINE2 = value; }
		}

		public string STREETADDRESSLINE3
		{
			get { return this.sTREETADDRESSLINE3; }
			set { this.sTREETADDRESSLINE3 = value; }
		}

		public string STREETCITY
		{
			get { return this.sTREETCITY; }
			set { this.sTREETCITY = value; }
		}

		public Int32? STREETCOUNTRY_ID
		{
			get { return this.sTREETCOUNTRYID; }
			set { this.sTREETCOUNTRYID = value; }
		}

		public Int32? STREETCOUNTY_ID
		{
			get { return this.sTREETCOUNTYID; }
			set { this.sTREETCOUNTYID = value; }
		}

		public string STREETPOSTALCODE
		{
			get { return this.sTREETPOSTALCODE; }
			set { this.sTREETPOSTALCODE = value; }
		}

		public Int32? STREETSTATE_ID
		{
			get { return this.sTREETSTATEID; }
			set { this.sTREETSTATEID = value; }
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

		public Int32? VISN_ID
		{
			get { return this.vISNID; }
			set { this.vISNID = value; }
		}

		public string VISTANAME
		{
			get { return this.vISTANAME; }
			set { this.vISTANAME = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
