using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class INDIVIDUAL
	{
		#region Fields

		private DateTime? bIRTHDATE;
		private DateTime? cREATED;
		private string cREATEDBY;
		private DateTime? dEATHDATE;
		private string fIRSTNAME;
		private Int32 iNDID;
		private string lASTNAME;
		private string mIDDLENAME;
		private Int32? pATIENTID;
		private string pREFIX;
		private string sUFFIX;
		private string tITLE;
		private DateTime? uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public INDIVIDUAL()
		{
		}

		#endregion

		#region Properties

		public DateTime? BIRTH_DATE
		{
			get { return this.bIRTHDATE; }
			set { this.bIRTHDATE = value; }
		}

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

		public DateTime? DEATH_DATE
		{
			get { return this.dEATHDATE; }
			set { this.dEATHDATE = value; }
		}

		public string FIRST_NAME
		{
			get { return this.fIRSTNAME; }
			set { this.fIRSTNAME = value; }
		}

		public Int32 IND_ID
		{
			get { return this.iNDID; }
			set { this.iNDID = value; }
		}

		public string LAST_NAME
		{
			get { return this.lASTNAME; }
			set { this.lASTNAME = value; }
		}

		public string MIDDLE_NAME
		{
			get { return this.mIDDLENAME; }
			set { this.mIDDLENAME = value; }
		}

		public Int32? PATIENT_ID
		{
			get { return this.pATIENTID; }
			set { this.pATIENTID = value; }
		}

		public string PREFIX
		{
			get { return this.pREFIX; }
			set { this.pREFIX = value; }
		}

		public string SUFFIX
		{
			get { return this.sUFFIX; }
			set { this.sUFFIX = value; }
		}

		public string TITLE
		{
			get { return this.tITLE; }
			set { this.tITLE = value; }
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
