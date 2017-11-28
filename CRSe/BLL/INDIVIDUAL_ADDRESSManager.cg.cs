using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class INDIVIDUAL_ADDRESSManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static INDIVIDUAL_ADDRESS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ADDRESS_ID)
		{
			INDIVIDUAL_ADDRESS objReturn = null;
			INDIVIDUAL_ADDRESSDB objDB = new INDIVIDUAL_ADDRESSDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, ADDRESS_ID);

			return objReturn;
		}

		public static List<INDIVIDUAL_ADDRESS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<INDIVIDUAL_ADDRESS> objReturn = null;
			INDIVIDUAL_ADDRESSDB objDB = new INDIVIDUAL_ADDRESSDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, INDIVIDUAL_ADDRESS objSave)
		{
			Int32 objReturn = 0;
			INDIVIDUAL_ADDRESSDB objDB = new INDIVIDUAL_ADDRESSDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ADDRESS_ID)
		{
			Boolean objReturn = false;
			INDIVIDUAL_ADDRESSDB objDB = new INDIVIDUAL_ADDRESSDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, ADDRESS_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, INDIVIDUAL_ADDRESS objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.ADDRESS_ID);
		}

		#endregion
	}
}
