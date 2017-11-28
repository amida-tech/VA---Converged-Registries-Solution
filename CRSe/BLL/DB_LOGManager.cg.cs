using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class DB_LOGManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static DB_LOG GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CRS_DB_LOG_ID)
		{
			DB_LOG objReturn = null;
			DB_LOGDB objDB = new DB_LOGDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, CRS_DB_LOG_ID);

			return objReturn;
		}

		public static List<DB_LOG> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<DB_LOG> objReturn = null;
			DB_LOGDB objDB = new DB_LOGDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DB_LOG objSave)
		{
			Int32 objReturn = 0;
			DB_LOGDB objDB = new DB_LOGDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CRS_DB_LOG_ID)
		{
			Boolean objReturn = false;
			DB_LOGDB objDB = new DB_LOGDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, CRS_DB_LOG_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DB_LOG objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.CRS_DB_LOG_ID);
		}

		#endregion
	}
}
