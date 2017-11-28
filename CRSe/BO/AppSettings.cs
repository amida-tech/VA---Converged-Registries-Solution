using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
    [Serializable, DataContract]
    public class AppSettings
    {
        #region Fields

        private int sqlCommandTimeout;
        private int logFileSize;
        private int logFileArchive;
        private bool logErrors;
        private bool logInformation;
        private bool logTiming;
        private bool databaseLogEnabled;
        private bool eventLogEnabled;
        private bool fileLogEnabled;
        private string fileLogPath;
        private bool mviEnabled;
        private string mviProcessingCode;
        private string mviCertName;
        private string mviServiceUrl;
        private string reportServerUrl;
        private string reportServicePath;
        private string reportBuilderPath;
        private string etlSchedule;
        private int etlRetryAttempts;
        private int etlTimeBetweenAttempts;
        private string homePageText;

		#endregion

		#region Constructors

        public AppSettings()
		{
		}

		#endregion

		#region Properties

		public int SqlCommandTimeout
        {
            get { return this.sqlCommandTimeout; }
            set { this.sqlCommandTimeout = value; }
        }

        public int LogFileSize
        {
            get { return this.logFileSize; }
            set { this.logFileSize = value; }
        }

        public int LogFileArchive
        {
            get { return this.logFileArchive; }
            set { this.logFileArchive = value; }
        }

        public bool LogErrors
        {
            get { return this.logErrors; }
            set { this.logErrors = value; }
        }

        public bool LogInformation
        {
            get { return this.logInformation; }
            set { this.logInformation = value; }
        }

        public bool LogTiming
        {
            get { return this.logTiming; }
            set { this.logTiming = value; }
        }

        public bool DatabaseLogEnabled
        {
            get { return this.databaseLogEnabled; }
            set { this.databaseLogEnabled = value; }
        }

        public bool EventLogEnabled
        {
            get { return this.eventLogEnabled; }
            set { this.eventLogEnabled = value; }
        }

        public bool FileLogEnabled
        {
            get { return this.fileLogEnabled; }
            set { this.fileLogEnabled = value; }
        }

        public string FileLogPath
        {
            get { return this.fileLogPath; }
            set { this.fileLogPath = value; }
        }

        public bool MviEnabled
        {
            get { return this.mviEnabled; }
            set { this.mviEnabled = value; }
        }

        public string MviProcessingCode
        {
            get { return this.mviProcessingCode; }
            set { this.mviProcessingCode = value; }
        }

        public string MviCertName
        {
            get { return this.mviCertName; }
            set { this.mviCertName = value; }
        }

        public string MviServiceUrl
        {
            get { return this.mviServiceUrl; }
            set { this.mviServiceUrl = value; }
        }

        public string ReportServerUrl
        {
            get { return this.reportServerUrl; }
            set { this.reportServerUrl = value; }
        }

        public string ReportServicePath
        {
            get { return this.reportServicePath; }
            set { this.reportServicePath = value; }
        }

        public string ReportBuilderPath
        {
            get { return this.reportBuilderPath; }
            set { this.reportBuilderPath = value; }
        }

        public string EtlSchedule
        {
            get { return this.etlSchedule; }
            set { this.etlSchedule = value; }
        }

        public int EtlRetryAttempts
        {
            get { return this.etlRetryAttempts; }
            set { this.etlRetryAttempts = value; }
        }

        public int EtlTimeBetweenAttempts
        {
            get { return this.etlTimeBetweenAttempts; }
            set { this.etlTimeBetweenAttempts = value; }
        }

        public string HomePageText
        {
            get { return this.homePageText; }
            set { this.homePageText = value; }
        }

		#endregion

		#region Methods
		#endregion
    }
}
