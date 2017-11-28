using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_WEB_PAGESManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static STD_WEB_PAGES GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PAGE_ID)
		{
			STD_WEB_PAGES objReturn = null;
			STD_WEB_PAGESDB objDB = new STD_WEB_PAGESDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, PAGE_ID);

			return objReturn;
		}

		public static List<STD_WEB_PAGES> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_WEB_PAGES> objReturn = null;
			STD_WEB_PAGESDB objDB = new STD_WEB_PAGESDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_WEB_PAGES objSave)
		{
			Int32 objReturn = 0;
			STD_WEB_PAGESDB objDB = new STD_WEB_PAGESDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PAGE_ID)
		{
			Boolean objReturn = false;
			STD_WEB_PAGESDB objDB = new STD_WEB_PAGESDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, PAGE_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_WEB_PAGES objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.PAGE_ID);
		}

		#endregion
	}
}
