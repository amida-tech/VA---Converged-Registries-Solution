using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class SETTINGS
	{
		#region Fields

		private string cOMMENTS;
		private DateTime cREATED;
		private string cREATEDBY;
		private Int32 cRSSETTINGSID;
		private string dESCRIPTION;
		private string nAME;
		private Int32 sTDREGISTRYID;
		private DateTime? uPDATED;
		private string uPDATEDBY;
		private string vALUE;

		#endregion

		#region Constructors

		public SETTINGS()
		{
		}

		#endregion

		#region Properties

		public string COMMENTS
		{
			get { return this.cOMMENTS; }
			set { this.cOMMENTS = value; }
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

		public Int32 CRS_SETTINGS_ID
		{
			get { return this.cRSSETTINGSID; }
			set { this.cRSSETTINGSID = value; }
		}

		public string DESCRIPTION
		{
			get { return this.dESCRIPTION; }
			set { this.dESCRIPTION = value; }
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

		public string VALUE
		{
			get { return this.vALUE; }
			set { this.vALUE = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
