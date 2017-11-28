using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class WKF_CASEManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<WKF_CASE> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<WKF_CASE> objReturn = null;
            WKF_CASEDB objDB = new WKF_CASEDB();

            objReturn = objDB.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static Boolean UpdateStatus(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_ID, Int32 STD_WKFCASESTS_ID)
        {
            Boolean objReturn = false;
            WKF_CASEDB objDB = new WKF_CASEDB();

            objReturn = objDB.UpdateStatus(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_ID, STD_WKFCASESTS_ID);

            return objReturn;
        }

		#endregion
	}
}
