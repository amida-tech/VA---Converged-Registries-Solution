using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
    public static partial class ETLManager
    {
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        public static int UpdateRegistryCohort(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            int objReturn = 0;

            List<REGISTRY_COHORT_DATA> cohorts = REGISTRY_COHORT_DATAManager.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID); //REGISTRY_COHORT_DATAManager.GetCdwFields(registryId);
            RegistryWizard wizard = REGISTRY_COHORT_DATAManager.ConvertToRegistryWizard(cohorts);
            if (wizard != null)
            {
                wizard.StdRegistryId = CURRENT_REGISTRY_ID;
                wizard.Username = CURRENT_USER;
                wizard.Count = false;

                ETLDB objDB = new ETLDB();
                List<SPATIENT> patientList = objDB.CDW_GetData(CURRENT_USER, CURRENT_REGISTRY_ID, wizard);
                if (patientList != null)
                {
                    objReturn = objDB.CDW_SaveData(CURRENT_USER, CURRENT_REGISTRY_ID, patientList);
                }
            }

            return objReturn;
        }

        public static int PreviewRegistryCohort(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            int objReturn = 0;

            List<REGISTRY_COHORT_DATA> cohorts = REGISTRY_COHORT_DATAManager.GetItemsSelectedByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID); //REGISTRY_COHORT_DATAManager.GetCdwFields(registryId);
            RegistryWizard wizard = REGISTRY_COHORT_DATAManager.ConvertToRegistryWizard(cohorts);
            if (wizard != null)
            {
                wizard.StdRegistryId = CURRENT_REGISTRY_ID;
                wizard.Username = CURRENT_USER;
                wizard.Count = true;

                ETLDB objDB = new ETLDB();
                objReturn = objDB.CDW_GetCount(CURRENT_USER, CURRENT_REGISTRY_ID, wizard);
            }

            return objReturn;
        }

        #endregion
    }
}
