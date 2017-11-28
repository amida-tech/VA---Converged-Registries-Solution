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
    public partial class Referral : BasePage
    {
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
                else if (UserSession.CurrentReferralId <= 0)
                {
                    Response.Redirect("~/Common/Referrals.aspx", false);
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

        private void SetReadOnly()
        {
            linkEdit.Visible = false;
            btnActivate.Enabled = false;
            btnDisqualify.Enabled = false;
            btnCancel.Enabled = false;
            btnDuplicate.Enabled = false;
            btnComplete.Enabled = false;
            lblResult.Text = "You are not able to edit information on this page.<br /><br />";
        }

        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                UserSession.PageMode = PageModes.Edit;
                Response.Redirect("~/Common/Referrals.aspx", false);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnActivate_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                STD_REFERRALSTS status = ServiceInterfaceManager.STD_REFERRALSTS_GET_BY_CODE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "ACTIVE");
                if (status != null && ServiceInterfaceManager.REFERRAL_UPDATE_STATUS(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentReferralId, status.ID))
                {
                    lblResult.Text = "This Referral has been activated.<br /><br />";
                    LoadForm();
                }
                else
                {
                    lblResult.Text = "An unexpected error occurred, please try again.<br /><br />";
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnDisqualify_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                lblDisqualify.Visible = true;
                txtDisqualifyReason.Visible = true;
                btnSaveDisqualifyReason.Visible = btnCancelDisqualifyReason.Visible = true;
                btnActivate.Enabled = btnCancel.Enabled = btnDuplicate.Enabled = btnComplete.Enabled = false;
                linkEdit.Enabled = false;
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
                STD_REFERRALSTS status = ServiceInterfaceManager.STD_REFERRALSTS_GET_BY_CODE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "CANCELED");
                if (status != null && ServiceInterfaceManager.REFERRAL_UPDATE_STATUS(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentReferralId, status.ID))
                {
                    lblResult.Text = "This Referral has been cancelled.<br /><br />";
                    LoadForm();
                }
                else
                {
                    lblResult.Text = "An unexpected error occurred, please try again.<br /><br />";
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnDuplicate_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                STD_REFERRALSTS status = ServiceInterfaceManager.STD_REFERRALSTS_GET_BY_CODE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "DUPLICATE");
                if (status != null && ServiceInterfaceManager.REFERRAL_UPDATE_STATUS(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentReferralId, status.ID))
                {
                    lblResult.Text = "This Referral has been marked as subsequent-duplicate.<br /><br />";
                    LoadForm();
                }
                else
                {
                    lblResult.Text = "An unexpected error occurred, please try again.<br /><br />";
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnComplete_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                STD_REFERRALSTS status = ServiceInterfaceManager.STD_REFERRALSTS_GET_BY_CODE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "COMPLETED");
                if (status != null && ServiceInterfaceManager.REFERRAL_UPDATE_STATUS(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentReferralId, status.ID))
                {
                    lblResult.Text = "This Referral has been completed.<br /><br />";
                    LoadForm();
                }
                else
                {
                    lblResult.Text = "An unexpected error occurred, please try again.<br /><br />";
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void LoadForm()
        {
            lblDisqualify.Visible = false;
            txtDisqualifyReason.Visible = false;
            btnSaveDisqualifyReason.Visible = btnCancelDisqualifyReason.Visible = false;
            linkEdit.Enabled = true;

            viewReferral.LoadForm(UserSession.CurrentReferralId);
            viewPatient.LoadForm(UserSession.CurrentPatientId);
            viewProvider.LoadForm(UserSession.CurrentProviderId);

            btnActivate.Enabled = btnDisqualify.Enabled = btnCancel.Enabled = btnDuplicate.Enabled = btnComplete.Enabled = false;

            switch (viewReferral.Status)
            {
                case "NEW":
                    btnActivate.Enabled = btnCancel.Enabled = btnDuplicate.Enabled = true;
                    break;
                case "NEW-MANUAL":
                    btnActivate.Enabled = btnCancel.Enabled = btnDuplicate.Enabled = true;
                    break;
                case "ACTIVE":
                    btnDisqualify.Enabled = btnCancel.Enabled = btnDuplicate.Enabled = btnComplete.Enabled = true;
                    break;
                case "DISQUALIFIED":
                    btnActivate.Enabled = true;
                    break;
                case "CANCELED":
                    btnActivate.Enabled = true;
                    break;
                case "DUPLICATE":
                    btnActivate.Enabled = true;
                    break;
                case "COMPLETED":
                    break;
                default:
                    break;
            }
        }

        protected void BtnSaveDisqualifyReason_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            int referralId = 0;
            
            try
            {
                if (!string.IsNullOrEmpty(txtDisqualifyReason.Text.Trim()))
                {
                    STD_REFERRALSTS status = ServiceInterfaceManager.STD_REFERRALSTS_GET_BY_CODE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "DISQUALIFIED");
                    REFERRAL r = ServiceInterfaceManager.REFERRAL_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentReferralId);

                    if (r != null && status != null)
                    {
                        r.COMMENT_TEXT = txtDisqualifyReason.Text.Trim();
                        r.STD_REFERRALSTS_ID = status.ID;
                        referralId = ServiceInterfaceManager.REFERRAL_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, r);
                    }

                    if (referralId > 0)
                    {
                        lblResult.Text = "This Referral has been disqualified.<br /><br />";
                        LoadForm();
                    }
                    else
                    {
                        lblResult.Text = "An unexpected error occurred, please try again.<br /><br />";
                    }
                }
                else
                {
                    lblResult.Text = "Please enter a Disqualify Reason and try again.<br /><br />";
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnCancelDisqualifyReason_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                LoadForm();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }
    }
}