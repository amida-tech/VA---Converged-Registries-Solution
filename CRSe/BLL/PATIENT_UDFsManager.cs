using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class PATIENT_UDFsManager
	{
		#region Fields
		#endregion
         
		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static PATIENT_UDFs GetItemByPatientUdf(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PATIENT_ID, Int32 STD_REG_UDFs_ID)
        {
            PATIENT_UDFs objReturn = null;
            PATIENT_UDFsDB objDB = new PATIENT_UDFsDB();

            objReturn = objDB.GetItemByPatientUdf(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID, STD_REG_UDFs_ID);

            return objReturn;
        }

		#endregion
	}
}
