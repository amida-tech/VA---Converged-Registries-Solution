using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
    [Serializable, DataContract]
    public class LogDetails
    {
        private DateTime createdTime;
        private DateTime? startTime;
        private DateTime? endTime;
        private string processName;
        private Int32 registryId;
        private string username;
        private string message;
        private Boolean isError;

        public LogDetails()
        {
            this.startTime = this.createdTime = DateTime.Now;
            this.isError = false;
        }

        public LogDetails(string processName)
        {
            this.startTime = this.createdTime = DateTime.Now;
            this.isError = false;
            this.ProcessName = processName;
        }

        public LogDetails(string processName, string username)
        {
            this.startTime = this.createdTime = DateTime.Now;
            this.isError = false;
            this.ProcessName = processName;
            this.username = username;
        }

        public LogDetails(string processName, string username, Int32 registryId)
        {
            this.startTime = this.createdTime = DateTime.Now;
            this.isError = false;
            this.processName = processName;
            this.username = username;
            this.registryId = registryId;
        }

        public DateTime CreatedTime
        {
            get { return this.createdTime; }
            set { this.createdTime = value; }
        }

        public DateTime? StartTime
        {
            get { return this.startTime; }
            set { this.startTime = value; }
        }

        public DateTime? EndTime
        {
            get { return this.endTime; }
            set { this.endTime = value; }
        }

        public string ProcessName
        {
            get { return this.processName; }
            set { this.processName = value; }
        }

        public Int32 RegistryId
        {
            get { return this.registryId; }
            set { this.registryId = value; }
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        public Boolean IsError
        {
            get { return this.isError; }
            set { this.isError = value; }
        }
    }
}
