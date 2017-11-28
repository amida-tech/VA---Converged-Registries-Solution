using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB.Custom.BCR
{
    public partial class Default : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);

                lblResult.Text = string.Empty;

                wmPatient.WatermarkText = "Enter Name, VA ID, or SSN";

                if (UserSession == null || UserSession.CurrentRegistryId <= 0)
                {
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        ResetForm();
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void DsFacilities_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                e.InputParameters.Clear();
                e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                e.InputParameters.Add("CURRENT_REGISTRY_ID", UserSession.CurrentRegistryId);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void ListFacilities_DataBound(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                listFacilities.Items.Insert(0, new ListItem("Search for Facility...", "0"));
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void ListFacilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                int id = 0;
                int.TryParse(listFacilities.SelectedValue, out id);

                if (id > 0)
                {
                    STD_INSTITUTION fac = ServiceInterfaceManager.STD_INSTITUTION_GET_COMPLETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
                    if (fac != null)
                    {
                        lblFacilityName.Text = fac.NAME;
                        lblFacilityCode.Text = fac.STATIONNUMBER;
                        lblVistaName.Text = fac.VISTANAME;
                        lblVisn.Text = fac.VISN.NAME;
                        lblAddress.Text = GenerateAddressBlock(fac);
                        lblFacilityType.Text = fac.STD_FACILITYTYPE.NAME;

                        pnlFacility.Visible = true;
                    }
                    else
                        pnlFacility.Visible = false;
                }
                else
                {
                    pnlFacility.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void ResetForm()
        {
            listFacilities.ClearSelection();
            pnlSearch.Visible = true;
            pnlFacility.Visible = pnlPatients.Visible = false;
        }

        private string GenerateAddressBlock(STD_INSTITUTION fac)
        {
            string addressBlock = string.Empty;

            string address1 = fac.STREETADDRESSLINE1;
            string address2 = fac.STREETADDRESSLINE2;
            string address3 = fac.STREETADDRESSLINE3;
            string cityStr = fac.STREETCITY;

            string stateStr = "N/A";
            if (fac.STREETSTATE != null)
                stateStr = fac.STREETSTATE.NAME;

            string zipString = fac.STREETPOSTALCODE;

            StringBuilder sb = new StringBuilder();

            if (!String.IsNullOrEmpty(address1))
            {
                sb.Append(address1);
            }

            if (!String.IsNullOrEmpty(address2))
            {
                if (!String.IsNullOrEmpty(sb.ToString()))
                {
                    sb.Append("<br />");
                }

                sb.Append(address2);
            }

            if (!String.IsNullOrEmpty(address3))
            {
                if (!String.IsNullOrEmpty(sb.ToString()))
                {
                    sb.Append("<br />");
                }

                sb.Append(address3);
            }

            if (!String.IsNullOrEmpty(sb.ToString()))
            {
                sb.Append("<br />");
            }

            sb.Append(cityStr + ", " + stateStr + " " + zipString);

            addressBlock = sb.ToString();

            return addressBlock;
        }

        protected void BtnPatient_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                gridPatients.DataBind();
                pnlPatients.Visible = true;
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
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void DsPatients_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                short id = 0;
                short.TryParse(lblFacilityCode.Text, out id);

                if (id > 0)
                {
                    e.InputParameters.Clear();
                    e.InputParameters.Add("CURRENT_USER", HttpContext.Current.User.Identity.Name);
                    e.InputParameters.Add("CURRENT_REGISTRY_ID", UserSession.CurrentRegistryId);
                    e.InputParameters.Add("STA3N", id);
                    e.InputParameters.Add("PATIENT_SEARCH", txtPatient.Text);
                }
                else
                {
                    pnlPatients.Visible = false;
                    e.Cancel = true;
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