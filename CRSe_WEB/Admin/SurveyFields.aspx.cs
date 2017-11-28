using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB.Admin
{
    public partial class SurveyFields : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);

                lblResult.Text = string.Empty;

                if (UserSession == null || UserSession.CurrentSurveyId <= 0)
                {
                    Response.Redirect("~/Admin/Survey.aspx", false);
                }
                else
                {
                    //BuildAdminMenu();
                    if (!Page.IsPostBack)
                    {
                        txtQuestionText.Attributes.Add("maxlength", txtQuestionText.MaxLength.ToString());
                        txtChoiceText.Attributes.Add("maxlength", txtChoiceText.MaxLength.ToString());

                        pnlSurveyFields.Visible = true;
                        pnlSurveyField.Visible = false;
                        pnlFieldChoices.Visible = false;
                        pnlFieldChoice.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkSurveyFieldAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                ResetForm();
                pnlSurveyFields.Visible = false;
                pnlSurveyField.Visible = true;
                pnlFieldChoices.Visible = false;
                pnlFieldChoice.Visible = false;
                gridFieldChoices.DataBind();
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
                        pnlSurveyFields.Visible = false;
                        pnlSurveyField.Visible = true;
                        pnlFieldChoices.Visible = true;
                        pnlFieldChoice.Visible = false;
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
                        ServiceInterfaceManager.STD_QUESTION_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        gridSurveyFields.DataBind();
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
                    gridSurveyFields.DataBind();

                    pnlSurveyFields.Visible = false;
                    pnlSurveyField.Visible = true;
                    pnlFieldChoices.Visible = true;
                    pnlFieldChoice.Visible = false;
                }
                else
                {
                    pnlSurveyFields.Visible = false;
                    pnlSurveyField.Visible = true;
                    pnlFieldChoices.Visible = false;
                    pnlFieldChoice.Visible = false;
                }

                lblResult.Text = strResult;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The Survey Field you are saving already exists<br /><br />";
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
                pnlSurveyFields.Visible = true;
                pnlSurveyField.Visible = false;
                pnlFieldChoices.Visible = false;
                pnlFieldChoice.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private bool SaveForm(ref string strResult)
        {
            int oldQuestionID = 0;

            STD_QUESTION question = null;
                
            if (string.IsNullOrEmpty(txtQuestionNumber.Text))
            {
                 strResult = "Question Number is Required<br /><br />";
            }
            else if (string.IsNullOrEmpty(txtSortOrder.Text))
            {
                 strResult = "Sort Order is Required<br /><br />";
            }
            else if (string.IsNullOrEmpty(txtQuestionText.Text))
            {
                strResult = "Question Text is Required<br /><br />";
            }
            else
            {
                int id = 0;
                if (!string.IsNullOrEmpty(hideSurveyFieldId.Value)) int.TryParse(hideSurveyFieldId.Value, out id);
                if (id > 0) question = ServiceInterfaceManager.STD_QUESTION_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                if (question == null)
                    question = new STD_QUESTION();
                else
                {
                    //If text changes, INACTIVATE current question and save a new one
                    if (txtQuestionText.Text != question.QUESTION_TEXT)
                    {
                        oldQuestionID = question.ID;

                        ServiceInterfaceManager.STD_QUESTION_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, question.ID);
                        question = new STD_QUESTION();
                    }
                }

                question.STD_SURVEY_TYPE_ID = UserSession.CurrentSurveyId;
                question.CREATEDBY = question.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                question.INACTIVE_FLAG = false;

                question.QUESTION_NUMBER = txtQuestionNumber.Text;
                int sortOrder = 0;
                if (int.TryParse(txtSortOrder.Text, out sortOrder)) question.SORT_ORDER = sortOrder;
                question.QUESTION_TEXT = txtQuestionText.Text;

                question.ID = ServiceInterfaceManager.STD_QUESTION_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, question);
                if (question.ID > 0)
                {
                    hideSurveyFieldId.Value = question.ID.ToString();
                    strResult = "Save successful<br /><br />";

                    if (oldQuestionID > 0)
                        ServiceInterfaceManager.STD_QUESTION_COPY_CHOICES(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, oldQuestionID, question.ID);

                    return true;
                }
                else
                {
                    strResult = "Error saving Survey Field, please try again<br /><br />";
                }
            }
            //else
            //{
            //   strResult = "<ul><li>Question text is Required</li></ul>";
            // }
            
            return false;
        }

        private void LoadForm(int id)
        {
            ResetForm();

            STD_QUESTION question = ServiceInterfaceManager.STD_QUESTION_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (question != null)
            {
                hideSurveyFieldId.Value = question.ID.ToString();
                txtQuestionNumber.Text = question.QUESTION_NUMBER;
                txtSortOrder.Text = question.SORT_ORDER.GetValueOrDefault().ToString();
                txtQuestionText.Text = question.QUESTION_TEXT;

                gridFieldChoices.DataBind();
            }
        }

        private void ResetForm()
        {
            hideSurveyFieldId.Value = string.Empty;
            txtQuestionNumber.Text = string.Empty;
            txtSortOrder.Text = string.Empty;
            txtQuestionText.Text = string.Empty;
        }

        protected void DsSurveyFields_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                string searchColumn = ddlSearch.SelectedValue;
                string searchText = txtSearch.Text;

                e.InputParameters.Clear();
                e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                e.InputParameters.Add("CURRENT_REGISTRY_ID", UserSession.CurrentRegistryId);
                e.InputParameters.Add("STD_SURVEY_TYPE_ID", UserSession.CurrentSurveyId.ToString());
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
                gridSurveyFields.DataBind();
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
                gridSurveyFields.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void DsFieldChoices_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                string searchColumn = ddlFilter.SelectedValue;
                string searchText = txtFilterChoices.Text;

                int id = 0;
                int.TryParse(hideSurveyFieldId.Value, out id);

                if (id > 0)
                {
                    e.InputParameters.Clear();
                    e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                    e.InputParameters.Add("CURRENT_REGISTRY_ID", UserSession.CurrentRegistryId);
                    e.InputParameters.Add("STD_QUESTION_ID", id);
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

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                gridFieldChoices.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnClearFieldChoices_Click(object sender, EventArgs e)
        {
            txtFilterChoices.Text = "";
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                gridFieldChoices.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkFieldChoiceAdd_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                ResetChoiceForm();
                pnlSurveyFields.Visible = false;
                pnlSurveyField.Visible = false;
                pnlFieldChoices.Visible = false;
                pnlFieldChoice.Visible = true;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkEditChoice_Click(object sender, EventArgs e)
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
                        LoadChoiceForm(id);
                        pnlSurveyFields.Visible = false;
                        pnlSurveyField.Visible = false;
                        pnlFieldChoices.Visible = false;
                        pnlFieldChoice.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkDeleteChoice_Click(object sender, EventArgs e)
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
                        ServiceInterfaceManager.STD_QUESTION_CHOICE_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        gridFieldChoices.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnSaveChoice_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                string strResult = string.Empty;

                if (SaveChoiceForm(ref strResult))
                {
                    gridFieldChoices.DataBind();

                    pnlSurveyFields.Visible = false;
                    pnlSurveyField.Visible = true;
                    pnlFieldChoices.Visible = true;
                    pnlFieldChoice.Visible = false;
                }
                else
                {
                    pnlSurveyFields.Visible = false;
                    pnlSurveyField.Visible = true;
                    pnlFieldChoices.Visible = false;
                    pnlFieldChoice.Visible = true;
                }

                lblResult.Text = strResult;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The Field Choice you are saving already exists<br /><br />";
                else
                {
                    ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                    throw ex;
                }
            }
        }

        protected void BtnCancelChoice_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                ResetChoiceForm();
                pnlSurveyFields.Visible = false;
                pnlSurveyField.Visible = true;
                pnlFieldChoices.Visible = true;
                pnlFieldChoice.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private bool SaveChoiceForm(ref string strResult)
        {
            STD_QUESTION_CHOICE choice = null;

               if (string.IsNullOrEmpty(txtChoiceName.Text))
                {
                    strResult = "Choice Name is Required<br /><br />";
                }
                else if (string.IsNullOrEmpty(txtChoiceSortOrder.Text))
                {
                    strResult = "Sort Order is Required<br /><br />";
                }
                else if (string.IsNullOrEmpty(txtChoiceText.Text))
                {
                    strResult = "Choice Text is Required<br /><br />";
                }
                else
                {
           // if (!string.IsNullOrEmpty(txtChoiceText.Text))
            
                int id = 0;
                if (!string.IsNullOrEmpty(hideFieldChoiceId.Value)) int.TryParse(hideFieldChoiceId.Value, out id);
                if (id > 0) choice = ServiceInterfaceManager.STD_QUESTION_CHOICE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                if (choice == null)
                    choice = new STD_QUESTION_CHOICE();
                else
                {
                    //If text changes, INACTIVATE current choice and save a new one
                    if (txtChoiceText.Text != choice.CHOICE_TEXT)
                    {
                        ServiceInterfaceManager.STD_QUESTION_CHOICE_DELETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, choice.STD_QUESTION_CHOICE_ID);
                        choice = new STD_QUESTION_CHOICE();
                    }
                }

                int fieldId = 0;
                if (string.IsNullOrEmpty(hideSurveyFieldId.Value) || !int.TryParse(hideSurveyFieldId.Value, out fieldId))
                {
                    if (SaveForm(ref strResult))
                    {
                        int.TryParse(hideSurveyFieldId.Value, out fieldId);
                        gridSurveyFields.DataBind();
                    }
                    else
                    {
                        strResult = "Error saving Survey Field and Field Choice, please save the Survey Field first before adding choices<br /><br />";
                        return false;
                    }
                }

                choice.STD_QUESTION_ID = fieldId;
                choice.CREATEDBY = choice.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                choice.INACTIVE_FLAG = false;

                choice.CHOICE_NAME = txtChoiceName.Text;
                int sortOrder = 0;
                if (int.TryParse(txtChoiceSortOrder.Text, out sortOrder)) choice.CHOICE_SORT_ORDER = sortOrder;
                choice.CHOICE_TEXT = txtChoiceText.Text;

                choice.STD_QUESTION_CHOICE_ID = ServiceInterfaceManager.STD_QUESTION_CHOICE_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, choice);
                if (choice.STD_QUESTION_CHOICE_ID > 0)
                {
                    hideFieldChoiceId.Value = choice.STD_QUESTION_CHOICE_ID.ToString();
                    strResult = "Save successful<br /><br />";
                    return true;
                }
                else
                {
                    strResult = "Error saving Field Choice, please try again<br /><br />";
                }
            
           //else
           // {
               // strResult = "<ul><li>Choice Name is Required</li></ul>";
            //}
        }
            return false;
        }

        private void LoadChoiceForm(int id)
        {
            ResetChoiceForm();

            STD_QUESTION_CHOICE choice = ServiceInterfaceManager.STD_QUESTION_CHOICE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (choice != null)
            {
                hideFieldChoiceId.Value = choice.STD_QUESTION_CHOICE_ID.ToString();
                txtChoiceName.Text = choice.CHOICE_NAME;
                txtChoiceSortOrder.Text = choice.CHOICE_SORT_ORDER.GetValueOrDefault().ToString();
                txtChoiceText.Text = choice.CHOICE_TEXT;
            }
        }

        private void ResetChoiceForm()
        {
            hideFieldChoiceId.Value = string.Empty;
            txtChoiceName.Text = string.Empty;
            txtChoiceSortOrder.Text = string.Empty;
            txtChoiceText.Text = string.Empty;
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                bool blnContinue = false;
                string strResult = string.Empty;

                if (pnlSurveyField.Visible)
                    blnContinue = SaveForm(ref strResult);
                else if (pnlFieldChoice.Visible)
                    blnContinue = SaveChoiceForm(ref strResult);
                else
                    blnContinue = true;

                if (blnContinue)
                    Response.Redirect("~/Admin/Survey.aspx", false);
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