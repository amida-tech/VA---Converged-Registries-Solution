using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_REGISTRY
	{
		#region Fields

		private string cODE;
		private string cOMMENTS;
		private DateTime cREATED;
		private string cREATEDBY;
		private string dESCRIPTIONTEXT;
		private Int32 iD;
		private DateTime? iNACTIVEDATE;
		private bool iNACTIVEFLAG;
		private string nAME;
		private Int32? rEGISTRYADMINISTRATOR;
		private Int32? rEGISTRYOWNER;
		private Int32? rEGISTRYSUPPORTCONTACT;
		private Int32 sORTORDER;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_REGISTRY()
		{
		}

		#endregion

		#region Properties

        [DataMember]
		public string CODE
		{
			get { return this.cODE; }
			set { this.cODE = value; }
		}

        [DataMember]
		public string COMMENTS
		{
			get { return this.cOMMENTS; }
			set { this.cOMMENTS = value; }
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
		public string DESCRIPTION_TEXT
		{
			get { return this.dESCRIPTIONTEXT; }
			set { this.dESCRIPTIONTEXT = value; }
		}

        [DataMember]
		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}

        [DataMember]
		public DateTime? INACTIVE_DATE
		{
			get { return this.iNACTIVEDATE; }
			set { this.iNACTIVEDATE = value; }
		}

        [DataMember]
		public bool INACTIVE_FLAG
		{
			get { return this.iNACTIVEFLAG; }
			set { this.iNACTIVEFLAG = value; }
		}

        [DataMember]
		public string NAME
		{
			get { return this.nAME; }
			set { this.nAME = value; }
		}

        [DataMember]
		public Int32? REGISTRY_ADMINISTRATOR
		{
			get { return this.rEGISTRYADMINISTRATOR; }
			set { this.rEGISTRYADMINISTRATOR = value; }
		}

        [DataMember]
		public Int32? REGISTRY_OWNER
		{
			get { return this.rEGISTRYOWNER; }
			set { this.rEGISTRYOWNER = value; }
		}

        [DataMember]
		public Int32? REGISTRY_SUPPORT_CONTACT
		{
			get { return this.rEGISTRYSUPPORTCONTACT; }
			set { this.rEGISTRYSUPPORTCONTACT = value; }
		}

        [DataMember]
		public Int32 SORT_ORDER
		{
			get { return this.sORTORDER; }
			set { this.sORTORDER = value; }
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

		#endregion

		#region Methods
		#endregion
	}
}
