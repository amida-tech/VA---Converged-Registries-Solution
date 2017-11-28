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
    public partial class RegistryInfo : BasePage
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
                    LoadForm(UserSession.CurrentRegistryId);
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        public void LoadForm(int id)
        {
            STD_REGISTRY registry = ServiceInterfaceManager.STD_REGISTRY_GET_COMPLETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (registry != null)
            {
                lblRegistryNameValue.Text = (registry.NAME == string.Empty ? "N/A" : registry.NAME);
                lblRegistryCodeValue.Text = (registry.CODE == string.Empty ? "N/A" : registry.CODE);
                lblRegistryDescriptionValue.Text = (registry.DESCRIPTION_TEXT == string.Empty ? "N/A" : registry.DESCRIPTION_TEXT);
                if (!registry.INACTIVE_FLAG)
                    lblRegistryStatusValue.Text = "Enabled";
                else
                    lblRegistryStatusValue.Text = "Disabled";

                if (registry.REGISTRY_OWNER_USER != null)
                    lblRegistryOwnerValue.Text = (registry.REGISTRY_OWNER_USER.FULL_NAME == string.Empty ? "N/A" : registry.REGISTRY_OWNER_USER.FULL_NAME);
                else
                    lblRegistryOwnerValue.Text = "N/A";

                if (registry.REGISTRY_ADMINISTRATOR_USER != null)
                    lblRegistryAdministratorValue.Text = (registry.REGISTRY_ADMINISTRATOR_USER.FULL_NAME == string.Empty ? "N/A" : registry.REGISTRY_ADMINISTRATOR_USER.FULL_NAME);
                else
                    lblRegistryAdministratorValue.Text = "N/A";

                if (registry.SUPPORT_CONTACT_USER != null)
                    lblSupportContactValue.Text = (registry.SUPPORT_CONTACT_USER.FULL_NAME == string.Empty ? "N/A" : registry.SUPPORT_CONTACT_USER.FULL_NAME);
                else
                    lblSupportContactValue.Text = "N/A";
            }
        }
    }
}