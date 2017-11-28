using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_ROLEManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<STD_ROLE> GetSystemRoles(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_ROLE> objReturn = null;
            STD_ROLEDB objDB = new STD_ROLEDB();

            objReturn = objDB.GetSystemRoles(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<STD_ROLE> GetRegistryRoles(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_ROLE> objReturn = null;
            STD_ROLEDB objDB = new STD_ROLEDB();

            objReturn = objDB.GetRegistryRoles(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<STD_ROLE> GetItemsByUserRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_ROLE> objReturn = null;
            STD_ROLEDB objDB = new STD_ROLEDB();

            objReturn = objDB.GetItemsByUserRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

		#endregion
	}
}
