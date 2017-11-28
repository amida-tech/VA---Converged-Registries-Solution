using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class PATIENTManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static PATIENT GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PATIENT_ID)
		{
			PATIENT objReturn = null;
			PATIENTDB objDB = new PATIENTDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID);

			return objReturn;
		}

		public static List<PATIENT> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<PATIENT> objReturn = null;
			PATIENTDB objDB = new PATIENTDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, PATIENT objSave)
		{
			Int32 objReturn = 0;
			PATIENTDB objDB = new PATIENTDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PATIENT_ID)
		{
			Boolean objReturn = false;
			PATIENTDB objDB = new PATIENTDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, PATIENT objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.PATIENT_ID);
		}

		#endregion
	}
}
