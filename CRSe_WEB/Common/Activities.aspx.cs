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
    public partial class Activities : BasePage
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
                    if (ServiceInterfaceManager.USER_ROLES_GET_BY_REGISTRYID_USERNAME_SET_READONLY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId))
                    {
                        gridRegistry.Columns[0].Visible = linkActivityAdd.Visible = false;
                        SetReadOnly();
                    }

                    if (!Page.IsPostBack)
                    {
                        //BuildCommonMenu();

                        if (UserSession.PageMode == PageModes.Edit && UserSession.CurrentActivityId > 0)
                        {
                            //After initial page load, reset page mode
                            UserSession.PageMode = PageModes.None;

                            pnlActivities.Visible = false;
                            pnlActivity.Visible = true;
                            LoadForm(UserSession.CurrentActivityId);
                        }
                        else
                        {
                            dsRegistry.DataBind();
                            pnlActivities.Visible = true;
                            pnlActivity.Visible = false;
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
            gridRegistry.Columns[0].Visible = false;
            linkActivityAdd.Visible = false;
            listActivityName.Enabled = false;
            txtContactName.ReadOnly = true;
            txtContactEmail.ReadOnly = true;
            txtContactPhone.ReadOnly = true;
            txtBestCallBackTime.ReadOnly = true;
            txtAddressLine1.ReadOnly = true;
            txtAddressLine2.ReadOnly = true;
            txtAddressLine3.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtState.ReadOnly = true;
            txtPostalCode.ReadOnly = true;
            txtCountry.ReadOnly = true;
            txtInfoConveyed.ReadOnly = true;
            txtInfoReceived.ReadOnly = true;
            btnSave.Enabled = false;
            btnSelectWorkstream.Enabled = false;
            lblResult.Text = "You are not able to edit information on this page.<br /><br />";
        }

        protected void LinkSelectActivity_Click(object sender, EventArgs e)
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
                        WKF_CASE_ACTIVITY a = ServiceInterfaceManager.WKF_CASE_ACTIVITY_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (a != null)
                        {
                            UserSession.CurrentActivityId = a.WKF_CASE_ACTIVITY_ID;
                            
                            WKF_CASE c = ServiceInterfaceManager.WKF_CASE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, a.WKF_CASE_ID);
                            if (c != null)
                            {
                                UserSession.CurrentWorkstreamId = c.WKF_CASE_ID;

                                if (c.REFERRAL_ID != null)
                                    UserSession.CurrentReferralId = c.REFERRAL_ID.Value;

                                UserSession.CurrentPatientId = c.PATIENT_ID;
                            }

                            Response.Redirect("~/Common/Activity.aspx", false);
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
                        WKF_CASE_ACTIVITY a = ServiceInterfaceManager.WKF_CASE_ACTIVITY_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (a != null)
                        {
                            UserSession.CurrentActivityId = a.WKF_CASE_ACTIVITY_ID;
                            
                            WKF_CASE c = ServiceInterfaceManager.WKF_CASE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, a.WKF_CASE_ID);
                            if (c != null)
                            {
                                UserSession.CurrentWorkstreamId = c.WKF_CASE_ID;

                                if (c.REFERRAL_ID != null)
                                    UserSession.CurrentReferralId = c.REFERRAL_ID.Value;

                                UserSession.CurrentPatientId = c.PATIENT_ID;
                            }

                            pnlActivities.Visible = false;
                            pnlActivity.Visible = true;
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
                        if (ServiceInterfaceManager.WKF_CASE_ACTIVITY_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id))
                        {
                            lblResult.Text = "Delete successful<br /><br />";
                        }
                        else
                        {
                            lblResult.Text = "Error deleting Activity, please try again<br /><br />";
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

        protected void LinkActivityAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (UserSession.CurrentWorkstreamId > 0)
                {
                    ResetForm();
                    pnlActivities.Visible = false;
                    pnlActivity.Visible = true;
                }
                else
                {
                    pnlSelectWorkstream.Visible = true;
                    pnlActivities.Visible = false;
                    pnlActivity.Visible = false;
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
                pnlActivities.Visible = true;
                pnlActivity.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnSelectWorkstream_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                Response.Redirect("~/Common/Workstreams.aspx", false);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private bool SaveForm(ref string strResult)
        {
            WKF_CASE_ACTIVITY activity = null;

            if (listActivityName.SelectedIndex > 0)
            {
                if (string.IsNullOrEmpty(txtContactName.Text))
                {
                    strResult = "<ul><li>Contact Name is Required</li></ul>";
                }
                else if (string.IsNullOrEmpty(txtContactEmail.Text))
                {
                    strResult = "<ul><li>Contact Email is Required</li></ul>";
                }
                else if (string.IsNullOrEmpty(txtContactPhone.Text))
                {
                    strResult = "<ul><li>Contact Phone is Required</li></ul>";
                }
                else if (string.IsNullOrEmpty(txtBestCallBackTime.Text))
                {
                    strResult = "<ul><li>Best Call Back Time is Required</li></ul>";
                }
                else if (string.IsNullOrEmpty(txtAddressLine1.Text))
                {
                    strResult = "<ul><li>Address Line 1 is Required</li></ul>";
                }
                else if (string.IsNullOrEmpty(txtCity.Text))
                {
                    strResult = "<ul><li>City is Required</li></ul>";
                }
                else if (string.IsNullOrEmpty(txtState.Text))
                {
                    strResult = "<ul><li>State is Required</li></ul>";
                }
                else if (string.IsNullOrEmpty(txtPostalCode.Text))
                {
                    strResult = "<ul><li>Postal Codeis Required</li></ul>";
                }
                else if (string.IsNullOrEmpty(txtCountry.Text))
                {
                    strResult = "<ul><li>Country is Required</li></ul>";
                }
                else if (string.IsNullOrEmpty(txtInfoConveyed.Text))
                {
                    strResult = "<ul><li>Info Conveyed is Required</li></ul>";
                }
                else if (string.IsNullOrEmpty(txtInfoReceived.Text))
                {
                    strResult = "<ul><li>Info Received is Required</li></ul>";
                }
                else
                {
                    int id = 0;
                    if (!string.IsNullOrEmpty(hideActivityId.Value)) int.TryParse(hideActivityId.Value, out id);
                    if (id > 0) activity = ServiceInterfaceManager.WKF_CASE_ACTIVITY_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                    if (activity == null) activity = new WKF_CASE_ACTIVITY();

                    activity.CREATED = activity.UPDATED = DateTime.Now;
                    activity.CREATEDBY = activity.UPDATEDBY = HttpContext.Current.User.Identity.Name;

                    int caseId = 0;
                    int.TryParse(hideWorkstreamId.Value, out caseId);
                    activity.WKF_CASE_ID = caseId;

                    int typeId = 0;
                    int.TryParse(listActivityName.SelectedValue, out typeId);
                    activity.STD_WKFACTIVITYTYPE_ID = typeId;

                    activity.CONTACT_NAME = txtContactName.Text;
                    activity.CONTACT_EMAIL = txtContactEmail.Text;
                    activity.CONTACT_PHONE = txtContactPhone.Text;
                    activity.BEST_CALL_BACK_TIME = txtBestCallBackTime.Text;
                    activity.ADDRESS_LINE1 = txtAddressLine1.Text;
                    activity.ADDRESS_LINE2 = txtAddressLine2.Text;
                    activity.ADDRESS_LINE3 = txtAddressLine3.Text;
                    activity.CITY = txtCity.Text;
                    activity.STATE = txtState.Text;
                    activity.POSTAL_CODE = txtPostalCode.Text;
                    activity.COUNTRY = txtCountry.Text;
                    activity.INFO_CONVEYED_TEXT = txtInfoConveyed.Text;
                    activity.INFO_RECEIVED_TEXT = txtInfoReceived.Text;

                    activity.WKF_CASE_ID = ServiceInterfaceManager.WKF_CASE_ACTIVITY_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, activity);
                    if (activity.WKF_CASE_ID > 0)
                    {
                        hideActivityId.Value = activity.WKF_CASE_ID.ToString();
                        strResult = "Save successful<br /><br />";
                        return true;
                    }
                    else
                    {
                        strResult = "Error saving Activity, please try again<br /><br />";
                    }
                }
                }
            else
            {
                strResult = "<ul><li>Please select an available Activity</li></ul>";
            }
                
            return false;
        }

        private void LoadForm(int id)
        {
            ResetForm();

            listActivityName.Enabled = false;

            WKF_CASE_ACTIVITY activity = ServiceInterfaceManager.WKF_CASE_ACTIVITY_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (activity != null)
            {
                hideActivityId.Value = activity.WKF_CASE_ACTIVITY_ID.ToString();
                hideWorkstreamId.Value = activity.WKF_CASE_ID.ToString();

                foreach (ListItem li in listActivityName.Items)
                {
                    if (li.Value == activity.STD_WKFACTIVITYTYPE_ID.ToString())
                    {
                        li.Selected = true;
                        break;
                    }
                }

                txtContactName.Text = activity.CONTACT_NAME;
                txtContactEmail.Text = activity.CONTACT_EMAIL;
                txtContactPhone.Text = activity.CONTACT_PHONE;
                txtBestCallBackTime.Text = activity.BEST_CALL_BACK_TIME;
                txtAddressLine1.Text = activity.ADDRESS_LINE1;
                txtAddressLine2.Text = activity.ADDRESS_LINE2;
                txtAddressLine3.Text = activity.ADDRESS_LINE3;
                txtCity.Text = activity.CITY;
                txtState.Text = activity.STATE;
                txtPostalCode.Text = activity.POSTAL_CODE;
                txtCountry.Text = activity.COUNTRY;
                txtInfoConveyed.Text = activity.INFO_CONVEYED_TEXT;
                txtInfoReceived.Text = activity.INFO_RECEIVED_TEXT;
            }
        }

        private void ResetForm()
        {
            hideActivityId.Value = string.Empty;

            listActivityName.ClearSelection();
            listActivityName.Items.Clear();

            listActivityName.Enabled = true;

            WKF_CASE workstream = ServiceInterfaceManager.WKF_CASE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentWorkstreamId);
            if (workstream != null)
            {
                hideWorkstreamId.Value = workstream.WKF_CASE_ID.ToString();

                STD_WKFCASETYPE type = ServiceInterfaceManager.STD_WKFCASETYPE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, workstream.STD_WKFCASETYPE_ID);
                if (type != null)
                {
                    txtWorkstreamName.Text = type.Name;

                    List<STD_WKFACTIVITYTYPE> cases = ServiceInterfaceManager.STD_WKFACTIVITYTYPE_GET_ALL_BY_WORKSTREAM(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, type.ID);
                    listActivityName.Items.Add(new ListItem("", "0"));
                    listActivityName.AppendDataBoundItems = true;
                    if (cases != null)
                    {
                        listActivityName.DataSource = cases;
                        listActivityName.DataBind();
                    }
                }
            }
            
            txtContactName.Text = string.Empty;
            txtContactEmail.Text = string.Empty;
            txtContactPhone.Text = string.Empty;
            txtBestCallBackTime.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressLine2.Text = string.Empty;
            txtAddressLine3.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtInfoConveyed.Text = string.Empty;
            txtInfoReceived.Text = string.Empty;
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