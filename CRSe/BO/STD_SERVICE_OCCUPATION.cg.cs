using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_SERVICE_OCCUPATION
	{
		#region Fields

		private DateTime cREATED;
		private string cREATEDBY;
		private string sERVICEOCCUPATIONCODE;
		private string sERVICETITLE;
		private Int32 sTDSERVICEOCCUPATIONID;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_SERVICE_OCCUPATION()
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

		public string SERVICE_OCCUPATION_CODE
		{
			get { return this.sERVICEOCCUPATIONCODE; }
			set { this.sERVICEOCCUPATIONCODE = value; }
		}

		public string SERVICE_TITLE
		{
			get { return this.sERVICETITLE; }
			set { this.sERVICETITLE = value; }
		}

		public Int32 STD_SERVICE_OCCUPATION_ID
		{
			get { return this.sTDSERVICEOCCUPATIONID; }
			set { this.sTDSERVICEOCCUPATIONID = value; }
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
