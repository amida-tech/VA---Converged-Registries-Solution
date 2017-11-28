using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_WKFCASETYPE
	{
		#region Fields

		private bool? aUTOCREATE;
		private string cODE;
		private DateTime cREATED;
		private string cREATEDBY;
		private string dESCRIPTIONTEXT;
		private Int32 iD;
		private DateTime? iNACTIVEDATE;
		private bool iNACTIVEFLAG;
		private string name;
		private Int32 sORTORDER;
		private Int32? sTDREGISTRYID;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_WKFCASETYPE()
		{
		}

		#endregion

		#region Properties

		public bool? AUTO_CREATE
		{
			get { return this.aUTOCREATE; }
			set { this.aUTOCREATE = value; }
		}

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

		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public Int32 SORT_ORDER
		{
			get { return this.sORTORDER; }
			set { this.sORTORDER = value; }
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

		#endregion

		#region Methods
		#endregion
	}
}
