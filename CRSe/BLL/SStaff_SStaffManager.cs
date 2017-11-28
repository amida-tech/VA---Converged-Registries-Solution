using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class SStaff_SStaffManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<SStaff_SStaff> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<SStaff_SStaff> objReturn = null;
            SStaff_SStaffDB objDB = new SStaff_SStaffDB();

            objReturn = objDB.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<SStaff_SStaff> GetItemsByName(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string LAST_NAME, string FIRST_NAME)
        {
            List<SStaff_SStaff> objReturn = null;
            SStaff_SStaffDB objDB = new SStaff_SStaffDB();

            objReturn = objDB.GetItemsByName(CURRENT_USER, CURRENT_REGISTRY_ID, LAST_NAME, FIRST_NAME);

            return objReturn;
        }

		#endregion
	}
}
