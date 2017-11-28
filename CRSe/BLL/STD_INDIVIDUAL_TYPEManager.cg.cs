using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_INDIVIDUAL_TYPEManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static STD_INDIVIDUAL_TYPE GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 TYPE_ID)
		{
			STD_INDIVIDUAL_TYPE objReturn = null;
			STD_INDIVIDUAL_TYPEDB objDB = new STD_INDIVIDUAL_TYPEDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, TYPE_ID);

			return objReturn;
		}

		public static List<STD_INDIVIDUAL_TYPE> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_INDIVIDUAL_TYPE> objReturn = null;
			STD_INDIVIDUAL_TYPEDB objDB = new STD_INDIVIDUAL_TYPEDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_INDIVIDUAL_TYPE objSave)
		{
			Int32 objReturn = 0;
			STD_INDIVIDUAL_TYPEDB objDB = new STD_INDIVIDUAL_TYPEDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 TYPE_ID)
		{
			Boolean objReturn = false;
			STD_INDIVIDUAL_TYPEDB objDB = new STD_INDIVIDUAL_TYPEDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, TYPE_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_INDIVIDUAL_TYPE objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.TYPE_ID);
		}

		#endregion
	}
}
