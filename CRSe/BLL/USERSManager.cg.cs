using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class USERSManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static USERS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ID)
		{
			USERS objReturn = null;
			USERSDB objDB = new USERSDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ID);

			return objReturn;
		}

		public static List<USERS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<USERS> objReturn = null;
			USERSDB objDB = new USERSDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, USERS objSave)
		{
			Int32 objReturn = 0;
			USERSDB objDB = new USERSDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ID)
		{
			Boolean objReturn = false;
			USERSDB objDB = new USERSDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, USERS objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.USER_ID);
		}

		#endregion
	}
}
