using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB
{
    public partial class _Default : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            //adding line of commented text for RTC Task 350744
            UserSession.Refresh();

            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);
               //BuildMenu();

                if (!Page.IsPostBack)
                {
                   USERS user = ServiceInterfaceManager.USERS_GET_BY_NAME(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, HttpContext.Current.User.Identity.Name);
                    if (user != null)
                    {
                        UserSession.DefautRegistryId = user.DEFAULT_REGISTRY_ID;
                    }
                    if (UserSession.DefautRegistryId > 0)                  
                    {
                       // UserSession.DefautRegistryId = user.DEFAULT_REGISTRY_ID;
                        Response.Redirect("~/Common/Default.aspx?id=" + UserSession.DefautRegistryId, false);                     
                    }
                    else
                   {
                        SETTINGS setting = ServiceInterfaceManager.GET_HOME_PAGE_SETTING();
                        if (setting != null && !string.IsNullOrEmpty(setting.VALUE))
                        {
                            lblDescription.Text = setting.VALUE;
                        }
                        else
                        {
                            lblDescription.Text = "Welcome to the Converged Registries Solution home page.";
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