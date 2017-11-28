using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using CRSe.CRS.BLL;
using System.Configuration;
using System.Linq;

namespace CRSe.CRS.DAL
{
	public partial class DBUtils
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties

        public string EtlConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["EtlConnectionString"].ConnectionString; }
        }

        public bool DatabaseLogEnabled
        {
            get
            {
                bool databaseLogEnabled = true; //Default
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["DatabaseLogEnabled"]))
                {
                    bool.TryParse(ConfigurationManager.AppSettings["DatabaseLogEnabled"], out databaseLogEnabled);
                }
                return databaseLogEnabled;
            }
        }

        public bool EventLogEnabled
        {
            get
            {
                bool eventLogEnabled = true; //Default
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EventLogEnabled"]))
                {
                    bool.TryParse(ConfigurationManager.AppSettings["EventLogEnabled"], out eventLogEnabled);
                }
                return eventLogEnabled;
            }
        }

        public bool FileLogEnabled
        {
            get
            {
                bool fileLogEnabled = true; //Default
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["FileLogEnabled"]))
                {
                    bool.TryParse(ConfigurationManager.AppSettings["FileLogEnabled"], out fileLogEnabled);
                }
                return fileLogEnabled;
            }
        }

        public string FileLogPath
        {
            get
            {
                string fileLogPath = "C:\\Temp\\CRSe.log"; //Default
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["FileLogPath"]))
                {
                    string tempPath = ConfigurationManager.AppSettings["FileLogPath"];
                    if (this.ValidFileLogPath(tempPath) && this.FileCheck(tempPath))
                        fileLogPath = tempPath;
                    else
                        if (!this.FileCheck(fileLogPath))
                        {
                            fileLogPath = string.Empty;
                        }
                }

                if (!string.IsNullOrEmpty(fileLogPath) && fileLogPath.Length > 1)
                    if (fileLogPath.ToUpper().Substring(0, 2) != "C:" && fileLogPath.ToUpper().Substring(0, 2) != "D:")
                        fileLogPath = string.Empty;

                return fileLogPath;
            }
        }

        public bool FileLogSize
        {
            get
            {
                bool filelogsize = true;
                string fileLogPath = this.FileLogPath;
                string directory = Path.GetDirectoryName(fileLogPath);
                int LogSize = 0;
                int.TryParse(ConfigurationManager.AppSettings["LogFileSize"], out LogSize);
                int configuredlogarchivedays = 0;
                int.TryParse(ConfigurationManager.AppSettings["LogFileArchive"], out configuredlogarchivedays);
                FileInfo fi = new FileInfo(fileLogPath);
                string[] files = Directory.GetFiles(directory);
                string newfilename = fi.Name + "_" + DateTime.Now.ToString("yyyyMMdd") + ".crsearchive";                  
                long currentlogsize = fi.Length;                
                if ((currentlogsize > LogSize) && currentlogsize > 0)
                {
                    bool check = false;
                    foreach (string file in files)
                    {
                        FileInfo df = new FileInfo(file);
                        if (df.Name == newfilename)
                        {                           
                            {                
                                using (Stream input = File.OpenRead(fileLogPath))
                                using (Stream output = new FileStream(file, FileMode.Append, FileAccess.Write, FileShare.None))                                                                
                                {
                                    input.CopyTo(output);
                                    
                                    input.Close();
                                    output.Close();
                                    fi.Create();
                                }                             
                            }                        
                            check = true;                        
                        }
                    }               
                    if (check == false)
                    {
                        string newFile = Path.Combine(directory, newfilename);
                        FileInfo nf = new FileInfo(newFile);

                        using (Stream input = File.OpenRead(fileLogPath))
                        using (Stream output = new FileStream(newFile, FileMode.Append, FileAccess.Write, FileShare.None))
                        {                                                          
                            input.CopyTo(output);
                            input.Close();
                            output.Close();
                            fi.Create();
                        }       
                    }
                }
                foreach (string file in files)
                {                   
                       FileInfo df = new FileInfo(file);
                       if (df.Exists)
                       {
                           try
                           {
                               if ((df.Name != fi.Name) && df.Name.Contains(".crsearchive"))
                               {
                                   int created_day = (DateTime.Now - df.CreationTime).Days;
                                   if ((created_day > configuredlogarchivedays) && created_day > 0)
                                   {
                                       df.Delete();
                                   }
                               }
                           }
                           catch (Exception)
                           {
                               // this file can't be deleted, do nothing... just skip the file
                           }
                       }
                }                   
                filelogsize = true;
                return filelogsize;
            }
        }

        public string MviServiceUrl
        {
            get
            {
                string mviServiceUrl = string.Empty;

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["MviServiceUrl"]))
                {
                    mviServiceUrl = ConfigurationManager.AppSettings["MviServiceUrl"];
                }

                return mviServiceUrl;
            }
        }

        public string MviProcessingCode
        {
            get
            {
                string mviProcessingCode = string.Empty;

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["MviProcessingCode"]))
                {
                    mviProcessingCode = ConfigurationManager.AppSettings["MviProcessingCode"];
                }

                return mviProcessingCode;
            }
        }

        public string MviCertName
        {
            get
            {
                string mviCertName = string.Empty;

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["MviCertName"]))
                {
                    mviCertName = ConfigurationManager.AppSettings["MviCertName"];
                }

                return mviCertName;
            }
        }

        public string ReportServerUrl
        {
            get
            {
                string reportServerUrl = string.Empty; //Default

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ReportServerUrl"]))
                {
                    reportServerUrl = ConfigurationManager.AppSettings["ReportServerUrl"];
                }

                return reportServerUrl;
            }
        }

        public string ReportServiceUrl
        {
            get
            {
                string reportServiceUrl = this.ReportServerUrl;

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ReportServicePath"]))
                {
                    reportServiceUrl += ConfigurationManager.AppSettings["ReportServicePath"];
                }

                return reportServiceUrl;
            }
        }

        public string ReportBuilderUrl
        {
            get
            {
                string reportBuilderUrl = this.ReportServerUrl;

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ReportBuilderPath"]))
                {
                    reportBuilderUrl += ConfigurationManager.AppSettings["ReportBuilderPath"];
                }

                return (!string.IsNullOrEmpty(reportBuilderUrl) ? reportBuilderUrl : "javascript:");
            }
        }

		#endregion

		#region Methods

        private bool FileCheck(string filePath)
        {
            try
            {
                FileInfo fi = new FileInfo(filePath);
                if (fi != null)
                {
                    if (!fi.Exists)
                    {
                        if (!fi.Directory.Exists)
                            fi.Directory.Create();

                        fi.Create();
                    }
                }

                if (File.Exists(filePath))
                    return true;
            }
            catch (Exception ex)
            {
                //LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));
                throw ex;
            }

            return false;
        }

        public void CheckDataSet(DataSet objDb)
        {
            if (objDb != null && objDb.Tables != null && objDb.Tables.Count > 0)
            {
                if (objDb.Tables[0].Rows != null && objDb.Tables[0].Rows.Count > 0)
                {
                    if (objDb.Tables[0].Columns != null && objDb.Tables[0].Columns.Count > 0)
                    {
                        if (objDb.Tables[0].Columns[0].ColumnName == "ErrorMsg")
                        {
                            throw new Exception(objDb.Tables[0].Rows[0]["ErrorMsg"].ToString());
                        }
                    }
                }
            }
        }

        public void CheckDataReader(SqlDataReader sReader)
        {
            if (sReader != null)
            {
                if (sReader.GetName(0) == "ErrorMsg")
                {
                    string ErrorMsg = (string)this.GetNullableObject(sReader["ErrorMsg"]);
                    if (!string.IsNullOrEmpty(ErrorMsg))
                    {
                        throw new Exception(ErrorMsg);
                    }
                }
            }
        }

        public bool ValidFileLogPath(string tempPath)
        {
            List<string> blackList = new List<string> { "config", "bginfo", "inetpub", "installanywhere", "netbackup", "program files", "users", "windows" };
            return blackList.Any(s => tempPath.Contains(s));
        }
		#endregion
	}
}
