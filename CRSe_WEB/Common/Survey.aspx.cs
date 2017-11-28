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
    public partial class Survey : BasePage
    {
        private SURVEYS SURVEY
        {
            get 
            {
                SURVEYS survey = null;

                if (ViewState["SURVEY"] != null)
                {
                    survey = ViewState["SURVEY"] as SURVEYS;
                }
                else
                {
                    int surveysId = 0;

                    if (!string.IsNullOrEmpty(hideSurveyId.Value))
                        int.TryParse(hideSurveyId.Value.ToString(), out surveysId);
                    else
                    {
                        surveysId = UserSession.CurrentSurveyId;
                        hideSurveyId.Value = UserSession.CurrentSurveyId.ToString();
                    }
                    
                    if (surveysId > 0)
                        survey = ServiceInterfaceManager.SURVEYS_GET_FOR_SURVEY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, surveysId);

                    ViewState["SURVEY"] = survey;
                }

                return survey;
            }
            set 
            {
                ViewState["SURVEY"] = value;
            }
        }

        private List<SURVEY_RESULTS> RESULTS
        {
            get
            {
                List<SURVEY_RESULTS> results = null;

                if (ViewState["RESULTS"] != null)
                {
                    results = ViewState["RESULTS"] as List<SURVEY_RESULTS>;
                }
                else
                {
                    int surveysId = 0;

                    if (!string.IsNullOrEmpty(hideSurveyId.Value))
                        int.TryParse(hideSurveyId.Value.ToString(), out surveysId);
                    else
                    {
                        surveysId = UserSession.CurrentSurveyId;
                        hideSurveyId.Value = UserSession.CurrentSurveyId.ToString();
                    }

                    if (surveysId > 0)
                        results = ServiceInterfaceManager.SURVEY_RESULTS_GET_ALL_BY_SURVEY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, surveysId);

                    ViewState["RESULTS"] = results;
                }

                return results;
            }
            set
            {
                ViewState["RESULTS"] = value;
            }
        }

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
                else if (UserSession.CurrentSurveyId <= 0)
                {
                    Response.Redirect("~/Common/Surveys.aspx", false);
                }
                else
                {
                    if (ServiceInterfaceManager.USER_ROLES_GET_BY_REGISTRYID_USERNAME_SET_READONLY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId))
                    {
                        SetReadOnly();
                    }
                    if (!Page.IsPostBack)
                    {
                        //BuildCommonMenu();
                    }

                    SetupForm();
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
            lblResult.Text = "You are not able to edit information on this page.<br /><br />";
            btnSave.Enabled = false;
            btnSaveComplete.Enabled = false;
            linkEdit.Visible = false;
        }

        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                UserSession.PageMode = PageModes.Edit;
                Response.Redirect("~/Common/Surveys.aspx", false);
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
                if (SaveForm())
                {
                    SURVEYS survey = SURVEY;
                    if (survey != null)
                    {
                        survey.SURVEY_STATUS = "IN PROGRESS";
                        survey.SURVEYS_ID = ServiceInterfaceManager.SURVEYS_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, survey);
                        SURVEY = survey;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnSaveComplete_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (SaveForm())
                {
                    SURVEYS survey = SURVEY;
                    if (survey != null)
                    {
                        survey.SURVEY_STATUS = "COMPLETE";
                        survey.SURVEYS_ID = ServiceInterfaceManager.SURVEYS_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, survey);
                        SURVEY = survey;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                UserSession.CurrentSurveyId = 0;
                Response.Redirect("~/Common/Surveys.aspx", false);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void SetupForm()
        {
            tblForm.Visible = false;

            viewPatient.LoadForm(UserSession.CurrentPatientId);

            SURVEYS survey = SURVEY;
            if (survey != null)
            {
                tblForm.Visible = true;
                
                if (survey.STD_SURVEY_TYPE != null)
                    lblPageTitle.Text = survey.STD_SURVEY_TYPE.NAME;

                List<SURVEY_RESULTS> results = RESULTS;
                if (results != null)
                {
                    //Select distinct question ids
                    List<Int32> questionIds = results.Select(data => data.STD_QUESTION_ID).Distinct().ToList();
                    if (questionIds != null && questionIds.Count > 0)
                    {
                        TableCell newCell = null;
                        TableRow newRow = null;
                        int rowIndex = 0;

                        foreach (Int32 questionId in questionIds)
                        {
                            List<SURVEY_RESULTS> questions = results.Where(data => data.STD_QUESTION_ID == questionId).ToList();
                            if (questions != null && questions.Count > 0)
                            {
                                Label lbl = new Label();

                                //Add question number and text to table
                                STD_QUESTION stdQuestion = questions.First().STD_QUESTION;
                                if (stdQuestion != null)
                                {
                                    lbl.ID = "lbl" + stdQuestion.ID.ToString();
                                    if (!string.IsNullOrEmpty(stdQuestion.QUESTION_NUMBER))
                                        lbl.Text = stdQuestion.QUESTION_NUMBER + ") " + stdQuestion.QUESTION_TEXT;
                                    else
                                        lbl.Text = stdQuestion.QUESTION_TEXT;

                                    newCell = new TableCell();
                                    newCell.Controls.Add(lbl);

                                    newRow = new TableRow();
                                    newRow.Cells.Add(newCell);

                                    tblForm.Rows.AddAt(rowIndex, newRow);
                                    rowIndex++;

                                    if (questions.Count > 1)
                                    {
                                        RadioButtonList rbl = new RadioButtonList();
                                        rbl.ID = "rbl" + stdQuestion.ID.ToString();

                                        foreach (SURVEY_RESULTS question in questions)
                                        {
                                            if (question.STD_QUESTION_CHOICE != null)
                                            {
                                                ListItem li = new ListItem(question.STD_QUESTION_CHOICE.CHOICE_TEXT, question.SURVEY_RESULT_ID.ToString());

                                                if (!Page.IsPostBack)
                                                {
                                                    li.Selected = question.SELECTED_FLAG;
                                                }
                                                else
                                                {
                                                    if (Request != null && Request.Form != null && Request.Form["ctl00$MainContent$" + rbl.ID] != null)
                                                    {
                                                        if (Request.Form["ctl00$MainContent$" + rbl.ID].ToString() == li.Value)
                                                            li.Selected = true;
                                                    }
                                                }

                                                rbl.Items.Add(li);
                                            }
                                        }

                                        newCell = new TableCell();
                                        newCell.Controls.Add(rbl);

                                        newRow = new TableRow();
                                        newRow.Cells.Add(newCell);

                                        tblForm.Rows.AddAt(rowIndex, newRow);
                                        rowIndex++;
                                    }
                                    else
                                    {
                                        SURVEY_RESULTS question = questions.First();
                                        if (question != null)
                                        {
                                            TextBox txt = new TextBox();
                                            txt.ID = "txt" + question.SURVEY_RESULT_ID.ToString();
                                            lbl.AssociatedControlID = txt.ID;
                                            txt.ToolTip = "Enter a value for Question " + stdQuestion.QUESTION_NUMBER;

                                            if (!Page.IsPostBack)
                                                txt.Text = question.RESULT_TEXT;
                                            else
                                            {
                                                if (Request != null && Request.Form != null && Request.Form["ctl00$MainContent$" + txt.ID] != null)
                                                    txt.Text = Request.Form["ctl00$MainContent$" + txt.ID].ToString();
                                            }

                                            newCell = new TableCell();
                                            newCell.Controls.Add(txt);

                                            newRow = new TableRow();
                                            newRow.Cells.Add(newCell);

                                            tblForm.Rows.AddAt(rowIndex, newRow);
                                            rowIndex++;
                                        }
                                    }

                                    //Add blank row/cell
                                    newCell = new TableCell();
                                    newCell.Text = "&nbsp;";

                                    newRow = new TableRow();
                                    newRow.Cells.Add(newCell);

                                    tblForm.Rows.AddAt(rowIndex, newRow);
                                    rowIndex++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool SaveForm()
        {
            bool objReturn = false;

            //Retrieve results from ViewState
            List<SURVEY_RESULTS> results = RESULTS;
            if (results == null)
            {
                //TODO: Should not be null, however if it is reload everything based on Survey ID

                //int id = 0;
                //int.TryParse(hideSurveyId.Value.ToString(), out id);
                //if (id > 0)
                //{
                //}
            }

            if (results != null)
            {
                if (tblForm.Rows != null)
                {
                    foreach (TableRow row in tblForm.Rows)
                    {
                        if (row.Cells != null && row.Cells.Count > 0)
                        {
                            if (row.Cells[0].Controls != null && row.Cells[0].Controls.Count > 0)
                            {
                                //if (row.Cells[0].Controls[0] is Label)
                                //{
                                //    Label ctrl = row.Cells[0].Controls[0] as Label;
                                //    if (ctrl != null)
                                //    {
                                //    }
                                //}
                                //else 
                                if (row.Cells[0].Controls[0] is RadioButtonList)
                                {
                                    RadioButtonList ctrl = row.Cells[0].Controls[0] as RadioButtonList;
                                    if (ctrl != null && ctrl.Items != null && ctrl.Items.Count > 0)
                                    {
                                        foreach (ListItem li in ctrl.Items)
                                        {
                                            int resultId = 0;
                                            if (int.TryParse(li.Value, out resultId))
                                            {
                                                foreach (SURVEY_RESULTS result in results)
                                                {
                                                    if (result.SURVEY_RESULT_ID == resultId)
                                                        result.SELECTED_FLAG = li.Selected;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (row.Cells[0].Controls[0] is TextBox)
                                {
                                    TextBox ctrl = row.Cells[0].Controls[0] as TextBox;
                                    if (ctrl != null)
                                    {
                                        int resultId = 0;
                                        if (int.TryParse(ctrl.ID.Replace("txt", ""), out resultId))
                                        {
                                            foreach (SURVEY_RESULTS result in results)
                                            {
                                                if (result.SURVEY_RESULT_ID == resultId)
                                                    result.RESULT_TEXT = ctrl.Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (ServiceInterfaceManager.SURVEY_RESULTS_SAVE_ALL(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, results))
                {
                    RESULTS = results;
                    lblResult.Text = "Save Successful<br /><br />";
                    objReturn = true;
                }
                else
                {
                    lblResult.Text = "Error saving Survey values, please try again.<br /><br />";
                    objReturn = false;
                }
            }

            return objReturn;
        }
    }
}