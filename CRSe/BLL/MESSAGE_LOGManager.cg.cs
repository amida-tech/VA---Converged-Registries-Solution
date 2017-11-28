using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class MESSAGE_LOGManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static MESSAGE_LOG GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CALL_ID)
		{
			MESSAGE_LOG objReturn = null;
			MESSAGE_LOGDB objDB = new MESSAGE_LOGDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, CALL_ID);

			return objReturn;
		}

		public static List<MESSAGE_LOG> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<MESSAGE_LOG> objReturn = null;
			MESSAGE_LOGDB objDB = new MESSAGE_LOGDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, MESSAGE_LOG objSave)
		{
			Int32 objReturn = 0;
			MESSAGE_LOGDB objDB = new MESSAGE_LOGDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CALL_ID)
		{
			Boolean objReturn = false;
			MESSAGE_LOGDB objDB = new MESSAGE_LOGDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, CALL_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, MESSAGE_LOG objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.CALL_ID);
		}

		#endregion
	}
}
