using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class REFERRAL_DETAILManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static REFERRAL_DETAIL GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 REFERRAL_DETAIL_ID)
		{
			REFERRAL_DETAIL objReturn = null;
			REFERRAL_DETAILDB objDB = new REFERRAL_DETAILDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, REFERRAL_DETAIL_ID);

			return objReturn;
		}

		public static List<REFERRAL_DETAIL> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<REFERRAL_DETAIL> objReturn = null;
			REFERRAL_DETAILDB objDB = new REFERRAL_DETAILDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, REFERRAL_DETAIL objSave)
		{
			Int32 objReturn = 0;
			REFERRAL_DETAILDB objDB = new REFERRAL_DETAILDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 REFERRAL_DETAIL_ID)
		{
			Boolean objReturn = false;
			REFERRAL_DETAILDB objDB = new REFERRAL_DETAILDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, REFERRAL_DETAIL_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, REFERRAL_DETAIL objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.REFERRAL_DETAIL_ID);
		}

		#endregion
	}
}
