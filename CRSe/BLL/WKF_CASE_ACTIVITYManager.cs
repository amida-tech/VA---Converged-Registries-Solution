using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class WKF_CASE_ACTIVITYManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<WKF_CASE_ACTIVITY> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<WKF_CASE_ACTIVITY> objReturn = null;
            WKF_CASE_ACTIVITYDB objDB = new WKF_CASE_ACTIVITYDB();

            objReturn = objDB.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<WKF_CASE_ACTIVITY> GetItemsByWorkstream(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_ID)
        {
            List<WKF_CASE_ACTIVITY> objReturn = null;
            WKF_CASE_ACTIVITYDB objDB = new WKF_CASE_ACTIVITYDB();

            objReturn = objDB.GetItemsByWorkstream(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_ID);

            return objReturn;
        }

        public static Boolean UpdateStatus(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_ACTIVITY_ID, Int32 STD_WKFACTIVITYSTS_ID)
        {
            Boolean objReturn = false;
            WKF_CASE_ACTIVITYDB objDB = new WKF_CASE_ACTIVITYDB();

            objReturn = objDB.UpdateStatus(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_ACTIVITY_ID, STD_WKFACTIVITYSTS_ID);

            return objReturn;
        }

		#endregion
	}
}
