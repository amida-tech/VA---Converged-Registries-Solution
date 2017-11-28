using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class SStaff_SStaffManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static SStaff_SStaff GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 Provider_ID)
		{
			SStaff_SStaff objReturn = null;
			SStaff_SStaffDB objDB = new SStaff_SStaffDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, Provider_ID);

			return objReturn;
		}

		public static List<SStaff_SStaff> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<SStaff_SStaff> objReturn = null;
			SStaff_SStaffDB objDB = new SStaff_SStaffDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SStaff_SStaff objSave)
		{
			Int32 objReturn = 0;
			SStaff_SStaffDB objDB = new SStaff_SStaffDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 Provider_ID)
		{
			Boolean objReturn = false;
			SStaff_SStaffDB objDB = new SStaff_SStaffDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, Provider_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SStaff_SStaff objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.Provider_ID);
		}

		#endregion
	}
}
