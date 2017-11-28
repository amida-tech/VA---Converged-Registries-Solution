using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_SURVEY_TYPEManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<STD_SURVEY_TYPE> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_SURVEY_TYPE> objReturn = null;
            STD_SURVEY_TYPEDB objDB = new STD_SURVEY_TYPEDB();

            objReturn = objDB.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

		#endregion
	}
}
