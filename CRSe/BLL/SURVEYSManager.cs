using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class SURVEYSManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static SURVEYS GetItemForSurvey(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 SURVEYS_ID)
        {
            SURVEYS objReturn = null;
            SURVEYSDB objDB = new SURVEYSDB();

            objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, SURVEYS_ID);
            if (objReturn != null)
            {
                if (objReturn.STD_SURVEY_TYPE_ID > 0)
                    objReturn.STD_SURVEY_TYPE = STD_SURVEY_TYPEManager.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, objReturn.STD_SURVEY_TYPE_ID);

                objReturn.SURVEY_RESULTS = SURVEY_RESULTSManager.GetItemsBySurvey(CURRENT_USER, CURRENT_REGISTRY_ID, SURVEYS_ID);
            }

            return objReturn;
        }

        public static List<SURVEYS> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<SURVEYS> objReturn = null;
            SURVEYSDB objDB = new SURVEYSDB();

            objReturn = objDB.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

		#endregion
	}
}
