using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class WKF_CASE_ASSIGNMENT
	{
		#region Fields

		private string cASEASSIGNEDBY;
		private string cASEASSIGNEDTO;
		private DateTime? cASEASSIGNMENTDATE;
		private DateTime cREATED;
		private string cREATEDBY;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private Int32 wKFCASEASSIGNMENTID;
		private Int32 wKFCASEID;

		#endregion

		#region Constructors

		public WKF_CASE_ASSIGNMENT()
		{
		}

		#endregion

		#region Properties

		public string CASE_ASSIGNED_BY
		{
			get { return this.cASEASSIGNEDBY; }
			set { this.cASEASSIGNEDBY = value; }
		}

		public string CASE_ASSIGNED_TO
		{
			get { return this.cASEASSIGNEDTO; }
			set { this.cASEASSIGNEDTO = value; }
		}

		public DateTime? CASE_ASSIGNMENT_DATE
		{
			get { return this.cASEASSIGNMENTDATE; }
			set { this.cASEASSIGNMENTDATE = value; }
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

		public Int32 WKF_CASE_ASSIGNMENT_ID
		{
			get { return this.wKFCASEASSIGNMENTID; }
			set { this.wKFCASEASSIGNMENTID = value; }
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
