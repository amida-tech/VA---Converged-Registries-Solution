using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_STATE
	{
		#region Fields

		private Int32 cOUNTRYID;
		private DateTime? cREATED;
		private string cREATEDBY;
		private string fIPSCODE;
		private Int32 iD;
		private string nAME;
		private string pOSTALNAME;
		private DateTime? uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_STATE()
		{
		}

		#endregion

		#region Properties

		public Int32 COUNTRY_ID
		{
			get { return this.cOUNTRYID; }
			set { this.cOUNTRYID = value; }
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

		public string FIPSCODE
		{
			get { return this.fIPSCODE; }
			set { this.fIPSCODE = value; }
		}

		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}

		public string NAME
		{
			get { return this.nAME; }
			set { this.nAME = value; }
		}

		public string POSTALNAME
		{
			get { return this.pOSTALNAME; }
			set { this.pOSTALNAME = value; }
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
