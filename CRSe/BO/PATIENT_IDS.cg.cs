using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class PATIENT_IDS
	{
		#region Fields

		private DateTime? cREATED;
		private string cREATEDBY;
		private Int32 iD;
		private Int32? patientID;
		private string patientEDIPI;
		private string patientICN;
		private string patientICNCheckSum;
		private string patientIEN;
		private Int32? patientSID;
		private string patientSSN;
		private Int16? sta3n;
		private DateTime? uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public PATIENT_IDS()
		{
		}

		#endregion

		#region Properties

		public DateTime? CREATED
		{
			get { return this.cREATED; }
			set { this.cREATED = value; }
		}

		public string CREATEDBY
		{
			get { return this.cREATEDBY; }
			set { this.cREATEDBY = value; }
		}

		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}

		public Int32? Patient_ID
		{
			get { return this.patientID; }
			set { this.patientID = value; }
		}

		public string PatientEDIPI
		{
			get { return this.patientEDIPI; }
			set { this.patientEDIPI = value; }
		}

		public string PatientICN
		{
			get { return this.patientICN; }
			set { this.patientICN = value; }
		}

		public string PatientICNCheckSum
		{
			get { return this.patientICNCheckSum; }
			set { this.patientICNCheckSum = value; }
		}

		public string PatientIEN
		{
			get { return this.patientIEN; }
			set { this.patientIEN = value; }
		}

		public Int32? PatientSID
		{
			get { return this.patientSID; }
			set { this.patientSID = value; }
		}

		public string PatientSSN
		{
			get { return this.patientSSN; }
			set { this.patientSSN = value; }
		}

		public Int16? Sta3n
		{
			get { return this.sta3n; }
			set { this.sta3n = value; }
		}

		public DateTime? UPDATED
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
