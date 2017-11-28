using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class DB_LOG
	{
		#region Fields

		private string cOMMENTS;
		private DateTime cREATED;
		private string cREATEDBY;
		private Int32 cRSDBLOGID;
		private bool iSERROR;
		private string mESSAGE;
		private string pROCESSNAME;
		private Int32 sTDREGISTRYID;

		#endregion

		#region Constructors

		public DB_LOG()
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

		public Int32 CRS_DB_LOG_ID
		{
			get { return this.cRSDBLOGID; }
			set { this.cRSDBLOGID = value; }
		}

		public bool IS_ERROR
		{
			get { return this.iSERROR; }
			set { this.iSERROR = value; }
		}

		public string MESSAGE
		{
			get { return this.mESSAGE; }
			set { this.mESSAGE = value; }
		}

		public string PROCESS_NAME
		{
			get { return this.pROCESSNAME; }
			set { this.pROCESSNAME = value; }
		}

		public Int32 STD_REGISTRY_ID
		{
			get { return this.sTDREGISTRYID; }
			set { this.sTDREGISTRYID = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
