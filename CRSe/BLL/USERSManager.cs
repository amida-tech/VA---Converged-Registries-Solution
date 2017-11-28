using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.DirectoryServices;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class USERSManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static DomainNames LoadFromActiveDirectory()
        {
            DomainNames objReturn = new DomainNames();
            objReturn.LoadFromActiveDirectory();
            return objReturn;
        }

        public static USERS GetItemByName(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string username)
        {
            USERS objReturn = null;
            USERSDB objDB = new USERSDB();

            objReturn = objDB.GetItemByName(CURRENT_USER, CURRENT_REGISTRY_ID, username);

            return objReturn;
        }

        public static List<DomainUser> GetActiveDirectory(DomainNames domainNames, string searchString)
        {
            List<DomainUser> objReturn = null;
            USERSDB objDB = new USERSDB();          

            if (!string.IsNullOrEmpty(searchString))
            {
                objReturn = objDB.GetActiveDirectory(domainNames, searchString);
            }

            return objReturn;
        }

        public static List<USERS> GetItemsByUser(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<USERS> objReturn = null;
            USERSDB objDB = new USERSDB();

            objReturn = objDB.GetItemsByUser(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<USERS> GetSystemUsers(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<USERS> objReturn = null;
            USERSDB objDB = new USERSDB();

            objReturn = objDB.GetSystemUsers(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static Int32 SaveWithReporting(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, USERS objSave)
        {
            Int32 objReturn = 0;
            USERSDB objDB = new USERSDB();

            objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
            if (objReturn > 0)
            {
                //Create System User
                ReportManager.AddSystemUser(CURRENT_USER, CURRENT_REGISTRY_ID, objSave.USERNAME);

                //Give Read Only to Root
                ReportManager.AddItemReadOnly(CURRENT_USER, CURRENT_REGISTRY_ID, objSave.USERNAME, "/");

                //Give Read Only to Reports
                ReportManager.AddItemReadOnly(CURRENT_USER, CURRENT_REGISTRY_ID, objSave.USERNAME, "/Reports");

                //Give Read Only to System
                STD_REGISTRY registry = STD_REGISTRYManager.GetSystemRegistry();
                if (registry != null && !string.IsNullOrEmpty(registry.CODE))
                    ReportManager.AddItemReadOnly(CURRENT_USER, CURRENT_REGISTRY_ID, objSave.USERNAME, "/Reports/" + registry.CODE);

                //Add User Folder and Give Admin
                string itemPath = ReportManager.CreateUserFolder(CURRENT_USER, CURRENT_REGISTRY_ID, objSave.USERNAME);
                if (!string.IsNullOrEmpty(itemPath))
                    ReportManager.AddItemAdmin(CURRENT_USER, CURRENT_REGISTRY_ID, objSave.USERNAME, itemPath);
            }

            return objReturn;
        }

        public static Boolean SetDefaultRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Boolean IS_DEFAULT)
        {
            Boolean objReturn = false;
            USERSDB objDB = new USERSDB();

            objReturn = objDB.SetDefaultRegistry(CURRENT_USER, CURRENT_REGISTRY_ID, IS_DEFAULT);

            return objReturn;
        }

		#endregion
	}
}
