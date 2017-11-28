using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRSe_WEB.SoaServices;
using CRSe_WEB.BaseCode;
using System.IO;
using System.Xml;
using System.Configuration;

namespace CRSe_WEB.Admin
{
    public partial class Settings : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ServiceInterfaceManager.LogInformation("PAGE_LOAD", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                base.Page_Load(sender, e);
                //BuildAdminMenu();

                lblResult.Text = string.Empty;

                wmEtlSchedule.WatermarkText = DateTime.Now.ToString("hh:mm:ss");

                if (UserSession.IsSystemAdministrator)
                {
                    if (!Page.IsPostBack)
                    {
                        txtHomePageText.Attributes.Add("maxlength", txtHomePageText.MaxLength.ToString());

                        LoadForm();
                    }
                }
                else
                {
                    DisableForm();
                    lblResult.Text = "You do not have sufficient permissions to edit this page.<br /><br />";
                }
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ServiceInterfaceManager.LogInformation("POSTBACK_EVENT", String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);

            try
            {
                if (SaveForm())
                    lblResult.Text = "Save successful<br /><br />";
                else
                    if (string.IsNullOrEmpty(lblResult.Text))
                        lblResult.Text = "An unexpected error occurred, please try again<br /><br />";
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
                Response.Redirect("~/Admin/Settings.aspx", false);
            }
            catch (Exception ex)
            {
                ServiceInterfaceManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), HttpContext.Current.User.Identity.Name, UserSession.CurrentRegistryId);
                throw ex;
            }
        }

        private bool SaveForm()
        {
            bool objReturn = false;

            STD_REGISTRY systemRegistry = ApplicationSession.SystemRegistry;

            AppSettings oldAppSettings = ServiceInterfaceManager.APPSETTINGS_GET(HttpContext.Current.User.Identity.Name, systemRegistry.ID);

            AppSettings newAppSettings = new AppSettings();

            int iValue = 0;
            int.TryParse(txtSqlCommandTimeout.Text, out iValue);
            newAppSettings.SqlCommandTimeout = iValue;

            iValue = 0;
            int.TryParse(txtLogFileSize.Text, out iValue);
            newAppSettings.LogFileSize = iValue;

            iValue = 0;
            int.TryParse(txtLogFileArchive.Text, out iValue);
            newAppSettings.LogFileArchive = iValue;

            bool bValue = false;
            bool.TryParse(listLogErrors.SelectedValue, out bValue);
            newAppSettings.LogErrors = bValue;

            bValue = false;
            bool.TryParse(listLogInformation.SelectedValue, out bValue);
            newAppSettings.LogInformation = bValue;

            bValue = false;
            bool.TryParse(listLogTiming.SelectedValue, out bValue);
            newAppSettings.LogTiming = bValue;

            bValue = false;
            bool.TryParse(listDatabaseLogEnabled.SelectedValue, out bValue);
            newAppSettings.DatabaseLogEnabled = bValue;

            bValue = false;
            //bool.TryParse(listEventLogEnabled.SelectedValue, out bValue);
            newAppSettings.EventLogEnabled = bValue;

            bValue = false;
            bool.TryParse(listFileLogEnabled.SelectedValue, out bValue);
            newAppSettings.FileLogEnabled = bValue;

            if (ValidFileLogPath())
            {
                newAppSettings.FileLogPath = txtFileLogPath.Text;
            }
            else
            {
                return false;
            }

            bValue = false;
            bool.TryParse(listMviEnabled.SelectedValue, out bValue);
            newAppSettings.MviEnabled = bValue;

            newAppSettings.MviProcessingCode = listMviProcessingCode.SelectedValue;
            newAppSettings.MviCertName = this.txtMviCertName.Text;
            newAppSettings.MviServiceUrl = this.txtMviServiceUrl.Text;

            newAppSettings.ReportBuilderPath = txtReportBuilderPath.Text;
            newAppSettings.ReportServerUrl = txtReportServerUrl.Text;
            newAppSettings.ReportServicePath = txtReportServicePath.Text;

            newAppSettings.EtlSchedule = txtEtlSchedule.Text;

            iValue = 0;
            int.TryParse(txtEtlRetryAttempts.Text, out iValue);
            newAppSettings.EtlRetryAttempts = iValue;

            iValue = 0;
            int.TryParse(txtEtlTimeBetweenAttempts.Text, out iValue);
            newAppSettings.EtlTimeBetweenAttempts = iValue;

            newAppSettings.HomePageText = txtHomePageText.Text;

            objReturn = ServiceInterfaceManager.APPSETTINGS_SAVE(HttpContext.Current.User.Identity.Name, systemRegistry.ID, newAppSettings);

            if (objReturn)
            {
                DB_LOG newLog = new DB_LOG();
                newLog.STD_REGISTRY_ID = systemRegistry.ID;
                newLog.IS_ERROR = false;
                newLog.PROCESS_NAME = "CRSe_WEB.Settings.SaveForm";
                newLog.MESSAGE = "CRSe app settings values have been updated (Old Values: " + WriteToXmlString(oldAppSettings) + ") to (New Values: " + WriteToXmlString(newAppSettings) + ")";
                newLog.CREATED = DateTime.Now;
                newLog.CREATEDBY = HttpContext.Current.User.Identity.Name;

                ServiceInterfaceManager.DB_LOG_SAVE(HttpContext.Current.User.Identity.Name, systemRegistry.ID, newLog);
            }
            return objReturn;
        }

        private void LoadForm()
        {
            ResetForm();

            STD_REGISTRY systemRegistry = ApplicationSession.SystemRegistry;

            AppSettings appSettings = ServiceInterfaceManager.APPSETTINGS_GET(HttpContext.Current.User.Identity.Name, systemRegistry.ID);
            if (appSettings != null)
            {
                txtSqlCommandTimeout.Text = appSettings.SqlCommandTimeout.ToString();
                txtLogFileSize.Text = appSettings.LogFileSize.ToString();
                txtLogFileArchive.Text = appSettings.LogFileArchive.ToString();
                listLogErrors.SelectedValue = appSettings.LogErrors.ToString().ToLower();
                listLogInformation.SelectedValue = appSettings.LogInformation.ToString().ToLower();
                listLogTiming.SelectedValue = appSettings.LogTiming.ToString().ToLower();
                listDatabaseLogEnabled.SelectedValue = appSettings.DatabaseLogEnabled.ToString().ToLower();
                //listEventLogEnabled.SelectedValue = appSettings.EventLogEnabled.ToString().ToLower();
                listFileLogEnabled.SelectedValue = appSettings.FileLogEnabled.ToString().ToLower();
                txtFileLogPath.Text = appSettings.FileLogPath.ToString();
                listMviEnabled.SelectedValue = appSettings.MviEnabled.ToString().ToLower();
                listMviProcessingCode.SelectedValue = appSettings.MviProcessingCode.ToString().ToUpper();
                txtMviCertName.Text = appSettings.MviCertName.ToString();
                txtMviServiceUrl.Text = appSettings.MviServiceUrl.ToString();
                txtReportBuilderPath.Text = appSettings.ReportBuilderPath.ToString();
                txtReportServerUrl.Text = appSettings.ReportServerUrl.ToString();
                txtReportServicePath.Text = appSettings.ReportServicePath.ToString();
                txtEtlSchedule.Text = appSettings.EtlSchedule;
                txtEtlRetryAttempts.Text = appSettings.EtlRetryAttempts.ToString();
                txtEtlTimeBetweenAttempts.Text = appSettings.EtlTimeBetweenAttempts.ToString();
                txtHomePageText.Text = appSettings.HomePageText;
            }
        }

        private void ResetForm()
        {
            txtSqlCommandTimeout.Text = string.Empty;
            txtLogFileSize.Text = string.Empty;
            txtLogFileArchive.Text = string.Empty;
            listLogErrors.ClearSelection();
            listLogInformation.ClearSelection();
            listLogTiming.ClearSelection();
            listDatabaseLogEnabled.ClearSelection();
            //listEventLogEnabled.ClearSelection();
            listFileLogEnabled.ClearSelection();
            txtFileLogPath.Text = string.Empty;
            listMviEnabled.ClearSelection();
            listMviProcessingCode.ClearSelection();
            txtMviCertName.Text = string.Empty;
            txtMviServiceUrl.Text = string.Empty;
            txtReportBuilderPath.Text = string.Empty;
            txtReportServerUrl.Text = string.Empty;
            txtReportServicePath.Text = string.Empty;
            txtEtlSchedule.Text = string.Empty;
            txtEtlRetryAttempts.Text = string.Empty;
            txtEtlTimeBetweenAttempts.Text = string.Empty;
            txtHomePageText.Text = string.Empty;
        }

        private bool ValidFileLogPath()
        {
            //In Future Get List From Database?
            List<string> blackList = new List<string> { "config", "bginfo", "inetpub", "installanywhere", "netbackup", "program files", "users", "windows" };

            if (string.IsNullOrEmpty(txtFileLogPath.Text))
            {
                lblResult.Text = "File Log Path is Required. <br /><br />";
                return false;
            }
            else
            {
                //Removes duplicated \\ or // to eliminate empty arrays. Ex: C:\\Log\\Temp.log shows as C:\\\\Temp\\\\CRSe.Log
                //Replaces turn it into C:\Temp\CRSe.Log so Path.DirectorySeperatorChar will not create empty values in array.
                //C:\\\\Temp\\\\CRSe.Log otherwise turns into ["C:"],[""],["Temp"],[""],["CRSe.Log"]
                string[] values = txtFileLogPath.Text.Replace(@"//", @"/").Replace(@"\\\\", @"\").Replace(@"\\", @"\").Split(Path.DirectorySeparatorChar);

                if (values[0].ToUpper() != "C:" && values[0].ToUpper() != "D:")
                {
                    lblResult.Text = "File Log Path must be configured for the local server C or D drive. <br /><br />";
                    return false;
                }

                if (blackList.Any(s => txtFileLogPath.Text.Contains(s)))
                {
                    lblResult.Text = "This is an invalid File Log Path. <br /><br />";
                    return false;
                }
            }

            return true;
        }

        private string WriteToXmlString(AppSettings appSettings)
        {
            string strReturn = string.Empty;

            if (appSettings != null)
            {
                strReturn += "<SqlCommandTimeout>" + appSettings.SqlCommandTimeout.ToString() + "</SqlCommandTimeout>";
                strReturn += "<LogFileSize>" + appSettings.LogFileSize.ToString() + "</LogFileSize>";
                strReturn += "<LogFileArchive>" + appSettings.LogFileArchive.ToString() + "</LogFileArchive>";
                strReturn += "<LogErrors>" + appSettings.LogErrors.ToString() + "</LogErrors>";
                strReturn += "<LogInformation>" + appSettings.LogInformation.ToString() + "</LogInformation>";
                strReturn += "<LogTiming>" + appSettings.LogTiming.ToString() + "</LogTiming>";
                strReturn += "<DatabaseLogEnabled>" + appSettings.DatabaseLogEnabled.ToString() + "</DatabaseLogEnabled>";
                strReturn += "<EventLogEnabled>" + appSettings.EventLogEnabled.ToString() + "</EventLogEnabled>";
                strReturn += "<FileLogEnabled>" + appSettings.FileLogEnabled.ToString() + "</FileLogEnabled>";
                strReturn += "<FileLogPath>" + appSettings.FileLogPath + "</FileLogPath>";
                strReturn += "<MviEnabled>" + appSettings.MviEnabled.ToString() + "</MviEnabled>";
                strReturn += "<MviProcessingCode>" + appSettings.MviProcessingCode + "</MviProcessingCode>";
                strReturn += "<MviCertName>" + appSettings.MviCertName + "</MviCertName>";
                strReturn += "<MviServiceUrl>" + appSettings.MviServiceUrl + "</MviServiceUrl>";
                strReturn += "<ReportServerUrl>" + appSettings.ReportServerUrl + "</ReportServerUrl>";
                strReturn += "<ReportServicePath>" + appSettings.ReportServicePath + "</ReportServicePath>";
                strReturn += "<ReportBuilderPath>" + appSettings.ReportBuilderPath + "</ReportBuilderPath>";
                strReturn += "<EtlSchedule>" + appSettings.EtlSchedule + "</EtlSchedule>";
                strReturn += "<EtlRetryAttempts>" + appSettings.EtlRetryAttempts.ToString() + "</EtlRetryAttempts>";
                strReturn += "<EtlTimeBetweenAttempts>" + appSettings.EtlTimeBetweenAttempts.ToString() + "</EtlTimeBetweenAttempts>";
                strReturn += "<HomePageText>" + appSettings.HomePageText + "</HomePageText>";
            }

            return strReturn;
        }

        private void DisableForm()
        {
            listLogErrors.Enabled = false;
            listLogInformation.Enabled = false;
            listLogTiming.Enabled = false;
            listDatabaseLogEnabled.Enabled = false;
            listFileLogEnabled.Enabled = false;
            hypLnkFileLogPathView.Visible = false;
            txtSqlCommandTimeout.Enabled = false;
            txtLogFileSize.Enabled = false;
            txtLogFileArchive.Enabled = false;
            txtFileLogPath.Enabled = false;
            listMviEnabled.Enabled = false;
            listMviProcessingCode.Enabled = false;
            txtMviCertName.Enabled = false;
            txtMviServiceUrl.Enabled = false;
            txtReportBuilderPath.Enabled = false;
            txtReportServerUrl.Enabled = false;
            txtReportServicePath.Enabled = false;
            txtEtlSchedule.Enabled = false;
            txtEtlRetryAttempts.Enabled = false;
            txtEtlTimeBetweenAttempts.Enabled = false;
            txtHomePageText.Enabled = false;
            btnSave.Enabled = false;
        }
    }
}