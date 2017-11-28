using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class WKF_CASE_ASSIGNMENTManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static WKF_CASE_ASSIGNMENT GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_ASSIGNMENT_ID)
		{
			WKF_CASE_ASSIGNMENT objReturn = null;
			WKF_CASE_ASSIGNMENTDB objDB = new WKF_CASE_ASSIGNMENTDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_ASSIGNMENT_ID);

			return objReturn;
		}

		public static List<WKF_CASE_ASSIGNMENT> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<WKF_CASE_ASSIGNMENT> objReturn = null;
			WKF_CASE_ASSIGNMENTDB objDB = new WKF_CASE_ASSIGNMENTDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, WKF_CASE_ASSIGNMENT objSave)
		{
			Int32 objReturn = 0;
			WKF_CASE_ASSIGNMENTDB objDB = new WKF_CASE_ASSIGNMENTDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_ASSIGNMENT_ID)
		{
			Boolean objReturn = false;
			WKF_CASE_ASSIGNMENTDB objDB = new WKF_CASE_ASSIGNMENTDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_ASSIGNMENT_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, WKF_CASE_ASSIGNMENT objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.WKF_CASE_ASSIGNMENT_ID);
		}

		#endregion
	}
}
