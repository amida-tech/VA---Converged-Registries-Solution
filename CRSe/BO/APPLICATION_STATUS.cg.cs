using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class APPLICATION_STATUS
	{
		#region Fields

		private string cOMMENT;
		private DateTime cREATED;
		private string cREATEDBY;
		private string mESSAGE;
		private Int32 sTATUSID;
		private Int32 sTDREGISTRYID;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public APPLICATION_STATUS()
		{
		}

		#endregion

		#region Properties

		public string COMMENT
		{
			get { return this.cOMMENT; }
            set { this.cOMMENT = value; }
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

		public string MESSAGE
		{
			get { return this.mESSAGE; }
			set { this.mESSAGE = value; }
		}

		public Int32 STATUS_ID
		{
			get { return this.sTATUSID; }
			set { this.sTATUSID = value; }
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
