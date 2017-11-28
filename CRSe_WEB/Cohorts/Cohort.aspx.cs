using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB.Cohorts
{
    public partial class Cohort : BasePage
    {
        private List<REGISTRY_COHORT_DATA> Cohort_Data_List
        {
            get
            {
                List<REGISTRY_COHORT_DATA> cohortDataList = null;

                if (ViewState["Cohort_Data_List"] == null)
                {
                    cohortDataList = ServiceInterfaceManager.REGISTRY_COHORT_DATA_GET_ALL_BY_REGISTRY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                    ViewState["Cohort_Data_List"] = cohortDataList;
                }
                else
                {
                    cohortDataList = ViewState["Cohort_Data_List"] as List<REGISTRY_COHORT_DATA>;
                }

                return cohortDataList;
            }
            set
            {
                ViewState["Cohort_Data_List"] = value;
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);

                lblRecordCount.Text = string.Empty;
                lblResult.Text = string.Empty;

                wmDobMin.WatermarkText = "e.g. " + DateTime.Now.ToString("MM/dd/yyyy");
                wmDobMax.WatermarkText = "e.g. " + DateTime.Now.ToString("MM/dd/yyyy");

                if (UserSession == null || UserSession.CurrentRegistryId <= 0)
                {
                    Response.Redirect("~/Cohorts/Default.aspx", false);
                }
                else
                {
                    //BuildCohortsMenu();
                    if (!Page.IsPostBack)
                    {
                        ResetForm();
                        LoadForm();
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnPreview_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                List<REGISTRY_COHORT_DATA> cohorts = Cohort_Data_List;
                if (cohorts != null)
                {
                    cohorts = cohorts.Where(data => data.SELECTED_FLAG == true).ToList();
                    int PopCount = ServiceInterfaceManager.REGISTRY_COHORT_DATA_GET_PREVIEW_COUNT(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, cohorts);
                    if (PopCount > 0)
                    {
                        lblRecordCount.Text = PopCount.ToString() + " records found for selected parameters<br /><br />";
                    }
                    else
                    {
                        lblRecordCount.Text = "Currently no Referrals are available for selected parameters<br /><br />";
                    }

                    mpePreview.Show();
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
                bool cohortsSaved = SaveCohorts();

                //Always attempt to save the Cohort parameters above
                //but don't overwrite other error messages (lblResult.Text)

                if (string.IsNullOrEmpty(lblResult.Text))
                {
                    if (cohortsSaved)
                        lblResult.Text = "Save successful<br /><br />";
                    else
                        lblResult.Text = "Error saving Cohort parameters, please try again<br /><br />";
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
                Response.Redirect("~/Cohorts/Cohort.aspx", false);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                ResetForm();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void RblScheduleAuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (rblScheduleAuto.SelectedIndex > 0)
                {
                    listScheduleAutoTime.Enabled = true;
                }
                else
                {
                    listScheduleAutoTime.ClearSelection();
                    listScheduleAutoTime.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                bool cohortsSaved = SaveCohorts();

                if (cohortsSaved)
                    Response.Redirect("~/Cohorts/Registry.aspx", false);
                else
                    lblResult.Text = "Error saving Cohort parameters, please try again<br /><br />";
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
                bool cohortsSaved = SaveCohorts();

                if (cohortsSaved)
                    Response.Redirect("~/Cohorts/FrameworkData.aspx", false);
                else
                    lblResult.Text = "Error saving Cohort parameters, please try again<br /><br />";
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkSchedule_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (pnlSchedule.Visible)
                {
                    linkSchedule.Text = "Show Schedule";
                    pnlSchedule.Visible = false;
                }
                else
                {
                    linkSchedule.Text = "Hide Schedule";
                    pnlSchedule.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnAddAll_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                foreach (ListItem li in listSource.Items)
                {
                    li.Selected = true;
                }

                MoveFromSource();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnAddOne_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                MoveFromSource();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnRemOne_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                MoveFromDestination();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnRemAll_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                foreach (ListItem li in listDestination.Items)
                {
                    li.Selected = true;
                }

                MoveFromDestination();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void ListDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                lblCategories.Text = string.Empty;
                listCategories.Items.Clear();

                if (listDestination.SelectedItem != null)
                {
                    lblCategories.Text = listDestination.SelectedItem.Text;

                    List<REGISTRY_COHORT_DATA> cohortDataList = Cohort_Data_List;
                    if (cohortDataList != null)
                    {
                        listCategories.DataValueField = "COHORT_TYPE_ID";
                        listCategories.DataTextField = "NAME";
                        listCategories.DataSource = cohortDataList.Select(data => data.STD_REGISTRY_COHORT_TYPES).Where(select => select.DESCRIPTION_TEXT.Contains(listDestination.SelectedItem.Text));
                        listCategories.DataBind();

                        if (listCategories.Items != null && listCategories.Items.Count > 0)
                            chkAll.Visible = true;
                        else
                            chkAll.Visible = false;

                        SelectCategories();
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void ListCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                List<REGISTRY_COHORT_DATA> cohortDataList = Cohort_Data_List;

                if (cohortDataList != null)
                {
                    foreach (ListItem li in listCategories.Items)
                    {
                        foreach (REGISTRY_COHORT_DATA rcd in cohortDataList)
                        {
                            if (li.Value == rcd.STD_REGISTRY_COHORT_TYPE_ID.ToString())
                            {
                                rcd.UPDATED = DateTime.Now;
                                rcd.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                                rcd.SELECTED_FLAG = li.Selected;
                                break;
                            }
                        }
                    }

                    Cohort_Data_List = cohortDataList;
                }

                CheckAll();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            List<REGISTRY_COHORT_DATA> cohortDataList = Cohort_Data_List;

            if (cohortDataList != null)
            {
                foreach (ListItem li in listCategories.Items)
                {
                    foreach (REGISTRY_COHORT_DATA rcd in cohortDataList)
                    {
                        if (li.Value == rcd.STD_REGISTRY_COHORT_TYPE_ID.ToString())
                        {
                            rcd.SELECTED_FLAG = li.Selected = chkAll.Checked;
                            break;
                        }
                    }
                }
            }
        }

        private bool SaveCohorts()
        {
            bool cohortsSaved = false;

            List<REGISTRY_COHORT_DATA> cohorts = Cohort_Data_List;
            if (cohorts != null)
            {
                if (ValidateDates())
                {
                    foreach (REGISTRY_COHORT_DATA rcd in cohorts)
                    {
                        if (rcd.STD_REGISTRY_COHORT_TYPES != null && rcd.STD_REGISTRY_COHORT_TYPES.CODE == "DOBMIN")
                        {
                            rcd.VALUE = string.Empty;

                            if (!string.IsNullOrEmpty(txtDobMin.Text))
                            {
                                DateTime dtDobMin = DateTime.MinValue;
                                if (DateTime.TryParse(txtDobMin.Text, out dtDobMin))
                                {
                                    rcd.VALUE = dtDobMin.ToString("yyyy-MM-dd");
                                    rcd.UPDATED = DateTime.Now;
                                    rcd.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                                    rcd.SELECTED_FLAG = true;
                                }
                            }
                        }
                        else if (rcd.STD_REGISTRY_COHORT_TYPES != null && rcd.STD_REGISTRY_COHORT_TYPES.CODE == "DOBMAX")
                        {
                            rcd.VALUE = string.Empty;

                            if (!string.IsNullOrEmpty(txtDobMax.Text))
                            {
                                DateTime dtDobMax = DateTime.MinValue;
                                if (DateTime.TryParse(txtDobMax.Text, out dtDobMax))
                                {
                                    rcd.VALUE = dtDobMax.ToString("yyyy-MM-dd");
                                    rcd.UPDATED = DateTime.Now;
                                    rcd.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                                    rcd.SELECTED_FLAG = true;
                                }
                            }
                        }
                    }

                    cohortsSaved = ServiceInterfaceManager.REGISTRY_COHORT_DATA_SAVE_LIST(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, cohorts);

                    SETTINGS setting = null;
                    setting = ServiceInterfaceManager.SETTINGS_GET_REGISTRYNAME(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "EtlScheduleManual");
                    if (setting == null)
                    {
                        setting = new SETTINGS();
                        setting.CREATED = DateTime.Now;
                        setting.CREATEDBY = HttpContext.Current.User.Identity.Name;
                        setting.NAME = "EtlScheduleManual";
                        setting.STD_REGISTRY_ID = UserSession.CurrentRegistryId;
                    }

                    setting.UPDATED = DateTime.Now;
                    setting.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                    setting.VALUE = rblScheduleManual.SelectedValue;
                    setting.CRS_SETTINGS_ID = ServiceInterfaceManager.SETTINGS_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, setting);

                    setting = ServiceInterfaceManager.SETTINGS_GET_REGISTRYNAME(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "EtlScheduleAuto");
                    if (setting == null)
                    {
                        setting = new SETTINGS();
                        setting.CREATED = DateTime.Now;
                        setting.CREATEDBY = HttpContext.Current.User.Identity.Name;
                        setting.NAME = "EtlScheduleAuto";
                        setting.STD_REGISTRY_ID = UserSession.CurrentRegistryId;
                    }

                    setting.UPDATED = DateTime.Now;
                    setting.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                    setting.VALUE = rblScheduleAuto.SelectedValue;
                    setting.CRS_SETTINGS_ID = ServiceInterfaceManager.SETTINGS_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, setting);

                    setting = ServiceInterfaceManager.SETTINGS_GET_REGISTRYNAME(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "EtlScheduleAutoTime");
                    if (setting == null)
                    {
                        setting = new SETTINGS();
                        setting.CREATED = DateTime.Now;
                        setting.CREATEDBY = HttpContext.Current.User.Identity.Name;
                        setting.NAME = "EtlScheduleAutoTime";
                        setting.STD_REGISTRY_ID = UserSession.CurrentRegistryId;
                    }

                    setting.UPDATED = DateTime.Now;
                    setting.UPDATEDBY = HttpContext.Current.User.Identity.Name;
                    setting.VALUE = listScheduleAutoTime.SelectedValue;
                    setting.CRS_SETTINGS_ID = ServiceInterfaceManager.SETTINGS_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, setting);
                }
            }
            return cohortsSaved;
        }

        private bool ValidateDates()
        {
            bool isValid = true;
            DateTime dtCohortDates;
            string error = "";

            if (txtDobMin.Text != "" && !DateTime.TryParse(txtDobMin.Text, out dtCohortDates))
            {
                isValid = false;
                error = String.Format("DOB Min is in an incorrect format. Please use this format: {0}  <br />", DateTime.Today.ToShortDateString());
            }

            if (txtDobMax.Text != "" && !DateTime.TryParse(txtDobMax.Text, out dtCohortDates))
            {
                isValid = false;
                error += String.Format("DOB Max is in an incorrect format. Please use this format: {0}", DateTime.Today.ToShortDateString());
            }

            lblResult.Text = error; //Nothing will be shown if no errors with dates format.
            return isValid;
        }

        private void ResetForm()
        {
            rblScheduleManual.ClearSelection();
            rblScheduleAuto.ClearSelection();
            listScheduleAutoTime.ClearSelection();
            listScheduleAutoTime.Enabled = false;

            linkSchedule.Text = "Show Schedule";
            pnlSchedule.Visible = false;

            txtDobMin.Text = txtDobMax.Text = string.Empty;

            listSource.Items.Clear();
            listDestination.Items.Clear();
            listCategories.Items.Clear();

            chkAll.Visible = false;

            //Populate Source List Box
            List<REGISTRY_COHORT_DATA> cohortDataList = Cohort_Data_List;
            if (cohortDataList != null)
            {
                listSource.DataSource = cohortDataList.Where(data => data.STD_REGISTRY_COHORT_TYPES.TABLE_NAME != "CUSTOM").GroupBy(where => where.STD_REGISTRY_COHORT_TYPES.DESCRIPTION_TEXT).Select(group => group.FirstOrDefault().STD_REGISTRY_COHORT_TYPES.DESCRIPTION_TEXT);
                listSource.DataBind();
            }
        }

        private void LoadForm()
        {
            SETTINGS setting = null;
            setting = ServiceInterfaceManager.SETTINGS_GET_REGISTRYNAME(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "EtlScheduleManual");
            if (setting != null)
                rblScheduleManual.SelectedValue = setting.VALUE;

            setting = ServiceInterfaceManager.SETTINGS_GET_REGISTRYNAME(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "EtlScheduleAuto");
            if (setting != null)
                rblScheduleAuto.SelectedValue = setting.VALUE;

            setting = ServiceInterfaceManager.SETTINGS_GET_REGISTRYNAME(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "EtlScheduleAutoTime");
            if (setting != null)
                listScheduleAutoTime.SelectedValue = setting.VALUE;

            if (rblScheduleAuto.SelectedIndex > 0)
                listScheduleAutoTime.Enabled = true;

            List<REGISTRY_COHORT_DATA> cohortDataList = Cohort_Data_List;

            if (cohortDataList != null)
            {
                foreach (REGISTRY_COHORT_DATA rcd in cohortDataList)
                {
                    if (rcd.STD_REGISTRY_COHORT_TYPES != null && rcd.STD_REGISTRY_COHORT_TYPES.CODE == "DOBMIN")
                    {
                        if (!string.IsNullOrEmpty(rcd.VALUE))
                        {
                            DateTime dtMin = DateTime.MinValue;
                            if (DateTime.TryParse(rcd.VALUE, out dtMin))
                                txtDobMin.Text = dtMin.ToString("MM/dd/yyyy");
                        }
                    }
                    else if (rcd.STD_REGISTRY_COHORT_TYPES != null && rcd.STD_REGISTRY_COHORT_TYPES.CODE == "DOBMAX")
                    {
                        if (!string.IsNullOrEmpty(rcd.VALUE))
                        {
                            DateTime dtMax = DateTime.MinValue;
                            if (DateTime.TryParse(rcd.VALUE, out dtMax))
                                txtDobMax.Text = dtMax.ToString("MM/dd/yyyy");
                        }
                    }
                }

                SelectSource();
            }
        }

        private void MoveFromSource()
        {
            int index = listDestination.Items.Count;

            for (int i = listSource.Items.Count - 1; i >= 0; i--)
            {
                if (listSource.Items[i].Selected)
                {
                    string category = listSource.Items[i].Text;
                    listDestination.Items.Insert(index, new ListItem(category, category));
                    listSource.Items.RemoveAt(i);
                }
            }

            lblCategories.Text = string.Empty;
            listCategories.Items.Clear();
        }

        private void MoveFromDestination()
        {
            int index = listSource.Items.Count;

            for (int i = listDestination.Items.Count - 1; i >= 0; i--)
            {
                if (listDestination.Items[i].Selected)
                {
                    string category = listDestination.Items[i].Text;
                    listSource.Items.Insert(index, new ListItem(category, category));
                    listDestination.Items.RemoveAt(i);

                    //Removing a category from the Destination list will automatically
                    //unselect all associated category list items
                    List<REGISTRY_COHORT_DATA> cohortDataList = Cohort_Data_List;

                    if (cohortDataList != null)
                    {
                        foreach (REGISTRY_COHORT_DATA rcd in cohortDataList)
                        {
                            if (rcd.STD_REGISTRY_COHORT_TYPES != null && rcd.STD_REGISTRY_COHORT_TYPES.DESCRIPTION_TEXT.Contains(category))
                            {
                                rcd.SELECTED_FLAG = false;
                            }
                        }
                    }
                }
            }

            lblCategories.Text = string.Empty;
            listCategories.Items.Clear();
        }

        private void SelectSource()
        {
            //Select appropriate Source items and move them to the Destination List

            List<REGISTRY_COHORT_DATA> cohortDataList = Cohort_Data_List;

            if (cohortDataList != null)
            {
                foreach (ListItem li in listSource.Items)
                {
                    foreach (REGISTRY_COHORT_DATA rcd in cohortDataList)
                    {
                        if (rcd.STD_REGISTRY_COHORT_TYPES != null && rcd.STD_REGISTRY_COHORT_TYPES.DESCRIPTION_TEXT.Contains(li.Text))
                        {
                            if (rcd.SELECTED_FLAG)
                            {
                                li.Selected = true;
                                break;
                            }
                        }
                    }
                }
            }

            MoveFromSource();
        }

        private void SelectCategories()
        {
            //Select appropriate Category list items

            List<REGISTRY_COHORT_DATA> cohortDataList = Cohort_Data_List;

            if (cohortDataList != null)
            {
                foreach (ListItem li in listCategories.Items)
                {
                    foreach (REGISTRY_COHORT_DATA rcd in cohortDataList)
                    {
                        if (li.Value == rcd.STD_REGISTRY_COHORT_TYPE_ID.ToString())
                        {
                            if (rcd.SELECTED_FLAG)
                                li.Selected = true;
                            else
                                li.Selected = false;

                            break;
                        }
                    }
                }
            }

            CheckAll();
        }

        private void CheckAll()
        {
            bool blnCheckAll = true;

            if (listCategories.Items != null && listCategories.Items.Count > 0)
            {
                foreach (ListItem li in listCategories.Items)
                {
                    if (!li.Selected)
                    {
                        blnCheckAll = false;
                        break;
                    }
                }
            }

            chkAll.Checked = blnCheckAll;
        }
    }
}