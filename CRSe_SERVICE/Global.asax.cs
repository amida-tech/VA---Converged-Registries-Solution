using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Security;
using System.Web.SessionState;
using CRSe.CRS.BLL;

namespace CRSe_SERVICE
{
    public class Global : System.Web.HttpApplication
    {
        protected void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new ServiceRoute("CohortServices", new WebServiceHostFactory(), typeof(CohortServices)));
            routes.Add(new ServiceRoute("CrsServices", new WebServiceHostFactory(), typeof(CrsServices)));
            routes.Add(new ServiceRoute("EtlServices", new WebServiceHostFactory(), typeof(EtlServices)));
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            LogManager.LogInformation("CRSe_SERVICE Started", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));

            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
            LogManager.LogInformation("CRSe_SERVICE Ending", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));
        }
    }
}