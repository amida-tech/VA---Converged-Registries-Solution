using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using System.Configuration;

namespace CRSe_WEB.BaseCode
{
    public partial class BaseControl : System.Web.UI.UserControl
    {
        private ApplicationSession applicationSession;
        private UserSession userSession;

        protected ApplicationSession ApplicationSession
        {
            get 
            {
                if (Application["ApplicationSession"] != null)
                {
                    applicationSession = (ApplicationSession)Application["ApplicationSession"];
                }

                if (applicationSession == null) applicationSession = new ApplicationSession();

                return applicationSession;
            }
            set
            {
                applicationSession = value;
            }
        }

        protected UserSession UserSession
        {
            get
            {
                if (Session["UserSession"] != null)
                {
                    userSession = (UserSession)Session["UserSession"];
                }

                if (userSession == null) userSession = new UserSession();

                return userSession;
            }
            set
            {
                userSession = value;
            }
        }

        protected string ReportServerUrl
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

        protected string ReportBuilderUrl
        {
            get
            {
                string reportBuilderUrl = ReportServerUrl;

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ReportBuilderPath"]))
                {
                    reportBuilderUrl += ConfigurationManager.AppSettings["ReportBuilderPath"];
                }

                return (!string.IsNullOrEmpty(reportBuilderUrl) ? reportBuilderUrl : "javascript:");
            }
        }

        protected int Timeout
        {
            get
            {
                int iTimeout = 30; //Default
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SqlCommandTimeout"]))
                {
                    int.TryParse(ConfigurationManager.AppSettings["SqlCommandTimeout"], out iTimeout);
                }
                return iTimeout;
            }
        }

        public BaseControl() 
        {
        }
    }
}