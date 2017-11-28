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
    public partial class Workstreams : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);

                lblResult.Text = string.Empty;

                wmCaseStartDate.WatermarkText = "e.g. " + DateTime.Now.ToString("MM/dd/yyyy");
                wmCaseDueDate.WatermarkText = "e.g. " + DateTime.Now.ToString("MM/dd/yyyy");

                if (UserSession == null || UserSession.CurrentRegistryId <= 0)
                {
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    if (ServiceInterfaceManager.USER_ROLES_GET_BY_REGISTRYID_USERNAME_SET_READONLY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId))
                    {
                        gridRegistry.Columns[0].Visible = linkWorkstreamAdd.Visible = false;
                        SetReadOnly();
                    }

                    if (!Page.IsPostBack)
                    {
                        //BuildCommonMenu();

                        if (UserSession.PageMode == PageModes.Edit && UserSession.CurrentWorkstreamId > 0)
                        {
                            //After initial page load, reset page mode
                            UserSession.PageMode = PageModes.None;

                            pnlWorkstreams.Visible = false;
                            pnlWorkstream.Visible = true;
                            LoadForm(UserSession.CurrentWorkstreamId);
                        }
                        else
                        {
                            dsRegistry.DataBind();
                            pnlWorkstreams.Visible = true;
                            pnlWorkstream.Visible = false;
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

        private void SetReadOnly()
        {
            linkWorkstreamAdd.Visible = false;
            lblResult.Text = "You will not be able to edit information on this page.<br /><br />";
            listWorkstreamName.Enabled = false;
            txtCaseDueDate.ReadOnly = true;
            txtCaseNumber.ReadOnly = true;
            txtCaseStartDate.ReadOnly = true;
            btnSave.Enabled = false;
        }

        protected void LinkSelectWorkstream_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                UserSession.RefreshCommon();

                LinkButton lb = (LinkButton)sender;
                if (lb != null)
                {
                    int id = 0;
                    int.TryParse(lb.CommandArgument, out id);

                    if (id > 0)
                    {
                        WKF_CASE w = ServiceInterfaceManager.WKF_CASE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (w != null)
                        {
                            UserSession.CurrentWorkstreamId = w.WKF_CASE_ID;

                            if (w.REFERRAL_ID != null)
                                UserSession.CurrentReferralId = w.REFERRAL_ID.Value;

                            UserSession.CurrentPatientId = w.PATIENT_ID;

                            Response.Redirect("~/Common/Workstream.aspx", false);
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

        protected void LinkSelectPatient_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                UserSession.RefreshCommon();

                LinkButton lb = (LinkButton)sender;
                if (lb != null)
                {
                    int id = 0;
                    int.TryParse(lb.CommandArgument, out id);

                    if (id > 0)
                    {
                        UserSession.CurrentPatientId = id;

                        Response.Redirect("~/Common/Patient.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkSelectReferral_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                UserSession.RefreshCommon();

                LinkButton lb = (LinkButton)sender;
                if (lb != null)
                {
                    int id = 0;
                    int.TryParse(lb.CommandArgument, out id);

                    if (id > 0)
                    {
                        REFERRAL r = ServiceInterfaceManager.REFERRAL_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (r != null)
                        {
                            UserSession.CurrentRegistryId = r.STD_REGISTRY_ID;
                            UserSession.CurrentReferralId = r.REFERRAL_ID;
                            UserSession.CurrentPatientId = r.PATIENT_ID;

                            if (r.PROVIDER_ID != null)
                                UserSession.CurrentProviderId = r.PROVIDER_ID.Value;

                            Response.Redirect("~/Common/Referral.aspx", false);
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

        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                UserSession.RefreshCommon();

                LinkButton lb = (LinkButton)sender;
                if (lb != null)
                {
                    int id = 0;
                    int.TryParse(lb.CommandArgument, out id);

                    if (id > 0)
                    {
                        WKF_CASE w = ServiceInterfaceManager.WKF_CASE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (w != null)
                        {
                            UserSession.CurrentWorkstreamId = w.WKF_CASE_ID;

                            if (w.REFERRAL_ID != null)
                                UserSession.CurrentReferralId = w.REFERRAL_ID.Value;

                            UserSession.CurrentPatientId = w.PATIENT_ID;

                            pnlWorkstreams.Visible = false;
                            pnlWorkstream.Visible = true;
                            LoadForm(id);
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

        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                UserSession.RefreshCommon();

                LinkButton lb = (LinkButton)sender;
                if (lb != null)
                {
                    int id = 0;
                    int.TryParse(lb.CommandArgument, out id);

                    if (id > 0)
                    {
                        if (ServiceInterfaceManager.WKF_CASE_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id))
                        {
                            lblResult.Text = "Delete successful<br /><br />";
                        }
                        else
                        {
                            lblResult.Text = "Error deleting Work Stream, please try again<br /><br />";
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

        protected void LinkWorkstreamAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (UserSession.CurrentPatientId > 0)
                {
                    ResetForm();
                    pnlWorkstreams.Visible = false;
                    pnlWorkstream.Visible = true;
                }
                else
                {
                    pnlSelectPatient.Visible = true;
                    pnlWorkstreams.Visible = false;
                    pnlWorkstream.Visible = false;
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
                pnlWorkstreams.Visible = true;
                pnlWorkstream.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private bool SaveForm(ref string strResult)
        {
            WKF_CASE workstream = null;

            if (listWorkstreamName.SelectedIndex > 0)
            {
                if (ValidateDates())
                {
                    if (string.IsNullOrEmpty(txtCaseNumber.Text))
                    {
                        strResult = "Case Number is Required<br /><br />";
                    }
                    else
                    {
                        int id = 0;
                        if (!string.IsNullOrEmpty(hideWorkstreamId.Value)) int.TryParse(hideWorkstreamId.Value, out id);
                        if (id > 0) workstream = ServiceInterfaceManager.WKF_CASE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (workstream == null) workstream = new WKF_CASE();

                        workstream.CREATED = workstream.UPDATED = DateTime.Now;
                        workstream.CREATEDBY = workstream.UPDATEDBY = HttpContext.Current.User.Identity.Name;

                        int patientId = 0;
                        int.TryParse(hidePatientId.Value, out patientId);
                        workstream.PATIENT_ID = patientId;

                        int referralId = 0;
                        int.TryParse(hideReferralId.Value, out referralId);
                        workstream.REFERRAL_ID = referralId;

                        int typeId = 0;
                        int.TryParse(listWorkstreamName.SelectedValue, out typeId);
                        workstream.STD_WKFCASETYPE_ID = typeId;

                        workstream.CASE_NUMBER = txtCaseNumber.Text;

                        DateTime dtStart = DateTime.MinValue;
                        if (DateTime.TryParse(txtCaseStartDate.Text, out dtStart))
                            workstream.CASE_START_DATE = dtStart;
                        else
                            workstream.CASE_START_DATE = null;

                        DateTime dtDue = DateTime.MinValue;
                        if (DateTime.TryParse(txtCaseDueDate.Text, out dtDue))
                            workstream.CASE_DUE_DATE = dtDue;
                        else
                            workstream.CASE_DUE_DATE = null;

                        workstream.WKF_CASE_ID = ServiceInterfaceManager.WKF_CASE_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, workstream);
                        if (workstream.WKF_CASE_ID > 0)
                        {
                            hideWorkstreamId.Value = workstream.WKF_CASE_ID.ToString();
                            strResult = "Save successful<br /><br />";
                            return true;
                        }
                        else
                        {
                            strResult = "Error saving Work Stream, please try again<br /><br />";
                        }
                    }
                }
                else
                {
                    strResult = lblResult.Text;
                }
            }
            else
            {
                strResult = "<ul><li>Please select an available Work Stream</li></ul>";
            }

            return false;
        }

        private bool ValidateDates()
        {
            //Only Validates if the txtboxes aren't empty. Not a required field, but is reuired formatting.
            bool isValid = true;
            string error = "";
            DateTime dtSurvey;

            if (txtCaseStartDate.Text != "" && !DateTime.TryParse(txtCaseStartDate.Text, out dtSurvey))
            {
                isValid = false;
                error = String.Format("Case Start Date is in an incorrect format. Please use this format: {0}", DateTime.Today.ToShortDateString());
            }
            if (txtCaseDueDate.Text != "" && !DateTime.TryParse(txtCaseDueDate.Text, out dtSurvey))
            {
                isValid = false;
                error += String.Format("Case Due Date is in an incorrect format. Please use this format: {0}", DateTime.Today.ToShortDateString());
            }

            lblResult.Text = error;
            return isValid;
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

        private void LoadForm(int id)
        {
            ResetForm();

            listWorkstreamName.Enabled = false;

            WKF_CASE workstream = ServiceInterfaceManager.WKF_CASE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (workstream != null)
            {
                hideWorkstreamId.Value = workstream.WKF_CASE_ID.ToString();

                //TODO: Patient ID should not be null or 0 here, but may need to add logic
                //here at some point in case it is.
                if (workstream.PATIENT_ID > 0)
                {
                    PATIENT p = ServiceInterfaceManager.PATIENT_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, workstream.PATIENT_ID);
                    if (p != null)
                    {
                        hidePatientId.Value = p.PATIENT_ID.ToString();

                        if (!string.IsNullOrEmpty(p.LAST_NAME) && !string.IsNullOrEmpty(p.FIRST_NAME))
                            txtPatientName.Text = p.LAST_NAME + ", " + p.FIRST_NAME;
                        else if (!string.IsNullOrEmpty(p.LAST_NAME))
                            txtPatientName.Text = p.LAST_NAME;
                        else if (!string.IsNullOrEmpty(p.FIRST_NAME))
                            txtPatientName.Text = p.FIRST_NAME;
                    }
                }

                if (workstream.REFERRAL_ID != null && workstream.REFERRAL_ID > 0)
                {
                    REFERRAL r = ServiceInterfaceManager.REFERRAL_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, workstream.REFERRAL_ID.Value);
                    if (r != null)
                    {
                        hideReferralId.Value = r.REFERRAL_ID.ToString();
                        if (r.REFERRAL_DATE != null)
                            txtReferralDate.Text = r.REFERRAL_DATE.Value.ToString("MM/dd/yyyy");
                    }
                }

                foreach (ListItem li in listWorkstreamName.Items)
                {
                    if (li.Value == workstream.STD_WKFCASETYPE_ID.ToString())
                    {
                        li.Selected = true;
                        break;
                    }
                }

                txtCaseNumber.Text = workstream.CASE_NUMBER;

                if (workstream.CASE_START_DATE != null)
                    txtCaseStartDate.Text = workstream.CASE_START_DATE.Value.ToString("MM/dd/yyyy");

                if (workstream.CASE_DUE_DATE != null)
                    txtCaseDueDate.Text = workstream.CASE_DUE_DATE.Value.ToString("MM/dd/yyyy");
            }
        }

        private void ResetForm()
        {
            hideWorkstreamId.Value = string.Empty;

            listWorkstreamName.ClearSelection();
            listWorkstreamName.Items.Clear();

            listWorkstreamName.Enabled = true;

            List<STD_WKFCASETYPE> cases = ServiceInterfaceManager.STD_WKFCASETYPE_GET_ALL_BY_REGISTRY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            listWorkstreamName.Items.Add(new ListItem("", "0"));
            listWorkstreamName.AppendDataBoundItems = true;
            if (cases != null)
            {
                listWorkstreamName.DataSource = cases;
                listWorkstreamName.DataBind();
            }

            if (UserSession.CurrentReferralId > 0)
            {
                REFERRAL r = ServiceInterfaceManager.REFERRAL_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentReferralId);
                if (r != null)
                {
                    hideReferralId.Value = r.REFERRAL_ID.ToString();

                    if (r.REFERRAL_DATE != null)
                        txtReferralDate.Text = r.REFERRAL_DATE.Value.ToString("MM/dd/yyyy");

                    if (UserSession.CurrentPatientId <= 0)
                        UserSession.CurrentPatientId = r.PATIENT_ID;
                }
            }
            else
                txtReferralDate.Text = string.Empty;

            if (UserSession.CurrentPatientId > 0)
            {
                PATIENT p = ServiceInterfaceManager.PATIENT_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentPatientId);
                if (p != null)
                {
                    hidePatientId.Value = p.PATIENT_ID.ToString();

                    if (!string.IsNullOrEmpty(p.LAST_NAME) && !string.IsNullOrEmpty(p.FIRST_NAME))
                        txtPatientName.Text = p.LAST_NAME + ", " + p.FIRST_NAME;
                    else if (!string.IsNullOrEmpty(p.LAST_NAME))
                        txtPatientName.Text = p.LAST_NAME;
                    else if (!string.IsNullOrEmpty(p.FIRST_NAME))
                        txtPatientName.Text = p.FIRST_NAME;
                }
            }
            else
                txtPatientName.Text = string.Empty;

            txtCaseNumber.Text = string.Empty;
            txtCaseStartDate.Text = string.Empty;
            txtCaseDueDate.Text = string.Empty;
        }
    }
}