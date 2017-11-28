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
    public partial class ViewReferral : BaseControl
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

            REFERRAL referral = ServiceInterfaceManager.REFERRAL_GET_COMPLETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (referral != null)
            {
                if (referral.STD_REFERRALSTS != null)
                    lblStatus.Text = referral.STD_REFERRALSTS.CODE;

                if (referral.REFERRAL_DATE != null)
                    lblReferralDate.Text = referral.REFERRAL_DATE.Value.ToString("MM/dd/yyyy");

                lblCreatedBy.Text = referral.CREATEDBY;
                lblCreated.Text = referral.CREATED.ToString("MM/dd/yyyy");
                lblUpdatedBy.Text = referral.UPDATEDBY;
                lblUpdated.Text = referral.UPDATED.ToString("MM/dd/yyyy");
                lblReviewBy.Text = referral.REVIEW_BY;

                if (referral.REVIEW_DATE != null)
                    lblReviewDate.Text = referral.REVIEW_DATE.Value.ToString("MM/dd/yyyy");
            }
            else
                linkViewDetails.Visible = false;
        }

        public void ResetForm()
        {
            lblStatus.Text = string.Empty;
            lblReferralDate.Text = string.Empty;
            lblCreatedBy.Text = string.Empty;
            lblCreated.Text = string.Empty;
            lblUpdatedBy.Text = string.Empty;
            lblUpdated.Text = string.Empty;
            lblReviewBy.Text = string.Empty;
            lblReviewDate.Text = string.Empty;
        }
    }
}