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
    public partial class Surveys : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);

                lblResult.Text = string.Empty;

                wmSurveyDate.WatermarkText = "e.g. " + DateTime.Now.ToString("MM/dd/yyyy");

                if (UserSession == null || UserSession.CurrentRegistryId <= 0)
                {
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    if (ServiceInterfaceManager.USER_ROLES_GET_BY_REGISTRYID_USERNAME_SET_READONLY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId))
                    {
                        gridRegistry.Columns[0].Visible = linkSurveyAdd.Visible = false;
                        SetReadOnly();
                    }

                    if (!Page.IsPostBack)
                    {
                        //BuildCommonMenu();

                        if (UserSession.PageMode == PageModes.Edit && UserSession.CurrentSurveyId > 0)
                        {
                            //After initial page load, reset page mode
                            UserSession.PageMode = PageModes.None;

                            pnlSurveys.Visible = false;
                            pnlSurvey.Visible = true;
                            LoadForm(UserSession.CurrentSurveyId);
                        }
                        else
                        {
                            dsRegistry.DataBind();
                            pnlSurveys.Visible = true;
                            pnlSurvey.Visible = false;
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
            linkSurveyAdd.Visible = false;
            lblResult.Text = "You will not be able to edit information on this page.<br /><br />";
            listSurveyName.Enabled = false;
            txtSurveyDate.ReadOnly = true;
            btnSave.Enabled = false;
            btnSelectPatient.Enabled = false;
        }

        protected void LinkSelectSurvey_Click(object sender, EventArgs e)
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
                        SURVEYS s = ServiceInterfaceManager.SURVEYS_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (s != null)
                        {
                            UserSession.CurrentSurveyId = s.SURVEYS_ID;

                            if (s.PATIENT_ID != null)
                                UserSession.CurrentPatientId = s.PATIENT_ID.Value;

                            if (s.PROVIDER_ID != null)
                                UserSession.CurrentProviderId = s.PROVIDER_ID.Value;

                            Response.Redirect("~/Common/Survey.aspx", false);
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
                        UserSession.CurrentProviderId = id;

                        Response.Redirect("~/Common/Provider.aspx", false);
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
                        SURVEYS s = ServiceInterfaceManager.SURVEYS_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (s != null)
                        {
                            UserSession.CurrentSurveyId = s.SURVEYS_ID;

                            if (s.PATIENT_ID != null)
                                UserSession.CurrentPatientId = s.PATIENT_ID.Value;

                            if (s.PROVIDER_ID != null)
                                UserSession.CurrentProviderId = s.PROVIDER_ID.Value;

                            pnlSurveys.Visible = false;
                            pnlSurvey.Visible = true;
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
                        if (ServiceInterfaceManager.SURVEYS_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id))
                        {
                            lblResult.Text = "Delete successful<br /><br />";
                        }
                        else
                        {
                            lblResult.Text = "Error deleting Survey, please try again<br /><br />";
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

        protected void LinkSurveyAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (UserSession.CurrentPatientId > 0)
                {
                    ResetForm();
                    pnlSurveys.Visible = false;
                    pnlSurvey.Visible = true;
                }
                else
                {
                    pnlSelectPatient.Visible = true;
                    pnlSurveys.Visible = false;
                    pnlSurvey.Visible = false;
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

                    pnlSurveys.Visible = true;
                    pnlSurvey.Visible = false;
                }
                else
                {
                    pnlSurveys.Visible = false;
                    pnlSurvey.Visible = true;
                }

                lblResult.Text = strResult;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The Survey you are saving already exists<br /><br />";
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
                pnlSurveys.Visible = true;
                pnlSurvey.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private bool SaveForm(ref string strResult)
        {
            SURVEYS survey = null;

            if (listSurveyName.SelectedIndex > 0)
            {
                if (string.IsNullOrEmpty(txtSurveyDate.Text))
                {
                    strResult = "<ul><li>Survey Date is Required</li></ul>";
                }
                else
                {
                    if (ValidateDates())
                    {
                        int id = 0;
                        if (!string.IsNullOrEmpty(hideSurveyId.Value)) int.TryParse(hideSurveyId.Value, out id);
                        if (id > 0) survey = ServiceInterfaceManager.SURVEYS_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (survey == null)
                        {
                            survey = new SURVEYS();
                            survey.SURVEY_STATUS = "NEW";
                        }

                        survey.CREATED = survey.UPDATED = DateTime.Now;
                        survey.CREATEDBY = survey.UPDATEDBY = HttpContext.Current.User.Identity.Name;

                        int patientId = 0;
                        int.TryParse(hidePatientId.Value, out patientId);
                        survey.PATIENT_ID = patientId;

                        int typeId = 0;
                        int.TryParse(listSurveyName.SelectedValue, out typeId);
                        survey.STD_SURVEY_TYPE_ID = typeId;

                        DateTime dtSurvey = DateTime.MinValue;
                        if (DateTime.TryParse(txtSurveyDate.Text, out dtSurvey))
                            survey.SURVEY_DATE = dtSurvey;

                        survey.SURVEYS_ID = ServiceInterfaceManager.SURVEYS_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, survey);
                        if (survey.SURVEYS_ID > 0)
                        {
                            hideSurveyId.Value = survey.SURVEYS_ID.ToString();
                            strResult = "Save successful<br /><br />";
                            return true;
                        }
                        else
                        {
                            strResult = "Error saving Survey, please try again<br /><br />";
                        }
                    }
                    else
                    {
                        strResult = lblResult.Text + "<br /><br />";
                    }
                }
            }
            else
            {
                strResult = "<ul><li>Please select an available Survey</li></ul>";
            }

            return false;
        }

        private void LoadForm(int id)
        {
            ResetForm();

            listSurveyName.Enabled = false;

            SURVEYS survey = ServiceInterfaceManager.SURVEYS_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (survey != null)
            {
                hideSurveyId.Value = survey.SURVEYS_ID.ToString();

                //TODO: Patient ID should not be null or 0 here, but may need to add logic
                //here at some point in case it is.
                if (survey.PATIENT_ID != null && survey.PATIENT_ID > 0)
                {
                    PATIENT p = ServiceInterfaceManager.PATIENT_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, survey.PATIENT_ID.Value);
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

                foreach (ListItem li in listSurveyName.Items)
                {
                    if (li.Value == survey.STD_SURVEY_TYPE_ID.ToString())
                    {
                        li.Selected = true;
                        break;
                    }
                }

                txtSurveyDate.Text = survey.SURVEY_DATE.ToString("MM/dd/yyyy");
            }
        }

        private bool ValidateDates()
        {
            bool isValid = true;
            DateTime dtSurvey;

            if (!DateTime.TryParse(txtSurveyDate.Text, out dtSurvey))
            {
                isValid = false;
                lblResult.Text = String.Format("Survey Date is in an incorrect format. Please use this format: {0}<br /><br />", DateTime.Today.ToShortDateString());
            }

            return isValid;
        }

        private void ResetForm()
        {
            hideSurveyId.Value = string.Empty;

            listSurveyName.ClearSelection();
            listSurveyName.Items.Clear();

            listSurveyName.Enabled = true;

            List<STD_SURVEY_TYPE> surveys = ServiceInterfaceManager.STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            listSurveyName.Items.Add(new ListItem("", "0"));
            listSurveyName.AppendDataBoundItems = true;
            if (surveys != null)
            {
                listSurveyName.DataSource = surveys;
                listSurveyName.DataBind();
            }

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

            txtSurveyDate.Text = string.Empty;
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