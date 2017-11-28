using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_SURVEY_TYPE
	{
		#region Fields

		private string cODE;
		private DateTime cREATED;
		private string cREATEDBY;
		private string dESCRIPTIONTEXT;
		private Int32 iD;
		private bool iNACTIVEFLAG;
		private string nAME;
		private Int32 sTDREGISTRYID;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_SURVEY_TYPE()
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
