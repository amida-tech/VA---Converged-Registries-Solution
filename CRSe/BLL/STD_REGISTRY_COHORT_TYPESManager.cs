using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
    public static partial class STD_REGISTRY_COHORT_TYPESManager
    {
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        public static List<STD_REGISTRY_COHORT_TYPES> GetCombatLocations(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            return GetItems(CURRENT_USER, CURRENT_REGISTRY_ID, "STD_REGISTRY_CODES.Combat Location");
        }

        public static List<STD_REGISTRY_COHORT_TYPES> GetEthnicities(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            return GetItems(CURRENT_USER, CURRENT_REGISTRY_ID, "STD_REGISTRY_CODES.Ethnicity");
        }

        public static List<STD_REGISTRY_COHORT_TYPES> GetGenders(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            return GetItems(CURRENT_USER, CURRENT_REGISTRY_ID, "STD_REGISTRY_CODES.Gender");
        }

        public static List<STD_REGISTRY_COHORT_TYPES> GetMaritalStatuses(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            return GetItems(CURRENT_USER, CURRENT_REGISTRY_ID, "STD_REGISTRY_CODES.Marital Status");
        }

        public static List<STD_REGISTRY_COHORT_TYPES> GetRaces(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            return GetItems(CURRENT_USER, CURRENT_REGISTRY_ID, "STD_REGISTRY_CODES.Race");
        }

        public static List<STD_REGISTRY_COHORT_TYPES> GetServiceBranches(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            return GetItems(CURRENT_USER, CURRENT_REGISTRY_ID, "STD_REGISTRY_CODES.Service Branch");
        }

        public static List<STD_REGISTRY_COHORT_TYPES> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string TABLE_NAME)
        {
            List<STD_REGISTRY_COHORT_TYPES> objReturn = null;
            STD_REGISTRY_COHORT_TYPESDB objDB = new STD_REGISTRY_COHORT_TYPESDB();

            objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID, TABLE_NAME);

            return objReturn;
        }

        public static STD_REGISTRY_COHORT_TYPES GetItemByTableCode(string TABLE_NAME, string CODE)
        {
            STD_REGISTRY_COHORT_TYPES objReturn = null;
            STD_REGISTRY_COHORT_TYPESDB objDB = new STD_REGISTRY_COHORT_TYPESDB();

            objReturn = objDB.GetItemByTableCode(TABLE_NAME, CODE);

            return objReturn;
        }

        #endregion
    }
}
