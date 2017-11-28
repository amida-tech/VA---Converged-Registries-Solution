using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class SETTINGSManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static SETTINGS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CRS_SETTINGS_ID)
		{
			SETTINGS objReturn = null;
			SETTINGSDB objDB = new SETTINGSDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, CRS_SETTINGS_ID);

			return objReturn;
		}

		public static List<SETTINGS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<SETTINGS> objReturn = null;
			SETTINGSDB objDB = new SETTINGSDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SETTINGS objSave)
		{
			Int32 objReturn = 0;
			SETTINGSDB objDB = new SETTINGSDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CRS_SETTINGS_ID)
		{
			Boolean objReturn = false;
			SETTINGSDB objDB = new SETTINGSDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, CRS_SETTINGS_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SETTINGS objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.CRS_SETTINGS_ID);
		}

		#endregion
	}
}
