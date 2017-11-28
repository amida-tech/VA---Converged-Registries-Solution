using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class REGISTRY_COHORT_DATAManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static REGISTRY_COHORT_DATA GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			REGISTRY_COHORT_DATA objReturn = null;
			REGISTRY_COHORT_DATADB objDB = new REGISTRY_COHORT_DATADB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static List<REGISTRY_COHORT_DATA> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<REGISTRY_COHORT_DATA> objReturn = null;
			REGISTRY_COHORT_DATADB objDB = new REGISTRY_COHORT_DATADB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, REGISTRY_COHORT_DATA objSave)
		{
			Int32 objReturn = 0;
			REGISTRY_COHORT_DATADB objDB = new REGISTRY_COHORT_DATADB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			Boolean objReturn = false;
			REGISTRY_COHORT_DATADB objDB = new REGISTRY_COHORT_DATADB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, REGISTRY_COHORT_DATA objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.ID);
		}

		#endregion
	}
}
