using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
    [Serializable, DataContract]
	public partial class REGISTRY_COHORT_DATA
	{
		#region Fields

		private string cOMMENT;
		private DateTime cREATED;
		private string cREATEDBY;
		private Int32 iD;
		private Int32 sTDREGISTRYCOHORTTYPEID;
		private Int32 sTDREGISTRYID;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private string vALUE;
        private Boolean sELECTEDFLAG;

		#endregion

		#region Constructors

		public REGISTRY_COHORT_DATA()
		{
		}

		#endregion

		#region Properties

        [DataMember]
		public string COMMENT
		{
			get { return this.cOMMENT; }
			set { this.cOMMENT = value; }
		}

        [DataMember]
		public DateTime CREATED
		{
			get { return this.cREATED; }
			set { this.cREATED = value; }
		}

        [DataMember]
		public string CREATEDBY
		{
			get { return this.cREATEDBY; }
			set { this.cREATEDBY = value; }
		}

        [DataMember]
		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}

        [DataMember]
		public Int32 STD_REGISTRY_COHORT_TYPE_ID
		{
			get { return this.sTDREGISTRYCOHORTTYPEID; }
			set { this.sTDREGISTRYCOHORTTYPEID = value; }
		}

        [DataMember]
		public Int32 STD_REGISTRY_ID
		{
			get { return this.sTDREGISTRYID; }
			set { this.sTDREGISTRYID = value; }
		}

        [DataMember]
		public DateTime UPDATED
		{
			get { return this.uPDATED; }
			set { this.uPDATED = value; }
		}

        [DataMember]
		public string UPDATEDBY
		{
			get { return this.uPDATEDBY; }
			set { this.uPDATEDBY = value; }
		}

        [DataMember]
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
