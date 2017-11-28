using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class REFERRALManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static REFERRAL GetItemComplete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 REFERRAL_ID)
        {
            REFERRAL objReturn = null;
            REFERRALDB objDB = new REFERRALDB();

            objReturn = objDB.GetItemComplete(CURRENT_USER, CURRENT_REGISTRY_ID, REFERRAL_ID);

            return objReturn;
        }

        public static List<REFERRAL> GetItemsByRegistryStatus(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_REFERRALSTS_ID)
        {
            List<REFERRAL> objReturn = null;
            REFERRALDB objDB = new REFERRALDB();

            objReturn = objDB.GetItemsByRegistryStatus(CURRENT_USER, CURRENT_REGISTRY_ID, STD_REFERRALSTS_ID);

            return objReturn;
        }

        public static List<REFERRALcommon> GetItemsCommonByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<REFERRALcommon> objReturn = null;
            REFERRALDB objDB = new REFERRALDB();

            objReturn = objDB.GetItemsCommonByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<REFERRALcommon> GetItemsCommonByPatient(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PATIENT_ID)
        {
            List<REFERRALcommon> objReturn = null;
            REFERRALDB objDB = new REFERRALDB();

            objReturn = objDB.GetItemsCommonByPatient(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID);

            return objReturn;
        }

        public static List<REFERRALcommon> GetItemsCommonByProvider(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PROVIDER_ID)
        {
            List<REFERRALcommon> objReturn = null;
            REFERRALDB objDB = new REFERRALDB();

            objReturn = objDB.GetItemsCommonByProvider(CURRENT_USER, CURRENT_REGISTRY_ID, PROVIDER_ID);

            return objReturn;
        }

        public static Boolean CheckPatientExists(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PATIENT_ID)
        {
            Boolean objReturn = false;
            REFERRALDB objDB = new REFERRALDB();

            REFERRAL objTemp = objDB.GetItemByRegistryPatient(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID);
            if (objTemp != null)
                objReturn = true;

            return objReturn;
        }

        public static Int32 SaveManual(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PATIENT_ID, Int32 PROVIDER_ID)
        {
            Int32 objReturn = 0;
            REFERRALDB objDB = new REFERRALDB();

            objReturn = objDB.SaveManual(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID, PROVIDER_ID);

            return objReturn;
        }

        public static Boolean UpdateStatus(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 REFERRAL_ID, Int32 STD_REFERRALSTS_ID)
        {
            Boolean objReturn = false;
            REFERRALDB objDB = new REFERRALDB();

            objReturn = objDB.UpdateStatus(CURRENT_USER, CURRENT_REGISTRY_ID, REFERRAL_ID, STD_REFERRALSTS_ID);

            return objReturn;
        }

		#endregion
	}
}
