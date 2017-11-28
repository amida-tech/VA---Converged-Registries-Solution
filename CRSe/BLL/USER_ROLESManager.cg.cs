using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class USER_ROLESManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static USER_ROLES GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ROLE_ID)
		{
			USER_ROLES objReturn = null;
			USER_ROLESDB objDB = new USER_ROLESDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ROLE_ID);

			return objReturn;
		}

		public static List<USER_ROLES> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<USER_ROLES> objReturn = null;
			USER_ROLESDB objDB = new USER_ROLESDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, USER_ROLES objSave)
		{
			Int32 objReturn = 0;
			USER_ROLESDB objDB = new USER_ROLESDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 USER_ROLE_ID)
		{
			Boolean objReturn = false;
			USER_ROLESDB objDB = new USER_ROLESDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ROLE_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, USER_ROLES objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.USER_ROLE_ID);
		}

		#endregion
	}
}
