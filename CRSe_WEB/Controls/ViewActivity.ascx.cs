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
    public partial class ViewActivity : BaseControl
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

            WKF_CASE_ACTIVITY activity = ServiceInterfaceManager.WKF_CASE_ACTIVITY_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (activity != null)
            {
                activity.STD_WKFACTIVITYTYPE = ServiceInterfaceManager.STD_WKFACTIVITYTYPE_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, activity.STD_WKFACTIVITYTYPE_ID);
                if (activity.STD_WKFACTIVITYTYPE != null)
                    lblActivityName.Text = activity.STD_WKFACTIVITYTYPE.NAME;

                activity.STD_WKFACTIVITYSTS = ServiceInterfaceManager.STD_WKFACTIVITYSTS_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, activity.STD_WKFACTIVITYSTS_ID);
                if (activity.STD_WKFACTIVITYSTS != null)
                    lblStatus.Text = activity.STD_WKFACTIVITYSTS.NAME;

                lblContactName.Text = activity.CONTACT_NAME;
                lblContactEmail.Text = activity.CONTACT_EMAIL;
                lblContactPhone.Text = activity.CONTACT_PHONE;
                lblBestCallBackTime.Text = activity.BEST_CALL_BACK_TIME;
                lblInfoConveyedText.Text = activity.INFO_CONVEYED_TEXT;
                lblInforReceivedText.Text = activity.INFO_RECEIVED_TEXT;
                lblAddressLine1.Text = activity.ADDRESS_LINE1;
                lblAddressLine2.Text = activity.ADDRESS_LINE2;
                lblAddressLine3.Text = activity.ADDRESS_LINE3;
                lblCity.Text = activity.CITY;
                lblState.Text = activity.STATE;
                lblPostalCode.Text = activity.POSTAL_CODE;
                lblCountry.Text = activity.COUNTRY;
                lblCreatedBy.Text = activity.CREATEDBY;
                lblCreated.Text = activity.CREATED.ToString("MM/dd/yyyy");
                lblUpdatedBy.Text = activity.UPDATEDBY;
                lblUpdated.Text = activity.UPDATED.ToString("MM/dd/yyyy");
            }
            else
                linkViewDetails.Visible = false;
        }

        public void ResetForm()
        {
            lblActivityName.Text = string.Empty;
            lblStatus.Text = string.Empty;
            lblContactName.Text = string.Empty;
            lblContactEmail.Text = string.Empty;
            lblContactPhone.Text = string.Empty;
            lblBestCallBackTime.Text = string.Empty;
            lblInfoConveyedText.Text = string.Empty;
            lblInforReceivedText.Text = string.Empty;
            lblAddressLine1.Text = string.Empty;
            lblAddressLine2.Text = string.Empty;
            lblAddressLine3.Text = string.Empty;
            lblCity.Text = string.Empty;
            lblState.Text = string.Empty;
            lblPostalCode.Text = string.Empty;
            lblCountry.Text = string.Empty;
            lblCreatedBy.Text = string.Empty;
            lblCreated.Text = string.Empty;
            lblUpdatedBy.Text = string.Empty;
            lblUpdated.Text = string.Empty;
        }
    }
}