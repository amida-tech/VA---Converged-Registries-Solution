using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class USER_ACTIVITY_LOG
	{
		#region Fields

		private Int32 aCTIVITYLOGID;
		private Int32 aCTIVITYTYPEID;
		private string cOMMENTS;
		private DateTime cREATED;
		private string cREATEDBY;
		private Int32? sTDREGISTRYID;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private Int32 uSERID;

		#endregion

		#region Constructors

		public USER_ACTIVITY_LOG()
		{
		}

		#endregion

		#region Properties

		public Int32 ACTIVITY_LOG_ID
		{
			get { return this.aCTIVITYLOGID; }
			set { this.aCTIVITYLOGID = value; }
		}

		public Int32 ACTIVITY_TYPE_ID
		{
			get { return this.aCTIVITYTYPEID; }
			set { this.aCTIVITYTYPEID = value; }
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

		public Int32? STD_REGISTRY_ID
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

		public Int32 USER_ID
		{
			get { return this.uSERID; }
			set { this.uSERID = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
