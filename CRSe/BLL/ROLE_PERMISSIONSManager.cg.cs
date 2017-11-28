using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class ROLE_PERMISSIONSManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static ROLE_PERMISSIONS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ROLE_PERMISSION_ID)
		{
			ROLE_PERMISSIONS objReturn = null;
			ROLE_PERMISSIONSDB objDB = new ROLE_PERMISSIONSDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, ROLE_PERMISSION_ID);

			return objReturn;
		}

		public static List<ROLE_PERMISSIONS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<ROLE_PERMISSIONS> objReturn = null;
			ROLE_PERMISSIONSDB objDB = new ROLE_PERMISSIONSDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, ROLE_PERMISSIONS objSave)
		{
			Int32 objReturn = 0;
			ROLE_PERMISSIONSDB objDB = new ROLE_PERMISSIONSDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ROLE_PERMISSION_ID)
		{
			Boolean objReturn = false;
			ROLE_PERMISSIONSDB objDB = new ROLE_PERMISSIONSDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, ROLE_PERMISSION_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, ROLE_PERMISSIONS objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.ROLE_PERMISSION_ID);
		}

		#endregion
	}
}
