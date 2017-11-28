using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_WEB_PAGES
	{
		#region Fields

        private bool cOREPAGE;
		private DateTime cREATED;
		private string cREATEDBY;
		private string dISPLAYTEXT;
		private DateTime? iNACTIVEDATE;
		private bool iNACTIVEFLAG;
		private string nAME;
		private Int32 pAGEID;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private string uRL;

		#endregion

		#region Constructors

		public STD_WEB_PAGES()
		{
		}

		#endregion

		#region Properties

        public bool CORE_PAGE
        {
            get { return this.cOREPAGE; }
            set { this.cOREPAGE = value; }
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

		public string DISPLAY_TEXT
		{
			get { return this.dISPLAYTEXT; }
			set { this.dISPLAYTEXT = value; }
		}

		public DateTime? INACTIVE_DATE
		{
			get { return this.iNACTIVEDATE; }
			set { this.iNACTIVEDATE = value; }
		}

		public bool INACTIVE_FLAG
		{
			get { return this.iNACTIVEFLAG; }
			set { this.iNACTIVEFLAG = value; }
		}

		public string NAME
		{
			get { return this.nAME; }
			set { this.nAME = value; }
		}

		public Int32 PAGE_ID
		{
			get { return this.pAGEID; }
			set { this.pAGEID = value; }
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

		public string URL
		{
			get { return this.uRL; }
			set { this.uRL = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
