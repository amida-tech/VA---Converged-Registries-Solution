using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
    public static partial class STD_REGISTRYManager
    {
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        public static STD_REGISTRY GetItemComplete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
        {
            STD_REGISTRY objReturn = null;
            STD_REGISTRYDB objDB = new STD_REGISTRYDB();

            objReturn = objDB.GetItemComplete(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

            return objReturn;
        }

        public static STD_REGISTRY GetSystemRegistry()
        {
            STD_REGISTRY objReturn = null;
            STD_REGISTRYDB objDB = new STD_REGISTRYDB();

            objReturn = objDB.GetSystemRegistry();

            return objReturn;
        }

        public static List<STD_REGISTRY> GetItemsByUser(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_REGISTRY> objReturn = null;
            STD_REGISTRYDB objDB = new STD_REGISTRYDB();

            objReturn = objDB.GetItemsByUser(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<STD_REGISTRY> GetNonSystemRegistries()
        {
            List<STD_REGISTRY> objReturn = null;
            STD_REGISTRYDB objDB = new STD_REGISTRYDB();

            objReturn = objDB.GetNonSystemRegistries();

            return objReturn;
        }

        public static List<STD_REGISTRY> GetNonSystemRegistriesByUser(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_REGISTRY> objReturn = null;
            STD_REGISTRYDB objDB = new STD_REGISTRYDB();

            objReturn = objDB.GetNonSystemRegistriesByUser(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static Int32 SaveWithReporting(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_REGISTRY objSave)
        {
            Int32 objReturn = 0;
            STD_REGISTRYDB objDB = new STD_REGISTRYDB();

            objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

            if (objReturn > 0)
            {
                string itemPath = ReportManager.CreateRegistryFolder(CURRENT_USER, objReturn);

                if (!string.IsNullOrEmpty(itemPath))
                {
                    ReportManager.CreateDataSet(CURRENT_USER, objReturn);

                    List<USERS> adminUsers = USERSManager.GetSystemUsers(CURRENT_USER, CURRENT_REGISTRY_ID);
                    if (adminUsers != null)
                    {
                        foreach (USERS user in adminUsers)
                        {
                            bool blnFound = false;

                            if (user.USER_ROLES != null)
                            {
                                foreach (USER_ROLES userRole in user.USER_ROLES)
                                {
                                    if (userRole.STD_ROLE != null)
                                    {
                                        switch (userRole.STD_ROLE.CODE)
                                        {
                                            case "CRSADMIN":
                                                ReportManager.AddItemAdmin(CURRENT_USER, CURRENT_REGISTRY_ID, user.USERNAME, itemPath);
                                                blnFound = true;
                                                break;
                                            case "CRSUPD":
                                                ReportManager.AddItemUpdate(CURRENT_USER, CURRENT_REGISTRY_ID, user.USERNAME, itemPath);
                                                blnFound = true;
                                                break;
                                            case "CRSREAD":
                                                ReportManager.AddItemReadOnly(CURRENT_USER, CURRENT_REGISTRY_ID, user.USERNAME, itemPath);
                                                blnFound = true;
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    if (blnFound) break;
                                }
                            }
                        }
                    }
                }

                ReportManager.CreateDataSet(CURRENT_USER, objReturn);
            }

            return objReturn;
        }

        #endregion
    }
}
