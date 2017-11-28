using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;

namespace CRSe_WEB.CustomErrors
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["aspxerrorpath"] != null)
            {
                if (Request.QueryString["aspxerrorpath"].Contains("Survey") == true)
                {
                    lblError.Text = "You cannot edit a completed survey any furthur.  Please select the button below to continue.";
                }

                btnContinue.PostBackUrl = Request.QueryString["aspxerrorpath"];
            }
        }
    }
}