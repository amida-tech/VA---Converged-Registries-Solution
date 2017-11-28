using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB.Controls
{
    public partial class PatientReferral : BaseControl
    {
        public delegate void ButtonClickedHandler(object sender, EventArgs e);

        public event ButtonClickedHandler SearchClicked;
        public event ButtonClickedHandler SearchCancelClicked;
        public event ButtonClickedHandler SelectClicked;

        protected virtual void OnSearch(EventArgs e)
        {
            if (SearchClicked != null)
                SearchClicked(this, e);
        }

        protected virtual void OnSearchCancel(EventArgs e)
        {
            if (SearchCancelClicked != null)
                SearchCancelClicked(this, e);
        }

        protected virtual void OnSelect(EventArgs e)
        {
            if (SelectClicked != null)
                SelectClicked(this, e);
        }

        public string SearchType
        {
            get { return hideSearchType.Value; }
            set { hideSearchType.Value = value; }
        }

        public int ResultId
        {
            get 
            {
                int resultId = 0;

                if (ViewState["ResultId"] != null)
                {
                    int.TryParse(ViewState["ResultId"].ToString(), out resultId);
                }

                return resultId;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //No need to log PAGE_LOAD here as the control will be available on .ASPX pages

            try
            {
                lblResult.Text = string.Empty;

                if (!this.Page.IsPostBack)
                {
                    ResetPage();
                }
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
                string strLastName = string.Empty;
                string strFirstName = string.Empty;
                string whitelist = "^[a-zA-Z ]+$";
                Regex pattern = new Regex(whitelist);

                if (!string.IsNullOrEmpty(txtSearchLastName.Text) && pattern.IsMatch(txtSearchLastName.Text))
                    strLastName = txtSearchLastName.Text.Trim();

                if (!string.IsNullOrEmpty(txtSearchFirstName.Text) && pattern.IsMatch(txtSearchFirstName.Text))
                    strFirstName += txtSearchFirstName.Text.Trim();

                if (string.IsNullOrEmpty(strLastName) && string.IsNullOrEmpty(strFirstName))
                {
                    gridResults.Visible = false;
                    lblResult.Text = "Please enter a valid last name and/or first name, no special characters are allowed<br /><br />";
                }
                else
                {
                    gridResults.Visible = true;
                    gridResults.DataBind();                   
                }

                OnSearch(e);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void Ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            try
            {
                string searchColumn = ddlSearch.SelectedValue;
                string searchText = txtSearch.Text;

                e.InputParameters.Clear();
                e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                e.InputParameters.Add("CURRENT_REGISTRY_ID", UserSession.CurrentRegistryId);
                e.InputParameters.Add("LAST_NAME", txtSearchLastName.Text);
                e.InputParameters.Add("FIRST_NAME", txtSearchFirstName.Text);
                e.InputParameters.Add("SEARCH_TYPE", hideSearchType.Value);
                e.InputParameters.Add("SEARCH_COLUMN", searchColumn);
                e.InputParameters.Add("SEARCH_TEXT", searchText);
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
                gridResults.DataBind();
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
                gridResults.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnSearchCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ResetPage();
                OnSearchCancel(e);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkSelect_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                if (lb != null)
                {
                    int id = 0;
                    if (int.TryParse(lb.CommandArgument, out id))
                    {
                        ViewState["ResultId"] = id;
                        ResetPage();
                        OnSelect(e);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void GridResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                LinkButton linkSelect = e.Row.FindControl("linkSelect") as LinkButton;
                if (linkSelect != null)
                    ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(linkSelect);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void ResetPage()
        {
            txtSearchLastName.Text = string.Empty;
            txtSearchFirstName.Text = string.Empty;
            gridResults.Visible = false;
        }
    }
}