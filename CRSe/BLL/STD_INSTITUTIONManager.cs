using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_INSTITUTIONManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static STD_INSTITUTION GetItemComplete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
        {
            STD_INSTITUTION objReturn = null;
            STD_INSTITUTIONDB objDB = new STD_INSTITUTIONDB();

            objReturn = objDB.GetItemComplete(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

            return objReturn;
        }

        public static List<STD_INSTITUTION> GetFacs(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_INSTITUTION> objReturn = null;
            STD_INSTITUTIONDB objDB = new STD_INSTITUTIONDB();

            objReturn = objDB.GetFacs(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

		#endregion
	}
}
