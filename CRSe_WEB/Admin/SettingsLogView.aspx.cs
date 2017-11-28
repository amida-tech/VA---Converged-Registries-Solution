using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace CRSe_WEB.Admin
{
    public partial class SettingsLogView : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);

                STD_REGISTRY systemRegistry = ApplicationSession.SystemRegistry;
                AppSettings appSetting = ServiceInterfaceManager.APPSETTINGS_GET(HttpContext.Current.User.Identity.Name, systemRegistry.ID);
                if (appSetting != null)
                {
                    string query = "";
                    query = Request.QueryString["query"] as string;

                    switch (query)
                    {
                        case "1": //File Log View
                            if (!string.IsNullOrEmpty(appSetting.FileLogPath.ToString()))
                            {
                                string logText = File.ReadAllText(appSetting.FileLogPath.ToString());

                                //string whitelist = "^[a-zA-Z0-9-,. ]+$";
                                //Regex pattern = new Regex(whitelist);

                                //if (!pattern.IsMatch(logText))
                                //    throw new Exception("Invalid Search Criteria");

                                txtOutput.Text = logText;
                            }
                            else
                            {
                                lblResult.Text = "There is no File Log Path saved in Settings. A file could not be generated to view.<br /><br />";
                                txtOutput.Visible = false;
                            }
                            break;
                        default:
                            {
                                lblResult.Text = "You have not selected a file to view. Please return to settings and pick a file.<br /><br />";
                                txtOutput.Visible = false;
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }
    }
}