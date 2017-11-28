using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_INDIVIDUAL_GROUPManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static STD_INDIVIDUAL_GROUP GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 GROUP_ID)
		{
			STD_INDIVIDUAL_GROUP objReturn = null;
			STD_INDIVIDUAL_GROUPDB objDB = new STD_INDIVIDUAL_GROUPDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, GROUP_ID);

			return objReturn;
		}

		public static List<STD_INDIVIDUAL_GROUP> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_INDIVIDUAL_GROUP> objReturn = null;
			STD_INDIVIDUAL_GROUPDB objDB = new STD_INDIVIDUAL_GROUPDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_INDIVIDUAL_GROUP objSave)
		{
			Int32 objReturn = 0;
			STD_INDIVIDUAL_GROUPDB objDB = new STD_INDIVIDUAL_GROUPDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 GROUP_ID)
		{
			Boolean objReturn = false;
			STD_INDIVIDUAL_GROUPDB objDB = new STD_INDIVIDUAL_GROUPDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, GROUP_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_INDIVIDUAL_GROUP objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.GROUP_ID);
		}

		#endregion
	}
}
