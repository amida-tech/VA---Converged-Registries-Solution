using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_COUNTRY
	{
		#region Fields

		private string aLPHA3CODE;
		private DateTime? cREATED;
		private string cREATEDBY;
		private string fIPSCODE;
		private Int32 iD;
		private bool? inactiveFlag;
		private string nUMERICCODE;
		private string pOSTALNAME;
		private string sHORTNAME;
		private DateTime? uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_COUNTRY()
		{
		}

		#endregion

		#region Properties

		public string ALPHA3CODE
		{
			get { return this.aLPHA3CODE; }
			set { this.aLPHA3CODE = value; }
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

		public string FIPSCODE
		{
			get { return this.fIPSCODE; }
			set { this.fIPSCODE = value; }
		}

		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}

		public bool? Inactive_Flag
		{
			get { return this.inactiveFlag; }
			set { this.inactiveFlag = value; }
		}

		public string NUMERICCODE
		{
			get { return this.nUMERICCODE; }
			set { this.nUMERICCODE = value; }
		}

		public string POSTALNAME
		{
			get { return this.pOSTALNAME; }
			set { this.pOSTALNAME = value; }
		}

		public string SHORTNAME
		{
			get { return this.sHORTNAME; }
			set { this.sHORTNAME = value; }
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
