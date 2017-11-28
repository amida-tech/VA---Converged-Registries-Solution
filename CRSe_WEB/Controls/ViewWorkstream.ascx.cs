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
    public partial class ViewWorkstream : BaseControl
    {
        public bool ShowViewDetails
        {
            get { return linkViewDetails.Visible; }
            set { linkViewDetails.Visible = value; }
        }

        public string Status
        {
            get
            {
                if (!string.IsNullOrEmpty(lblStatus.Text))
                    return lblStatus.Text.Trim().ToUpper();
                else
                    return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //No need to log PAGE_LOAD here as the control will be available on .ASPX pages

            try
            {
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        public void LoadForm(int id)
        {
            ResetForm();

            WKF_CASE wkfCase = ServiceInterfaceManager.WKF_CASE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (wkfCase != null)
            {
                wkfCase.STD_WKFCASETYPE = ServiceInterfaceManager.STD_WKFCASETYPE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, wkfCase.STD_WKFCASETYPE_ID);
                if (wkfCase.STD_WKFCASETYPE != null)
                    lblWorkstreamName.Text = wkfCase.STD_WKFCASETYPE.Name;

                wkfCase.STD_WKFCASESTS = ServiceInterfaceManager.STD_WKFCASESTS_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, wkfCase.STD_WKFCASESTS_ID);
                if (wkfCase.STD_WKFCASESTS != null)
                    lblStatus.Text = wkfCase.STD_WKFCASESTS.NAME;

                lblCaseNumber.Text = wkfCase.CASE_NUMBER;

                if (wkfCase.CASE_START_DATE != null)
                    lblCaseStartDate.Text = wkfCase.CASE_START_DATE.Value.ToString("MM/dd/yyyy");

                if (wkfCase.CASE_DUE_DATE != null)
                    lblCaseDueDate.Text = wkfCase.CASE_DUE_DATE.Value.ToString("MM/dd/yyyy");

                lblCreatedBy.Text = wkfCase.CREATEDBY;
                lblCreated.Text = wkfCase.CREATED.ToString("MM/dd/yyyy");
                lblUpdatedBy.Text = wkfCase.UPDATEDBY;
                lblUpdated.Text = wkfCase.UPDATED.ToString("MM/dd/yyyy");
            }
            else
                linkViewDetails.Visible = false;
        }

        public void ResetForm()
        {
            lblWorkstreamName.Text = string.Empty;
            lblStatus.Text = string.Empty;
            lblCaseNumber.Text = string.Empty;
            lblCaseStartDate.Text = string.Empty;
            lblCaseDueDate.Text = string.Empty;
            lblCreatedBy.Text = string.Empty;
            lblCreated.Text = string.Empty;
            lblUpdatedBy.Text = string.Empty;
            lblUpdated.Text = string.Empty;
        }
    }
}