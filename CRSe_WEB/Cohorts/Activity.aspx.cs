using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB.Cohorts
{
    public partial class Activity : BasePage
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
                    Response.Redirect("~/Cohorts/Default.aspx", false);
                }
                else
                {
                    //BuildCohortsMenu();
                    if (!Page.IsPostBack)
                    {
                        txtActivityDescription.Attributes.Add("maxlength", txtActivityDescription.MaxLength.ToString());

                        pnlActivities.Visible = true;
                        pnlActivity.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkActivityAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                ResetForm();
                pnlActivities.Visible = false;
                pnlActivity.Visible = true;
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
                        LoadForm(id);
                        pnlActivities.Visible = false;
                        pnlActivity.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
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
                gridActivities.DataBind();
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
                gridActivities.DataBind();
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
                        ServiceInterfaceManager.STD_WKFACTIVITYTYPE_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        gridActivities.DataBind();
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
                    gridActivities.DataBind();

                    pnlActivities.Visible = true;
                    pnlActivity.Visible = false;
                }
                else
                {
                    pnlActivities.Visible = false;
                    pnlActivity.Visible = true;
                }

                lblResult.Text = strResult;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The Activity you are saving already exists<br /><br />";
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
                pnlActivities.Visible = true;
                pnlActivity.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private bool SaveForm(ref string strResult)
        {
            STD_WKFACTIVITYTYPE activity = null;

            if (string.IsNullOrEmpty(txtActivityName.Text))
            {
                strResult = "Activity Name is Required<br /><br />";
            }             
            else if (string.IsNullOrEmpty(txtActivityCode.Text))
            {
                 strResult = "Activity Code is Required<br /><br />";
            }
            else if (string.IsNullOrEmpty(txtActivitySortOrder.Text))
            {
                strResult = "Sort Order is Required<br /><br />";
            }
            else if (string.IsNullOrEmpty(txtActivityDescription.Text))
            {
                strResult = "Description is Required<br /><br />";
            }
            else
            {
                int id = 0;
                if (!string.IsNullOrEmpty(hideActivityId.Value)) int.TryParse(hideActivityId.Value, out id);
                if (id > 0) activity = ServiceInterfaceManager.STD_WKFACTIVITYTYPE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                if (activity == null) activity = new STD_WKFACTIVITYTYPE();

                activity.STD_REGISTRY_ID = UserSession.CurrentRegistryId;
                activity.CREATEDBY = activity.UPDATEDBY = HttpContext.Current.User.Identity.Name;

                int wf = 0;
                int.TryParse(listWorkstream.SelectedValue, out wf);

                activity.STD_WKFCASETYPE_ID = wf;
                activity.NAME = txtActivityName.Text;
                activity.CODE = txtActivityCode.Text;

                int order = 0;
                int.TryParse(txtActivitySortOrder.Text, out order);

                activity.SORT_ORDER = order;
                activity.DESCRIPTION_TEXT = txtActivityDescription.Text;
                activity.AUTO_CREATE = chkAutoCreated.Checked;

                activity.ID = ServiceInterfaceManager.STD_WKFACTIVITYTYPE_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, activity);
                if (activity.ID > 0)
                {
                    hideActivityId.Value = activity.ID.ToString();
                    strResult = "Save successful<br /><br />";
                    return true;
                }
                else
                {
                    strResult = "Error saving Activity, please try again<br /><br />";
                }
                //}
                // else
                // {
                //    strResult = "<ul><li>Activity Name is Required</li></ul>";
                // }
            }
            return false;
        }

        private void LoadForm(int id)
        {
            ResetForm();

            STD_WKFACTIVITYTYPE activity = ServiceInterfaceManager.STD_WKFACTIVITYTYPE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (activity != null)
            {
                hideActivityId.Value = activity.ID.ToString();
                if (activity.STD_WKFCASETYPE_ID != null)
                {
                    listWorkstream.SelectedValue = activity.STD_WKFCASETYPE_ID.ToString();
                }
                txtActivityName.Text = activity.NAME;
                txtActivityCode.Text = activity.CODE;
                txtActivitySortOrder.Text = activity.SORT_ORDER.ToString();
                txtActivityDescription.Text = activity.DESCRIPTION_TEXT;
                chkAutoCreated.Checked = activity.AUTO_CREATE.GetValueOrDefault();
            }
        }

        private void ResetForm()
        {
            listWorkstream.ClearSelection();
            listWorkstream.Items.Clear();

            List<STD_WKFCASETYPE> cases = ServiceInterfaceManager.STD_WKFCASETYPE_GET_ALL_BY_REGISTRY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            listWorkstream.Items.Add(new ListItem("", "0"));
            listWorkstream.AppendDataBoundItems = true;
            if (cases != null)
            {
                listWorkstream.DataSource = cases;
                listWorkstream.DataBind();
            }

            hideActivityId.Value = string.Empty;
            txtActivityName.Text = string.Empty;
            txtActivityCode.Text = string.Empty;
            txtActivitySortOrder.Text = string.Empty;
            txtActivityDescription.Text = string.Empty;
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                bool blnContinue = false;
                string strResult = string.Empty;

                if (pnlActivity.Visible)
                    blnContinue = SaveForm(ref strResult);
                else
                    blnContinue = true;

                if (blnContinue)
                    Response.Redirect("~/Cohorts/Workstream.aspx", false);
                else
                    lblResult.Text = strResult;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }
    }
}