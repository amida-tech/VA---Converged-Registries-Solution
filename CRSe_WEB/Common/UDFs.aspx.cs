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
    public partial class UDFs : BasePage
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
                    pnlSelectPatient.Visible = true;
                    pnlForm.Visible = false;
                }
                else
                {
                    if (ServiceInterfaceManager.USER_ROLES_GET_BY_REGISTRYID_USERNAME_SET_READONLY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId))
                    {
                        SetReadOnly();
                    }
                    //BuildCommonMenu();

                    List<STD_REG_UDFs> udfs = ServiceInterfaceManager.STD_REG_UDFs_GET_ALL_BY_REGISTRY(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                    SetupForm(udfs);
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
            lblResult.Text = "You will not be able to edit information on this page.<br /><br />";
            btnSave.Enabled = false;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (UserSession.CurrentRegistryId > 0 && UserSession.CurrentPatientId > 0)
                {
                    if (tblForm.Rows != null)
                    {
                        foreach (TableRow row in tblForm.Rows)
                        {
                            if (row.Cells != null && row.Cells.Count > 1)
                            {
                                if (row.Cells[1].Controls != null && row.Cells[1].Controls.Count > 1)
                                {
                                    HiddenField hide = (HiddenField)row.Cells[1].Controls[0];
                                    if (hide != null)
                                    {
                                        int STD_REG_UDFs_Id = 0;
                                        if (int.TryParse(hide.Value, out STD_REG_UDFs_Id))
                                        {
                                            string strResponse = string.Empty;
                                            TextBox txt = (TextBox)row.Cells[1].Controls[1];
                                            if (txt != null) strResponse = txt.Text;

                                            PATIENT_UDFs pUdf = ServiceInterfaceManager.PATIENT_UDFs_GET_BY_PATIENT_UDF(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentPatientId, STD_REG_UDFs_Id);
                                            if (pUdf == null) pUdf = new PATIENT_UDFs();
                                            pUdf.CREATED = pUdf.UPDATED = DateTime.Now;
                                            pUdf.CREATEDBY = pUdf.UPDATEDBY = User.Identity.Name;
                                            pUdf.PATIENT_ID = UserSession.CurrentPatientId;
                                            pUdf.STD_REG_UDFs_ID = STD_REG_UDFs_Id;
                                            pUdf.UDF_Value = strResponse;
                                            pUdf.ID = ServiceInterfaceManager.PATIENT_UDFs_SAVE(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, pUdf);

                                            if (pUdf.ID > 0)
                                            {
                                                lblResult.Text = "User-Defined Fields have been saved<br /><br />";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("already exists"))
                    lblResult.Text = "The User-Defined Field you are saving already exists<br /><br />";
                else
                {
                    ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                    throw ex;
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                Response.Redirect("~/Common/Default.aspx", false);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private void SetupForm(List<STD_REG_UDFs> udfs)
        {
            viewReferral.LoadForm(UserSession.CurrentReferralId);
            viewPatient.LoadForm(UserSession.CurrentPatientId);

            if (udfs == null)
            {
                pnlForm.Visible = false;
                lblResult.Text = "Currently no User-Defined Fields exist for this Registry<br /><br />";
            }
            else
            {
                int rowIndex = 0;

                foreach (STD_REG_UDFs udf in udfs)
                {
                    HiddenField hide = new HiddenField();
                    hide.ID = "hide" + udf.NAME.Replace(" ", string.Empty).ToUpper();
                    hide.Value = udf.ID.ToString();

                    TextBox txt = new TextBox();
                    txt.ID = "txt" + udf.NAME.Replace(" ", string.Empty).ToUpper();
                    txt.ToolTip = "Enter value for " + udf.NAME;

                    if (!Page.IsPostBack)
                    {
                        PATIENT_UDFs pUdf = ServiceInterfaceManager.PATIENT_UDFs_GET_BY_PATIENT_UDF(HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId, UserSession.CurrentPatientId, udf.ID);
                        if (pUdf != null)
                        {
                            txt.Text = pUdf.UDF_Value;
                        }
                    }
                    else
                    {
                        if (Request != null && Request.Form != null && Request.Form["ctl00$MainContent$" + txt.ID] != null)
                            txt.Text = Request.Form["ctl00$MainContent$" + txt.ID].ToString();
                    }

                    Label lbl = new Label();
                    lbl.ID = "lbl" + udf.NAME.Replace(" ", string.Empty).ToUpper();
                    lbl.Text = lbl.ToolTip = udf.NAME;
                    lbl.AssociatedControlID = txt.ID;

                    TableCell lblCell = new TableCell();
                    lblCell.Controls.Add(lbl);

                    TableCell txtCell = new TableCell();
                    txtCell.Controls.Add(hide);
                    txtCell.Controls.Add(txt);

                    TableRow newRow = new TableRow();
                    newRow.Cells.Add(lblCell);
                    newRow.Cells.Add(txtCell);

                    tblForm.Rows.AddAt(rowIndex, newRow);

                    rowIndex++;
                }
            }
        }
    }
}