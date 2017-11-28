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
    public partial class FrameworkData : BasePage
    {
        private List<REGISTRY_CORE_DATA> Core_Data_List
        {
            get
            {
                List<REGISTRY_CORE_DATA> coreDataList = null;

                if (ViewState["Core_Data_List"] == null)
                {
                    coreDataList = ServiceInterfaceManager.REGISTRY_CORE_DATA_GET_ALL_BY_REGISTRY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                    ViewState["Core_Data_List"] = coreDataList;
                }
                else
                {
                    coreDataList = ViewState["Core_Data_List"] as List<REGISTRY_CORE_DATA>;
                }

                return coreDataList;
            }
            set
            {
                ViewState["Core_Data_List"] = value;
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
                    Response.Redirect("~/Cohorts/Default.aspx", false);
                }
                else
                {
                    //BuildCohortsMenu();
                    if (!Page.IsPostBack)
                    {
                        ResetForm();
                        //LoadForm();
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
                bool coreSaved = false;

                List<REGISTRY_CORE_DATA> coreDataList = Core_Data_List;
                if (coreDataList != null)
                {
                    coreSaved = ServiceInterfaceManager.REGISTRY_CORE_DATA_SAVE_LIST(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, coreDataList);
                }

                //Always attempt to save the Core Data parameters above
                //but don't overwrite other error messages (lblResult.Text)

                if (string.IsNullOrEmpty(lblResult.Text))
                {
                    if (coreSaved)
                        lblResult.Text = "Save successful<br /><br />";
                    else
                        lblResult.Text = "Error saving Core Data parameters, please try again<br /><br />";
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
                Response.Redirect("~/Cohorts/FrameworkData.aspx", false);
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

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                bool coreSaved = false;

                List<REGISTRY_CORE_DATA> coreDataList = Core_Data_List;
                if (coreDataList != null)
                {
                    coreSaved = ServiceInterfaceManager.REGISTRY_CORE_DATA_SAVE_LIST(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, coreDataList);
                }

                if (coreSaved)
                    Response.Redirect("~/Cohorts/Cohort.aspx", false);
                else
                    lblResult.Text = "Error saving Core Data parameters, please try again<br /><br />";
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
                bool coreSaved = false;

                List<REGISTRY_CORE_DATA> coreDataList = Core_Data_List;
                if (coreDataList != null)
                {
                    coreSaved = ServiceInterfaceManager.REGISTRY_CORE_DATA_SAVE_LIST(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, coreDataList);
                }

                if (coreSaved)
                    Response.Redirect("~/Cohorts/UDF.aspx", false);
                else
                    lblResult.Text = "Error saving Core Data parameters, please try again<br /><br />";
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

                    List<REGISTRY_CORE_DATA> coreDataList = Core_Data_List;
                    if (coreDataList != null)
                    {
                        listCategories.DataValueField = "CORE_TYPE_ID";
                        listCategories.DataTextField = "NAME";
                        listCategories.DataSource = coreDataList.Select(data => data.STD_REGISTRY_CORE_TYPES).Where(select => select.DESCRIPTION_TEXT.Contains(listDestination.SelectedItem.Text));
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
                List<REGISTRY_CORE_DATA> coreDataList = Core_Data_List;

                if (coreDataList != null)
                {
                    foreach (ListItem li in listCategories.Items)
                    {
                        foreach (REGISTRY_CORE_DATA rcd in coreDataList)
                        {
                            if (li.Value == rcd.CORE_TYPE_ID.ToString())
                            {
                                rcd.SELECTED_FLAG = li.Selected;
                                break;
                            }
                        }
                    }

                    Core_Data_List = coreDataList;
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
            List<REGISTRY_CORE_DATA> coreDataList = Core_Data_List;

            if (coreDataList != null)
            {
                foreach (ListItem li in listCategories.Items)
                {
                    foreach (REGISTRY_CORE_DATA rcd in coreDataList)
                    {
                        if (li.Value == rcd.CORE_TYPE_ID.ToString())
                        {
                            rcd.SELECTED_FLAG = li.Selected = chkAll.Checked;
                            break;
                        }
                    }
                }
            }
        }

        private void ResetForm()
        {
            listSource.Items.Clear();
            listDestination.Items.Clear();
            listCategories.Items.Clear();

            chkAll.Visible = false;

            //Populate Source List Box
            List<REGISTRY_CORE_DATA> coreDataList = Core_Data_List;
            if (coreDataList != null)
            {
                listSource.DataSource = coreDataList.Where(data => data.STD_REGISTRY_CORE_TYPES.TABLE_NAME != "CUSTOM").GroupBy(where => where.STD_REGISTRY_CORE_TYPES.DESCRIPTION_TEXT).Select(group => group.FirstOrDefault().STD_REGISTRY_CORE_TYPES.DESCRIPTION_TEXT);
                listSource.DataBind();

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
                    List<REGISTRY_CORE_DATA> coreDataList = Core_Data_List;

                    if (coreDataList != null)
                    {
                        foreach (REGISTRY_CORE_DATA rcd in coreDataList)
                        {
                            if (rcd.STD_REGISTRY_CORE_TYPES != null && rcd.STD_REGISTRY_CORE_TYPES.DESCRIPTION_TEXT.Contains(category))
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

            List<REGISTRY_CORE_DATA> coreDataList = Core_Data_List;

            if (coreDataList != null)
            {
                foreach (ListItem li in listSource.Items)
                {
                    foreach (REGISTRY_CORE_DATA rcd in coreDataList)
                    {
                        if (rcd.STD_REGISTRY_CORE_TYPES != null && rcd.STD_REGISTRY_CORE_TYPES.DESCRIPTION_TEXT.Contains(li.Text))
                        {
                            li.Selected = rcd.SELECTED_FLAG;
                            break;
                        }
                    }
                }
            }

            MoveFromSource();
        }

        private void SelectCategories()
        {
            //Select appropriate Category list items

            List<REGISTRY_CORE_DATA> coreDataList = Core_Data_List;

            if (coreDataList != null)
            {
                foreach (ListItem li in listCategories.Items)
                {
                    foreach (REGISTRY_CORE_DATA rcd in coreDataList)
                    {
                        if (li.Value == rcd.CORE_TYPE_ID.ToString())
                        {
                            li.Selected = rcd.SELECTED_FLAG;
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