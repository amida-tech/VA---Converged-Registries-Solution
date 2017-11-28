using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_MENU_ITEMSManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static STD_MENU_ITEMS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 MENU_ID)
		{
			STD_MENU_ITEMS objReturn = null;
			STD_MENU_ITEMSDB objDB = new STD_MENU_ITEMSDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, MENU_ID);

			return objReturn;
		}

		public static List<STD_MENU_ITEMS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_MENU_ITEMS> objReturn = null;
			STD_MENU_ITEMSDB objDB = new STD_MENU_ITEMSDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_MENU_ITEMS objSave)
		{
			Int32 objReturn = 0;
			STD_MENU_ITEMSDB objDB = new STD_MENU_ITEMSDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 MENU_ID)
		{
			Boolean objReturn = false;
			STD_MENU_ITEMSDB objDB = new STD_MENU_ITEMSDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, MENU_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_MENU_ITEMS objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.MENU_ID);
		}

		#endregion
	}
}
