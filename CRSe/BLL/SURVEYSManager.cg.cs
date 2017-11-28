using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class SURVEYSManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static SURVEYS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 SURVEYS_ID)
		{
			SURVEYS objReturn = null;
			SURVEYSDB objDB = new SURVEYSDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, SURVEYS_ID);

			return objReturn;
		}

		public static List<SURVEYS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<SURVEYS> objReturn = null;
			SURVEYSDB objDB = new SURVEYSDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SURVEYS objSave)
		{
			Int32 objReturn = 0;
			SURVEYSDB objDB = new SURVEYSDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 SURVEYS_ID)
		{
			Boolean objReturn = false;
			SURVEYSDB objDB = new SURVEYSDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, SURVEYS_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SURVEYS objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.SURVEYS_ID);
		}

		#endregion
	}
}
