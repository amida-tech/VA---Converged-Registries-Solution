using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_WKFACTIVITYTYPEManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<STD_WKFACTIVITYTYPE> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_WKFACTIVITYTYPE> objReturn = null;
            STD_WKFACTIVITYTYPEDB objDB = new STD_WKFACTIVITYTYPEDB();

            objReturn = objDB.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<STD_WKFACTIVITYTYPE> GetItemsByWorkstream(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_WKFCASETYPE_ID)
        {
            List<STD_WKFACTIVITYTYPE> objReturn = null;
            STD_WKFACTIVITYTYPEDB objDB = new STD_WKFACTIVITYTYPEDB();

            objReturn = objDB.GetItemsByWorkstream(CURRENT_USER, CURRENT_REGISTRY_ID, STD_WKFCASETYPE_ID);

            return objReturn;
        }

		#endregion
	}
}
