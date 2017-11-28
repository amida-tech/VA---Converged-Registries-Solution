using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("CRSe_WEB Started", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);

            if (Application["ApplicationSession"] == null)
                Application["ApplicationSession"] = new ApplicationSession();
        }

        void Application_End(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("CRSe_WEB Ending", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);

            Application["ApplicationSession"] = null;
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
        }

        void Application_OnAuthenticateRequest(object sender, EventArgs e)
        {
        }

        void Session_OnStart()
        {
            //if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && !string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            //{
            //    ServiceInterfaceManager.USERS_SAVECurrentRegistry(HttpContext.Current.User.Identity.Name, string.Empty);
            //}

            if (Session["UserSession"] == null)
                Session["UserSession"] = new UserSession();
        }

        void Session_OnEnd()
        {
            Session["UserSession"] = null;
        }
    }
}
