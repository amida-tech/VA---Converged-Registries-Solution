using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class STD_MENU_ITEMS
	{
		#region Fields

		private DateTime cREATED;
		private string cREATEDBY;
		private DateTime? iNACTIVEDATE;
		private bool iNACTIVEFLAG;
		private Int32 mENUID;
		private Int32 mENUPAGEID;
		private Int32 pAGEID;
        private Int32 sORTORDER;
		private Int32 sTDREGISTRYID;
		private Int32 sTDROLEID;
		private DateTime uPDATED;
		private string uPDATEDBY;

		#endregion

		#region Constructors

		public STD_MENU_ITEMS()
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

		public Int32 MENU_ID
		{
			get { return this.mENUID; }
			set { this.mENUID = value; }
		}

		public Int32 MENU_PAGE_ID
		{
			get { return this.mENUPAGEID; }
			set { this.mENUPAGEID = value; }
		}

		public Int32 PAGE_ID
		{
			get { return this.pAGEID; }
			set { this.pAGEID = value; }
		}

        public Int32 SORT_ORDER
        {
            get { return this.sORTORDER; }
            set { this.sORTORDER = value; }
        }

		public Int32 STD_REGISTRY_ID
		{
			get { return this.sTDREGISTRYID; }
			set { this.sTDREGISTRYID = value; }
		}

		public Int32 STD_ROLE_ID
		{
			get { return this.sTDROLEID; }
			set { this.sTDROLEID = value; }
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
