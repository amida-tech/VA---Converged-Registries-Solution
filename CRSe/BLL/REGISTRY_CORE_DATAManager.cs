using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class REGISTRY_CORE_DATAManager
	{
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        public static REGISTRY_CORE_DATA GetItemByRegistryCore(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 CORE_TYPE_ID)
        {
            REGISTRY_CORE_DATA objReturn = null;
            REGISTRY_CORE_DATADB objDB = new REGISTRY_CORE_DATADB();

            objReturn = objDB.GetItemByRegistryCore(CURRENT_USER, CURRENT_REGISTRY_ID, CORE_TYPE_ID);

            return objReturn;
        }

        public static List<REGISTRY_CORE_DATA> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<REGISTRY_CORE_DATA> objReturn = null;
            REGISTRY_CORE_DATADB objDB = new REGISTRY_CORE_DATADB();

            objReturn = objDB.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static Boolean SaveList(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, List<REGISTRY_CORE_DATA> cores)
        {
            if (cores == null) return false;

            Boolean objReturn = false;
            REGISTRY_CORE_DATADB objDB = new REGISTRY_CORE_DATADB();

            objReturn = objDB.SaveList(CURRENT_USER, CURRENT_REGISTRY_ID, cores);

            return objReturn;
        }

        #endregion
	}
}
