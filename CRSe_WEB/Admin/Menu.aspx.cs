using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB.Admin
{
    public partial class Menu : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);
                //BuildAdminMenu();

                lblResult.Text = string.Empty;

                if (!Page.IsPostBack)
                {
                    pnlPages.Visible = true;
                    pnlPage.Visible = false;
                    pnlMenuItems.Visible = true;
                    pnlMenuItem.Visible = false;
                }
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
                    pnlMenuItems.Visible = true;
                    pnlMenuItem.Visible = false;
                    listRoles.DataBind();
                    gridMenuItems.DataBind();
                    listRoleName.DataBind();
                }
                else
                {
                    UserSession.CurrentRegistryId = 0;
                    pnlMenuItems.Visible = false;
                    pnlMenuItem.Visible = false;
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

        protected void ListRoles_DataBound(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                listRoles.Items.Insert(0, new ListItem("Select...", "0"));
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void ListRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                int id = 0;
                int.TryParse(listRegistries.SelectedValue, out id);

                if (id > 0)
                {
                    UserSession.CurrentRegistryId = id;
                    pnlMenuItems.Visible = true;
                    pnlMenuItem.Visible = false;
                    gridMenuItems.DataBind();
                    listRoleName.DataBind();
                }
                else
                {
                    UserSession.CurrentRegistryId = 0;
                    pnlMenuItems.Visible = false;
                    pnlMenuItem.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void DsRoles_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            try
            {
                int id = 0;
                int.TryParse(listRegistries.SelectedValue, out id);
                if (id > 0)
                {
                    e.InputParameters.Clear();
                    e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                    e.InputParameters.Add("CURRENT_REGISTRY_ID", id);
                }
                else
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkPageAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                ResetPageForm();
                pnlPages.Visible = false;
                pnlPage.Visible = true;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkPageEdit_Click(object sender, EventArgs e)
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
                        LoadPageForm(id);
                        pnlPages.Visible = false;
                        pnlPage.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkPageDelete_Click(object sender, EventArgs e)
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
                        ServiceInterfaceManager.STD_WEB_PAGES_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        gridPages.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnSavePage_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                string strResult = string.Empty;

                if (SavePageForm(ref strResult))
                {
                    gridPages.DataBind();

                    pnlPages.Visible = true;
                    pnlPage.Visible = false;
                }
                else
                {
                    pnlPages.Visible = false;
                    pnlPage.Visible = true;
                }

                lblResult.Text = strResult;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The Page you are saving already exists<br /><br />";
                else
                {
                    ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                    throw ex;
                }
            }
        }

        protected void BtnCancelPage_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                ResetPageForm();
                pnlPages.Visible = true;
                pnlPage.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private bool SavePageForm(ref string strResult)
        {
            STD_WEB_PAGES page = null;

           // if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtDisplayText.Text) && !string.IsNullOrEmpty(txtUrl.Text))
           
            if (string.IsNullOrEmpty(txtName.Text))
            {
                strResult = "<ul><li>Page Name is Required</li></ul>";
            }
            else if (string.IsNullOrEmpty(txtDisplayText.Text))
            {
                strResult = "<ul><li>Display Text is Required</li></ul>";
            }
            else if (string.IsNullOrEmpty(txtUrl.Text))
            {
                strResult = "<ul><li>URL is Required</li></ul>";
            }
            else
            {
                int id = 0;
                if (!string.IsNullOrEmpty(hidePageId.Value)) int.TryParse(hidePageId.Value, out id);
                if (id > 0) page = ServiceInterfaceManager.STD_WEB_PAGES_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                if (page == null) page = new STD_WEB_PAGES();

                page.CREATEDBY = page.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                page.INACTIVE_FLAG = false;

                page.NAME = txtName.Text;
                page.DISPLAY_TEXT = txtDisplayText.Text;
                page.URL = txtUrl.Text;

                bool corePage = false;
                bool.TryParse(listCorePage.SelectedValue, out corePage);
                page.CORE_PAGE = corePage;

                page.PAGE_ID = ServiceInterfaceManager.STD_WEB_PAGES_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, page);
                if (page.PAGE_ID > 0)
                {
                    hidePageId.Value = page.PAGE_ID.ToString();
                    strResult = "Save successful<br /><br />";

                    listPageName.DataBind();
                    listMenuPageName.DataBind();

                    return true;
                }
                else
                {
                    strResult = "Error saving Page, please try again<br /><br />";
                }

                //  else
                //  {
                //      strResult = "<ul><li>Please enter a value Page Name, Display Text, and URL</li></ul>";
                // }
            }
            return false;
        }

        private void LoadPageForm(int id)
        {
            ResetPageForm();

            STD_WEB_PAGES page = ServiceInterfaceManager.STD_WEB_PAGES_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (page != null)
            {
                hidePageId.Value = page.PAGE_ID.ToString();
                txtName.Text = page.NAME;
                txtDisplayText.Text = page.DISPLAY_TEXT;
                txtUrl.Text = page.URL;
                listCorePage.SelectedValue = page.CORE_PAGE.ToString().ToLower();
            }
        }

        private void ResetPageForm()
        {
            hidePageId.Value = string.Empty;
            txtName.Text = string.Empty;
            txtDisplayText.Text = string.Empty;
            txtUrl.Text = string.Empty;
            listCorePage.ClearSelection();
        }

        protected void LinkMenuAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (listRegistries.SelectedIndex > 0)
                {
                    ResetMenuForm();
                    pnlMenuItems.Visible = false;
                    pnlMenuItem.Visible = true;
                }
                else
                    lblResult.Text = "Please select an Available Registry before adding new Menu Items<br /><br />";
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkMenuEdit_Click(object sender, EventArgs e)
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
                        LoadMenuForm(id);
                        pnlMenuItems.Visible = false;
                        pnlMenuItem.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkMenuDelete_Click(object sender, EventArgs e)
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
                        ServiceInterfaceManager.STD_MENU_ITEMS_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        gridMenuItems.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                gridPages.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            txtPageItems.Text = "";
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                gridPages.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void DsPages_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            try
            {
                string searchColumn = ddlPageItems.SelectedValue;
                string searchText = txtPageItems.Text;

                e.InputParameters.Clear();
                e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                e.InputParameters.Add("CURRENT_REGISTRY_ID", 0);
                e.InputParameters.Add("SEARCH_COLUMN", searchColumn);
                e.InputParameters.Add("SEARCH_TEXT", searchText);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void DsMenuItems_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            try
            {
                int roleId = 0;
                int.TryParse(listRoles.SelectedValue, out roleId);

                int id = 0;
                int.TryParse(listRegistries.SelectedValue, out id);
                if (id > 0)
                {
                    string searchColumn = ddlMenuItems.SelectedValue;
                    string searchText = txtMenuItems.Text;

                    e.InputParameters.Clear();
                    e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                    e.InputParameters.Add("CURRENT_REGISTRY_ID", id);
                    e.InputParameters.Add("STD_ROLE_ID", roleId);
                    e.InputParameters.Add("SEARCH_COLUMN", searchColumn);
                    e.InputParameters.Add("SEARCH_TEXT", searchText);
                }
                else
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnMenuItems_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                gridMenuItems.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnClearMenuItems_Click(object sender, EventArgs e)
        {
            txtMenuItems.Text = "";
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                gridMenuItems.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void ListPageName_DataBound(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                listPageName.Items.Insert(0, new ListItem("Select...", "0"));
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void ListMenuPageName_DataBound(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                listMenuPageName.Items.Insert(0, new ListItem("Select...", "0"));
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void ListRoleName_DataBound(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                listRoleName.Items.Insert(0, new ListItem("Select...", "0"));
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void DsRoleName_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                int id = 0;
                int.TryParse(listRegistries.SelectedValue, out id);
                if (id > 0)
                {
                    e.InputParameters.Clear();
                    e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                    e.InputParameters.Add("CURRENT_REGISTRY_ID", id);
                }
                else
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnSaveMenu_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                string strResult = string.Empty;

                if (SaveMenuForm(ref strResult))
                {
                    gridMenuItems.DataBind();

                    pnlMenuItems.Visible = true;
                    pnlMenuItem.Visible = false;
                }
                else
                {
                    pnlMenuItems.Visible = false;
                    pnlMenuItem.Visible = true;
                }

                lblResult.Text = strResult;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The Menu Item you are saving already exists<br /><br />";
                else
                {
                    ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                    throw ex;
                }
            }
        }

        protected void BtnCancelMenu_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                ResetMenuForm();
                pnlMenuItems.Visible = true;
                pnlMenuItem.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private bool SaveMenuForm(ref string strResult)
        {
            STD_MENU_ITEMS menu = null;

            int registryId = 0;
            int.TryParse(listRegistries.SelectedValue, out registryId);

            int pageId = 0;
            int.TryParse(listPageName.SelectedValue, out pageId);

            int menuPageId = 0;
            int.TryParse(listMenuPageName.SelectedValue, out menuPageId);

            int roleId = 0;
            int.TryParse(listRoleName.SelectedValue, out roleId);

            if (registryId > 0 && menuPageId > 0 && roleId > 0)
            {
                if (string.IsNullOrEmpty(txtSortOrder.Text))
                {
                    strResult = "<ul><li>Sort Order is Required</li></ul>";
                }
                else
                {
                    int id = 0;
                    if (!string.IsNullOrEmpty(hideMenuId.Value)) int.TryParse(hideMenuId.Value, out id);
                    if (id > 0) menu = ServiceInterfaceManager.STD_MENU_ITEMS_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                    if (menu == null) menu = new STD_MENU_ITEMS();

                    menu.STD_REGISTRY_ID = registryId;
                    menu.CREATEDBY = menu.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                    menu.INACTIVE_FLAG = false;

                    menu.PAGE_ID = pageId;
                    menu.MENU_PAGE_ID = menuPageId;
                    menu.STD_ROLE_ID = roleId;

                    int sortOrder = 0;
                    int.TryParse(txtSortOrder.Text, out sortOrder);
                    menu.SORT_ORDER = sortOrder;

                    menu.MENU_ID = ServiceInterfaceManager.STD_MENU_ITEMS_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, menu);
                    if (menu.MENU_ID > 0)
                    {
                        hideMenuId.Value = menu.MENU_ID.ToString();
                        strResult = "Save successful<br /><br />";
                        return true;
                    }
                    else
                    {
                        strResult = "Error saving Menu Item, please try again<br /><br />";
                    }
                }
            }
            else
            {
                strResult = "<ul><li>Please select a Registry, Page, Menu Item, and Role</li></ul>";
            }

            return false;
        }

        private void LoadMenuForm(int id)
        {
            ResetMenuForm();

            STD_MENU_ITEMS menu = ServiceInterfaceManager.STD_MENU_ITEMS_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (menu != null)
            {
                hideMenuId.Value = menu.MENU_ID.ToString();
                listPageName.SelectedValue = menu.PAGE_ID.ToString();
                listMenuPageName.SelectedValue = menu.MENU_PAGE_ID.ToString();
                listRoleName.SelectedValue = menu.STD_ROLE_ID.ToString();
                txtSortOrder.Text = menu.SORT_ORDER.ToString();
            }
        }

        private void ResetMenuForm()
        {
            hideMenuId.Value = string.Empty;
            listPageName.ClearSelection();
            listMenuPageName.ClearSelection();
            listRoleName.ClearSelection();
            txtSortOrder.Text = string.Empty;
        }
    }
}