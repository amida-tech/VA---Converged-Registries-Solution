using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_USER_ACTIVITY_TYPEManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static STD_USER_ACTIVITY_TYPE GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			STD_USER_ACTIVITY_TYPE objReturn = null;
			STD_USER_ACTIVITY_TYPEDB objDB = new STD_USER_ACTIVITY_TYPEDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static List<STD_USER_ACTIVITY_TYPE> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_USER_ACTIVITY_TYPE> objReturn = null;
			STD_USER_ACTIVITY_TYPEDB objDB = new STD_USER_ACTIVITY_TYPEDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_USER_ACTIVITY_TYPE objSave)
		{
			Int32 objReturn = 0;
			STD_USER_ACTIVITY_TYPEDB objDB = new STD_USER_ACTIVITY_TYPEDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			Boolean objReturn = false;
			STD_USER_ACTIVITY_TYPEDB objDB = new STD_USER_ACTIVITY_TYPEDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_USER_ACTIVITY_TYPE objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.ID);
		}

		#endregion
	}
}
