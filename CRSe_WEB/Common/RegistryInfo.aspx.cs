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
    public partial class RegistryInfo : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);

                lblResult.Text = string.Empty;

                if (UserSession == null || UserSession.CurrentRegistryId <= 0)
                {
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        if (ServiceInterfaceManager.USER_ROLES_GET_BY_REGISTRYID_USERNAME_SET_READONLY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId))
                        {
                            SetReadOnly();
                        }
                        //BuildCommonMenu();
                        LoadForm(UserSession.CurrentRegistryId);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void SetReadOnly()
        {
            lblResult.Text = "You are only able to set the Default Registry on this page.<br /><br />";
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

            USERS user = ServiceInterfaceManager.USERS_GET_BY_NAME(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, HttpContext.Current.User.Identity.Name);
            if (user != null)
            {
                if (UserSession.CurrentRegistryId == user.DEFAULT_REGISTRY_ID)
                    chkRegistryDefault.Checked = true;
                else
                    chkRegistryDefault.Checked = false;
            }
        }

        protected void ChkRegistryDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (ServiceInterfaceManager.USERS_DEFAULT_REGISTRY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, chkRegistryDefault.Checked))
                lblResult.Text = "Default Registry has been updated<br /><br />";
                UserSession.DefautRegistryId = UserSession.CurrentRegistryId;
        }

        protected override void Ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                e.InputParameters.Clear();

                string searchColumn = ddlSearch.SelectedValue;
                string searchText = txtSearch.Text;

                e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                e.InputParameters.Add("CURRENT_REGISTRY_ID", UserSession.CurrentRegistryId);
                e.InputParameters.Add("SEARCH_COLUMN", searchColumn);
                e.InputParameters.Add("SEARCH_TEXT", searchText);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                gridRegistry.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                gridRegistry.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }
    }
}