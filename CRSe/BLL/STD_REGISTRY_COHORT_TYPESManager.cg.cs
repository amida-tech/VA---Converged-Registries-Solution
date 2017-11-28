using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_REGISTRY_COHORT_TYPESManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static STD_REGISTRY_COHORT_TYPES GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 COHORT_TYPE_ID)
		{
			STD_REGISTRY_COHORT_TYPES objReturn = null;
			STD_REGISTRY_COHORT_TYPESDB objDB = new STD_REGISTRY_COHORT_TYPESDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, COHORT_TYPE_ID);

			return objReturn;
		}

		public static List<STD_REGISTRY_COHORT_TYPES> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<STD_REGISTRY_COHORT_TYPES> objReturn = null;
			STD_REGISTRY_COHORT_TYPESDB objDB = new STD_REGISTRY_COHORT_TYPESDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_REGISTRY_COHORT_TYPES objSave)
		{
			Int32 objReturn = 0;
			STD_REGISTRY_COHORT_TYPESDB objDB = new STD_REGISTRY_COHORT_TYPESDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 COHORT_TYPE_ID)
		{
			Boolean objReturn = false;
			STD_REGISTRY_COHORT_TYPESDB objDB = new STD_REGISTRY_COHORT_TYPESDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, COHORT_TYPE_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, STD_REGISTRY_COHORT_TYPES objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.COHORT_TYPE_ID);
		}

		#endregion
	}
}
