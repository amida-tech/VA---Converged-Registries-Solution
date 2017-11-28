using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB.Common
{
    public partial class Default : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
               base.Page_Load(sender, e);

               if (UserSession == null || UserSession.CurrentRegistryId <= 0)
               {
                 Response.Redirect("~/Default.aspx", false);
              }
              else
                {
                    bool blnFoundReferral = false;
                    string firstMenuItem = string.Empty;

                    string path = "~" + Request.Url.AbsolutePath;
                    CrsMenu crsMenu = ServiceInterfaceManager.STD_MENU_ITEMS_GET_MENU(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, path);
                    if (crsMenu != null && crsMenu.MenuItems != null)
                    {
                        foreach (CrsMenuItem mi in crsMenu.MenuItems)
                        {
                            if (string.IsNullOrEmpty(firstMenuItem))
                                firstMenuItem = mi.NavigateUrl;

                            if (mi.NavigateUrl.ToLower().Contains("/common/referrals.aspx"))
                                blnFoundReferral = true;
                        }
                    }

                    if (blnFoundReferral)
                        Response.Redirect("~/Common/Referrals.aspx", false);
                    else if (!string.IsNullOrEmpty(firstMenuItem) && !path.ToLower().Contains(firstMenuItem.ToLower()))
                        Response.Redirect(firstMenuItem, false);
                    else
                        lblPageTitle.Text = UserSession.CurrentRegistry;             
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