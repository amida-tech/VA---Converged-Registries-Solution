using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class WKF_CASE_COMMENTS
	{
		#region Fields

		private string cOMMENTTEXT;
		private DateTime cREATED;
		private string cREATEDBY;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private Int32 wKFCASECOMMENTID;
		private Int32 wKFCASEID;

		#endregion

		#region Constructors

		public WKF_CASE_COMMENTS()
		{
		}

		#endregion

		#region Properties

		public string COMMENT_TEXT
		{
			get { return this.cOMMENTTEXT; }
			set { this.cOMMENTTEXT = value; }
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

		public Int32 WKF_CASE_COMMENT_ID
		{
			get { return this.wKFCASECOMMENTID; }
			set { this.wKFCASECOMMENTID = value; }
		}

		public Int32 WKF_CASE_ID
		{
			get { return this.wKFCASEID; }
			set { this.wKFCASEID = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
