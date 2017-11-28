using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;
using System.Xml.Serialization;

namespace CRSe.CRS.BLL
{
	public static partial class STD_MENU_ITEMSManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<STD_MENU_ITEMS> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_MENU_ITEMS> objReturn = null;
            STD_MENU_ITEMSDB objDB = new STD_MENU_ITEMSDB();

            objReturn = objDB.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<STD_MENU_ITEMS> GetMenu(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string PATH)
        {
            List<STD_MENU_ITEMS> objReturn = new List<STD_MENU_ITEMS>();
            STD_MENU_ITEMSDB objDB = new STD_MENU_ITEMSDB();
            STD_MENU_ITEMS menuItem = null;

            if (string.IsNullOrEmpty(PATH) 
                || PATH.Equals("~/Default.aspx", StringComparison.InvariantCultureIgnoreCase) 
                || PATH.Equals("~/DataDictionary.aspx", StringComparison.InvariantCultureIgnoreCase)
                || PATH.Equals("~/RegistryInfo.aspx", StringComparison.InvariantCultureIgnoreCase))
            {
                string[] roles = USER_ROLESManager.GetRoles(CURRENT_USER);

                List<STD_REGISTRY> allRegs = STD_REGISTRYManager.GetNonSystemRegistries();
                List<STD_REGISTRY> uRegs = null;

                if (IsSystemUser(roles))
                    uRegs = STD_REGISTRYManager.GetNonSystemRegistries();
                else
                    uRegs = STD_REGISTRYManager.GetNonSystemRegistriesByUser(CURRENT_USER, CURRENT_REGISTRY_ID);

                if (uRegs != null && uRegs.Count > 0)
                {
                    menuItem = new STD_MENU_ITEMS();
                    menuItem.MENU_PAGE = new STD_WEB_PAGES();
                    menuItem.MENU_PAGE.DISPLAY_TEXT = "Your Registries";
                    menuItem.MENU_PAGE.URL = string.Empty;
                    objReturn.Add(menuItem);

                    foreach (STD_REGISTRY reg in uRegs)
                    {
                        menuItem = new STD_MENU_ITEMS();
                        menuItem.MENU_PAGE = new STD_WEB_PAGES();
                        menuItem.MENU_PAGE.DISPLAY_TEXT = reg.NAME;
                        menuItem.MENU_PAGE.URL = "~/Common/Default.aspx?id=" + reg.ID.ToString();
                        objReturn.Add(menuItem);

                        if (allRegs != null && allRegs.Count > 0)
                        {
                            int? index = null;
                            for (int i = 0; i < allRegs.Count; i++)
                            {
                                if (reg.ID == allRegs[i].ID)
                                {
                                    index = i;
                                    break;
                                }
                            }
                            if (index != null)
                                allRegs.RemoveAt(index.Value);
                        }
                    }
                }

                if (allRegs != null && allRegs.Count > 0)
                {
                    if (objReturn.Count > 1)
                    {
                        menuItem = new STD_MENU_ITEMS();
                        menuItem.MENU_PAGE = new STD_WEB_PAGES();
                        menuItem.MENU_PAGE.DISPLAY_TEXT = string.Empty;
                        menuItem.MENU_PAGE.URL = string.Empty;
                        objReturn.Add(menuItem);
                    }

                    menuItem = new STD_MENU_ITEMS();
                    menuItem.MENU_PAGE = new STD_WEB_PAGES();
                    menuItem.MENU_PAGE.DISPLAY_TEXT = "Available Registries";
                    menuItem.MENU_PAGE.URL = string.Empty;
                    objReturn.Add(menuItem);

                    foreach (STD_REGISTRY reg in allRegs)
                    {
                        menuItem = new STD_MENU_ITEMS();
                        menuItem.MENU_PAGE = new STD_WEB_PAGES();
                        menuItem.MENU_PAGE.DISPLAY_TEXT = reg.NAME;
                        menuItem.MENU_PAGE.URL = "~/RegistryInfo.aspx?id=" + reg.ID.ToString();
                        objReturn.Add(menuItem);
                    }
                }
            }
            else if (PATH.ToLower().Contains("~/reports/"))
            {
                string reportStore = string.Empty;

                List<ReportItem> reports = ReportManager.GetAllByUserAndRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);
                if (reports != null && reports.Count > 0)
                {
                    foreach (ReportItem report in reports)
                    {
                        if (report.ReportStore != reportStore)
                        {
                            reportStore = report.ReportStore;

                            if (objReturn.Count > 1)
                            {
                                menuItem = new STD_MENU_ITEMS();
                                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                                menuItem.MENU_PAGE.DISPLAY_TEXT = string.Empty;
                                menuItem.MENU_PAGE.URL = string.Empty;
                                objReturn.Add(menuItem);
                            }

                            menuItem = new STD_MENU_ITEMS();
                            menuItem.MENU_PAGE = new STD_WEB_PAGES();
                            menuItem.MENU_PAGE.DISPLAY_TEXT = reportStore + " Reports";
                            menuItem.MENU_PAGE.URL = string.Empty;
                            objReturn.Add(menuItem);
                        }

                        menuItem = new STD_MENU_ITEMS();
                        menuItem.MENU_PAGE = new STD_WEB_PAGES();
                        menuItem.MENU_PAGE.DISPLAY_TEXT = report.Name;
                        menuItem.MENU_PAGE.URL = "~/Reports/RunReport.aspx?path=" + report.Path;
                        objReturn.Add(menuItem);
                    }
                }

                string[] roles = USER_ROLESManager.GetRoles(CURRENT_USER);
                if (!IsReadOnlyUser(roles))
                {
                    if (objReturn.Count > 1)
                    {
                        menuItem = new STD_MENU_ITEMS();
                        menuItem.MENU_PAGE = new STD_WEB_PAGES();
                        menuItem.MENU_PAGE.DISPLAY_TEXT = string.Empty;
                        menuItem.MENU_PAGE.URL = string.Empty;
                        objReturn.Add(menuItem);
                    }

                    DBUtils utils = new DBUtils();

                    menuItem = new STD_MENU_ITEMS();
                    menuItem.MENU_PAGE = new STD_WEB_PAGES();
                    menuItem.MENU_PAGE.DISPLAY_TEXT = "Report Builder";
                    menuItem.MENU_PAGE.URL = utils.ReportBuilderUrl;
                    objReturn.Add(menuItem);
                }
            }
            else if (PATH.ToLower().Contains("~/cohorts/"))
            {
                string titleName = "Registry and Cohort Administration";

                STD_REGISTRY reg = STD_REGISTRYManager.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_REGISTRY_ID);
                if (reg != null)
                    titleName = reg.NAME;

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = titleName;
                menuItem.MENU_PAGE.URL = string.Empty;
                objReturn.Add(menuItem);

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = "Cohort Criteria";
                menuItem.MENU_PAGE.URL = "~/Cohorts/Cohort.aspx";
                objReturn.Add(menuItem);

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = "Framework Data";
                menuItem.MENU_PAGE.URL = "~/Cohorts/FrameworkData.aspx";
                objReturn.Add(menuItem);

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = "User-Defined Fields";
                menuItem.MENU_PAGE.URL = "~/Cohorts/UDF.aspx";
                objReturn.Add(menuItem);

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = "Work Streams";
                menuItem.MENU_PAGE.URL = "~/Cohorts/Workstream.aspx";
                objReturn.Add(menuItem);

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = "Activities";
                menuItem.MENU_PAGE.URL = "~/Cohorts/Activity.aspx";
                objReturn.Add(menuItem);

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = string.Empty;
                menuItem.MENU_PAGE.URL = string.Empty;
                objReturn.Add(menuItem);

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = "Registries and Cohorts";
                menuItem.MENU_PAGE.URL = "~/Cohorts/Default.aspx";
                objReturn.Add(menuItem);
            }
            else if (PATH.ToLower().Contains("~/admin/"))
            {
                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = "Administration";
                menuItem.MENU_PAGE.URL = string.Empty;
                objReturn.Add(menuItem);

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = "Survey Administration";
                menuItem.MENU_PAGE.URL = "~/Admin/Survey.aspx";
                objReturn.Add(menuItem);

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = "User Administration";
                menuItem.MENU_PAGE.URL = "~/Admin/User.aspx";
                objReturn.Add(menuItem);

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = "Menu Administration";
                menuItem.MENU_PAGE.URL = "~/Admin/Menu.aspx";
                objReturn.Add(menuItem);

                menuItem = new STD_MENU_ITEMS();
                menuItem.MENU_PAGE = new STD_WEB_PAGES();
                menuItem.MENU_PAGE.DISPLAY_TEXT = "Settings";
                menuItem.MENU_PAGE.URL = "~/Admin/Settings.aspx";
                objReturn.Add(menuItem);
            }
            else
            {
                objReturn = objDB.GetItemsByUserRegistryPath(CURRENT_USER, CURRENT_REGISTRY_ID, PATH);
                if (objReturn != null && objReturn.Count > 0)
                {
                    menuItem = new STD_MENU_ITEMS();
                    menuItem.MENU_PAGE = new STD_WEB_PAGES();
                    menuItem.MENU_PAGE.DISPLAY_TEXT = objReturn[0].STD_REGISTRY.NAME;
                    menuItem.MENU_PAGE.URL = string.Empty;
                    objReturn.Insert(0, menuItem);
                }
            }

            if (objReturn != null && objReturn.Count > 0)
                return objReturn;
            else
                return null;
        }

        private static bool IsSystemUser(string[] roles)
        {
            if (roles != null)
            {
                foreach (string role in roles)
                {
                    if (role == "CRSADMIN")
                        return true;
                    else if (role == "CRSUPD")
                        return true;
                    else if (role == "CRSREAD")
                        return true;
                }
            }

            return false;
        }

        private static bool IsReadOnlyUser(string[] roles)
        {
            bool IsReadOnly = true;

            if (roles != null)
            {
                foreach (string role in roles)
                {
                    if (role == "CRSADMIN")
                        IsReadOnly = false;
                    else if (role == "CRSUPD")
                        IsReadOnly = false;
                    else if (role == "REGADMIN")
                        IsReadOnly = false;
                    else if (role == "REGUPD")
                        IsReadOnly = false;
                }
            }

            return IsReadOnly;
        }

		#endregion
	}
}
