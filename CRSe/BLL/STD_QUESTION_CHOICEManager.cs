using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_QUESTION_CHOICEManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<STD_QUESTION_CHOICE> GetItemsByQuestion(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_QUESTION_ID)
        {
            List<STD_QUESTION_CHOICE> objReturn = null;
            STD_QUESTION_CHOICEDB objDB = new STD_QUESTION_CHOICEDB();

            objReturn = objDB.GetItemsByQuestion(CURRENT_USER, CURRENT_REGISTRY_ID, STD_QUESTION_ID);

            return objReturn;
        }

		#endregion
	}
}
