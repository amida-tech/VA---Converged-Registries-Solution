using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class SURVEY_RESULTSManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static SURVEY_RESULTS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 SURVEY_RESULT_ID)
		{
			SURVEY_RESULTS objReturn = null;
			SURVEY_RESULTSDB objDB = new SURVEY_RESULTSDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, SURVEY_RESULT_ID);

			return objReturn;
		}

		public static List<SURVEY_RESULTS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<SURVEY_RESULTS> objReturn = null;
			SURVEY_RESULTSDB objDB = new SURVEY_RESULTSDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SURVEY_RESULTS objSave)
		{
			Int32 objReturn = 0;
			SURVEY_RESULTSDB objDB = new SURVEY_RESULTSDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 SURVEY_RESULT_ID)
		{
			Boolean objReturn = false;
			SURVEY_RESULTSDB objDB = new SURVEY_RESULTSDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, SURVEY_RESULT_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SURVEY_RESULTS objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.SURVEY_RESULT_ID);
		}

		#endregion
	}
}
