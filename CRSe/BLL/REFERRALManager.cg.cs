using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class REFERRALManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static REFERRAL GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 REFERRAL_ID)
		{
			REFERRAL objReturn = null;
			REFERRALDB objDB = new REFERRALDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, REFERRAL_ID);

			return objReturn;
		}

		public static List<REFERRAL> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<REFERRAL> objReturn = null;
			REFERRALDB objDB = new REFERRALDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, REFERRAL objSave)
		{
			Int32 objReturn = 0;
			REFERRALDB objDB = new REFERRALDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 REFERRAL_ID)
		{
			Boolean objReturn = false;
			REFERRALDB objDB = new REFERRALDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, REFERRAL_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, REFERRAL objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.REFERRAL_ID);
		}

		#endregion
	}
}
