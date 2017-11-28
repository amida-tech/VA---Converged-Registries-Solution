using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class ETL_ExtractBatch_Log
	{
		#region Fields

		private string cDWTableViewName;
		private Int32? countFinal;
		private Int32? countStage;
		private string eTLName;
		private string eTLStepName;
		private Int32? eTLBatchID;
		private Int64? extractBatchID;
		private DateTime? extractDateTime;
		private Int32 iD;
		private Int32? registryID;
		private string userName;

		#endregion

		#region Constructors

		public ETL_ExtractBatch_Log()
		{
		}

		#endregion

		#region Properties

		public string CDW_Table_View_Name
		{
			get { return this.cDWTableViewName; }
			set { this.cDWTableViewName = value; }
		}

		public Int32? CountFinal
		{
			get { return this.countFinal; }
			set { this.countFinal = value; }
		}

		public Int32? CountStage
		{
			get { return this.countStage; }
			set { this.countStage = value; }
		}

		public string ETL_Name
		{
			get { return this.eTLName; }
			set { this.eTLName = value; }
		}

		public string ETL_StepName
		{
			get { return this.eTLStepName; }
			set { this.eTLStepName = value; }
		}

		public Int32? ETLBatchID
		{
			get { return this.eTLBatchID; }
			set { this.eTLBatchID = value; }
		}

		public Int64? ExtractBatchID
		{
			get { return this.extractBatchID; }
			set { this.extractBatchID = value; }
		}

		public DateTime? ExtractDateTime
		{
			get { return this.extractDateTime; }
			set { this.extractDateTime = value; }
		}

		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}

		public Int32? Registry_ID
		{
			get { return this.registryID; }
			set { this.registryID = value; }
		}

		public string UserName
		{
			get { return this.userName; }
			set { this.userName = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
