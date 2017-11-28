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

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static List<BCCCR_BCR_ALL> GetItemsBySearch(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int16 STA3N, string PATIENT_SEARCH)
        {
            List<BCCCR_BCR_ALL> objReturn = null;
            BCCCR_BCR_ALLDB objDB = new BCCCR_BCR_ALLDB();

            objReturn = objDB.GetItemsBySearch(CURRENT_USER, CURRENT_REGISTRY_ID, STA3N, PATIENT_SEARCH);

            return objReturn;
        }

		#endregion
	}
}
