using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class USER_ACTIVITY_LOGManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static USER_ACTIVITY_LOG GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ACTIVITY_LOG_ID)
		{
			USER_ACTIVITY_LOG objReturn = null;
			USER_ACTIVITY_LOGDB objDB = new USER_ACTIVITY_LOGDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, ACTIVITY_LOG_ID);

			return objReturn;
		}

		public static List<USER_ACTIVITY_LOG> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<USER_ACTIVITY_LOG> objReturn = null;
			USER_ACTIVITY_LOGDB objDB = new USER_ACTIVITY_LOGDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, USER_ACTIVITY_LOG objSave)
		{
			Int32 objReturn = 0;
			USER_ACTIVITY_LOGDB objDB = new USER_ACTIVITY_LOGDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ACTIVITY_LOG_ID)
		{
			Boolean objReturn = false;
			USER_ACTIVITY_LOGDB objDB = new USER_ACTIVITY_LOGDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, ACTIVITY_LOG_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, USER_ACTIVITY_LOG objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.ACTIVITY_LOG_ID);
		}

		#endregion
	}
}
