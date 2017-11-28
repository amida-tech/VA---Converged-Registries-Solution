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
    public class BasePage : System.Web.UI.Page
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

        public BasePage() 
        {
        }

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            int id = 0;

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    if (int.TryParse(Request.QueryString["id"].ToString(), out id))
                    {
                        UserSession.CurrentRegistryId = id;
                    }
                }

                if (Request.QueryString["path"] != null)
                {
                    userSession.CurrentReportPath = Request.QueryString["path"];
                }

                if (UserSession.CurrentRegistryId > 0)
                {
                    STD_REGISTRY r = ServiceInterfaceManager.STD_REGISTRY_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentRegistryId);
                    if (r != null)
                    {
                        UserSession.CurrentRegistry = r.NAME;
                        UserSession.CurrentRegistryId = r.ID;
                    }
                }
            }
        }

        protected virtual void Ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                e.InputParameters.Clear();
                e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                e.InputParameters.Add("CURRENT_REGISTRY_ID", UserSession.CurrentRegistryId);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected virtual void BtnSelectPatient_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                Response.Redirect("~/Common/Default.aspx", false);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        //protected void BuildAdminMenu()
        //{
        //    Menu mnuLeftMenu = (Menu)this.Master.FindControl("mnuLeftMenu");
        //    if (mnuLeftMenu != null)
        //    {
        //        mnuLeftMenu.Items.Clear();

        //        MenuItem menuTitle = new MenuItem("Administration", null, null, null, null);
        //        menuTitle.Selectable = false;
        //        mnuLeftMenu.Items.Add(menuTitle);

        //        mnuLeftMenu.Items.Add(new MenuItem("Survey Administration", null, null, "~/Admin/Survey.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("User Administration", null, null, "~/Admin/User.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Menu Administration", null, null, "~/Admin/Menu.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Settings", null, null, "~/Admin/Settings.aspx", null));
        //    }
        //}

        //protected void BuildCohortsMenu()
        //{
        //    Menu mnuLeftMenu = (Menu)this.Master.FindControl("mnuLeftMenu");
        //    if (mnuLeftMenu != null)
        //    {
        //        mnuLeftMenu.Items.Clear();

        //        MenuItem menuTitle = new MenuItem(UserSession.CurrentRegistry, null, null, null, null);
        //        menuTitle.Selectable = false;
        //        mnuLeftMenu.Items.Add(menuTitle);

        //        mnuLeftMenu.Items.Add(new MenuItem("Cohort Criteria", null, null, "~/Cohorts/Cohort.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Framework Data", null, null, "~/Cohorts/FrameworkData.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("User-Defined Fields", null, null, "~/Cohorts/UDF.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Work Streams", null, null, "~/Cohorts/Workstream.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Activities", null, null, "~/Cohorts/Activity.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem(null, null, null, null, null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Registries and Cohorts", null, null, "~/Cohorts/Default.aspx", null));
        //    }
        //}

        //protected void BuildCustomMenu(NameValueCollection nameValueCollection)
        //{
        //    Menu mnuLeftMenu = (Menu)this.Master.FindControl("mnuLeftMenu");
        //    if (mnuLeftMenu != null)
        //    {
        //        mnuLeftMenu.Items.Clear();

        //        if (nameValueCollection != null && nameValueCollection.Keys != null)
        //        {
        //            foreach (string key in nameValueCollection.Keys)
        //            {
        //                MenuItem newItem = new MenuItem(key, null, null, nameValueCollection.Get(key), null);
        //                if (string.IsNullOrEmpty(newItem.NavigateUrl))
        //                    newItem.Selectable = false;

        //                mnuLeftMenu.Items.Add(newItem);
        //            }
        //        }
        //    }
        //}

        //protected void BuildCommonMenu()
        //{
        //    Menu mnuLeftMenu = (Menu)this.Master.FindControl("mnuLeftMenu");
        //    if (mnuLeftMenu != null)
        //    {
        //        mnuLeftMenu.Items.Clear();

        //        MenuItem menuTitle = new MenuItem(userSession.CurrentRegistry, null, null, null, null);
        //        menuTitle.Selectable = false;
        //        mnuLeftMenu.Items.Add(menuTitle);

        //        mnuLeftMenu.Items.Add(new MenuItem("Registry Info", null, null, "~/Common/RegistryInfo.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Patients", null, null, "~/Common/Patients.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Providers", null, null, "~/Common/Providers.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Referrals", null, null, "~/Common/Referrals.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Work Stream", null, null, "~/Common/Workstreams.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Activities", null, null, "~/Common/Activities.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("Surveys", null, null, "~/Common/Surveys.aspx", null));
        //        mnuLeftMenu.Items.Add(new MenuItem("User-Defined Fields", null, null, "~/Common/UDFs.aspx", null));
        //    }
        //}

        //protected void //BuildReportMenu()
        //{
        //    List<ReportItem> reports = ServiceInterfaceManager.REPORTS_GET_ALL_BY_USER_REGISTRY(HttpContext.Current.User.Identity.Name, userSession.CurrentRegistryId);
        //    //BuildReportMenu(reports);
        //}

        //protected void //BuildReportMenu(List<ReportItem> reports)
        //{
        //    int currCount = 0;

        //    Menu mnuLeftMenu = (Menu)this.Master.FindControl("mnuLeftMenu");
        //    if (mnuLeftMenu != null)
        //    {
        //        mnuLeftMenu.Items.Clear();

        //        MenuItem menuTitle = new MenuItem("Reports", null, null, null, null);
        //        menuTitle.Selectable = false;
        //        mnuLeftMenu.Items.Add(menuTitle);
        //        currCount++;

        //        //if (reports == null) reports = ServiceInterfaceManager.REPORTS_GET_ALL_BY_USER_REGISTRY(HttpContext.Current.User.Identity.Name, userSession.CurrentRegistryId);
        //        if (reports != null)
        //        {
        //            foreach (ReportItem report in reports)
        //            {
        //                mnuLeftMenu.Items.Add(new MenuItem(report.Name, null, null, "~/Reports/RunReport.aspx?path=" + report.Path, null));
        //                currCount++;
        //            }
        //        }

        //        if (currCount > 1)
        //        {
        //            menuTitle = new MenuItem(null, null, null, null, null);
        //            menuTitle.Selectable = false;
        //            mnuLeftMenu.Items.AddAt(currCount, menuTitle);
        //            currCount++;
        //        }

        //        mnuLeftMenu.Items.Add(new MenuItem("Report Builder", null, null, ReportBuilderUrl, null));
        //    }
        //}

        //protected void BuildViewMenu(int STD_REGISTRY_ID)
        //{
        //    Menu mnuLeftMenu = (Menu)this.Master.FindControl("mnuLeftMenu");
        //    if (mnuLeftMenu != null)
        //    {
        //        mnuLeftMenu.Items.Clear();

        //        MenuItem menuTitle = new MenuItem("Referrals", null, null, null, null);
        //        menuTitle.Selectable = false;
        //        mnuLeftMenu.Items.Add(menuTitle);

        //        mnuLeftMenu.Items.Add(new MenuItem("View", null, null, "~/Read/Default.aspx?id=" + STD_REGISTRY_ID.ToString(), null));
        //    }
        //}

        //protected void BuildMenu()
        //{
        //    Menu mnuLeftMenu = (Menu)this.Master.FindControl("mnuLeftMenu");
        //    if (mnuLeftMenu != null)
        //    {
        //        mnuLeftMenu.Items.Clear();

        //        List<STD_REGISTRY> urs = ServiceInterfaceManager.STD_REGISTRY_GET_ALL_BY_USER(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
        //        List<STD_REGISTRY> regs = ApplicationSession.Registries;

        //        if (UserSession.IsSystemAdministrator || UserSession.IsSystemUpdate || UserSession.IsSystemRead)
        //        {
        //            if (regs != null)
        //            {
        //                foreach (STD_REGISTRY r in regs)
        //                {
        //                    bool blnFound = false;

        //                    if (urs != null)
        //                    {
        //                        foreach (STD_REGISTRY u in urs)
        //                        {
        //                            if (r.ID == u.ID)
        //                            {
        //                                blnFound = true;
        //                                break;
        //                            }
        //                        }
        //                    }

        //                    if (!blnFound)
        //                    {
        //                        if (!UserSession.IsSystemAdministrator && !UserSession.IsSystemUpdate && UserSession.IsSystemRead) 
        //                            r.COMMENTS = "CRSREAD";

        //                        urs.Add(r);
        //                    }
        //                }
        //            }
        //        }

        //        if (urs != null && regs != null)
        //        {
        //            BuildYourRegistries(mnuLeftMenu, urs, regs);
        //            BuildAvailableRegistries(mnuLeftMenu, urs, regs);
        //        }
        //        else if (regs != null)
        //        {
        //            BuildAvailableRegistries(mnuLeftMenu, urs, regs);
        //        }
        //    }
        //}

        //private void BuildYourRegistries(Menu mnuLeftMenu, List<STD_REGISTRY> urs, List<STD_REGISTRY> regs)
        //{
        //    int count = 0;

        //    foreach (STD_REGISTRY u in urs)
        //    {
        //        foreach (STD_REGISTRY r in regs)
        //        {
        //            if (u.ID == r.ID)
        //            {
        //                bool blnFound = false;

        //                foreach (MenuItem miCheck in mnuLeftMenu.Items)
        //                {
        //                    if (miCheck.Text == r.NAME)
        //                    {
        //                        blnFound = true;
        //                        break;
        //                    }
        //                }

        //                if (!blnFound)
        //                {
        //                    mnuLeftMenu.Items.Add(new MenuItem(u.NAME, null, null, "~/Common/Default.aspx?id=" + u.ID.ToString(), null));
        //                    count++;
        //                }
        //            }
        //        }
        //    }

        //    if (count > 0)
        //    {
        //        MenuItem menuTitle = new MenuItem("Your Registries", null, null, null, null);
        //        menuTitle.Selectable = false;
        //        mnuLeftMenu.Items.AddAt(0, menuTitle);
        //    }
        //}

        //private void BuildAvailableRegistries(Menu mnuLeftMenu, List<STD_REGISTRY> urs, List<STD_REGISTRY> regs)
        //{
        //    int currCount = mnuLeftMenu.Items.Count;
        //    int count = 0;

        //    foreach (STD_REGISTRY r in regs)
        //    {
        //        if (urs != null)
        //        {
        //            bool blnFound = false;
        //            foreach (STD_REGISTRY u in urs)
        //            {
        //                if (u.ID == r.ID)
        //                {
        //                    blnFound = true;
        //                    break;
        //                }
        //            }

        //            if (!blnFound)
        //            {
        //                mnuLeftMenu.Items.Add(new MenuItem(r.NAME, null, null, "~/RegistryInfo.aspx?id=" + r.ID.ToString(), null));
        //                count++;
        //            }
        //        }
        //        else
        //        {
        //            mnuLeftMenu.Items.Add(new MenuItem(r.NAME, null, null, "~/RegistryInfo.aspx?id=" + r.ID.ToString(), null));
        //            count++;
        //        }
        //    }

        //    if (count > 0)
        //    {
        //        MenuItem menuTitle = null;

        //        if (currCount > 0)
        //        {
        //            menuTitle = new MenuItem(null, null, null, null, null);
        //            menuTitle.Selectable = false;
        //            mnuLeftMenu.Items.AddAt(currCount, menuTitle);
        //            currCount++;
        //        }

        //        menuTitle = new MenuItem("Available Registries", null, null, null, null);
        //        menuTitle.Selectable = false;
        //        mnuLeftMenu.Items.AddAt(currCount, menuTitle);
        //    }
        //}
    }
}