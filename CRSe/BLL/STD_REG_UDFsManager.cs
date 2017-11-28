using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_REG_UDFsManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<STD_REG_UDFs> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_REG_UDFs> objReturn = null;
            STD_REG_UDFsDB objDB = new STD_REG_UDFsDB();

            objReturn = objDB.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

		#endregion
	}
}
