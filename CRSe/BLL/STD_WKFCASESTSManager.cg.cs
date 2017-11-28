using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_WKFCASESTSManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static STD_WKFCASESTS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			STD_WKFCASESTS objReturn = null;
			STD_WKFCASESTSDB objDB = new STD_WKFCASESTSDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static List<STD_WKFCASESTS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_WKFCASESTS> objReturn = null;
			STD_WKFCASESTSDB objDB = new STD_WKFCASESTSDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_WKFCASESTS objSave)
		{
			Int32 objReturn = 0;
			STD_WKFCASESTSDB objDB = new STD_WKFCASESTSDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			Boolean objReturn = false;
			STD_WKFCASESTSDB objDB = new STD_WKFCASESTSDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_WKFCASESTS objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.ID);
		}

		#endregion
	}
}
