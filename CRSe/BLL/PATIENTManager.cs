using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class PATIENTManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static PATIENT GetItemComplete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PATIENT_ID)
        {
            PATIENT objReturn = null;
            PATIENTDB objDB = new PATIENTDB();

            objReturn = objDB.GetItemComplete(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID);

            return objReturn;
        }

        public static List<PATIENT> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<PATIENT> objReturn = null;
            PATIENTDB objDB = new PATIENTDB();

            objReturn = objDB.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<PATIENT> GetItemsByName(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string LAST_NAME, string FIRST_NAME)
        {
            List<PATIENT> objReturn = null;
            PATIENTDB objDB = new PATIENTDB();

            objReturn = objDB.GetItemsByName(CURRENT_USER, CURRENT_REGISTRY_ID, LAST_NAME, FIRST_NAME);

            return objReturn;
        }

        public static Int32 SaveComplete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, PATIENT objSave)
        {
            Int32 objReturn = 0;

            PATIENTDB objDB = new PATIENTDB();
            objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

            if (objSave.SPATIENT != null)
            {
                SPATIENTDB sDB = new SPATIENTDB();
                objSave.SPATIENT.PK_ID = sDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave.SPATIENT);
            }

            return objReturn;
        }

		#endregion
	}
}
