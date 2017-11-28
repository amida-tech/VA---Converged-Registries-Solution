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
    public partial class ViewProvider : BaseControl
    {
        public bool ShowViewDetails
        {
            get { return linkViewDetails.Visible; }
            set { linkViewDetails.Visible = value; }
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

            SStaff_SStaff provider = ServiceInterfaceManager.SStaff_SStaff_GET(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (provider != null)
            {
                lblIen.Text = provider.StaffIEN;
                lblLastName.Text = provider.LastName;
                lblFirstName.Text = provider.FirstName;

                if (provider.Sta3n != null)
                    lblStation.Text = provider.Sta3n.Value.ToString();

                lblCity.Text = provider.City;
                lblState.Text = provider.StateName;
            }
            else
                linkViewDetails.Visible = false;
        }

        public void ResetForm()
        {
            lblIen.Text = string.Empty;
            lblLastName.Text = string.Empty;
            lblFirstName.Text = string.Empty;
            lblStation.Text = string.Empty;
            lblCity.Text = string.Empty;
            lblState.Text = string.Empty;
        }
    }
}