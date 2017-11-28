using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class SURVEY_RESULTSManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<SURVEY_RESULTS> GetItemsBySurvey(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 SURVEYS_ID)
        {
            List<SURVEY_RESULTS> objReturn = null;
            SURVEY_RESULTSDB objDB = new SURVEY_RESULTSDB();

            objReturn = objDB.GetItemsBySurvey(CURRENT_USER, CURRENT_REGISTRY_ID, SURVEYS_ID);

            return objReturn;
        }

        public static Boolean SaveAll(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, List<SURVEY_RESULTS> RESULTS)
        {
            Boolean objReturn = false;
            SURVEY_RESULTSDB objDB = new SURVEY_RESULTSDB();

            if (RESULTS != null)
                objReturn = objDB.SaveAll(CURRENT_USER, CURRENT_REGISTRY_ID, RESULTS);

            return objReturn;
        }

		#endregion
	}
}
