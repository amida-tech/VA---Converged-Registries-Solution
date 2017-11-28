using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class USER_ROLES
	{
		#region Fields

		private DateTime cREATED;
		private string cREATEDBY;
		private DateTime? iNACTIVEDATE;
		private bool iNACTIVEFLAG;
		private Int32 sTDROLEID;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private Int32 uSERID;
		private Int32 uSERROLEID;

		#endregion

		#region Constructors

		public USER_ROLES()
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

		public DateTime? INACTIVE_DATE
		{
			get { return this.iNACTIVEDATE; }
			set { this.iNACTIVEDATE = value; }
		}

		public bool INACTIVE_FLAG
		{
			get { return this.iNACTIVEFLAG; }
			set { this.iNACTIVEFLAG = value; }
		}

		public Int32 STD_ROLE_ID
		{
			get { return this.sTDROLEID; }
			set { this.sTDROLEID = value; }
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

		public Int32 USER_ROLE_ID
		{
			get { return this.uSERROLEID; }
			set { this.uSERROLEID = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
