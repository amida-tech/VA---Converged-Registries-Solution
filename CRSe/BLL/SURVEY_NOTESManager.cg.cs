using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class SURVEY_NOTESManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static SURVEY_NOTES GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 NOTE_ID)
		{
			SURVEY_NOTES objReturn = null;
			SURVEY_NOTESDB objDB = new SURVEY_NOTESDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, NOTE_ID);

			return objReturn;
		}

		public static List<SURVEY_NOTES> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<SURVEY_NOTES> objReturn = null;
			SURVEY_NOTESDB objDB = new SURVEY_NOTESDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SURVEY_NOTES objSave)
		{
			Int32 objReturn = 0;
			SURVEY_NOTESDB objDB = new SURVEY_NOTESDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 NOTE_ID)
		{
			Boolean objReturn = false;
			SURVEY_NOTESDB objDB = new SURVEY_NOTESDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, NOTE_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SURVEY_NOTES objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.NOTE_ID);
		}

		#endregion
	}
}
