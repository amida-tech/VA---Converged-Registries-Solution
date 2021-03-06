using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class PATIENT_IDSManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static PATIENT_IDS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			PATIENT_IDS objReturn = null;
			PATIENT_IDSDB objDB = new PATIENT_IDSDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static List<PATIENT_IDS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<PATIENT_IDS> objReturn = null;
			PATIENT_IDSDB objDB = new PATIENT_IDSDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, PATIENT_IDS objSave)
		{
			Int32 objReturn = 0;
			PATIENT_IDSDB objDB = new PATIENT_IDSDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			Boolean objReturn = false;
			PATIENT_IDSDB objDB = new PATIENT_IDSDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, PATIENT_IDS objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.ID);
		}

		#endregion
	}
}
