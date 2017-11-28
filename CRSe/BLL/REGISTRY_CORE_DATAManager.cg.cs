using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class REGISTRY_CORE_DATAManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static REGISTRY_CORE_DATA GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CORE_DATA_ID)
		{
			REGISTRY_CORE_DATA objReturn = null;
			REGISTRY_CORE_DATADB objDB = new REGISTRY_CORE_DATADB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, CORE_DATA_ID);

			return objReturn;
		}

		public static List<REGISTRY_CORE_DATA> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<REGISTRY_CORE_DATA> objReturn = null;
			REGISTRY_CORE_DATADB objDB = new REGISTRY_CORE_DATADB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, REGISTRY_CORE_DATA objSave)
		{
			Int32 objReturn = 0;
			REGISTRY_CORE_DATADB objDB = new REGISTRY_CORE_DATADB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CORE_DATA_ID)
		{
			Boolean objReturn = false;
			REGISTRY_CORE_DATADB objDB = new REGISTRY_CORE_DATADB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, CORE_DATA_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, REGISTRY_CORE_DATA objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.CORE_DATA_ID);
		}

		#endregion
	}
}
