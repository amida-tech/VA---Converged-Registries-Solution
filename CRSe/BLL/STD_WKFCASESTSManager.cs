using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_WKFCASESTSManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static STD_WKFCASESTS GetItemByCode(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string CODE)
        {
            STD_WKFCASESTS objReturn = null;
            STD_WKFCASESTSDB objDB = new STD_WKFCASESTSDB();

            objReturn = objDB.GetItemByCode(CURRENT_USER, CURRENT_REGISTRY_ID, CODE);

            return objReturn;
        }

		#endregion
	}
}
