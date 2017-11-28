using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class SETTINGSManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static SETTINGS GetItemByRegistryName(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string NAME)
        {
            SETTINGS objReturn = null;
            SETTINGSDB objDB = new SETTINGSDB();

            objReturn = objDB.GetItemByRegistryName(CURRENT_USER, CURRENT_REGISTRY_ID, NAME);

            return objReturn;
        }

        public static SETTINGS GetItemHomePage()
        {
            SETTINGS objReturn = null;
            SETTINGSDB objDB = new SETTINGSDB();

            objReturn = objDB.GetItemHomePage();

            return objReturn;
        }

        public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string NAME, string VALUE)
        {
            Int32 objReturn = 0;
            SETTINGSDB objDB = new SETTINGSDB();

            SETTINGS objSave = GetItemByRegistryName(CURRENT_USER, CURRENT_REGISTRY_ID, NAME);
            if (objSave == null)
            {
                objSave = new SETTINGS();
                objSave.CREATED = DateTime.Now;
                objSave.CREATEDBY = CURRENT_USER;
            }

            objSave.UPDATED = DateTime.Now;
            objSave.UPDATEDBY = CURRENT_USER;
            objSave.STD_REGISTRY_ID = CURRENT_REGISTRY_ID;
            objSave.NAME = NAME;
            objSave.VALUE = VALUE;

            objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

            return objReturn;
        }

        public static bool SaveAll(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, AppSettings appSettings)
        {
            bool objReturn = false;
            SETTINGSDB objDB = new SETTINGSDB();

            objReturn = objDB.SaveAll(CURRENT_USER, CURRENT_REGISTRY_ID, appSettings);

            return objReturn;
        }

		#endregion
    }
}
