using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting;
using Microsoft.Reporting.WebForms;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB.Reports
{
    public partial class RunReport : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);

                if (UserSession == null)
                {
                    Response.Redirect("~/Default.aspx", false);
                }
                else if (string.IsNullOrEmpty(UserSession.CurrentReportPath))
                {
                    Response.Redirect("~/Reports/Default.aspx", false);
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        //BuildReportMenu();

                        LoadReport();
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void LoadReport()
        {
            reportViewer.Reset();
            reportViewer.ProcessingMode = ProcessingMode.Remote;
            reportViewer.ServerReport.Timeout = (Timeout * 1000); //this timeout is in milliseconds
            reportViewer.ServerReport.ReportServerUrl = new Uri(ReportServerUrl);
            reportViewer.ServerReport.ReportPath = UserSession.CurrentReportPath;
            reportViewer.ServerReport.Refresh();
        }
    }
}