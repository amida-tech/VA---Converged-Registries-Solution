using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class DIM_TIME
	{
		#region Fields

		private Int32? calendarYear;
		private string dateName;
		private Int32? dayOfMonth;
		private string dayOfMonthName;
		private Int32? dayOfQuarter;
		private string dayOfQuarterName;
		private Int32? dayOfYear;
		private string dayOfYearName;
		private string ePRPQuarter;
		private DateTime? fiscalDay;
		private string fiscalDayName;
		private Int32? fiscalDayOfMonth;
		private string fiscalDayOfMonthName;
		private Int32? fiscalDayOfQuarter;
		private string fiscalDayOfQuarterName;
		private Int32? fiscalDayOfYear;
		private string fiscalDayOfYearName;
		private DateTime? fiscalMonth;
		private string fiscalMonthName;
		private Int32? fiscalMonthOfQuarter;
		private string fiscalMonthOfQuarterName;
		private Int32? fiscalMonthOfYear;
		private string fiscalMonthOfYearName;
		private DateTime? fiscalQuarter;
		private string fiscalQuarterName;
		private Int32? fiscalQuarterOfYear;
		private string fiscalQuarterOfYearName;
		private DateTime? fiscalYear;
		private string fiscalYearName;
		private Int32? fiscalQuarterID;
		private Int32? fiscalYearInt;
		private string fYQuarter;
		private DateTime? month;
		private Int32? monthID;
		private string monthName;
		private Int32? monthOfQuarter;
		private string monthOfQuarterName;
		private Int32? monthOfYear;
		private string monthOfYearName;
		private string monthShortName;
		private DateTime pKDate;
		private DateTime? quarter;
		private string quarterName;
		private Int32? quarterOfYear;
		private string quarterOfYearName;
		private DateTime? year;
		private string yearName;

		#endregion

		#region Constructors

		public DIM_TIME()
		{
		}

		#endregion

		#region Properties

		public Int32? Calendar_Year
		{
			get { return this.calendarYear; }
			set { this.calendarYear = value; }
		}

		public string Date_Name
		{
			get { return this.dateName; }
			set { this.dateName = value; }
		}

		public Int32? Day_Of_Month
		{
			get { return this.dayOfMonth; }
			set { this.dayOfMonth = value; }
		}

		public string Day_Of_Month_Name
		{
			get { return this.dayOfMonthName; }
			set { this.dayOfMonthName = value; }
		}

		public Int32? Day_Of_Quarter
		{
			get { return this.dayOfQuarter; }
			set { this.dayOfQuarter = value; }
		}

		public string Day_Of_Quarter_Name
		{
			get { return this.dayOfQuarterName; }
			set { this.dayOfQuarterName = value; }
		}

		public Int32? Day_Of_Year
		{
			get { return this.dayOfYear; }
			set { this.dayOfYear = value; }
		}

		public string Day_Of_Year_Name
		{
			get { return this.dayOfYearName; }
			set { this.dayOfYearName = value; }
		}

		public string EPRPQuarter
		{
			get { return this.ePRPQuarter; }
			set { this.ePRPQuarter = value; }
		}

		public DateTime? Fiscal_Day
		{
			get { return this.fiscalDay; }
			set { this.fiscalDay = value; }
		}

		public string Fiscal_Day_Name
		{
			get { return this.fiscalDayName; }
			set { this.fiscalDayName = value; }
		}

		public Int32? Fiscal_Day_Of_Month
		{
			get { return this.fiscalDayOfMonth; }
			set { this.fiscalDayOfMonth = value; }
		}

		public string Fiscal_Day_Of_Month_Name
		{
			get { return this.fiscalDayOfMonthName; }
			set { this.fiscalDayOfMonthName = value; }
		}

		public Int32? Fiscal_Day_Of_Quarter
		{
			get { return this.fiscalDayOfQuarter; }
			set { this.fiscalDayOfQuarter = value; }
		}

		public string Fiscal_Day_Of_Quarter_Name
		{
			get { return this.fiscalDayOfQuarterName; }
			set { this.fiscalDayOfQuarterName = value; }
		}

		public Int32? Fiscal_Day_Of_Year
		{
			get { return this.fiscalDayOfYear; }
			set { this.fiscalDayOfYear = value; }
		}

		public string Fiscal_Day_Of_Year_Name
		{
			get { return this.fiscalDayOfYearName; }
			set { this.fiscalDayOfYearName = value; }
		}

		public DateTime? Fiscal_Month
		{
			get { return this.fiscalMonth; }
			set { this.fiscalMonth = value; }
		}

		public string Fiscal_Month_Name
		{
			get { return this.fiscalMonthName; }
			set { this.fiscalMonthName = value; }
		}

		public Int32? Fiscal_Month_Of_Quarter
		{
			get { return this.fiscalMonthOfQuarter; }
			set { this.fiscalMonthOfQuarter = value; }
		}

		public string Fiscal_Month_Of_Quarter_Name
		{
			get { return this.fiscalMonthOfQuarterName; }
			set { this.fiscalMonthOfQuarterName = value; }
		}

		public Int32? Fiscal_Month_Of_Year
		{
			get { return this.fiscalMonthOfYear; }
			set { this.fiscalMonthOfYear = value; }
		}

		public string Fiscal_Month_Of_Year_Name
		{
			get { return this.fiscalMonthOfYearName; }
			set { this.fiscalMonthOfYearName = value; }
		}

		public DateTime? Fiscal_Quarter
		{
			get { return this.fiscalQuarter; }
			set { this.fiscalQuarter = value; }
		}

		public string Fiscal_Quarter_Name
		{
			get { return this.fiscalQuarterName; }
			set { this.fiscalQuarterName = value; }
		}

		public Int32? Fiscal_Quarter_Of_Year
		{
			get { return this.fiscalQuarterOfYear; }
			set { this.fiscalQuarterOfYear = value; }
		}

		public string Fiscal_Quarter_Of_Year_Name
		{
			get { return this.fiscalQuarterOfYearName; }
			set { this.fiscalQuarterOfYearName = value; }
		}

		public DateTime? Fiscal_Year
		{
			get { return this.fiscalYear; }
			set { this.fiscalYear = value; }
		}

		public string Fiscal_Year_Name
		{
			get { return this.fiscalYearName; }
			set { this.fiscalYearName = value; }
		}

		public Int32? FiscalQuarterID
		{
			get { return this.fiscalQuarterID; }
			set { this.fiscalQuarterID = value; }
		}

		public Int32? FiscalYear
		{
            get { return this.fiscalYearInt; }
            set { this.fiscalYearInt = value; }
		}

		public string FYQuarter
		{
			get { return this.fYQuarter; }
			set { this.fYQuarter = value; }
		}

		public DateTime? Month
		{
			get { return this.month; }
			set { this.month = value; }
		}

		public Int32? Month_ID
		{
			get { return this.monthID; }
			set { this.monthID = value; }
		}

		public string Month_Name
		{
			get { return this.monthName; }
			set { this.monthName = value; }
		}

		public Int32? Month_Of_Quarter
		{
			get { return this.monthOfQuarter; }
			set { this.monthOfQuarter = value; }
		}

		public string Month_Of_Quarter_Name
		{
			get { return this.monthOfQuarterName; }
			set { this.monthOfQuarterName = value; }
		}

		public Int32? Month_Of_Year
		{
			get { return this.monthOfYear; }
			set { this.monthOfYear = value; }
		}

		public string Month_Of_Year_Name
		{
			get { return this.monthOfYearName; }
			set { this.monthOfYearName = value; }
		}

		public string Month_Short_Name
		{
			get { return this.monthShortName; }
			set { this.monthShortName = value; }
		}

		public DateTime PK_Date
		{
			get { return this.pKDate; }
			set { this.pKDate = value; }
		}

		public DateTime? Quarter
		{
			get { return this.quarter; }
			set { this.quarter = value; }
		}

		public string Quarter_Name
		{
			get { return this.quarterName; }
			set { this.quarterName = value; }
		}

		public Int32? Quarter_Of_Year
		{
			get { return this.quarterOfYear; }
			set { this.quarterOfYear = value; }
		}

		public string Quarter_Of_Year_Name
		{
			get { return this.quarterOfYearName; }
			set { this.quarterOfYearName = value; }
		}

		public DateTime? Year
		{
			get { return this.year; }
			set { this.year = value; }
		}

		public string Year_Name
		{
			get { return this.yearName; }
			set { this.yearName = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
