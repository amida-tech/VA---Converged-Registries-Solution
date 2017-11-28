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
    public partial class Activity : BasePage
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
                else if (UserSession.CurrentActivityId <= 0)
                {
                    Response.Redirect("~/Common/Activities.aspx", false);
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
            btnStart.Enabled = false;
            btnResume.Enabled = false;
            btnPause.Enabled = false;
            btnComplete.Enabled = false;
            btnTerminate.Enabled = false;
            lblResult.Text = "You are not able to edit information on this page.<br /><br />";
        }

        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                UserSession.PageMode = PageModes.Edit;
                Response.Redirect("~/Common/Activities.aspx", false);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnStart_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                STD_WKFACTIVITYSTS status = ServiceInterfaceManager.STD_WKFACTIVITYSTS_GET_BY_CODE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "IN PROGRESS");
                if (status != null && ServiceInterfaceManager.WKF_CASE_ACTIVITY_UPDATE_STATUS(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentActivityId, status.ID))
                {
                    lblResult.Text = "This Activity has started.<br /><br />";
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

        protected void BtnResume_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                STD_WKFACTIVITYSTS status = ServiceInterfaceManager.STD_WKFACTIVITYSTS_GET_BY_CODE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "IN PROGRESS");
                if (status != null && ServiceInterfaceManager.WKF_CASE_ACTIVITY_UPDATE_STATUS(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentActivityId, status.ID))
                {
                    lblResult.Text = "This Activity has resumed.<br /><br />";
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

        protected void BtnPause_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                STD_WKFACTIVITYSTS status = ServiceInterfaceManager.STD_WKFACTIVITYSTS_GET_BY_CODE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "PAUSED");
                if (status != null && ServiceInterfaceManager.WKF_CASE_ACTIVITY_UPDATE_STATUS(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentActivityId, status.ID))
                {
                    lblResult.Text = "This Activity has been paused.<br /><br />";
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
                STD_WKFACTIVITYSTS status = ServiceInterfaceManager.STD_WKFACTIVITYSTS_GET_BY_CODE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "COMPLETED");
                if (status != null && ServiceInterfaceManager.WKF_CASE_ACTIVITY_UPDATE_STATUS(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentActivityId, status.ID))
                {
                    lblResult.Text = "This Activity has been completed.<br /><br />";
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

        protected void BtnTerminate_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                STD_WKFACTIVITYSTS status = ServiceInterfaceManager.STD_WKFACTIVITYSTS_GET_BY_CODE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, "TERMINATED");
                if (status != null && ServiceInterfaceManager.WKF_CASE_ACTIVITY_UPDATE_STATUS(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentActivityId, status.ID))
                {
                    lblResult.Text = "This Activity has been terminated.<br /><br />";
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
            viewActivity.LoadForm(UserSession.CurrentActivityId);
            viewWorkstream.LoadForm(UserSession.CurrentWorkstreamId);
            viewReferral.LoadForm(UserSession.CurrentReferralId);
            viewPatient.LoadForm(UserSession.CurrentPatientId);

            btnStart.Enabled = btnResume.Enabled = btnPause.Enabled = btnComplete.Enabled = btnTerminate.Enabled = false;

            if (viewWorkstream.Status != "PAUSED")
            {
                switch (viewActivity.Status)
                {
                    case "READY TO START":
                        btnStart.Enabled = btnTerminate.Enabled = true;
                        break;
                    case "IN PROGRESS":
                        btnPause.Enabled = btnComplete.Enabled = btnTerminate.Enabled = true;
                        break;
                    case "PAUSED":
                        btnResume.Enabled = btnTerminate.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}