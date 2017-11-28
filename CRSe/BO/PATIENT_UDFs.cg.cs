using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class PATIENT_UDFs
	{
		#region Fields

		private DateTime cREATED;
		private string cREATEDBY;
		private Int32 iD;
		private Int32 pATIENTID;
		private Int32 sTDREGUDFsID;
		private string uDFValue;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public PATIENT_UDFs()
		{
		}

		#endregion

		#region Properties

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

		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}

		public Int32 PATIENT_ID
		{
			get { return this.pATIENTID; }
			set { this.pATIENTID = value; }
		}

		public Int32 STD_REG_UDFs_ID
		{
			get { return this.sTDREGUDFsID; }
			set { this.sTDREGUDFsID = value; }
		}

		public string UDF_Value
		{
			get { return this.uDFValue; }
			set { this.uDFValue = value; }
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
