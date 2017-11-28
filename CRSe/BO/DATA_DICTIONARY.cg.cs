using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class DATA_DICTIONARY
	{
		#region Fields

		private double? allowsNull;
		private string columnName;
		private string dataType;
		private string description;
		private string objectName;

		#endregion

		#region Constructors

		public DATA_DICTIONARY()
		{
		}

		#endregion

		#region Properties

		public double? AllowsNull
		{
			get { return this.allowsNull; }
			set { this.allowsNull = value; }
		}

		public string ColumnName
		{
			get { return this.columnName; }
			set { this.columnName = value; }
		}

		public string DataType
		{
			get { return this.dataType; }
			set { this.dataType = value; }
		}

		public string Description
		{
			get { return this.description; }
			set { this.description = value; }
		}

		public string ObjectName
		{
			get { return this.objectName; }
			set { this.objectName = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
