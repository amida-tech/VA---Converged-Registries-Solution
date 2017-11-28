using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB.Cohorts
{
    public partial class Registry : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);
                //BuildCohortsMenu();

                lblResult.Text = string.Empty;

                if (!UserSession.IsSystemAdministrator && UserSession.IsRegistryAdministrator)
                {
                    linkRegistryAdd.Visible = false;
                }

                if (!Page.IsPostBack)
                {
                    txtRegistryDescription.Attributes.Add("maxlength", txtRegistryDescription.MaxLength.ToString());

                    if (UserSession.CurrentRegistryId > 0)
                    {
                        RegistryEdit(UserSession.CurrentRegistryId);
                    }
                    else
                    {
                        pnlRegistries.Visible = true;
                        pnlRegistry.Visible = false;
                        btnNext.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkRegistryAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                RegistryAdd();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                LinkButton lb = (LinkButton)sender;
                if (lb != null)
                {
                    int id = 0;

                    if (int.TryParse(lb.CommandArgument, out id))
                    {
                        RegistryEdit(id);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                LinkButton lb = (LinkButton)sender;
                if (lb != null)
                {
                    int id = 0;

                    if (int.TryParse(lb.CommandArgument, out id))
                    {
                        ServiceInterfaceManager.STD_REGISTRY_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        gridRegistry.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkName_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                LinkButton lb = (LinkButton)sender;
                if (lb != null)
                {
                    int id = 0;

                    if (int.TryParse(lb.CommandArgument, out id))
                    {
                        UserSession.CurrentRegistryId = id;
                        Response.Redirect("~/Cohorts/Cohort.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                string strResult = string.Empty;

                if (SaveForm(ref strResult))
                {
                    gridRegistry.DataBind();

                    pnlRegistries.Visible = false;
                    pnlRegistry.Visible = true;
                    btnNext.Visible = true;
                }
                else
                {
                    pnlRegistries.Visible = false;
                    pnlRegistry.Visible = true;
                    btnNext.Visible = false;
                }

                lblResult.Text = strResult;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The Registry/Cohort you are saving already exists<br /><br />";
                else
                {
                    ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                    throw ex;
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                UserSession.CurrentRegistryId = 0;
                UserSession.CurrentSurveyId = 0;

                ResetForm();
                pnlRegistries.Visible = true;
                pnlRegistry.Visible = false;
                btnNext.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                bool blnContinue = false;
                string strResult = string.Empty;
                blnContinue = SaveForm(ref strResult);

                if (blnContinue)
                {
                    UserSession.CurrentRegistryId = 0;
                    UserSession.CurrentSurveyId = 0;

                    ResetForm();
                    pnlRegistries.Visible = true;
                    pnlRegistry.Visible = false;
                    btnNext.Visible = false;
                }
                else
                    lblResult.Text = strResult;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                bool blnContinue = false;
                string strResult = string.Empty;
                blnContinue = SaveForm(ref strResult);

                if (blnContinue)
                {
                    int id = 0;

                    if (int.TryParse(hideRegistryId.Value, out id))
                    {
                        UserSession.CurrentRegistryId = id;
                        Response.Redirect("~/Cohorts/Cohort.aspx", false);
                    }
                }
                else
                    lblResult.Text = strResult;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkContinue_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                int id = 0;

                if (int.TryParse(hideRegistryId.Value, out id))
                {
                    RegistryEdit(id);
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkNew_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                RegistryAdd();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void RegistryAdd()
        {
            ResetForm();
            pnlRegistries.Visible = false;
            pnlRegistry.Visible = true;
            btnNext.Visible = false;
        }

        private void RegistryEdit(int STD_REGISTRY_ID)
        {
            LoadForm(STD_REGISTRY_ID);
            pnlRegistries.Visible = false;
            pnlRegistry.Visible = true;
            btnNext.Visible = true;
        }

        public bool SaveForm(ref string strResult)
        {
            STD_REGISTRY registry = null;

            if (string.IsNullOrEmpty(txtRegistryName.Text))
            {
                strResult = "<ul><li>Registry Name is Required</li></ul>";
            }
            else if (string.IsNullOrEmpty(txtRegistryCode.Text))
            {
                strResult = "<ul><li>Registry Code is Required</li></ul>";
            }
            else if (string.IsNullOrEmpty(txtRegistryDescription.Text))
            {
                strResult = "<ul><li>Description is Required</li></ul>";
            }
            else
            {
                int id = 0;
                if (!string.IsNullOrEmpty(hideRegistryId.Value))
                {
                    int.TryParse(hideRegistryId.Value, out id);
                }

                registry = ServiceInterfaceManager.STD_REGISTRY_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                if (registry == null) registry = new STD_REGISTRY();

                registry.CREATEDBY = registry.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                registry.NAME = txtRegistryName.Text;
                registry.CODE = txtRegistryCode.Text.Trim();
                registry.DESCRIPTION_TEXT = txtRegistryDescription.Text;

                int userId = 0;
                int.TryParse(listRegistryOwner.SelectedValue, out userId);
                if (userId > 0)
                    registry.REGISTRY_OWNER = userId;
                else
                    registry.REGISTRY_OWNER = null;

                userId = 0;
                int.TryParse(listRegistryAdministrator.SelectedValue, out userId);
                if (userId > 0)
                    registry.REGISTRY_ADMINISTRATOR = userId;
                else
                    registry.REGISTRY_ADMINISTRATOR = null;

                userId = 0;
                int.TryParse(listSupportContact.SelectedValue, out userId);
                if (userId > 0)
                    registry.REGISTRY_SUPPORT_CONTACT = userId;
                else
                    registry.REGISTRY_SUPPORT_CONTACT = null;

                registry.ID = ServiceInterfaceManager.STD_REGISTRY_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, registry);
                if (registry.ID > 0)
                {
                    ApplicationSession.Refresh(false);

                    hideRegistryId.Value = registry.ID.ToString();
                    strResult = "Save successful<br /><br />";
                    return true;
                }
                else
                {
                    strResult = "Error saving Registry, please try again<br /><br />";
                }
            }

            return false;
        }

        public void LoadForm(int id)
        {
            ResetForm();

            STD_REGISTRY registry = ServiceInterfaceManager.STD_REGISTRY_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (registry != null)
            {
                hideRegistryId.Value = registry.ID.ToString();

                txtRegistryName.Text = registry.NAME;
                txtRegistryCode.Text = registry.CODE;
                txtRegistryDescription.Text = registry.DESCRIPTION_TEXT;

                LoadUserLists();

                if (registry.REGISTRY_OWNER > 0) listRegistryOwner.SelectedValue = registry.REGISTRY_OWNER.ToString();
                if (registry.REGISTRY_ADMINISTRATOR > 0) listRegistryAdministrator.SelectedValue = registry.REGISTRY_ADMINISTRATOR.ToString();
                if (registry.REGISTRY_SUPPORT_CONTACT > 0) listSupportContact.SelectedValue = registry.REGISTRY_SUPPORT_CONTACT.ToString();
            }
        }

        private void LoadUserLists()
        {
            List<USERS> users = ServiceInterfaceManager.USERS_GET_ALL(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            listRegistryOwner.Items.Clear();
            listRegistryOwner.Items.Add(new ListItem("Select...", "0"));
            listRegistryOwner.AppendDataBoundItems = true;
            listRegistryOwner.DataSource = users;
            listRegistryOwner.DataBind();

            listRegistryAdministrator.Items.Clear();
            listRegistryAdministrator.Items.Add(new ListItem("Select...", "0"));
            listRegistryAdministrator.AppendDataBoundItems = true;
            listRegistryAdministrator.DataSource = users;
            listRegistryAdministrator.DataBind();

            listSupportContact.Items.Clear();
            listSupportContact.Items.Add(new ListItem("Select...", "0"));
            listSupportContact.AppendDataBoundItems = true;
            listSupportContact.DataSource = users;
            listSupportContact.DataBind();
        }

        public void ResetForm()
        {
            TabControl.ActiveTab = TabControl.Tabs[0];

            hideRegistryId.Value = string.Empty;

            txtRegistryName.Text = string.Empty;
            txtRegistryCode.Text = string.Empty;
            txtRegistryDescription.Text = string.Empty;

            LoadUserLists();
        }

        protected override void Ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Ds_Selecting(sender, e);

                if (!UserSession.IsSystemAdministrator)
                {
                    linkRegistryAdd.Visible = false;
                }
                string searchColumn = ddlSearch.SelectedValue;
                string searchText = txtSearch.Text;

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

        protected void BtnAddUser_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                mpeAddUser.Show();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void AdminUser_SearchClicked(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                mpeAddUser.Show();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void AdminUser_SearchCancelClicked(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (!string.IsNullOrEmpty(AdminUser.Username))
                {
                    mpeAddUser.Show();
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void AdminUser_SaveClicked(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                int id = 0;
                if (int.TryParse(hideRegistryId.Value, out id))
                {
                    LoadForm(id);
                    TabControl.ActiveTab = TabControl.Tabs[1];
                    lblResult.Text = "New User has been created and is now available in the drop down lists<br /><br />";
                }
                else
                {
                    lblResult.Text = "New User has been created, however you may have to refresh the page for them to be included in the drop down list<br /><br />";
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void AdminUser_CancelClicked(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void AdminUser_SaveRolesClicked(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                mpeAddUser.Show();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }
    }
}