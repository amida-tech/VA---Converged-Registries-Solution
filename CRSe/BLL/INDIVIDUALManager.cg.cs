using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class INDIVIDUALManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static INDIVIDUAL GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 IND_ID)
		{
			INDIVIDUAL objReturn = null;
			INDIVIDUALDB objDB = new INDIVIDUALDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, IND_ID);

			return objReturn;
		}

		public static List<INDIVIDUAL> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<INDIVIDUAL> objReturn = null;
			INDIVIDUALDB objDB = new INDIVIDUALDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, INDIVIDUAL objSave)
		{
			Int32 objReturn = 0;
			INDIVIDUALDB objDB = new INDIVIDUALDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 IND_ID)
		{
			Boolean objReturn = false;
			INDIVIDUALDB objDB = new INDIVIDUALDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, IND_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, INDIVIDUAL objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.IND_ID);
		}

		#endregion
	}
}
