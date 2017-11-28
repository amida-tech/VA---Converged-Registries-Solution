using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_QUESTIONManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<STD_QUESTION> GetItemsBySurvey(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_SURVEY_TYPE_ID)
        {
            List<STD_QUESTION> objReturn = null;
            STD_QUESTIONDB objDB = new STD_QUESTIONDB();

            objReturn = objDB.GetItemsBySurvey(CURRENT_USER, CURRENT_REGISTRY_ID, STD_SURVEY_TYPE_ID);

            return objReturn;
        }

        public static Boolean CopyChoices(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 OLD_QUESTION_ID, Int32 NEW_QUESTION_ID)
        {
            Boolean objReturn = false;
            STD_QUESTIONDB objDB = new STD_QUESTIONDB();

            objReturn = objDB.CopyChoices(CURRENT_USER, CURRENT_REGISTRY_ID, OLD_QUESTION_ID, NEW_QUESTION_ID);

            return objReturn;
        }

		#endregion
	}
}
