using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRSe_WEB.SoaServices;

namespace CRSe_WEB.BaseCode
{
    [Serializable()]
    public class UserSession
    {
        private bool isSystemAdministrator;
        private bool isSystemUpdate;
        private bool isSystemRead;

        private bool isRegistryAdministrator;
        private bool isRegistryUpdate;
        private bool isRegistryRead;

        private string currentReportPath;
        private string currentRegistry;
        private int currentRegistryId;
        private int currentReferralId;
        private int currentPatientId;
        private int currentProviderId;
        private int currentWorkstreamId;
        private int currentActivityId;
        private int currentSurveyId;
        private int? defaultRegistryId;

        private PageModes pageMode;

        public UserSession()
        {
            this.Refresh();
        }

        public bool IsSystemAdministrator
        {
            get 
            { 
                return this.isSystemAdministrator; 
            }
            set
            {
                this.isSystemAdministrator = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public bool IsSystemUpdate
        {
            get { return this.isSystemUpdate; }
        }

        public bool IsSystemRead
        {
            get { return this.isSystemRead; }
        }

        public bool IsRegistryAdministrator
        {
            get 
            { 
                return this.isRegistryAdministrator; 
            }
            set
            {
                this.isRegistryAdministrator = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public bool IsRegistryUpdate
        {
            get { return this.isRegistryUpdate; }
        }

        public bool IsRegistryRead
        {
            get { return this.isRegistryRead; }
        }

        public string CurrentReportPath
        {
            get
            {
                return this.currentReportPath;
            }
            set
            {
                this.currentReportPath = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public string CurrentRegistry
        {
            get
            {
                return this.currentRegistry;
            }
            set
            {
                this.currentRegistry = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public int CurrentRegistryId
        {
            get
            {
                return this.currentRegistryId;
            }
            set
            {
                this.currentRegistryId = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public int? DefautRegistryId
        {
            get
            {
                return this.defaultRegistryId;
            }
            set
            {
                this.defaultRegistryId = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }
        public int CurrentReferralId
        {
            get
            {
                return this.currentReferralId;
            }
            set
            {
                this.currentReferralId = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public int CurrentPatientId
        {
            get
            {
                return this.currentPatientId;
            }
            set
            {
                this.currentPatientId = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public int CurrentProviderId
        {
            get
            {
                return this.currentProviderId;
            }
            set
            {
                this.currentProviderId = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public int CurrentWorkstreamId
        {
            get
            {
                return this.currentWorkstreamId;
            }
            set
            {
                this.currentWorkstreamId = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public int CurrentActivityId
        {
            get
            {
                return this.currentActivityId;
            }
            set
            {
                this.currentActivityId = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public int CurrentSurveyId
        {
            get
            {
                return this.currentSurveyId;
            }
            set
            {
                this.currentSurveyId = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public PageModes PageMode
        {
            get 
            { 
                return this.pageMode; 
            }
            set 
            { 
                this.pageMode = value;
                HttpContext.Current.Session["UserSession"] = this;
            }
        }

        public void Refresh()
        {
            this.isSystemAdministrator = false;
            this.isSystemUpdate = false;
            this.isSystemRead = false;
            this.isRegistryAdministrator = false;
            this.isRegistryUpdate = false;
            this.isRegistryRead = false;
           
            string[] roles = ServiceInterfaceManager.USER_ROLES_GET_ROLES(HttpContext.Current.User.Identity.Name);
            if (roles != null)
            {
                foreach (string role in roles)
                {
                    if (role == "CRSADMIN")
                        this.isSystemAdministrator = true;
                    else if (role == "CRSUPD")
                        this.isSystemUpdate = true;
                    else if (role == "CRSREAD")
                        this.isSystemRead = true;
                    else if (role == "REGADMIN")
                        this.isRegistryAdministrator = true;
                    else if (role == "REGUPD")
                        this.isRegistryUpdate = true;
                    else if (role == "REGREAD")
                        this.isRegistryRead = true;
                }
            }

            this.currentReportPath = string.Empty;
            this.currentRegistry = string.Empty;
            this.currentRegistryId = 0;
            this.currentReferralId = 0;
            this.currentPatientId = 0;
            this.currentProviderId = 0;
            this.currentWorkstreamId = 0;
            this.currentActivityId = 0;
            this.currentSurveyId = 0;
            this.defaultRegistryId = 0;

            this.pageMode = PageModes.None;

            HttpContext.Current.Session["UserSession"] = this;
        }

        public void RefreshCommon()
        {
            this.currentReferralId = 0;
            this.currentPatientId = 0;
            this.currentProviderId = 0;
            this.currentWorkstreamId = 0;
            this.currentActivityId = 0;
            this.currentSurveyId = 0;
            this.defaultRegistryId = 0;

            HttpContext.Current.Session["UserSession"] = this;
        }
    }
}