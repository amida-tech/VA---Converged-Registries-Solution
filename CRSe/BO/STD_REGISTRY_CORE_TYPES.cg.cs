using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_REGISTRY_CORE_TYPES
	{
		#region Fields

		private string cODE;
		private string cOMMENT;
		private Int32 cORETYPEID;
		private DateTime cREATED;
		private string cREATEDBY;
		private string dESCRIPTIONTEXT;
		private string nAME;
		private string tABLENAME;
		private Int32? tYPEPK;
		private DateTime uPDATED;
		private string uPDATEDBY;
        private bool dEFAULTFLAG;

		#endregion

		#region Constructors

		public STD_REGISTRY_CORE_TYPES()
		{
		}

		#endregion

		#region Properties

		public string CODE
		{
			get { return this.cODE; }
			set { this.cODE = value; }
		}

		public string COMMENT
		{
			get { return this.cOMMENT; }
			set { this.cOMMENT = value; }
		}

		public Int32 CORE_TYPE_ID
		{
			get { return this.cORETYPEID; }
			set { this.cORETYPEID = value; }
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

		public string NAME
		{
			get { return this.nAME; }
			set { this.nAME = value; }
		}

		public string TABLE_NAME
		{
			get { return this.tABLENAME; }
			set { this.tABLENAME = value; }
		}

		public Int32? TYPE_PK
		{
			get { return this.tYPEPK; }
			set { this.tYPEPK = value; }
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

        public bool DEFAULT_FLAG
        {
            get { return this.dEFAULTFLAG; }
            set { this.dEFAULTFLAG = value; }
        }

		#endregion

		#region Methods
		#endregion
	}
}
