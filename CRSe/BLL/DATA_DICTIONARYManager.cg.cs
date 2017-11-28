using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class DATA_DICTIONARYManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static DATA_DICTIONARY GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string ObjectName)
		{
			DATA_DICTIONARY objReturn = null;
			DATA_DICTIONARYDB objDB = new DATA_DICTIONARYDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, ObjectName);

			return objReturn;
		}

		public static List<DATA_DICTIONARY> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<DATA_DICTIONARY> objReturn = null;
			DATA_DICTIONARYDB objDB = new DATA_DICTIONARYDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static string Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DATA_DICTIONARY objSave)
		{
			string objReturn = string.Empty;
			DATA_DICTIONARYDB objDB = new DATA_DICTIONARYDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string ObjectName)
		{
			Boolean objReturn = false;
			DATA_DICTIONARYDB objDB = new DATA_DICTIONARYDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, ObjectName);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DATA_DICTIONARY objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.ObjectName);
		}

		#endregion
	}
}
