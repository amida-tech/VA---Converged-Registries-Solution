using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class ROLE_PERMISSIONS
	{
		#region Fields

		private DateTime cREATED;
		private string cREATEDBY;
		private bool? dELETE;
		private bool? iNSERT;
		private Int32 rOLEPERMISSIONID;
		private Int32 sTDGUICONTROLSID;
		private Int32 sTDROLEID;
		private bool? uPDATE;
		private DateTime uPDATED;
		private string uPDATEDBY;
		private bool? vIEW;

		#endregion

		#region Constructors

		public ROLE_PERMISSIONS()
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

		public bool? DELETE
		{
			get { return this.dELETE; }
			set { this.dELETE = value; }
		}

		public bool? INSERT
		{
			get { return this.iNSERT; }
			set { this.iNSERT = value; }
		}

		public Int32 ROLE_PERMISSION_ID
		{
			get { return this.rOLEPERMISSIONID; }
			set { this.rOLEPERMISSIONID = value; }
		}

		public Int32 STD_GUI_CONTROLS_ID
		{
			get { return this.sTDGUICONTROLSID; }
			set { this.sTDGUICONTROLSID = value; }
		}

		public Int32 STD_ROLE_ID
		{
			get { return this.sTDROLEID; }
			set { this.sTDROLEID = value; }
		}

		public bool? UPDATE
		{
			get { return this.uPDATE; }
			set { this.uPDATE = value; }
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

		public bool? VIEW
		{
			get { return this.vIEW; }
			set { this.vIEW = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
