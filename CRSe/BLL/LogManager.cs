using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.Diagnostics;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
    public static class LogManager
    {
        //TODO: Config settings should be manageable from the UI
        private static bool DbLogEnabled
        {
            get 
            {
                DBUtils utils = new DBUtils();
                return utils.DatabaseLogEnabled;
            }   
        }

        private static bool EventLogEnabled
        {
            get
            {
                DBUtils utils = new DBUtils();
                return utils.EventLogEnabled;
            }
        }

        private static bool FileLogEnabled
        {
            get
            {
                DBUtils utils = new DBUtils();
                return utils.FileLogEnabled;
            }
        }

        private static string FileLogPath
        {
            get
            {
                DBUtils utils = new DBUtils();
                return utils.FileLogPath;
            }
        }
        private static bool FileLogSize
        {
            get
            {
                DBUtils utils = new DBUtils();
                return utils.FileLogSize;
            }
        }
       
        public static void LogDetails(LogDetails logDetails)
        {
            if (logDetails == null)
            {
                logDetails = new LogDetails();
                logDetails.Message = "An attempt to log details occurred, however LogDetails are NULL";
                logDetails.IsError = true;
                logDetails.ProcessName = String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            logDetails.CreatedTime = DateTime.Now;

            if (string.IsNullOrEmpty(logDetails.Username))
                logDetails.Username = "APPLICATION";

            if (DbLogEnabled)
                LogToDb(logDetails);

            if (EventLogEnabled)
                LogToEventLog(logDetails);

            if (FileLogEnabled)
                LogToFileSystem(logDetails);
        }

        public static void LogTiming(LogDetails logDetails)
        {
            if (logDetails == null)
            {
                logDetails = new LogDetails();
                logDetails.Message = "An attempt to log TIMING occurred, however LogDetails are NULL";
                logDetails.IsError = true;
                logDetails.ProcessName = String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name);
                LogDetails(logDetails);
                return;
            }
            else if (logDetails.StartTime == null)
            {
                logDetails.Message = "An attempt to log TIMING occurred, however StartTime is NULL";
                logDetails.IsError = true;
                LogDetails(logDetails);
                return;
            }

            if (logDetails.EndTime == null)
                logDetails.EndTime = DateTime.Now;

            TimeSpan timeSpan = (logDetails.EndTime.Value - logDetails.StartTime.Value);

            logDetails.Message = "TIMING: Process took " + timeSpan.TotalSeconds + " seconds to complete";

            LogDetails(logDetails);
        }

        private static void LogToDb(LogDetails logDetails)
        {
            try
            {
                DB_LOG log = new DB_LOG();

                log.CREATED = logDetails.CreatedTime;
                log.CREATEDBY = logDetails.Username;
                log.IS_ERROR = logDetails.IsError;
                log.MESSAGE = logDetails.Message;
                log.PROCESS_NAME = logDetails.ProcessName;
                log.STD_REGISTRY_ID = logDetails.RegistryId;

                DB_LOGManager.Save(logDetails.Username, logDetails.RegistryId, log);
            }
            catch (Exception ex)
            {
                logDetails.Message += " ADDITIONAL_ERROR: " + ex.Message;
                LogToEventLog(logDetails);
                LogToFileSystem(logDetails);
                //throw ex;
            }
            finally
            {
            }
        }

        private static void LogToEventLog(LogDetails logDetails)
        {
            XmlSerializer writer = null;
            StringWriter stream = null;

            try
            {
                writer = new XmlSerializer(logDetails.GetType());
                stream = new StringWriter();
                writer.Serialize(stream, logDetails);

                //EventLog.WriteEntry("", stream.ToString());
            }
            catch (Exception ex)
            {
                logDetails.Message += " ADDITIONAL_ERROR: " + ex.Message;
                LogToDb(logDetails);
                LogToFileSystem(logDetails);
                //throw ex;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                    stream = null;
                }
            }
        }

        private static void LogToFileSystem(LogDetails logDetails)
        {
            XmlSerializer writer = null;
            StringWriter stream = null;

            if (FileLogSize)
            {
                try
                {
                    string logFile = FileLogPath;
                    writer = new XmlSerializer(logDetails.GetType());
                    stream = new StringWriter();
                    writer.Serialize(stream, logDetails);
                    if (!string.IsNullOrEmpty(logFile))
                        File.AppendAllText(logFile, stream.ToString() + "\r\n");
                }
                catch (Exception ex)
                {
                    logDetails.Message += " ADDITIONAL_ERROR: " + ex.Message;
                    LogToDb(logDetails);
                    LogToEventLog(logDetails);
                    //throw ex;
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                        stream.Dispose();
                        stream = null;
                    }
                }
            }
        }

        public static void LogInformation(string message)
        {
            LogDetails logDetails = new LogDetails();
            logDetails.IsError = false;
            logDetails.Message = message;
            LogDetails(logDetails);
        }

        public static void LogInformation(string message, string processName)
        {
            LogDetails logDetails = new LogDetails();
            logDetails.IsError = false;
            logDetails.Message = message;
            logDetails.ProcessName = processName;
            LogDetails(logDetails);
        }

        public static void LogInformation(string message, string processName, string username)
        {
            LogDetails logDetails = new LogDetails();
            logDetails.IsError = false;
            logDetails.Message = message;
            logDetails.ProcessName = processName;
            logDetails.Username = username;
            LogDetails(logDetails);
        }

        public static void LogInformation(string message, string processName, string username, Int32 registryId)
        {
            LogDetails logDetails = new LogDetails();
            logDetails.IsError = false;
            logDetails.Message = message;
            logDetails.ProcessName = processName;
            logDetails.Username = username;
            logDetails.RegistryId = registryId;
            LogDetails(logDetails);
        }

        public static void LogError(string message)
        {
            LogDetails logDetails = new LogDetails();
            logDetails.IsError = true;
            logDetails.Message = message;
            LogDetails(logDetails);
        }

        public static void LogError(string message, string processName)
        {
            LogDetails logDetails = new LogDetails();
            logDetails.IsError = true;
            logDetails.Message = message;
            logDetails.ProcessName = processName;
            LogDetails(logDetails);
        }

        public static void LogError(string message, string processName, string username)
        {
            LogDetails logDetails = new LogDetails();
            logDetails.IsError = true;
            logDetails.Message = message;
            logDetails.ProcessName = processName;
            logDetails.Username = username;
            LogDetails(logDetails);
        }

        public static void LogError(string message, string processName, string username, Int32 registryId)
        {
            LogDetails logDetails = new LogDetails();
            logDetails.IsError = true;
            logDetails.Message = message;
            logDetails.ProcessName = processName;
            logDetails.Username = username;
            logDetails.RegistryId = registryId;
            LogDetails(logDetails);
        }
    }
}
