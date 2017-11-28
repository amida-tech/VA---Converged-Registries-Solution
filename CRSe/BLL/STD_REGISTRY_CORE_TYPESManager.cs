using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_REGISTRY_CORE_TYPESManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<STD_REGISTRY_CORE_TYPES> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string TABLE_NAME)
        {
            List<STD_REGISTRY_CORE_TYPES> objReturn = null;
            STD_REGISTRY_CORE_TYPESDB objDB = new STD_REGISTRY_CORE_TYPESDB();

            objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID, TABLE_NAME);

            return objReturn;
        }

        public static STD_REGISTRY_CORE_TYPES GetItemByTableCode(string TABLE_NAME, string CODE)
        {
            STD_REGISTRY_CORE_TYPES objReturn = null;
            STD_REGISTRY_CORE_TYPESDB objDB = new STD_REGISTRY_CORE_TYPESDB();

            objReturn = objDB.GetItemByTableCode(TABLE_NAME, CODE);

            return objReturn;
        }

		#endregion
	}
}
