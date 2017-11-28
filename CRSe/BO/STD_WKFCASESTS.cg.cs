using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_WKFCASESTS
	{
		#region Fields

		private string cODE;
		private DateTime cREATED;
		private string cREATEDBY;
		private string dESCRIPTIONTEXT;
		private Int32 iD;
		private DateTime? iNACTIVEDATE;
		private bool iNACTIVEFLAG;
		private string nAME;
		private Int32 sORTORDER;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_WKFCASESTS()
		{
		}

		#endregion

		#region Properties

		public string CODE
		{
			get { return this.cODE; }
			set { this.cODE = value; }
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

		public string DESCRIPTION_TEXT
		{
			get { return this.dESCRIPTIONTEXT; }
			set { this.dESCRIPTIONTEXT = value; }
		}

		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
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

		public string NAME
		{
			get { return this.nAME; }
			set { this.nAME = value; }
		}

		public Int32 SORT_ORDER
		{
			get { return this.sORTORDER; }
			set { this.sORTORDER = value; }
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
