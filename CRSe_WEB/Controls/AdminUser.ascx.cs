using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;

using CRSe_WEB.BaseCode;

namespace CRSe_WEB.Controls
{
    public partial class AdminUser : BaseControl
    {
        public delegate void ButtonClickedHandler(object sender, EventArgs e);

        public event ButtonClickedHandler SearchClicked;
        public event ButtonClickedHandler SearchCancelClicked;
        public event ButtonClickedHandler SaveClicked;
        public event ButtonClickedHandler CancelClicked;
        public event ButtonClickedHandler SaveRolesClicked;

        protected virtual void OnSearch(EventArgs e)
        {
            if (SearchClicked != null)
                SearchClicked(this, e);
        }

        protected virtual void OnSearchCancel(EventArgs e)
        {
            if (SearchCancelClicked != null)
                SearchCancelClicked(this, e);
        }

        protected virtual void OnSave(EventArgs e)
        {
            if (SaveClicked != null)
                SaveClicked(this, e);
        }

        protected virtual void OnCancel(EventArgs e)
        {
            if (CancelClicked != null)
                CancelClicked(this, e);
        }

        protected virtual void OnSaveRoles(EventArgs e)
        {
            if (SaveRolesClicked != null)
                SaveRolesClicked(this, e);
        }

        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        private List<DomainUser> ActiveDirectory
        {
            get
            {
                if (ViewState["ActiveDirectory"] != null)
                    return ViewState["ActiveDirectory"] as List<DomainUser>;
                else
                    return null;
            }
            set 
            { 
                ViewState["ActiveDirectory"] = value; 
            }
        }

        private List<USER_ROLES> UserRoles
        {
            get
            {
                List<USER_ROLES> userRoles = null;
                int user_id = 0;
                int.TryParse(hideUserId.Value, out user_id);

                if (user_id > 0)
                {
                    if (ViewState["UserRoles"] == null)
                    {
                        userRoles = ServiceInterfaceManager.USER_ROLES_GET_ALL_BY_USER(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, user_id);
                        ViewState["UserRoles"] = userRoles;
                    }
                    else
                    {
                        userRoles = ViewState["UserRoles"] as List<USER_ROLES>;
                    }
                }

                return userRoles;
            }
            set 
            { 
                ViewState["UserRoles"] = value; 
            }
        }

        private string SORT_DIRECTION
        {
            get
            {
                string sortDirection = string.Empty;

                if (ViewState["SORT_DIRECTION"] != null)
                    sortDirection = ViewState["SORT_DIRECTION"] as string;

                return sortDirection;
            }
            set
            {
                ViewState["SORT_DIRECTION"] = value;
            }
        }

        private string SORT_EXPRESSION
        {
            get 
            {
                string sortExpression = string.Empty;

                if (ViewState["SORT_EXPRESSION"] != null)
                    sortExpression = ViewState["SORT_EXPRESSION"] as string;

                return sortExpression;
            }
            set 
            {
                ViewState["SORT_EXPRESSION"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //No need to log PAGE_LOAD here as the control will be available on .ASPX pages

            try
            {
                lblResult.Text = string.Empty;
                txtSearchLastName.Focus();

                if (!this.Page.IsPostBack)
                {
                    pnlSearch.Visible = true;
                    pnlResult.Visible = pnlUserInfo.Visible = false;
                }
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
                pnlResult.Visible = true;

                DoSearch();

                OnSearch(e);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnSearchCancel_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    pnlResult.Visible = false;

                    ResetForm();
                    OnCancel(e);
                }
                else
                {
                    pnlSearch.Visible = false;
                    pnlUserInfo.Visible = true;
                }

                OnSearchCancel(e);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnActiveDirectory_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                pnlSearch.Visible = true;
                pnlResult.Visible = pnlUserInfo.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void GridActiveDirectory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                gridActiveDirectory.PageIndex = e.NewPageIndex;
                gridActiveDirectory.DataSource = ActiveDirectory;
                gridActiveDirectory.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void GridActiveDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (gridActiveDirectory.SelectedIndex > -1)
                {
                    USERS user = new USERS();
                    user.USERNAME = gridActiveDirectory.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                    user.FIRST_NAME = gridActiveDirectory.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                    user.LAST_NAME = gridActiveDirectory.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                    user.FULL_NAME = user.FIRST_NAME + " " + user.LAST_NAME;
                    user.EMAIL_ADDRESS = gridActiveDirectory.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                    user.JOB_TITLE = gridActiveDirectory.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                    user.TELEPHONE_NUMBER = gridActiveDirectory.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                    user.FAX_NUMBER = gridActiveDirectory.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

                    LoadForm(user);
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
                    ResetForm();
                    OnSave(e);
                }
                else
                {
                    pnlSearch.Visible = pnlResult.Visible = false;
                    pnlUserInfo.Visible = true;

                    lblResult.Text = strResult;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The User you are saving already exists<br /><br />";
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
                ResetForm();
                OnCancel(e);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void ResetSearch()
        {
            txtSearchLastName.Text = string.Empty;
            txtSearchFirstName.Text = string.Empty;

            gridActiveDirectory.DataSource = ActiveDirectory = null;
            gridActiveDirectory.DataBind();

            pnlSearch.Visible = true;
            pnlResult.Visible = pnlUserInfo.Visible = false;
        }

        public void ResetForm()
        {
            ResetSearch();

            TabControl.ActiveTabIndex = 0;

            hideUserId.Value = "0";
            txtUsername.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtMaidenName.Text = string.Empty;
            txtEmployeeNumber.Text = string.Empty;
            txtJobTitle.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            txtTelephoneNumber.Text = string.Empty;
            txtFaxNumber.Text = string.Empty;
            chkEmailAlerts.Checked = false;

            rblSystemRoles.ClearSelection();
            listRegistries.ClearSelection();
            rblRegistryRoles.ClearSelection();

            rblRegistryRoles.Items.Clear();
        }

        public void LoadForm(int UserId)
        {
            USERS user = ServiceInterfaceManager.USERS_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserId);
            if (user != null)
            {
                LoadForm(user);
            }
        }

        private void LoadForm(USERS user)
        {
            ResetForm();
            pnlSearch.Visible = pnlResult.Visible = false;
            pnlUserInfo.Visible = true;

            hideUserId.Value = user.USER_ID.ToString();
            txtUsername.Text = user.USERNAME;
            txtFirstName.Text = user.FIRST_NAME;
            txtMiddleName.Text = user.MIDDLE_NAME;
            txtLastName.Text = user.LAST_NAME;
            txtFullName.Text = user.FULL_NAME;
            txtMaidenName.Text = user.MAIDEN_NAME;
            txtEmployeeNumber.Text = user.EMPLOYEE_NUMBER;
            txtJobTitle.Text = user.JOB_TITLE;
            txtEmailAddress.Text = user.EMAIL_ADDRESS;
            txtTelephoneNumber.Text = user.TELEPHONE_NUMBER;
            txtFaxNumber.Text = user.FAX_NUMBER;

            if (user.RECEIVE_EMAIL != null)
                chkEmailAlerts.Checked = user.RECEIVE_EMAIL.Value;

            if (rblSystemRoles.Items.Count <= 0) rblSystemRoles.DataBind();
            if (rblSystemRoles.Items.Count > 0)
            {
                rblSystemRoles.SelectedIndex = 0;

                List<USER_ROLES> userRoles = ServiceInterfaceManager.USER_ROLES_GET_ALL_BY_USER(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, user.USER_ID);
                if (userRoles != null)
                {
                    foreach (USER_ROLES userRole in userRoles)
                    {
                        foreach (ListItem li in rblSystemRoles.Items)
                        {
                            if (userRole.STD_ROLE_ID.ToString() == li.Value && !userRole.INACTIVE_FLAG)
                                li.Selected = true;
                        }
                    }
                }

                UserRoles = userRoles;
            }
        }

        public bool SaveForm(ref string strResult)
        {
            USERS user = null;

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                strResult = "User Name is Required<br /><br />";
            }
            else if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                strResult = "First Name is Required<br /><br />";
            }
            else if (string.IsNullOrEmpty(txtLastName.Text))
            {
                strResult = "Last Name is Required<br /><br />";
            }
            else if (string.IsNullOrEmpty(txtFullName.Text))
            {
                strResult = "Full Name is Required<br /><br />";
            }
            else if (string.IsNullOrEmpty(txtJobTitle.Text))
            {
                strResult = "Job Title is Required<br /><br />";
            }
            else
            {
                if (txtUsername.Text.Length > 30)
                {
                    strResult = "<ul><li>Username is longer than 30 characters which is not currently allowed by this system.  Please contact a System Administrator.</li></ul>";
                    return false;
                }

                int UserId = 0;
                int.TryParse(hideUserId.Value, out UserId);

                if (UserId > 0) user = ServiceInterfaceManager.USERS_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserId);
                if (user == null) user = new USERS();

                user.CREATEDBY = user.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                user.USERNAME = txtUsername.Text;
                user.FIRST_NAME = txtFirstName.Text;
                user.MIDDLE_NAME = txtMiddleName.Text;
                user.LAST_NAME = txtLastName.Text;
                user.FULL_NAME = txtFullName.Text;
                user.MAIDEN_NAME = txtMaidenName.Text;
                user.EMPLOYEE_NUMBER = txtEmployeeNumber.Text;
                user.JOB_TITLE = txtJobTitle.Text;
                user.EMAIL_ADDRESS = txtEmailAddress.Text;
                user.TELEPHONE_NUMBER = txtTelephoneNumber.Text;
                user.FAX_NUMBER = txtFaxNumber.Text;
                user.RECEIVE_EMAIL = chkEmailAlerts.Checked;

                user.USER_ID = ServiceInterfaceManager.USERS_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, user);
                if (user.USER_ID > 0)
                {
                    hideUserId.Value = user.USER_ID.ToString();

                    SaveRoles();

                    strResult = "Save successful<br /><br />";
                    return true;
                }
                else
                {
                    strResult = "Error saving User, please try again<br /><br />";
                }
            }
            // else
            // {
            //    strResult = "<ul><li>Username is Required</li></ul>";
            // }
            
            return false;
        }

        private bool SaveRoles()
        {
            //Do one last save of system roles because of strange bug with auto-postback
            STD_REGISTRY system = ApplicationSession.SystemRegistry;
            if (system != null)
            {
                int roleId = 0;
                int.TryParse(rblSystemRoles.SelectedValue, out roleId);

                UpdateRoles(system.ID, roleId);
            }

            //Default to true, if there is an error saving to DB, will set value to false
            bool blnReturn = true;

            List<USER_ROLES> saveRoles = new List<USER_ROLES>();

            List<USER_ROLES> userRoles = UserRoles;
            if (userRoles != null)
            {
                //Work with any system roles first
                userRoles = userRoles.OrderByDescending(data => data.STD_ROLE.SUPER_USER_FLAG).ToList<USER_ROLES>();

                int userId = 0;
                if (int.TryParse(hideUserId.Value, out userId))
                {
                    foreach (USER_ROLES userRole in userRoles)
                    {
                        userRole.USER_ID = userId;

                        //Only save to the DB if there is an existing record (USER_ROLD_ID > 0)
                        //Or, if it has a valid role (STD_ROLE_ID > 0)
                        if (userRole.USER_ROLE_ID > 0 || userRole.STD_ROLE_ID > 0)
                            saveRoles.Add(userRole);
                    }

                    if (saveRoles.Count > 0)
                        ServiceInterfaceManager.USER_ROLES_SAVE_ALL(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, saveRoles);

                    UserRoles = ServiceInterfaceManager.USER_ROLES_GET_ALL_BY_USER(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, userId);
                }
            }

            return blnReturn;
        }

        protected void RblSystemRoles_DataBound(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                rblSystemRoles.Items.Insert(0, new ListItem("None", "0"));
                rblSystemRoles.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
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

        protected void RblRegistryRoles_DataBound(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (rblRegistryRoles.Items != null && rblRegistryRoles.Items.Count > 0 && rblRegistryRoles.Items[0].Text != "None")
                {
                    rblRegistryRoles.Items.Insert(0, new ListItem("None", "0"));
                    rblRegistryRoles.SelectedIndex = 0;
                }
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
                rblRegistryRoles.Items.Clear();
                rblRegistryRoles.DataBind();

                List<USER_ROLES> userRoles = UserRoles;

                if (userRoles != null && rblRegistryRoles.Items != null)
                {
                    foreach (USER_ROLES userRole in userRoles)
                    {
                        foreach (ListItem li in rblRegistryRoles.Items)
                        {
                            if (userRole.STD_ROLE_ID.ToString() == li.Value && !userRole.INACTIVE_FLAG)
                            {
                                rblRegistryRoles.SelectedValue = li.Value;
                            }
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

        protected void DsSystemRoles_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                e.InputParameters.Clear();
                e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                e.InputParameters.Add("CURRENT_REGISTRY_ID", UserSession.CurrentRegistryId);
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
                e.InputParameters.Add("CURRENT_REGISTRY_ID", UserSession.CurrentRegistryId);

                if (!UserSession.IsSystemAdministrator)
                {
                    tblRoleInfo.Rows[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void DsRegistryRoles_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                int id = 0;
                int.TryParse(listRegistries.SelectedValue, out id);

                //Use selected registry from drop down list
                e.InputParameters.Clear();
                e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                e.InputParameters.Add("CURRENT_REGISTRY_ID", id.ToString());
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void RblSystemRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                STD_REGISTRY system = ApplicationSession.SystemRegistry;
                if (system != null)
                {
                    int roleId = 0;
                    int.TryParse(rblSystemRoles.SelectedValue, out roleId);

                    UpdateRoles(system.ID, roleId);
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void RblRegistryRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                int registryId = 0;
                int.TryParse(listRegistries.SelectedValue, out registryId);

                if (registryId > 0)
                {
                    int roleId = 0;
                    int.TryParse(rblRegistryRoles.SelectedValue, out roleId);

                    UpdateRoles(registryId, roleId);
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void UpdateRoles(int registryId, int roleId)
        {
            List<USER_ROLES> userRoles = UserRoles;

            int userId = 0;
            int.TryParse(hideUserId.Value, out userId);

            if (registryId > 0)
            {
                bool foundRegistry = false;

                if (userRoles != null)
                {
                    for (int i = 0; i < userRoles.Count; i++)
                    {
                        if (userRoles[i].STD_ROLE == null) userRoles[i].STD_ROLE = ServiceInterfaceManager.STD_ROLE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, userRoles[i].STD_ROLE_ID);

                        if (userRoles[i].STD_ROLE != null && userRoles[i].STD_ROLE.STD_REGISTRY_ID == registryId)
                        {
                            foundRegistry = true;

                            userRoles[i].UPDATED = DateTime.Now;
                            userRoles[i].UPDATEDBY = HttpContext.Current.User.Identity.Name;

                            if (roleId > 0)
                            {
                                userRoles[i].INACTIVE_FLAG = false;
                                userRoles[i].INACTIVE_DATE = null;

                                if (userRoles[i].STD_ROLE_ID != roleId)
                                    userRoles[i].STD_ROLE = ServiceInterfaceManager.STD_ROLE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, roleId);

                                userRoles[i].STD_ROLE_ID = roleId;
                            }
                            else
                            {
                                userRoles[i].INACTIVE_FLAG = true;
                                userRoles[i].INACTIVE_DATE = DateTime.Now;
                                //userRoles[i].STD_ROLE_ID = roleId;
                            }
                        }
                    }
                }
                
                if (!foundRegistry && roleId > 0)
                {
                    if (userRoles == null) userRoles = new List<USER_ROLES>();

                    USER_ROLES userRole = new USER_ROLES();

                    userRole.CREATED = userRole.UPDATED = DateTime.Now;
                    userRole.CREATEDBY = userRole.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                    userRole.INACTIVE_FLAG = false;
                    userRole.INACTIVE_DATE = null;
                    userRole.USER_ID = userId;

                    STD_ROLE stdRole = ServiceInterfaceManager.STD_ROLE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, roleId);
                    if (stdRole != null)
                    {
                        userRole.STD_ROLE_ID = stdRole.ID;
                        userRole.STD_ROLE = stdRole;
                        userRoles.Add(userRole);
                    }
                }
            }

            if (userRoles != null && userRoles.Count > 0)
                UserRoles = userRoles;
        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                DoSearch();
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
                DoSearch();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void GridActiveDirectory_Sorting(object sender, GridViewSortEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                if (SORT_DIRECTION == "ASC")
                    SORT_DIRECTION = "DESC";
                else
                    SORT_DIRECTION = "ASC";

                string sortExpression = string.Empty;

                if (!string.IsNullOrEmpty(e.SortExpression))
                {
                    sortExpression += e.SortExpression + " " + SORT_DIRECTION;
                }

                SORT_EXPRESSION = sortExpression;

                DoSearch();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void DoSearch()
        {
            string strSearch = string.Empty;

            if (!string.IsNullOrEmpty(txtSearchLastName.Text))
            {
                strSearch += txtSearchLastName.Text.Trim();
            }

            if (!string.IsNullOrEmpty(txtSearchFirstName.Text))
            {
                if (!string.IsNullOrEmpty(strSearch))
                {
                    strSearch += ", ";
                }

                strSearch += txtSearchFirstName.Text.Trim();
            }

            if (string.IsNullOrEmpty(strSearch))
            {
                lblResult.Text = "Please enter a valid last name and/or first name, no special characters are allowed<br /><br />";
            }

            string searchColumn = ddlSearch.SelectedValue;
            string searchText = txtSearch.Text;

            ActiveDirectory = ServiceInterfaceManager.USERS_GET_ALL_BY_AD(ApplicationSession.DomainNames, strSearch, searchColumn, searchText, SORT_EXPRESSION);
            gridActiveDirectory.DataSource = ActiveDirectory;
            gridActiveDirectory.DataBind();
        }
    }
}