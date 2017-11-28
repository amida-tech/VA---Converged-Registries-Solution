using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string antiXsrfTokenValue;

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

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += Master_Page_PreLoad;
        }

        protected void Master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BuildMenu();
                    //if (ServiceInterfaceManager.USER_ROLES_GET_BY_REGISTRYID_USERNAME_SET_READONLY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId))
                    //{
                    //    mnuTopMenu.Items[2].Selectable = false;
                    //    mnuTopMenu.Items[3].Selectable = false;
                    //}
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, 0);
                throw ex;
            }
        }

        private void BuildMenu()
        {
            try
            {
                string path = "~" + Request.Url.AbsolutePath;
                CrsMenu crsMenu = ServiceInterfaceManager.STD_MENU_ITEMS_GET_MENU(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, path);

                if (crsMenu != null)
                {
                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(CrsMenu));
                    System.IO.StringWriter stream = new System.IO.StringWriter();
                    writer.Serialize(stream, crsMenu);

                    string xml = stream.ToString(); 

                    stream.Close();

                    dsLeftMenu.Data = xml;
                }
                else
                    dsLeftMenu.Data = "<CrsMenu></CrsMenu>";
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, 0);
                throw ex;
            }
        }

        protected void ListRegistries_DataBound(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                listRegistries.Items.Insert(0, new ListItem("Select...", "0"));
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void ListRegistries_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                int id = 0;
                int.TryParse(listRegistries.SelectedValue, out id);

                if (id > 0)
                {
                    UserSession.CurrentRegistryId = id;
                    Response.Redirect("~/Common/Default.aspx?id=" + UserSession.CurrentRegistryId, false);
                }
                else
                {
                    UserSession.CurrentRegistryId = 0;
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void DsRegistries_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                e.InputParameters.Clear();
                e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                e.InputParameters.Add("CURRENT_REGISTRY_ID", 0);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }
    }
}