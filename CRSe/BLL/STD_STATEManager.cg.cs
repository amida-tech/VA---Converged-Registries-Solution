using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_STATEManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static STD_STATE GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			STD_STATE objReturn = null;
			STD_STATEDB objDB = new STD_STATEDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static List<STD_STATE> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_STATE> objReturn = null;
			STD_STATEDB objDB = new STD_STATEDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_STATE objSave)
		{
			Int32 objReturn = 0;
			STD_STATEDB objDB = new STD_STATEDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			Boolean objReturn = false;
			STD_STATEDB objDB = new STD_STATEDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_STATE objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.ID);
		}

		#endregion
	}
}
