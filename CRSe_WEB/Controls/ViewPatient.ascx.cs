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
    public partial class ViewPatient : BaseControl
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

            PATIENT patient = ServiceInterfaceManager.PATIENT_GET_COMPLETE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, id);
            if (patient != null)
            {
                lblLastName.Text = patient.LAST_NAME;
                lblFirstName.Text = patient.FIRST_NAME;

                if (patient.BIRTH_DATE != null)
                    lblDateOfBirth.Text = patient.BIRTH_DATE.Value.ToString("MM/dd/yyyy");

                if (patient.OEFOIF_IND != null)
                    lblOefOif.Text = (patient.OEFOIF_IND.Value) ? "Yes" : "No";

                if (patient.SPATIENT != null)
                {
                    lblIcn.Text = patient.SPATIENT.PatientICN;
                    lblLastFour.Text = patient.SPATIENT.PatientLastFour;
                    if (patient.SPATIENT.LastServiceSeparationDate != null)
                        lblServiceSeparation.Text = patient.SPATIENT.LastServiceSeparationDate.Value.ToString("MM/dd/yyyy");
                }
            }
            else
                linkViewDetails.Visible = false;
        }

        public void ResetForm()
        {
            lblIcn.Text = string.Empty;
            lblLastName.Text = string.Empty;
            lblFirstName.Text = string.Empty;
            lblDateOfBirth.Text = string.Empty;
            lblLastFour.Text = string.Empty;
            lblOefOif.Text = string.Empty;
            lblServiceSeparation.Text = string.Empty;
        }
    }
}