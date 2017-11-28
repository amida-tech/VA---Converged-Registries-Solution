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
    public partial class Workstream : BasePage
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
                        txtWorkstreamDescription.Attributes.Add("maxlength", txtWorkstreamDescription.MaxLength.ToString());

                        pnlWorkstreams.Visible = true;
                        pnlWorkstream.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkWorkstreamAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                ResetForm();
                pnlWorkstreams.Visible = false;
                pnlWorkstream.Visible = true;
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
                        pnlWorkstreams.Visible = false;
                        pnlWorkstream.Visible = true;
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
                        ServiceInterfaceManager.STD_WKFCASETYPE_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        this.gridWorkstreams.DataBind();
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
                    gridWorkstreams.DataBind();

                    pnlWorkstreams.Visible = true;
                    pnlWorkstream.Visible = false;
                }
                else
                {
                    pnlWorkstreams.Visible = false;
                    pnlWorkstream.Visible = true;
                }

                lblResult.Text = strResult;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The Work Stream you are saving already exists<br /><br />";
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
                pnlWorkstreams.Visible = true;
                pnlWorkstream.Visible = false;
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
                gridWorkstreams.DataBind();
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
                gridWorkstreams.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private bool SaveForm(ref string strResult)
        {
            STD_WKFCASETYPE workstream = null;

            if (string.IsNullOrEmpty(txtWorkstreamName.Text))
            {
                 strResult = "Workstream Name is Required<br /><br />";
            }
            else if (string.IsNullOrEmpty(txtWorkstreamCode.Text))
            {
                 strResult = "Workstream  Code is Required<br /><br />";
            }
            else if (string.IsNullOrEmpty(txtWorkstreamSortOrder.Text))
            {
                strResult = "Sort Order is Required<br /><br />";
            }
            else if (string.IsNullOrEmpty(txtWorkstreamDescription.Text))
            {
                strResult = "Description is Required<br /><br />";
            }
            else
            {
                int id = 0;
                if (!string.IsNullOrEmpty(hideWorkstreamId.Value)) int.TryParse(hideWorkstreamId.Value, out id);
                if (id > 0) workstream = ServiceInterfaceManager.STD_WKFCASETYPE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                if (workstream == null) workstream = new STD_WKFCASETYPE();

                workstream.STD_REGISTRY_ID = UserSession.CurrentRegistryId;
                workstream.CREATEDBY = workstream.UPDATEDBY = HttpContext.Current.User.Identity.Name;

                workstream.Name = txtWorkstreamName.Text;
                workstream.CODE = txtWorkstreamCode.Text;
                int order = 0;
                int.TryParse(txtWorkstreamSortOrder.Text, out order);
                workstream.SORT_ORDER = order;
                workstream.DESCRIPTION_TEXT = txtWorkstreamDescription.Text;
                workstream.AUTO_CREATE = chkAutoCreated.Checked;

                workstream.ID = ServiceInterfaceManager.STD_WKFCASETYPE_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, workstream);
                if (workstream.ID > 0)
                {
                    hideWorkstreamId.Value = workstream.ID.ToString();
                    strResult = "Save successful<br /><br />";
                    return true;
                }
                else
                {
                    strResult = "Error saving Workstream, please try again<br /><br />";
                }
            }
           // }
           //else
           // {
           //   strResult = "<ul><li>Workstream Name is Required</li></ul>";

            return false;
        }

        private void LoadForm(int id)
        {
            ResetForm();

            STD_WKFCASETYPE workstream = ServiceInterfaceManager.STD_WKFCASETYPE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (workstream != null)
            {
                hideWorkstreamId.Value = workstream.ID.ToString();
                txtWorkstreamName.Text = workstream.Name;
                txtWorkstreamCode.Text = workstream.CODE;
                txtWorkstreamSortOrder.Text = workstream.SORT_ORDER.ToString();
                txtWorkstreamDescription.Text = workstream.DESCRIPTION_TEXT;
                chkAutoCreated.Checked = workstream.AUTO_CREATE.GetValueOrDefault();
            }
        }

        private void ResetForm()
        {
            hideWorkstreamId.Value = string.Empty;
            txtWorkstreamName.Text = string.Empty;
            txtWorkstreamCode.Text = string.Empty;
            txtWorkstreamSortOrder.Text = string.Empty;
            txtWorkstreamDescription.Text = string.Empty;
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                bool blnContinue = false;
                string strResult = string.Empty;

                if (pnlWorkstream.Visible)
                    blnContinue = SaveForm(ref strResult);
                else
                    blnContinue = true;

                if (blnContinue)
                    Response.Redirect("~/Cohorts/UDF.aspx", false);
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

                if (pnlWorkstream.Visible)
                    blnContinue = SaveForm(ref strResult);
                else
                    blnContinue = true;

                if (blnContinue)
                    Response.Redirect("~/Cohorts/Activity.aspx", false);
                else
                    lblResult.Text = strResult;
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
    }
}