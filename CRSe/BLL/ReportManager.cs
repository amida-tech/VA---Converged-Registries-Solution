using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;
using CRSe.ReportService;

namespace CRSe.CRS.BLL
{
    public static partial class ReportManager
    {
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Method

        public static bool AddSystemAdmin(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username)
        {
            bool objReturn = false;
            ReportDB objDB = new ReportDB();

            objReturn = objDB.AddSystemAdmin(CURRENT_USER, CURRENT_REGISTRY_ID, username);
            objDB.Dispose();

            return objReturn;
        }

        public static bool AddSystemUser(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username)
        {
            bool objReturn = false;
            ReportDB objDB = new ReportDB();

            objReturn = objDB.AddSystemUser(CURRENT_USER, CURRENT_REGISTRY_ID, username);
            objDB.Dispose();

            return objReturn;
        }

        public static bool AddItemAdmin(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username, string itemPath)
        {
            bool objReturn = false;
            ReportDB objDB = new ReportDB();

            objReturn = objDB.AddItemAdmin(CURRENT_USER, CURRENT_REGISTRY_ID, username, itemPath);
            objDB.Dispose();

            return objReturn;
        }

        public static bool AddItemUpdate(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username, string itemPath)
        {
            bool objReturn = false;
            ReportDB objDB = new ReportDB();

            objReturn = objDB.AddItemUpdate(CURRENT_USER, CURRENT_REGISTRY_ID, username, itemPath);
            objDB.Dispose();

            return objReturn;
        }

        public static bool AddItemReadOnly(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username, string itemPath)
        {
            bool objReturn = false;
            ReportDB objDB = new ReportDB();

            objReturn = objDB.AddItemReadOnly(CURRENT_USER, CURRENT_REGISTRY_ID, username, itemPath);
            objDB.Dispose();

            return objReturn;
        }

        public static bool AddItemMyReports(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username, string itemPath)
        {
            bool objReturn = false;
            ReportDB objDB = new ReportDB();

            objReturn = objDB.AddItemMyReports(CURRENT_USER, CURRENT_REGISTRY_ID, username, itemPath);
            objDB.Dispose();

            return objReturn;
        }

        public static bool RemovePrivileges(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username, string itemPath)
        {
            bool objReturn = false;
            ReportDB objDB = new ReportDB();

            objReturn = objDB.RemovePrivileges(CURRENT_USER, CURRENT_REGISTRY_ID, username, itemPath);
            objDB.Dispose();

            return objReturn;
        }

        public static bool UpdateItemProperties(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string itemPath, string description)
        {
            bool objReturn = false;
            ReportDB objDB = new ReportDB();

            objReturn = objDB.UpdateItemProperties(CURRENT_USER, CURRENT_REGISTRY_ID, itemPath, description);
            objDB.Dispose();

            return objReturn;
        }

        public static bool CreateDataSet(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            bool objReturn = false;
            ReportDB objDB = new ReportDB();

            STD_REGISTRY registry = STD_REGISTRYManager.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_REGISTRY_ID);
            if (registry == null || string.IsNullOrEmpty(registry.CODE))
                return false;

            string name = registry.CODE;
            string parent = "/Reports/" + registry.CODE;

            objReturn = objDB.CreateDataSet(CURRENT_USER, CURRENT_REGISTRY_ID, name, parent);
            objDB.Dispose();

            return objReturn;
        }

        public static string CreateSystemFolder(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            string objReturn = string.Empty;
            ReportDB objDB = new ReportDB();

            STD_REGISTRY registry = STD_REGISTRYManager.GetSystemRegistry();
            if (registry == null || string.IsNullOrEmpty(registry.CODE))
                return string.Empty;

            string folderName = registry.CODE;

            objReturn = objDB.CreateFolder(CURRENT_USER, CURRENT_REGISTRY_ID, folderName);
            objDB.Dispose();

            return objReturn;
        }

        public static string CreateRegistryFolder(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            string objReturn = string.Empty;
            ReportDB objDB = new ReportDB();

            STD_REGISTRY registry = STD_REGISTRYManager.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_REGISTRY_ID);
            if (registry == null || string.IsNullOrEmpty(registry.CODE))
                return string.Empty;

            string folderName = registry.CODE;

            objReturn = objDB.CreateFolder(CURRENT_USER, CURRENT_REGISTRY_ID, folderName);
            objDB.Dispose();

            return objReturn;
        }

        public static string CreateUserFolder(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username)
        {
            string objReturn = string.Empty;
            ReportDB objDB = new ReportDB();

            string folderName = username.Replace("\\", "_");

            objReturn = objDB.CreateFolder(CURRENT_USER, CURRENT_REGISTRY_ID, folderName);
            objDB.Dispose();

            return objReturn;
        }

        public static List<ReportItem> GetAllByUserAndRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<ReportItem> objReturn = null;
            ReportDB objDB = new ReportDB();

            List<ReportItem> objSystem = GetSystemReports(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objSystem != null)
            {
                if (objReturn == null) objReturn = new List<ReportItem>();
                foreach (ReportItem ri in objSystem)
                {
                    objReturn.Add(ri);
                }
            }

            if (CURRENT_REGISTRY_ID > 0)
            {
                List<ReportItem> objRegistry = GetRegistryReports(CURRENT_USER, CURRENT_REGISTRY_ID);
                if (objRegistry != null)
                {
                    if (objReturn == null) objReturn = new List<ReportItem>();
                    foreach (ReportItem ri in objRegistry)
                    {
                        objReturn.Add(ri);
                    }
                }
            }
            else
            {
                List<USER_ROLES> roles = USER_ROLESManager.GetItemsByUser(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_USER);
                if (roles != null)
                {
                    bool systemUser = false;
                    //First check if they have a system level role
                    foreach (USER_ROLES role in roles)
                    {
                        if (!role.INACTIVE_FLAG)
                        {
                            if (role.STD_ROLE != null && role.STD_ROLE.SUPER_USER_FLAG)
                            {
                                systemUser = true;
                                break;
                            }
                        }
                    }

                    //If system user, get registry reports for all registries
                    if (systemUser)
                    {
                        List<STD_REGISTRY> registries = STD_REGISTRYManager.GetNonSystemRegistries();
                        if (registries != null)
                        {
                            foreach (STD_REGISTRY reg in registries)
                            {
                                List<ReportItem> objRegistry = GetRegistryReports(CURRENT_USER, reg.ID);
                                if (objRegistry != null)
                                {
                                    if (objReturn == null) objReturn = new List<ReportItem>();
                                    foreach (ReportItem ri in objRegistry)
                                    {
                                        objReturn.Add(ri);
                                    }
                                }
                            }
                        }
                    }
                    else //if not sytem user, get registry reports for all registries user has access to
                    {
                        foreach (USER_ROLES role in roles)
                        {
                            if (!role.INACTIVE_FLAG)
                            {
                                if (role.STD_ROLE != null && role.STD_ROLE.STD_REGISTRY_ID > 0)
                                {
                                    List<ReportItem> objRegistry = GetRegistryReports(CURRENT_USER, role.STD_ROLE.STD_REGISTRY_ID);
                                    if (objRegistry != null)
                                    {
                                        if (objReturn == null) objReturn = new List<ReportItem>();
                                        foreach (ReportItem ri in objRegistry)
                                        {
                                            objReturn.Add(ri);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            List<ReportItem> objUser = GetUserReports(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objUser != null)
            {
                if (objReturn == null) objReturn = new List<ReportItem>();
                foreach (ReportItem ri in objUser)
                {
                    objReturn.Add(ri);
                }
            }

            objDB.Dispose();

            return objReturn;
        }

        public static List<ReportItem> GetSystemReports(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<ReportItem> objReturn = null;
            ReportDB objDB = new ReportDB();

            STD_REGISTRY registry = STD_REGISTRYManager.GetSystemRegistry();
            if (registry == null || string.IsNullOrEmpty(registry.CODE))
                return null;

            string folderName = "/Reports/" + registry.CODE;

            objReturn = objDB.GetReports(CURRENT_USER, CURRENT_REGISTRY_ID, folderName);
            objDB.Dispose();

            return objReturn;
        }

        public static List<ReportItem> GetRegistryReports(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<ReportItem> objReturn = null;
            ReportDB objDB = new ReportDB();

            STD_REGISTRY registry = STD_REGISTRYManager.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_REGISTRY_ID);
            if (registry == null || string.IsNullOrEmpty(registry.CODE))
                return null;

            string folderName = "/Reports/" + registry.CODE;

            objReturn = objDB.GetReports(CURRENT_USER, CURRENT_REGISTRY_ID, folderName);
            objDB.Dispose();

            return objReturn;
        }

        public static List<ReportItem> GetUserReports(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<ReportItem> objReturn = null;
            ReportDB objDB = new ReportDB();

            string folderName = "/Reports/" + CURRENT_USER.Replace("\\", "_");

            objReturn = objDB.GetReports(CURRENT_USER, CURRENT_REGISTRY_ID, folderName);

            return objReturn;
        }

        #endregion
    }
}
