using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class STD_REFERRALSTSManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static STD_REFERRALSTS GetItemByCode(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string CODE)
        {
            STD_REFERRALSTS objReturn = null;
            STD_REFERRALSTSDB objDB = new STD_REFERRALSTSDB();

            objReturn = objDB.GetItemByCode(CURRENT_USER, CURRENT_REGISTRY_ID, CODE);

            return objReturn;
        }

		#endregion
	}
}
