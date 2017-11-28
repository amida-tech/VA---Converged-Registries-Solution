using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_QUESTION_CHOICEManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static STD_QUESTION_CHOICE GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_QUESTION_CHOICE_ID)
		{
			STD_QUESTION_CHOICE objReturn = null;
			STD_QUESTION_CHOICEDB objDB = new STD_QUESTION_CHOICEDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, STD_QUESTION_CHOICE_ID);

			return objReturn;
		}

		public static List<STD_QUESTION_CHOICE> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_QUESTION_CHOICE> objReturn = null;
			STD_QUESTION_CHOICEDB objDB = new STD_QUESTION_CHOICEDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_QUESTION_CHOICE objSave)
		{
			Int32 objReturn = 0;
			STD_QUESTION_CHOICEDB objDB = new STD_QUESTION_CHOICEDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_QUESTION_CHOICE_ID)
		{
			Boolean objReturn = false;
			STD_QUESTION_CHOICEDB objDB = new STD_QUESTION_CHOICEDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, STD_QUESTION_CHOICE_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_QUESTION_CHOICE objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.STD_QUESTION_CHOICE_ID);
		}

		#endregion
	}
}
