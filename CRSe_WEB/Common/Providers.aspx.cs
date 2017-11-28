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
    public partial class Providers : BasePage
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
                        gridRegistry.Columns[0].Visible = linkProviderAdd.Visible = false;
                        SetReadOnly();
                    }

                    if (!Page.IsPostBack)
                    {
                        //BuildCommonMenu();

                        if (UserSession.PageMode == PageModes.Edit && (UserSession.CurrentReferralId > 0 || UserSession.CurrentProviderId > 0))
                        {
                            //After initial page load, reset page mode
                            UserSession.PageMode = PageModes.None;

                            pnlProviders.Visible = false;
                            pnlProvider.Visible = true;
                            pnlSearch.Visible = false;

                            if (UserSession.CurrentReferralId > 0)
                                LoadForm(UserSession.CurrentReferralId);
                            else if (UserSession.CurrentProviderId > 0)
                                LoadProvider(UserSession.CurrentProviderId);
                        }
                        else
                        {
                            dsRegistry.DataBind();
                            pnlProviders.Visible = true;
                            pnlProvider.Visible = pnlSearch.Visible = false;
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
            linkProviderAdd.Visible = false;
            btnAddPatient.Visible = false;
            btnSave.Enabled = false;
            lblResult.Text = "You are not able to edit information on this page.<br /><br />";
        }

        protected void LinkSelect_Click(object sender, EventArgs e)
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

                            pnlProviders.Visible = false;
                            pnlProvider.Visible = true;
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
                            lblResult.Text = "Error deleting Provider, please try again<br /><br />";
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

        protected void LinkProviderAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                PatientReferral.SearchType = "PROVIDER";
                pnlProviders.Visible = false;
                pnlProvider.Visible = false;
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
                pnlProviders.Visible = true;
                pnlProvider.Visible = pnlSearch.Visible = false;
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
                    if (PatientReferral.SearchType == "PROVIDER")
                    {
                        LoadProvider(id);
                    }
                    else if (PatientReferral.SearchType == "PATIENT")
                    {
                        LoadPatient(id);
                    }

                    pnlProviders.Visible = false;
                    pnlSearch.Visible = false;
                    pnlProvider.Visible = true;
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
                    int patientId = 0;
                    int.TryParse(hidePatientId.Value, out patientId);
                    if (patientId <= 0)
                    {
                        lblResult.Text = "Patient is a Required Field<br /><br />";
                    }
                    else
                    {
                        if (SaveForm(patientId, id))
                        {
                            ResetForm();
                            pnlProviders.Visible = true;
                            pnlProvider.Visible = pnlSearch.Visible = false;

                            lblResult.Text = "Save successful<br /><br />";
                            gridRegistry.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The Provider you are saving already exists<br /><br />";
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
                pnlProviders.Visible = true;
                pnlProvider.Visible = pnlSearch.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
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
            PATIENT patient = ServiceInterfaceManager.PATIENT_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (patient != null)
            {
                hidePatientId.Value = patient.PATIENT_ID.ToString();
                if (!string.IsNullOrEmpty(patient.LAST_NAME) && !string.IsNullOrEmpty(patient.FIRST_NAME))
                    txtPatient.Text = patient.LAST_NAME + ", " + patient.FIRST_NAME;
                else if (!string.IsNullOrEmpty(patient.LAST_NAME))
                    txtPatient.Text = patient.LAST_NAME;
                else if (!string.IsNullOrEmpty(patient.FIRST_NAME))
                    txtPatient.Text = patient.FIRST_NAME;
            }
        }

        private void LoadProvider(int id)
        {
            SStaff_SStaff provider = ServiceInterfaceManager.SStaff_SStaff_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (provider != null)
            {
                hideResultId.Value = provider.Provider_ID.ToString();
                txtLastName.Text = provider.LastName;
                txtFirstName.Text = provider.FirstName;
                txtGender.Text = provider.Gender;
                txtCity.Text = provider.City;
                txtState.Text = provider.StateName;
                txtPostalCode.Text = provider.ZipCode;
            }
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
            hidePatientId.Value = string.Empty;
            txtPatient.Text = string.Empty;
        }

        protected void BtnAddPatient_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                PatientReferral.SearchType = "PATIENT";
                pnlProviders.Visible = false;
                pnlProvider.Visible = false;
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