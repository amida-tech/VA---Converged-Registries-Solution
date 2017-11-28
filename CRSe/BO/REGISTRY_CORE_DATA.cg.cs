using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class REGISTRY_CORE_DATA
	{
		#region Fields

		private string cOMMENT;
		private Int32 cOREDATAID;
		private Int32 cORETYPEID;
		private DateTime cREATED;
		private string cREATEDBY;
		private Int32 sTDREGISTRYID;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private string vALUE;
        private Boolean sELECTEDFLAG;

		#endregion

		#region Constructors

		public REGISTRY_CORE_DATA()
		{
		}

		#endregion

		#region Properties

		public string COMMENT
		{
			get { return this.cOMMENT; }
			set { this.cOMMENT = value; }
		}

		public Int32 CORE_DATA_ID
		{
			get { return this.cOREDATAID; }
			set { this.cOREDATAID = value; }
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

		public string VALUE
		{
			get { return this.vALUE; }
			set { this.vALUE = value; }
		}

        [DataMember]
        public Boolean SELECTED_FLAG
        {
            get { return this.sELECTEDFLAG; }
            set { this.sELECTEDFLAG = value; }
        }

		#endregion

		#region Methods
		#endregion
	}
}
