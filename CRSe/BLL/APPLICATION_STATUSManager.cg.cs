using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class APPLICATION_STATUSManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static APPLICATION_STATUS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STATUS_ID)
		{
			APPLICATION_STATUS objReturn = null;
			APPLICATION_STATUSDB objDB = new APPLICATION_STATUSDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, STATUS_ID);

			return objReturn;
		}

		public static List<APPLICATION_STATUS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<APPLICATION_STATUS> objReturn = null;
			APPLICATION_STATUSDB objDB = new APPLICATION_STATUSDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, APPLICATION_STATUS objSave)
		{
			Int32 objReturn = 0;
			APPLICATION_STATUSDB objDB = new APPLICATION_STATUSDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STATUS_ID)
		{
			Boolean objReturn = false;
			APPLICATION_STATUSDB objDB = new APPLICATION_STATUSDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, STATUS_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, APPLICATION_STATUS objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.STATUS_ID);
		}

		#endregion
	}
}
