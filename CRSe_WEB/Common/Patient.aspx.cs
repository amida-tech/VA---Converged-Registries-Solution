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
    public partial class Patient : BasePage
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
                else if (UserSession.CurrentPatientId <= 0)
                {
                    Response.Redirect("~/Common/Patients.aspx", false);
                }
                else
                {
                    if (ServiceInterfaceManager.USER_ROLES_GET_BY_REGISTRYID_USERNAME_SET_READONLY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId))
                    {
                        gridRegistry.Columns[0].Visible = false;
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
            btnMvi.Enabled = false;
            linkEdit.Visible = false;
            lblResult.Text = "You are not able to edit information on this page.<br /><br />";            
        }

        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                UserSession.PageMode = PageModes.Edit;
                Response.Redirect("~/Common/Patients.aspx", false);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected override void Ds_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                e.InputParameters.Clear();

                string searchColumn = ddlSearch.SelectedValue;
                string searchText = txtSearch.Text;

                e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                e.InputParameters.Add("CURRENT_REGISTRY_ID", UserSession.CurrentRegistryId);
                e.InputParameters.Add("PATIENT_ID", UserSession.CurrentPatientId);
                e.InputParameters.Add("SEARCH_COLUMN", searchColumn);
                e.InputParameters.Add("SEARCH_TEXT", searchText);
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
                gridRegistry.DataBind();
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
                gridRegistry.DataBind();
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void LinkSelect_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                LinkButton lb = (LinkButton)sender;
                if (lb != null)
                {
                    int id = 0;

                    if (int.TryParse(lb.CommandArgument, out id))
                    {
                        REFERRAL r = ServiceInterfaceManager.REFERRAL_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                        if (r != null)
                        {
                            UserSession.CurrentRegistryId = r.STD_REGISTRY_ID;
                            UserSession.CurrentReferralId = r.REFERRAL_ID;
                            UserSession.CurrentPatientId = r.PATIENT_ID;
                            UserSession.CurrentProviderId = r.PROVIDER_ID.GetValueOrDefault();

                            Response.Redirect("~/Common/Referral.aspx", false);
                        }
                    }
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
            bool mviEnabled = false;
            AppSettings settings = ServiceInterfaceManager.APPSETTINGS_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
            if (settings != null)
                mviEnabled = settings.MviEnabled;

            btnMvi.Visible = mviEnabled;

            viewPatient.LoadForm(UserSession.CurrentPatientId);
        }

        protected void BtnMvi_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (UserSession.CurrentRegistryId > 0 && UserSession.CurrentPatientId > 0)
                {
                    bool objReturn = ServiceInterfaceManager.PRPA_IN201305UV02(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentPatientId);
                    if (objReturn)
                    {
                        LoadForm();
                        gridRegistry.DataBind();

                        lblResult.Text = "An MVI match was found and this patient's information has been updated<br /><br />";
                    }
                    else
                    {
                        lblResult.Text = "An error occurred or an MVI match was not found.  This patient's information has not been updated<br /><br />";
                    }
                }
                else
                {
                    lblResult.Text = "An unexpected error occurred.  Please try again or return to the Referrals/Patients page to select the patient again.<br /><br />";
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }
    }
}