using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_SURVEY_SECTIONManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static STD_SURVEY_SECTION GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_SURVEY_SECTION_ID)
		{
			STD_SURVEY_SECTION objReturn = null;
			STD_SURVEY_SECTIONDB objDB = new STD_SURVEY_SECTIONDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, STD_SURVEY_SECTION_ID);

			return objReturn;
		}

		public static List<STD_SURVEY_SECTION> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_SURVEY_SECTION> objReturn = null;
			STD_SURVEY_SECTIONDB objDB = new STD_SURVEY_SECTIONDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_SURVEY_SECTION objSave)
		{
			Int32 objReturn = 0;
			STD_SURVEY_SECTIONDB objDB = new STD_SURVEY_SECTIONDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_SURVEY_SECTION_ID)
		{
			Boolean objReturn = false;
			STD_SURVEY_SECTIONDB objDB = new STD_SURVEY_SECTIONDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, STD_SURVEY_SECTION_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_SURVEY_SECTION objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.STD_SURVEY_SECTION_ID);
		}

		#endregion
	}
}
