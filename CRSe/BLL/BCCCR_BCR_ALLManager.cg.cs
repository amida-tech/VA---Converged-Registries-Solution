using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class BCCCR_BCR_ALLManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static BCCCR_BCR_ALL GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			BCCCR_BCR_ALL objReturn = null;
			BCCCR_BCR_ALLDB objDB = new BCCCR_BCR_ALLDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static List<BCCCR_BCR_ALL> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<BCCCR_BCR_ALL> objReturn = null;
			BCCCR_BCR_ALLDB objDB = new BCCCR_BCR_ALLDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, BCCCR_BCR_ALL objSave)
		{
			Int32 objReturn = 0;
			BCCCR_BCR_ALLDB objDB = new BCCCR_BCR_ALLDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			Boolean objReturn = false;
			BCCCR_BCR_ALLDB objDB = new BCCCR_BCR_ALLDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, BCCCR_BCR_ALL objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.ID);
		}

		#endregion
	}
}
