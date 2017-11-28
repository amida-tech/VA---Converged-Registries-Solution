using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class REGISTRY_COHORT_DATAManager
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static RegistryWizard ConvertToRegistryWizard(List<REGISTRY_COHORT_DATA> cohorts)
        {
            RegistryWizard objReturn = null;

            if (cohorts != null)
            {
                cohorts = cohorts.Where(data => data.SELECTED_FLAG == true).ToList();

                objReturn = new RegistryWizard();

                foreach (REGISTRY_COHORT_DATA cohort in cohorts)
                {
                    if (cohort.STD_REGISTRY_COHORT_TYPES != null)
                    {
                        DateTime dt = DateTime.Now;

                        switch (cohort.STD_REGISTRY_COHORT_TYPES.DESCRIPTION_TEXT)
                        {
                            case "Combat Location":
                                if (!string.IsNullOrEmpty(objReturn.CombatLocIds))
                                    objReturn.CombatLocIds += "','";

                                objReturn.CombatLocIds += cohort.STD_REGISTRY_COHORT_TYPES.CODE;
                                break;
                            case "CPTCodes for a patient":
                                if (!string.IsNullOrEmpty(objReturn.CPTCodes))
                                    objReturn.CPTCodes += "','";

                                objReturn.CPTCodes += cohort.STD_REGISTRY_COHORT_TYPES.CODE;
                                break;
                            case "Ethnicity":
                                if (!string.IsNullOrEmpty(objReturn.EthnicityIds))
                                    objReturn.EthnicityIds += "','";

                                objReturn.EthnicityIds += cohort.STD_REGISTRY_COHORT_TYPES.CODE;
                                break;
                            case "Gender":
                                if (!string.IsNullOrEmpty(objReturn.GenderIds))
                                    objReturn.GenderIds += "','";

                                objReturn.GenderIds += cohort.STD_REGISTRY_COHORT_TYPES.CODE;
                                break;
                            case "HealthFactor Type":
                                if (!string.IsNullOrEmpty(objReturn.HealthFactorType))
                                    objReturn.HealthFactorType += "','";

                                objReturn.HealthFactorType += cohort.STD_REGISTRY_COHORT_TYPES.CODE;
                                break;
                            case "ICD10_Code":
                                if (!string.IsNullOrEmpty(objReturn.ICD10))
                                    objReturn.ICD10 += "','";

                                objReturn.ICD10 += cohort.STD_REGISTRY_COHORT_TYPES.CODE;
                                break;
                            case "ICD9_Code":
                                if (!string.IsNullOrEmpty(objReturn.ICD9))
                                    objReturn.ICD9 += "','";

                                objReturn.ICD9 += cohort.STD_REGISTRY_COHORT_TYPES.CODE;
                                break;
                            case "Marital Status":
                                if (!string.IsNullOrEmpty(objReturn.MaritalStatusIds))
                                    objReturn.MaritalStatusIds += "','";

                                objReturn.MaritalStatusIds += cohort.STD_REGISTRY_COHORT_TYPES.CODE;
                                break;
                            case "Maximum age":
                                if (DateTime.TryParse(cohort.VALUE, out dt))
                                    objReturn.DOBMax = dt;
                                break;
                            case "Minimum age":
                                if (DateTime.TryParse(cohort.VALUE, out dt))
                                    objReturn.DOBMin = dt;
                                break;
                            case "Race":
                                if (!string.IsNullOrEmpty(objReturn.RaceIds))
                                    objReturn.RaceIds += "','";

                                objReturn.RaceIds += cohort.STD_REGISTRY_COHORT_TYPES.CODE;
                                break;
                            case "Service Branch":
                                if (!string.IsNullOrEmpty(objReturn.ServiceIds))
                                    objReturn.ServiceIds += "','";

                                objReturn.ServiceIds += cohort.STD_REGISTRY_COHORT_TYPES.CODE;
                                break;
                            case "Shows participation in OEF/OIF": //todo
                                if (cohort.SELECTED_FLAG)
                                    objReturn.OEFOIFLocation = true;
                                break; 
                            default:
                                break;
                        }
                    }
                }
            }

            return objReturn;
        }

        public static List<REGISTRY_COHORT_DATA> ConvertToDataList(RegistryWizard wizard)
        {
            List<REGISTRY_COHORT_DATA> objReturn = null;

            REGISTRY_COHORT_DATA cohort = null;
            STD_REGISTRY_COHORT_TYPES type = null;

            if (wizard != null)
            {
                objReturn = new List<REGISTRY_COHORT_DATA>();

                if (wizard.DOBMin != null)
                {
                    cohort = new REGISTRY_COHORT_DATA();
                    type = STD_REGISTRY_COHORT_TYPESManager.GetItemByTableCode("CUSTOM", "DOBMIN");
                    if (type != null)
                        cohort.STD_REGISTRY_COHORT_TYPE_ID = type.COHORT_TYPE_ID;
                    cohort.CREATED = cohort.UPDATED = DateTime.Now;
                    cohort.VALUE = wizard.DOBMin.Value.ToString("yyyy-MM-dd");

                    objReturn.Add(cohort);
                }

                if (wizard.DOBMax != null)
                {
                    cohort = new REGISTRY_COHORT_DATA();
                    type = STD_REGISTRY_COHORT_TYPESManager.GetItemByTableCode("CUSTOM", "DOBMAX");
                    if (type != null)
                        cohort.STD_REGISTRY_COHORT_TYPE_ID = type.COHORT_TYPE_ID;
                    cohort.CREATED = cohort.UPDATED = DateTime.Now;
                    cohort.VALUE = wizard.DOBMax.Value.ToString("yyyy-MM-dd");

                    objReturn.Add(cohort);
                }

                if (wizard.OEFOIFLocation != null)
                {
                    cohort = new REGISTRY_COHORT_DATA();
                    type = STD_REGISTRY_COHORT_TYPESManager.GetItemByTableCode("CUSTOM", "OEFOIF");
                    if (type != null)
                        cohort.STD_REGISTRY_COHORT_TYPE_ID = type.COHORT_TYPE_ID;
                    cohort.CREATED = cohort.UPDATED = DateTime.Now;
                    cohort.SELECTED_FLAG = wizard.OEFOIFLocation.GetValueOrDefault();

                    objReturn.Add(cohort);
                }

                if (!string.IsNullOrEmpty(wizard.CombatLocIds))
                {
                    string[] idList = wizard.CombatLocIds.Split(',');
                    if (idList != null)
                    {
                        foreach (string idS in idList)
                        {
                            int id = 0;
                            if (int.TryParse(idS, out id))
                            {
                                cohort = new REGISTRY_COHORT_DATA();
                                cohort.STD_REGISTRY_COHORT_TYPE_ID = id;
                                cohort.CREATED = cohort.UPDATED = DateTime.Now;

                                objReturn.Add(cohort);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(wizard.EthnicityIds))
                {
                    string[] idList = wizard.EthnicityIds.Split(',');
                    if (idList != null)
                    {
                        foreach (string idS in idList)
                        {
                            int id = 0;
                            if (int.TryParse(idS, out id))
                            {
                                cohort = new REGISTRY_COHORT_DATA();
                                cohort.STD_REGISTRY_COHORT_TYPE_ID = id;
                                cohort.CREATED = cohort.UPDATED = DateTime.Now;

                                objReturn.Add(cohort);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(wizard.GenderIds))
                {
                    string[] idList = wizard.GenderIds.Split(',');
                    if (idList != null)
                    {
                        foreach (string idS in idList)
                        {
                            int id = 0;
                            if (int.TryParse(idS, out id))
                            {
                                cohort = new REGISTRY_COHORT_DATA();
                                cohort.STD_REGISTRY_COHORT_TYPE_ID = id;
                                cohort.CREATED = cohort.UPDATED = DateTime.Now;

                                objReturn.Add(cohort);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(wizard.MaritalStatusIds))
                {
                    string[] idList = wizard.MaritalStatusIds.Split(',');
                    if (idList != null)
                    {
                        foreach (string idS in idList)
                        {
                            int id = 0;
                            if (int.TryParse(idS, out id))
                            {
                                cohort = new REGISTRY_COHORT_DATA();
                                cohort.STD_REGISTRY_COHORT_TYPE_ID = id;
                                cohort.CREATED = cohort.UPDATED = DateTime.Now;

                                objReturn.Add(cohort);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(wizard.RaceIds))
                {
                    string[] idList = wizard.RaceIds.Split(',');
                    if (idList != null)
                    {
                        foreach (string idS in idList)
                        {
                            int id = 0;
                            if (int.TryParse(idS, out id))
                            {
                                cohort = new REGISTRY_COHORT_DATA();
                                cohort.STD_REGISTRY_COHORT_TYPE_ID = id;
                                cohort.CREATED = cohort.UPDATED = DateTime.Now;

                                objReturn.Add(cohort);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(wizard.ServiceIds))
                {
                    string[] idList = wizard.ServiceIds.Split(',');
                    if (idList != null)
                    {
                        foreach (string idS in idList)
                        {
                            int id = 0;
                            if (int.TryParse(idS, out id))
                            {
                                cohort = new REGISTRY_COHORT_DATA();
                                cohort.STD_REGISTRY_COHORT_TYPE_ID = id;
                                cohort.CREATED = cohort.UPDATED = DateTime.Now;

                                objReturn.Add(cohort);
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static REGISTRY_COHORT_DATA GetItemByRegistryCohort(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 STD_REGISTRY_COHORT_TYPE_ID)
        {
            REGISTRY_COHORT_DATA objReturn = null;
            REGISTRY_COHORT_DATADB objDB = new REGISTRY_COHORT_DATADB();

            objReturn = objDB.GetItemByRegistryCohort(CURRENT_USER, CURRENT_REGISTRY_ID, STD_REGISTRY_COHORT_TYPE_ID);

            return objReturn;
        }

        public static List<REGISTRY_COHORT_DATA> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<REGISTRY_COHORT_DATA> objReturn = null;
            REGISTRY_COHORT_DATADB objDB = new REGISTRY_COHORT_DATADB();

            objReturn = objDB.GetItemsByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<REGISTRY_COHORT_DATA> GetItemsSelectedByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<REGISTRY_COHORT_DATA> objReturn = null;
            REGISTRY_COHORT_DATADB objDB = new REGISTRY_COHORT_DATADB();

            objReturn = objDB.GetItemsSelectedByRegistry(CURRENT_USER, CURRENT_REGISTRY_ID);

            return objReturn;
        }

        public static List<REGISTRY_COHORT_DATA> GetCdwFields(Int32 REGISTRY_ID)
        {
            List<REGISTRY_COHORT_DATA> objReturn = null;
            REGISTRY_COHORT_DATADB objDB = new REGISTRY_COHORT_DATADB();

            objReturn = objDB.GetCdwFields(REGISTRY_ID);

            return objReturn;
        }

        public static Int32 GetPreviewCount(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, List<REGISTRY_COHORT_DATA> cohorts)
        {
            Int32 objReturn = 0;
            REGISTRY_COHORT_DATADB objDB = new REGISTRY_COHORT_DATADB();

            RegistryWizard registryWizard = ConvertToRegistryWizard(cohorts);

            if (registryWizard != null)
                objReturn = objDB.GetPreviewCount(CURRENT_USER, CURRENT_REGISTRY_ID, registryWizard);

            return objReturn;
        }

        public static Boolean SaveList(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, List<REGISTRY_COHORT_DATA> cohorts)
        {
            if (cohorts == null) return false;

            Boolean objReturn = false;
            REGISTRY_COHORT_DATADB objDB = new REGISTRY_COHORT_DATADB();

            objReturn = objDB.SaveList(CURRENT_USER, CURRENT_REGISTRY_ID, cohorts);

            return objReturn;
        }

        public static Boolean PopulateRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, RegistryWizard registryWizard)
        {
            Boolean objReturn = false;
            REGISTRY_COHORT_DATADB objDB = new REGISTRY_COHORT_DATADB();

            objReturn = objDB.PopulateRegistry(CURRENT_USER, CURRENT_REGISTRY_ID, registryWizard);

            return objReturn;
        }

		#endregion
	}
}
