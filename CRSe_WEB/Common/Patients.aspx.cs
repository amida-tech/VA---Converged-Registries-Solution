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
    public partial class Patients : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);

                lblResult.Text = string.Empty;

                wmBirthDate.WatermarkText = "e.g. " + DateTime.Now.ToString("MM/dd/yyyy");

                if (UserSession == null || UserSession.CurrentRegistryId <= 0)
                {
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    if (ServiceInterfaceManager.USER_ROLES_GET_BY_REGISTRYID_USERNAME_SET_READONLY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId))
                    {
                        gridRegistry.Columns[0].Visible = linkPatientAdd.Visible = false;
                        SetReadOnly();
                    }

                    if (!Page.IsPostBack)
                    {
                        //BuildCommonMenu();

                        if (UserSession.PageMode == PageModes.Edit && (UserSession.CurrentReferralId > 0 || UserSession.CurrentPatientId > 0))
                        {
                            //After initial page load, reset page mode
                            UserSession.PageMode = PageModes.None;

                            pnlPatients.Visible = false;
                            pnlPatient.Visible = true;
                            pnlSearch.Visible = false;

                            if (UserSession.CurrentReferralId > 0)
                                LoadForm(UserSession.CurrentReferralId);
                            else if (UserSession.CurrentPatientId > 0)
                                LoadPatient(UserSession.CurrentPatientId);
                        }
                        else
                        {
                            dsRegistry.DataBind();
                            pnlPatients.Visible = true;
                            pnlPatient.Visible = pnlSearch.Visible = false;
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
            linkPatientAdd.Visible = false;
            btnAddProvider.Enabled = false;
            btnSave.Enabled = false;
            lblResult.Text = "You are not able to edit information on this page.<br /><br />";
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
                        REFERRAL r = ServiceInterfaceManager.REFERRAL_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (r != null)
                        {
                            UserSession.CurrentRegistryId = r.STD_REGISTRY_ID;
                            UserSession.CurrentReferralId = r.REFERRAL_ID;
                            UserSession.CurrentPatientId = r.PATIENT_ID;

                            if (r.PROVIDER_ID != null)
                                UserSession.CurrentProviderId = r.PROVIDER_ID.Value;

                            Response.Redirect("~/Common/Patient.aspx", false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                //throw ex;
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

        protected void LinkSelectProvider_Click(object sender, EventArgs e)
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

                            Response.Redirect("~/Common/Provider.aspx", false);
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
                        REFERRAL r = ServiceInterfaceManager.REFERRAL_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (r != null)
                        {
                            UserSession.CurrentReferralId = r.REFERRAL_ID;
                            UserSession.CurrentPatientId = r.PATIENT_ID;

                            if (r.PROVIDER_ID != null)
                                UserSession.CurrentProviderId = r.PROVIDER_ID.Value;

                            pnlPatients.Visible = false;
                            pnlPatient.Visible = true;
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
                        if (ServiceInterfaceManager.REFERRAL_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id))
                        {
                            lblResult.Text = "Delete successful<br /><br />";
                        }
                        else
                        {
                            lblResult.Text = "Error deleting Patient, please try again<br /><br />";
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

        protected void LinkPatientAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                PatientReferral.SearchType = "PATIENT";
                pnlPatients.Visible = false;
                pnlPatient.Visible = false;
                pnlSearch.Visible = true;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void PatientReferral_SearchCancelClicked(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                pnlPatients.Visible = true;
                pnlPatient.Visible = pnlSearch.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void PatientReferral_SelectClicked(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                int id = PatientReferral.ResultId;
                if (id > 0)
                {
                    if (PatientReferral.SearchType == "PATIENT")
                    {
                        LoadPatient(id);
                    }
                    else if (PatientReferral.SearchType == "PROVIDER")
                    {
                        LoadProvider(id);
                    }

                    pnlPatients.Visible = false;
                    pnlSearch.Visible = false;
                    pnlPatient.Visible = true;
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
            try
            {
                int id = 0;

                if (int.TryParse(hideResultId.Value, out id))
                {
                    int providerId = 0;
                    int.TryParse(hideProviderId.Value, out providerId);

                    if (SaveForm(id, providerId))
                    {
                        ResetForm();
                        pnlPatients.Visible = true;
                        pnlPatient.Visible = pnlSearch.Visible = false;

                        lblResult.Text = "Save successful<br /><br />";
                        gridRegistry.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The Patient you are saving already exists<br /><br />";
                else
                {
                    ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                    throw ex;
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ResetForm();
                pnlPatients.Visible = true;
                pnlPatient.Visible = pnlSearch.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void LoadForm(int id)
        {
            REFERRAL referral = ServiceInterfaceManager.REFERRAL_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (referral != null)
            {
                LoadPatient(referral.PATIENT_ID);
                if (referral.PROVIDER_ID != null)
                    LoadProvider(referral.PROVIDER_ID.Value);
            }
        }

        private void LoadPatient(int id)
        {
            PATIENT patient = ServiceInterfaceManager.PATIENT_GET_COMPLETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (patient != null)
            {
                hideResultId.Value = patient.PATIENT_ID.ToString();
                txtLastName.Text = patient.LAST_NAME;
                txtFirstName.Text = patient.FIRST_NAME;

                if (patient.BIRTH_DATE != null)
                    txtBirthDate.Text = patient.BIRTH_DATE.Value.ToString("MM/dd/yyyy");

                if (patient.SPATIENT != null)
                {
                    txtLastFour.Text = patient.SPATIENT.PatientLastFour;
                    txtGender.Text = patient.SPATIENT.Gender;
                    txtCity.Text = patient.SPATIENT.City;
                    txtState.Text = patient.SPATIENT.State;
                    txtPostalCode.Text = patient.SPATIENT.PostalCode;
                }
            }
        }

        private void LoadProvider(int id)
        {
            SStaff_SStaff provider = ServiceInterfaceManager.SStaff_SStaff_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (provider != null)
            {
                hideProviderId.Value = provider.Provider_ID.ToString();
                if (!string.IsNullOrEmpty(provider.LastName) && !string.IsNullOrEmpty(provider.FirstName))
                    txtProvider.Text = provider.LastName + ", " + provider.FirstName;
                else if (!string.IsNullOrEmpty(provider.LastName))
                    txtProvider.Text = provider.LastName;
                else if (!string.IsNullOrEmpty(provider.FirstName))
                    txtProvider.Text = provider.FirstName;
            }
        }

        private bool SaveForm(int patientId, int providerId)
        {
            bool objReturn = false;

            //if (ServiceInterfaceManager.REFERRAL_PATIENT_EXISTS(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, patientId))
            //{
            //    lblResult.Text = "The selected Patient has already been added to this Registry.<br /><br />";
            //}
            //else
            //{
                int referralId = ServiceInterfaceManager.REFERRAL_SAVE_MANUAL(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, patientId, providerId);

                if (referralId > 0)
                {
                    REFERRAL r = ServiceInterfaceManager.REFERRAL_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, referralId);
                    if (r != null)
                    {
                        UserSession.CurrentRegistryId = r.STD_REGISTRY_ID;
                        UserSession.CurrentReferralId = r.REFERRAL_ID;
                        UserSession.CurrentPatientId = r.PATIENT_ID;
                        UserSession.CurrentProviderId = r.PROVIDER_ID.GetValueOrDefault();
                    }

                    objReturn = true;
                }
                else
                {
                    lblResult.Text = "An error occurred while attempting to save, please try again.<br /><br />";
                }
            //}

            return objReturn;
        }

        private void ResetForm()
        {
            hideResultId.Value = string.Empty;
            txtLastFour.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtGender.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            hideProviderId.Value = string.Empty;
            txtProvider.Text = string.Empty;
        }

        protected void BtnAddProvider_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                PatientReferral.SearchType = "PROVIDER";
                pnlPatients.Visible = false;
                pnlPatient.Visible = false;
                pnlSearch.Visible = true;
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