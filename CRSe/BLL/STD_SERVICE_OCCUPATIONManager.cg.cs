using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_SERVICE_OCCUPATIONManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static STD_SERVICE_OCCUPATION GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_SERVICE_OCCUPATION_ID)
		{
			STD_SERVICE_OCCUPATION objReturn = null;
			STD_SERVICE_OCCUPATIONDB objDB = new STD_SERVICE_OCCUPATIONDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, STD_SERVICE_OCCUPATION_ID);

			return objReturn;
		}

		public static List<STD_SERVICE_OCCUPATION> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_SERVICE_OCCUPATION> objReturn = null;
			STD_SERVICE_OCCUPATIONDB objDB = new STD_SERVICE_OCCUPATIONDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_SERVICE_OCCUPATION objSave)
		{
			Int32 objReturn = 0;
			STD_SERVICE_OCCUPATIONDB objDB = new STD_SERVICE_OCCUPATIONDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_SERVICE_OCCUPATION_ID)
		{
			Boolean objReturn = false;
			STD_SERVICE_OCCUPATIONDB objDB = new STD_SERVICE_OCCUPATIONDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, STD_SERVICE_OCCUPATION_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_SERVICE_OCCUPATION objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.STD_SERVICE_OCCUPATION_ID);
		}

		#endregion
	}
}
