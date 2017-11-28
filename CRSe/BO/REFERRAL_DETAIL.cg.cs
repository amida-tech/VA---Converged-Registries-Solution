using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class REFERRAL_DETAIL
	{
		#region Fields

		private Int32? admParentKey;
		private string clinic;
		private string cOMMENTTEXT;
		private DateTime cREATED;
		private string cREATEDBY;
		private string curSta3n;
		private string hFVISITID;
		private string iCN;
		private Int32 rEFERRALDETAILID;
		private Int32 rEFERRALID;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private Int32? vISITIEN;

		#endregion

		#region Constructors

		public REFERRAL_DETAIL()
		{
		}

		#endregion

		#region Properties

		public Int32? AdmParent_Key
		{
			get { return this.admParentKey; }
			set { this.admParentKey = value; }
		}

		public string Clinic
		{
			get { return this.clinic; }
			set { this.clinic = value; }
		}

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

		public string CurSta3n
		{
			get { return this.curSta3n; }
			set { this.curSta3n = value; }
		}

		public string HF_VISITID
		{
			get { return this.hFVISITID; }
			set { this.hFVISITID = value; }
		}

		public string ICN
		{
			get { return this.iCN; }
			set { this.iCN = value; }
		}

		public Int32 REFERRAL_DETAIL_ID
		{
			get { return this.rEFERRALDETAILID; }
			set { this.rEFERRALDETAILID = value; }
		}

		public Int32 REFERRAL_ID
		{
			get { return this.rEFERRALID; }
			set { this.rEFERRALID = value; }
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

		public Int32? VISIT_IEN
		{
			get { return this.vISITIEN; }
			set { this.vISITIEN = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
