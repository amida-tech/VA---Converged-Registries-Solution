using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class PATIENT
	{
		#region Fields

		private DateTime? bIRTHDATE;
		private string cELLPHONE;
		private DateTime? cREATED;
		private string cREATEDBY;
		private DateTime? dEATHDATE;
		private string eMAILADDRESS;
		private string fIRSTNAME;
		private string lASTNAME;
		private string mIDDLENAME;
		private bool? oEFOIFIND;
		private Int32 pATIENTID;
		private Int32? pATIENTSID;
		private string pERFERREDADDRESSTYPE;
		private DateTime? uPDATED;
		private string uPDATEDBY;
        private string pATIENTICN;

		#endregion

		#region Constructors

		public PATIENT()
		{
		}

		#endregion

		#region Properties

        [DataMember]
		public DateTime? BIRTH_DATE
		{
			get { return this.bIRTHDATE; }
			set { this.bIRTHDATE = value; }
		}

        [DataMember]
		public string CELL_PHONE
		{
			get { return this.cELLPHONE; }
			set { this.cELLPHONE = value; }
		}

        [DataMember]
		public DateTime? CREATED
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
		public DateTime? DEATH_DATE
		{
			get { return this.dEATHDATE; }
			set { this.dEATHDATE = value; }
		}

        [DataMember]
		public string EMAIL_ADDRESS
		{
			get { return this.eMAILADDRESS; }
			set { this.eMAILADDRESS = value; }
		}

        [DataMember]
		public string FIRST_NAME
		{
			get { return this.fIRSTNAME; }
			set { this.fIRSTNAME = value; }
		}

        [DataMember]
		public string LAST_NAME
		{
			get { return this.lASTNAME; }
			set { this.lASTNAME = value; }
		}

        [DataMember]
		public string MIDDLE_NAME
		{
			get { return this.mIDDLENAME; }
			set { this.mIDDLENAME = value; }
		}

        [DataMember]
		public bool? OEFOIF_IND
		{
			get { return this.oEFOIFIND; }
			set { this.oEFOIFIND = value; }
		}

        [DataMember]
		public Int32 PATIENT_ID
		{
			get { return this.pATIENTID; }
			set { this.pATIENTID = value; }
		}

        [DataMember]
		public Int32? PATIENTSID
		{
			get { return this.pATIENTSID; }
			set { this.pATIENTSID = value; }
		}

        [DataMember]
		public string PERFERRED_ADDRESS_TYPE
		{
			get { return this.pERFERREDADDRESSTYPE; }
			set { this.pERFERREDADDRESSTYPE = value; }
		}

        [DataMember]
		public DateTime? UPDATED
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
        public string PatientICN
        {
            get { return this.pATIENTICN; }
            set { this.pATIENTICN = value; }
        }

		#endregion

		#region Methods
		#endregion
	}
}
