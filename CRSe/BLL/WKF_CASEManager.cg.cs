using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class WKF_CASEManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static WKF_CASE GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_ID)
		{
			WKF_CASE objReturn = null;
			WKF_CASEDB objDB = new WKF_CASEDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_ID);

			return objReturn;
		}

		public static List<WKF_CASE> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<WKF_CASE> objReturn = null;
			WKF_CASEDB objDB = new WKF_CASEDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, WKF_CASE objSave)
		{
			Int32 objReturn = 0;
			WKF_CASEDB objDB = new WKF_CASEDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_ID)
		{
			Boolean objReturn = false;
			WKF_CASEDB objDB = new WKF_CASEDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, WKF_CASE objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.WKF_CASE_ID);
		}

		#endregion
	}
}
