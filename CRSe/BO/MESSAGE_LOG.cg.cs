using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class MESSAGE_LOG
	{
		#region Fields

		private Int32 cALLID;
		private string cOMMENTS;
		private DateTime cREATED;
		private string cREATEDBY;
		private Int32? eRRORLEVEL;
		private Int32 mESSAGESTATUSID;
		private Int32 mESSAGETYPEID;
		private string pARAMETERS;
		private string rETURNEDDATA;
		private DateTime sENT;
		private Int32 sTDREGISTRYID;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public MESSAGE_LOG()
		{
		}

		#endregion

		#region Properties

		public Int32 CALL_ID
		{
			get { return this.cALLID; }
			set { this.cALLID = value; }
		}

		public string COMMENTS
		{
			get { return this.cOMMENTS; }
			set { this.cOMMENTS = value; }
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

		public Int32? ERROR_LEVEL
		{
			get { return this.eRRORLEVEL; }
			set { this.eRRORLEVEL = value; }
		}

		public Int32 MESSAGE_STATUS_ID
		{
			get { return this.mESSAGESTATUSID; }
			set { this.mESSAGESTATUSID = value; }
		}

		public Int32 MESSAGE_TYPE_ID
		{
			get { return this.mESSAGETYPEID; }
			set { this.mESSAGETYPEID = value; }
		}

		public string PARAMETERS
		{
			get { return this.pARAMETERS; }
			set { this.pARAMETERS = value; }
		}

		public string RETURNED_DATA
		{
			get { return this.rETURNEDDATA; }
			set { this.rETURNEDDATA = value; }
		}

		public DateTime SENT
		{
			get { return this.sENT; }
			set { this.sENT = value; }
		}

		public Int32 STD_REGISTRY_ID
		{
			get { return this.sTDREGISTRYID; }
			set { this.sTDREGISTRYID = value; }
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
