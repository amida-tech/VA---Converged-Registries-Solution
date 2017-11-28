using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB.Reports
{
    public partial class Default : BasePage
    {
        private List<ReportItem> ReportItems
        {
            get
            {
                List<ReportItem> reportItems = null;

                if (ViewState["ReportItems"] == null)
                {
                    reportItems = ServiceInterfaceManager.REPORTS_GET_ALL_BY_USER_REGISTRY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                    ViewState["ReportItems"] = reportItems;
                }
                else
                {
                    reportItems = ViewState["ReportItems"] as List<ReportItem>;
                }

                return reportItems;
            }
            set
            {
                ViewState["ReportItems"] = value;
            }
        }

        private string SORT_DIRECTION
        {
            get
            {
                string sortDirection = string.Empty;

                if (ViewState["SORT_DIRECTION"] != null)
                    sortDirection = ViewState["SORT_DIRECTION"] as string;

                return sortDirection;
            }
            set
            {
                ViewState["SORT_DIRECTION"] = value;
            }
        }

        private string SORT_EXPRESSION
        {
            get
            {
                string sortExpression = string.Empty;

                if (ViewState["SORT_EXPRESSION"] != null)
                    sortExpression = ViewState["SORT_EXPRESSION"] as string;

                return sortExpression;
            }
            set
            {
                ViewState["SORT_EXPRESSION"] = value;
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

                if (UserSession.IsSystemRead || UserSession.IsRegistryRead)
                {
                    gridRegistry.Columns[0].Visible = linkReportAdd.Visible = false;
                }

                if (!Page.IsPostBack)
                {
                    List<ReportItem> reports = ReportItems;

                    //BuildReportMenu(reports);

                    gridRegistry.DataSource = reports;
                    gridRegistry.DataBind();

                    linkReportAdd.NavigateUrl = ReportBuilderUrl;

                    pnlReports.Visible = true;
                    pnlReport.Visible = false;
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
                LinkButton lb = (LinkButton)sender;
                if (lb != null)
                {
                    string id = lb.CommandArgument;

                    if (!string.IsNullOrEmpty(id))
                    {
                        pnlReports.Visible = false;
                        pnlReport.Visible = true;
                        LoadForm(id);
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
                //TODO
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
                    gridRegistry.DataSource = ReportItems;
                    gridRegistry.DataBind();

                    pnlReports.Visible = true;
                    pnlReport.Visible = false;
                }
                else
                {
                    pnlReports.Visible = false;
                    pnlReport.Visible = true;
                }

                lblResult.Text = strResult;
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
                pnlReports.Visible = true;
                pnlReport.Visible = false;
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private bool SaveForm(ref string strResult)
        {
            List<ReportItem> reportItems = ReportItems;

            if (reportItems != null && !string.IsNullOrEmpty(txtReportName.Text))
            {
                string itemPath = string.Empty;

                foreach (ReportItem item in reportItems)
                {
                    if (item.ID == hideReportId.Value)
                    {
                        itemPath = item.Path;
                        item.Description = txtReportDescription.Text;
                    }
                }

                if (ServiceInterfaceManager.REPORTS_UPDATE_ITEM_PROPERTIES(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, itemPath, txtReportDescription.Text))
                {
                    ReportItems = reportItems;
                    strResult = "Save successful<br /><br />";
                    return true;
                }
                else
                {
                    strResult = "Error saving Report, please try again<br /><br />";
                }
            }
            else
            {
                strResult = "<ul><li>Please enter a Report Name</li></ul>";
            }

            return false;
        }

        private void LoadForm(string id)
        {
            ResetForm();

            ReportItem reportItem = null;

            if (ReportItems != null)
            {
                foreach (ReportItem item in ReportItems)
                {
                    if (item.ID == id)
                    {
                        reportItem = item;
                    }
                }
            }

            if (reportItem != null)
            {
                hideReportId.Value = reportItem.ID;
                txtReportName.Text = reportItem.Name;
                txtReportDescription.Text = reportItem.Description;
            }
        }

        private void ResetForm()
        {
            hideReportId.Value = string.Empty;
            txtReportName.Text = string.Empty;
            txtReportDescription.Text = string.Empty;
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                DoSearch();
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
                DoSearch();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void GridRegistry_Sorting(object sender, GridViewSortEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                if (SORT_DIRECTION == "ASC")
                    SORT_DIRECTION = "DESC";
                else
                    SORT_DIRECTION = "ASC";

                string sortExpression = string.Empty;

                if (!string.IsNullOrEmpty(e.SortExpression))
                {
                    sortExpression += e.SortExpression + " " + SORT_DIRECTION;
                }

                SORT_EXPRESSION = sortExpression;

                DoSearch();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void DoSearch()
        {
            string searchColumn = ddlSearch.SelectedValue;
            string searchText = txtSearch.Text;

            ReportItems = ServiceInterfaceManager.REPORTS_GET_ALL_BY_USER_REGISTRY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, searchColumn, searchText, SORT_EXPRESSION);
            gridRegistry.DataSource = ReportItems;
            gridRegistry.DataBind();
        }

        protected void GridRegistry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            try
            {
                gridRegistry.PageIndex = e.NewPageIndex;
                gridRegistry.DataSource = ReportItems;
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