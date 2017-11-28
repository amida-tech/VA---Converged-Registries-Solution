using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
    public static partial class USER_ROLESManager
    {
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        public static USER_ROLES GetItemByUserIdRoleId(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ID, Int32 STD_ROLE_ID)
        {
            USER_ROLES objReturn = null;
            USER_ROLESDB objDB = new USER_ROLESDB();

            objReturn = objDB.GetItemByUserIdRoleId(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ID, STD_ROLE_ID);

            return objReturn;
        }

        public static USER_ROLES GetItemByUserRole(string Username, string RoleName)
        {
            USER_ROLES objReturn = null;
            USER_ROLESDB objDB = new USER_ROLESDB();

            objReturn = objDB.GetItemByUserRole(Username, RoleName);

            return objReturn;
        }

        public static string[] GetRoles(string Username)
        {
            string[] objReturn = null;
            USER_ROLESDB objDB = new USER_ROLESDB();

            objReturn = objDB.GetRoles(Username);

            return objReturn;
        }

        public static List<string> GetItemsByRegistryIdUsername(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<string> objReturn = null;
            USER_ROLESDB objDB = new USER_ROLESDB();

            objReturn = objDB.GetRoleByRegistryId(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<USER_ROLES> GetItemsByUser(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ID)
        {
            List<USER_ROLES> objReturn = null;
            USER_ROLESDB objDB = new USER_ROLESDB();

            objReturn = objDB.GetItemsByUser(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ID);

            return objReturn;
        }

        public static List<USER_ROLES> GetItemsByUser(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string Username)
        {
            List<USER_ROLES> objReturn = null;
            USER_ROLESDB objDB = new USER_ROLESDB();

            objReturn = objDB.GetItemsByUser(CURRENT_USER, CURRENT_REGISTRY_ID, Username);

            return objReturn;
        }

        public static Boolean DeleteByUserRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ID, Int32 STD_REGISTRY_ID)
        {
            Boolean objReturn = false;
            USER_ROLESDB objDB = new USER_ROLESDB();

            objReturn = objDB.DeleteByUserRegistry(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ID, STD_REGISTRY_ID);

            return objReturn;
        }

        public static Boolean SaveAll(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, List<USER_ROLES> USER_ROLES)
        {
            if (USER_ROLES == null  || USER_ROLES.Count == 0)
                return false;

            Boolean objReturn = false;
            USER_ROLESDB objDB = new USER_ROLESDB();

            objReturn = objDB.SaveAll(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ROLES);
            if (objReturn)
            {
                //Get a system role if available
                string systemRole = string.Empty;
                foreach (USER_ROLES userRole in USER_ROLES)
                {
                    if (userRole.STD_ROLE == null && userRole.STD_ROLE_ID > 0) 
                        userRole.STD_ROLE = STD_ROLEManager.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, userRole.STD_ROLE_ID);
                    if (userRole.STD_ROLE != null)
                        if (userRole.STD_ROLE.SUPER_USER_FLAG && !userRole.INACTIVE_FLAG)
                        {
                            systemRole = userRole.STD_ROLE.CODE;
                            break;
                        }
                }

                USERS user = USERSManager.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ROLES[0].USER_ID);
                if (user != null)
                {
                    List<STD_REGISTRY> allRegs = STD_REGISTRYManager.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);
                    if (allRegs != null)
                    {
                        foreach (STD_REGISTRY reg in allRegs)
                        {
                            foreach (USER_ROLES userRole in USER_ROLES)
                            {
                                Boolean blnFound = false;

                                if (userRole.STD_ROLE != null)
                                {
                                    if (reg.ID == userRole.STD_ROLE.STD_REGISTRY_ID)
                                    {
                                        switch (userRole.STD_ROLE.CODE)
                                        {
                                            case "REGADMIN":
                                                blnFound = true;
                                                ReportManager.AddItemAdmin(CURRENT_USER, CURRENT_REGISTRY_ID, user.USERNAME, "/Reports/" + reg.CODE);
                                                break;
                                            case "REGUPD":
                                                if (systemRole != "CRSADMIN")
                                                {
                                                    blnFound = true;
                                                    ReportManager.AddItemUpdate(CURRENT_USER, CURRENT_REGISTRY_ID, user.USERNAME, "/Reports/" + reg.CODE);
                                                }
                                                break;
                                            case "REGREAD":
                                                if (systemRole != "CRSADMIN" && systemRole != "CRSUPD")
                                                {
                                                    blnFound = true;
                                                    ReportManager.AddItemReadOnly(CURRENT_USER, CURRENT_REGISTRY_ID, user.USERNAME, "/Reports/" + reg.CODE);
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }

                                if (!blnFound && string.IsNullOrEmpty(systemRole))
                                    ReportManager.RemovePrivileges(CURRENT_USER, CURRENT_REGISTRY_ID, user.USERNAME, "/Reports/" + reg.CODE);
                                else if (!blnFound)
                                {
                                    switch (systemRole)
                                    {
                                        case "CRSADMIN":
                                            ReportManager.AddItemAdmin(CURRENT_USER, CURRENT_REGISTRY_ID, user.USERNAME, "/Reports/" + reg.CODE);
                                            break;
                                        case "CRSUPD":
                                            ReportManager.AddItemUpdate(CURRENT_USER, CURRENT_REGISTRY_ID, user.USERNAME, "/Reports/" + reg.CODE);
                                            break;
                                        case "CRSREAD":
                                            ReportManager.AddItemReadOnly(CURRENT_USER, CURRENT_REGISTRY_ID, user.USERNAME, "/Reports/" + reg.CODE);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        #endregion
    }
}
