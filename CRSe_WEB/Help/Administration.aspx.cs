using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CRSe_WEB.Help
{
    public partial class Administration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string searchText = Request.Params["txtSearch"];
            if (!string.IsNullOrEmpty(searchText))
            {
                string whitelist = "^[a-zA-Z0-9-,. ]+$";
                Regex pattern = new Regex(whitelist);

                if (!pattern.IsMatch(searchText))
                    throw new Exception("Invalid Search Criteria");

                ClientScript.RegisterStartupScript(this.GetType(), "highlightSearchTerms", "highlightSearchTerms('" + searchText + "');", true);
            }
        }
    }
}