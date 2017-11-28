using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRSe_WEB.SoaServices;

namespace CRSe_WEB.BaseCode
{
    public static partial class ServiceInterfaceManager
    {
        private static CrsServices services = new CrsServices() { Credentials = System.Net.CredentialCache.DefaultCredentials };

        #region APPLICATION_STATUS

        public static APPLICATION_STATUS APPLICATION_STATUS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.APPLICATION_STATUS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<APPLICATION_STATUS> APPLICATION_STATUS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            APPLICATION_STATUS[] temp = services.APPLICATION_STATUS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<APPLICATION_STATUS>();
            return null;
        }

        public static int APPLICATION_STATUS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, APPLICATION_STATUS objSave)
        {
            return services.APPLICATION_STATUS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean APPLICATION_STATUS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.APPLICATION_STATUS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region BCCCR_BCR_ALL

        public static BCCCR_BCR_ALL BCCCR_BCR_ALL_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.BCCCR_BCR_ALL_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<BCCCR_BCR_ALL> BCCCR_BCR_ALL_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            BCCCR_BCR_ALL[] temp = services.BCCCR_BCR_ALL_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<BCCCR_BCR_ALL>();
            return null;
        }

        public static int BCCCR_BCR_ALL_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, BCCCR_BCR_ALL objSave)
        {
            return services.BCCCR_BCR_ALL_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean BCCCR_BCR_ALL_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.BCCCR_BCR_ALL_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region DATA_DICTIONARY

        public static DATA_DICTIONARY DATA_DICTIONARY_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, string objectName)
        {
            return services.DATA_DICTIONARY_GET(CURRENT_USER, CURRENT_REGISTRY_ID, objectName);
        }

        public static List<DATA_DICTIONARY> DATA_DICTIONARY_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            DATA_DICTIONARY[] temp = services.DATA_DICTIONARY_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<DATA_DICTIONARY>();
            return null;
        }

        public static string DATA_DICTIONARY_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, DATA_DICTIONARY objSave)
        {
            return services.DATA_DICTIONARY_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave); 
        }

        public static Boolean DATA_DICTIONARY_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, string objectName)
        {
            return services.DATA_DICTIONARY_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, objectName);
        }

        #endregion

        #region DB_LOG

        public static DB_LOG DB_LOG_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.DB_LOG_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<DB_LOG> DB_LOG_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            DB_LOG[] temp = services.DB_LOG_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<DB_LOG>();
            return null;
        }

        public static int DB_LOG_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, DB_LOG objSave)
        {
            return services.DB_LOG_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean DB_LOG_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.DB_LOG_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region DIM_TIME

        public static DIM_TIME DIM_TIME_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, DateTime dt)
        {
            return services.DIM_TIME_GET(CURRENT_USER, CURRENT_REGISTRY_ID, dt);
        }

        public static List<DIM_TIME> DIM_TIME_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            DIM_TIME[] temp = services.DIM_TIME_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<DIM_TIME>();
            return null;
        }

        public static DateTime DIM_TIME_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, DIM_TIME objSave)
        {
            return services.DIM_TIME_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean DIM_TIME_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, DateTime dt)
        {
            return services.DIM_TIME_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, dt);
        }

        #endregion

        #region ETL_ExtractBatch_Log

        public static ETL_ExtractBatch_Log ETL_ExtractBatch_Log_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.ETL_ExtractBatch_Log_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<ETL_ExtractBatch_Log> ETL_ExtractBatch_Log_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            ETL_ExtractBatch_Log[] temp = services.ETL_ExtractBatch_Log_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<ETL_ExtractBatch_Log>();
            return null;
        }

        public static int ETL_ExtractBatch_Log_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, ETL_ExtractBatch_Log objSave)
        {
            return services.ETL_ExtractBatch_Log_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean ETL_ExtractBatch_Log_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.ETL_ExtractBatch_Log_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region INDIVIDUAL

        public static INDIVIDUAL INDIVIDUAL_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.INDIVIDUAL_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<INDIVIDUAL> INDIVIDUAL_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            INDIVIDUAL[] temp = services.INDIVIDUAL_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<INDIVIDUAL>();
            return null;
        }

        public static int INDIVIDUAL_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, INDIVIDUAL objSave)
        {
            return services.INDIVIDUAL_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean INDIVIDUAL_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.INDIVIDUAL_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region INDIVIDUAL_ADDRESS

        public static INDIVIDUAL_ADDRESS INDIVIDUAL_ADDRESS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {  
            return services.INDIVIDUAL_ADDRESS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<INDIVIDUAL_ADDRESS> INDIVIDUAL_ADDRESS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            INDIVIDUAL_ADDRESS[] temp = services.INDIVIDUAL_ADDRESS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<INDIVIDUAL_ADDRESS>();
            return null;
        }

        public static int INDIVIDUAL_ADDRESS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, INDIVIDUAL_ADDRESS objSave)
        {
            return services.INDIVIDUAL_ADDRESS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean INDIVIDUAL_ADDRESS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.INDIVIDUAL_ADDRESS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region MESSAGE_LOG

        public static MESSAGE_LOG MESSAGE_LOG_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.MESSAGE_LOG_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<MESSAGE_LOG> MESSAGE_LOG_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            MESSAGE_LOG[] temp = services.MESSAGE_LOG_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<MESSAGE_LOG>();
            return null;
        }

        public static int MESSAGE_LOG_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, MESSAGE_LOG objSave)
        {
            return services.MESSAGE_LOG_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean MESSAGE_LOG_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.MESSAGE_LOG_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region PATIENT

        public static PATIENT PATIENT_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.PATIENT_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<PATIENT> PATIENT_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            PATIENT[] temp = services.PATIENT_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<PATIENT>();
            return null;
        }

        public static int PATIENT_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, PATIENT objSave)
        {
            return services.PATIENT_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean PATIENT_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.PATIENT_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region PATIENT_IDS

        public static PATIENT_IDS PATIENT_IDS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.PATIENT_IDS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<PATIENT_IDS> PATIENT_IDS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            PATIENT_IDS[] temp = services.PATIENT_IDS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<PATIENT_IDS>();
            return null;
        }

        public static int PATIENT_IDS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, PATIENT_IDS objSave)
        {
            return services.PATIENT_IDS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean PATIENT_IDS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.PATIENT_IDS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region PATIENT_UDFs

        public static PATIENT_UDFs PATIENT_UDFs_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.PATIENT_UDFs_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<PATIENT_UDFs> PATIENT_UDFs_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            PATIENT_UDFs[] temp = services.PATIENT_UDFs_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<PATIENT_UDFs>();
            return null;
        }

        public static int PATIENT_UDFs_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, PATIENT_UDFs objSave)
        {
            return services.PATIENT_UDFs_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean PATIENT_UDFs_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.PATIENT_UDFs_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region REFERRAL

        public static REFERRAL REFERRAL_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.REFERRAL_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<REFERRAL> REFERRAL_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            REFERRAL[] temp = services.REFERRAL_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<REFERRAL>();
            return null;
        }

        public static int REFERRAL_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, REFERRAL objSave)
        {
            return services.REFERRAL_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean REFERRAL_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.REFERRAL_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region REFERRAL_DETAIL

        public static REFERRAL_DETAIL REFERRAL_DETAIL_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.REFERRAL_DETAIL_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<REFERRAL_DETAIL> REFERRAL_DETAIL_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            REFERRAL_DETAIL[] temp = services.REFERRAL_DETAIL_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<REFERRAL_DETAIL>();
            return null;
        }

        public static int REFERRAL_DETAIL_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, REFERRAL_DETAIL objSave)
        {
            return services.REFERRAL_DETAIL_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean REFERRAL_DETAIL_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.REFERRAL_DETAIL_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region REGISTRY_COHORT_DATA

        public static REGISTRY_COHORT_DATA REGISTRY_COHORT_DATA_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.REGISTRY_COHORT_DATA_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            REGISTRY_COHORT_DATA[] temp = services.REGISTRY_COHORT_DATA_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<REGISTRY_COHORT_DATA>();
            return null;
        }

        public static int REGISTRY_COHORT_DATA_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, REGISTRY_COHORT_DATA objSave)
        {
            return services.REGISTRY_COHORT_DATA_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean REGISTRY_COHORT_DATA_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.REGISTRY_COHORT_DATA_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region REGISTRY_CORE_DATA

        public static REGISTRY_CORE_DATA REGISTRY_CORE_DATA_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.REGISTRY_CORE_DATA_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<REGISTRY_CORE_DATA> REGISTRY_CORE_DATA_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            REGISTRY_CORE_DATA[] temp = services.REGISTRY_CORE_DATA_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<REGISTRY_CORE_DATA>();
            return null;
        }

        public static int REGISTRY_CORE_DATA_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, REGISTRY_CORE_DATA objSave)
        {
            return services.REGISTRY_CORE_DATA_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean REGISTRY_CORE_DATA_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.REGISTRY_CORE_DATA_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region ROLE_PERMISSIONS

        public static ROLE_PERMISSIONS ROLE_PERMISSIONS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.ROLE_PERMISSIONS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<ROLE_PERMISSIONS> ROLE_PERMISSIONS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            ROLE_PERMISSIONS[] temp = services.ROLE_PERMISSIONS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<ROLE_PERMISSIONS>();
            return null;
        }

        public static int ROLE_PERMISSIONS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, ROLE_PERMISSIONS objSave)
        {
            return services.ROLE_PERMISSIONS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean ROLE_PERMISSIONS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.ROLE_PERMISSIONS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region SETTINGS

        public static SETTINGS SETTINGS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SETTINGS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<SETTINGS> SETTINGS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            SETTINGS[] temp = services.SETTINGS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<SETTINGS>();
            return null;
        }

        public static int SETTINGS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, SETTINGS objSave)
        {
            return services.SETTINGS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean SETTINGS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SETTINGS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region SPATIENT

        public static SPATIENT SPATIENT_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SPATIENT_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<SPATIENT> SPATIENT_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            SPATIENT[] temp = services.SPATIENT_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<SPATIENT>();
            return null;
        }

        public static int SPATIENT_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, SPATIENT objSave)
        {
            return services.SPATIENT_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean SPATIENT_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SPATIENT_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region SStaff_SStaff

        public static SStaff_SStaff SStaff_SStaff_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SStaff_SStaff_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<SStaff_SStaff> SStaff_SStaff_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            SStaff_SStaff[] temp = services.SStaff_SStaff_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<SStaff_SStaff>();
            return null;
        }

        public static int SStaff_SStaff_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, SStaff_SStaff objSave)
        {
            return services.SStaff_SStaff_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean SStaff_SStaff_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SStaff_SStaff_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_COUNTRY

        public static STD_COUNTRY STD_COUNTRY_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_COUNTRY_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_COUNTRY> STD_COUNTRY_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_COUNTRY[] temp = services.STD_COUNTRY_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_COUNTRY>();
            return null;
        }

        public static int STD_COUNTRY_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_COUNTRY objSave)
        {
            return services.STD_COUNTRY_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_COUNTRY_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_COUNTRY_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_GUI_CONTROLS

        public static STD_GUI_CONTROLS STD_GUI_CONTROLS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_GUI_CONTROLS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_GUI_CONTROLS> STD_GUI_CONTROLS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_GUI_CONTROLS[] temp = services.STD_GUI_CONTROLS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_GUI_CONTROLS>();
            return null;
        }

        public static int STD_GUI_CONTROLS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_GUI_CONTROLS objSave)
        {
            return services.STD_GUI_CONTROLS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_GUI_CONTROLS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_GUI_CONTROLS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_INDIVIDUAL_GROUP

        public static STD_INDIVIDUAL_GROUP STD_INDIVIDUAL_GROUP_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_INDIVIDUAL_GROUP_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_INDIVIDUAL_GROUP> STD_INDIVIDUAL_GROUP_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_INDIVIDUAL_GROUP[] temp = services.STD_INDIVIDUAL_GROUP_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_INDIVIDUAL_GROUP>();
            return null;
        }

        public static int STD_INDIVIDUAL_GROUP_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_INDIVIDUAL_GROUP objSave)
        {
            return services.STD_INDIVIDUAL_GROUP_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_INDIVIDUAL_GROUP_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_INDIVIDUAL_GROUP_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_INDIVIDUAL_TYPE

        public static STD_INDIVIDUAL_TYPE STD_INDIVIDUAL_TYPE_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_INDIVIDUAL_TYPE_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_INDIVIDUAL_TYPE> STD_INDIVIDUAL_TYPE_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_INDIVIDUAL_TYPE[] temp = services.STD_INDIVIDUAL_TYPE_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_INDIVIDUAL_TYPE>();
            return null;
        }

        public static int STD_INDIVIDUAL_TYPE_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_INDIVIDUAL_TYPE objSave)
        {
            return services.STD_INDIVIDUAL_TYPE_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_INDIVIDUAL_TYPE_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_INDIVIDUAL_TYPE_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_INSTITUTION

        public static STD_INSTITUTION STD_INSTITUTION_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_INSTITUTION_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_INSTITUTION> STD_INSTITUTION_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_INSTITUTION[] temp = services.STD_INSTITUTION_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_INSTITUTION>();
            return null;
        }

        public static int STD_INSTITUTION_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_INSTITUTION objSave)
        {
            return services.STD_INSTITUTION_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_INSTITUTION_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_INSTITUTION_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_MENU_ITEMS

        public static STD_MENU_ITEMS STD_MENU_ITEMS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_MENU_ITEMS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_MENU_ITEMS[] temp = services.STD_MENU_ITEMS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_MENU_ITEMS>();
            return null;
        }

        public static int STD_MENU_ITEMS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_MENU_ITEMS objSave)
        {
            return services.STD_MENU_ITEMS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_MENU_ITEMS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_MENU_ITEMS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_QUESTION

        public static STD_QUESTION STD_QUESTION_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_QUESTION_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_QUESTION> STD_QUESTION_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_QUESTION[] temp = services.STD_QUESTION_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_QUESTION>();
            return null;
        }

        public static int STD_QUESTION_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_QUESTION objSave)
        {
            return services.STD_QUESTION_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_QUESTION_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_QUESTION_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_QUESTION_CHOICE

        public static STD_QUESTION_CHOICE STD_QUESTION_CHOICE_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_QUESTION_CHOICE_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_QUESTION_CHOICE> STD_QUESTION_CHOICE_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_QUESTION_CHOICE[] temp = services.STD_QUESTION_CHOICE_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_QUESTION_CHOICE>();
            return null;
        }

        public static int STD_QUESTION_CHOICE_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_QUESTION_CHOICE objSave)
        {
            return services.STD_QUESTION_CHOICE_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_QUESTION_CHOICE_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_QUESTION_CHOICE_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_REFERRALSTS

        public static STD_REFERRALSTS STD_REFERRALSTS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REFERRALSTS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_REFERRALSTS> STD_REFERRALSTS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_REFERRALSTS[] temp = services.STD_REFERRALSTS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_REFERRALSTS>();
            return null;
        }

        public static int STD_REFERRALSTS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_REFERRALSTS objSave)
        {
            return services.STD_REFERRALSTS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_REFERRALSTS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REFERRALSTS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_REG_UDFs

        public static STD_REG_UDFs STD_REG_UDFs_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REG_UDFs_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_REG_UDFs> STD_REG_UDFs_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_REG_UDFs[] temp = services.STD_REG_UDFs_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_REG_UDFs>();
            return null;
        }

        public static int STD_REG_UDFs_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_REG_UDFs objSave)
        {
            return services.STD_REG_UDFs_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_REG_UDFs_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REG_UDFs_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_REGISTRY

        public static STD_REGISTRY STD_REGISTRY_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REGISTRY_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_REGISTRY> STD_REGISTRY_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_REGISTRY[] temp = services.STD_REGISTRY_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_REGISTRY>();
            return null;
        }

        public static int STD_REGISTRY_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_REGISTRY objSave)
        {
            return services.STD_REGISTRY_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_REGISTRY_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REGISTRY_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_REGISTRY_CODES

        public static STD_REGISTRY_CODES STD_REGISTRY_CODES_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REGISTRY_CODES_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_REGISTRY_CODES> STD_REGISTRY_CODES_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_REGISTRY_CODES[] temp = services.STD_REGISTRY_CODES_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_REGISTRY_CODES>();
            return null;
        }

        public static int STD_REGISTRY_CODES_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_REGISTRY_CODES objSave)
        {
            return services.STD_REGISTRY_CODES_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_REGISTRY_CODES_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REGISTRY_CODES_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_REGISTRY_COHORT_TYPES

        public static STD_REGISTRY_COHORT_TYPES STD_REGISTRY_COHORT_TYPES_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REGISTRY_COHORT_TYPES_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_REGISTRY_COHORT_TYPES> STD_REGISTRY_COHORT_TYPES_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_REGISTRY_COHORT_TYPES[] temp = services.STD_REGISTRY_COHORT_TYPES_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_REGISTRY_COHORT_TYPES>();
            return null;
        }

        public static int STD_REGISTRY_COHORT_TYPES_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_REGISTRY_COHORT_TYPES objSave)
        {
            return services.STD_REGISTRY_COHORT_TYPES_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_REGISTRY_COHORT_TYPES_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REGISTRY_COHORT_TYPES_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_REGISTRY_CORE_TYPES

        public static STD_REGISTRY_CORE_TYPES STD_REGISTRY_CORE_TYPES_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REGISTRY_CORE_TYPES_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_REGISTRY_CORE_TYPES> STD_REGISTRY_CORE_TYPES_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_REGISTRY_CORE_TYPES[] temp = services.STD_REGISTRY_CORE_TYPES_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_REGISTRY_CORE_TYPES>();
            return null;
        }

        public static int STD_REGISTRY_CORE_TYPES_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_REGISTRY_CORE_TYPES objSave)
        {
            return services.STD_REGISTRY_CORE_TYPES_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_REGISTRY_CORE_TYPES_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_REGISTRY_CORE_TYPES_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_ROLE

        public static STD_ROLE STD_ROLE_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_ROLE_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_ROLE> STD_ROLE_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_ROLE[] temp = services.STD_ROLE_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_ROLE>();
            return null;
        }

        public static int STD_ROLE_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_ROLE objSave)
        {
            return services.STD_ROLE_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_ROLE_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_ROLE_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_SERVICE_OCCUPATION

        public static STD_SERVICE_OCCUPATION STD_SERVICE_OCCUPATION_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_SERVICE_OCCUPATION_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_SERVICE_OCCUPATION> STD_SERVICE_OCCUPATION_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_SERVICE_OCCUPATION[] temp = services.STD_SERVICE_OCCUPATION_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_SERVICE_OCCUPATION>();
            return null;
        }

        public static int STD_SERVICE_OCCUPATION_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_SERVICE_OCCUPATION objSave)
        {
            return services.STD_SERVICE_OCCUPATION_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_SERVICE_OCCUPATION_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_SERVICE_OCCUPATION_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_STATE

        public static STD_STATE STD_STATE_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_STATE_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_STATE> STD_STATE_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_STATE[] temp = services.STD_STATE_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_STATE>();
            return null;
        }

        public static int STD_STATE_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_STATE objSave)
        {
            return services.STD_STATE_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_STATE_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_STATE_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_SURVEY_SECTION

        public static STD_SURVEY_SECTION STD_SURVEY_SECTION_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_SURVEY_SECTION_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_SURVEY_SECTION> STD_SURVEY_SECTION_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_SURVEY_SECTION[] temp = services.STD_SURVEY_SECTION_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_SURVEY_SECTION>();
            return null;
        }

        public static int STD_SURVEY_SECTION_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_SURVEY_SECTION objSave)
        {
            return services.STD_SURVEY_SECTION_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_SURVEY_SECTION_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_SURVEY_SECTION_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_SURVEY_SUB_SECTION

        public static STD_SURVEY_SUB_SECTION STD_SURVEY_SUB_SECTION_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_SURVEY_SUB_SECTION_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_SURVEY_SUB_SECTION> STD_SURVEY_SUB_SECTION_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_SURVEY_SUB_SECTION[] temp = services.STD_SURVEY_SUB_SECTION_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_SURVEY_SUB_SECTION>();
            return null;
        }

        public static int STD_SURVEY_SUB_SECTION_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_SURVEY_SUB_SECTION objSave)
        {
            return services.STD_SURVEY_SUB_SECTION_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_SURVEY_SUB_SECTION_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_SURVEY_SUB_SECTION_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_SURVEY_TYPE

        public static STD_SURVEY_TYPE STD_SURVEY_TYPE_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_SURVEY_TYPE_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_SURVEY_TYPE> STD_SURVEY_TYPE_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_SURVEY_TYPE[] temp = services.STD_SURVEY_TYPE_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_SURVEY_TYPE>();
            return null;
        }

        public static int STD_SURVEY_TYPE_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_SURVEY_TYPE objSave)
        {
            return services.STD_SURVEY_TYPE_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_SURVEY_TYPE_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_SURVEY_TYPE_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_USER_ACTIVITY_TYPE

        public static STD_USER_ACTIVITY_TYPE STD_USER_ACTIVITY_TYPE_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_USER_ACTIVITY_TYPE_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_USER_ACTIVITY_TYPE> STD_USER_ACTIVITY_TYPE_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_USER_ACTIVITY_TYPE[] temp = services.STD_USER_ACTIVITY_TYPE_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_USER_ACTIVITY_TYPE>();
            return null;
        }

        public static int STD_USER_ACTIVITY_TYPE_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_USER_ACTIVITY_TYPE objSave)
        {
            return services.STD_USER_ACTIVITY_TYPE_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_USER_ACTIVITY_TYPE_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_USER_ACTIVITY_TYPE_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_WEB_PAGES

        public static STD_WEB_PAGES STD_WEB_PAGES_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_WEB_PAGES_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_WEB_PAGES> STD_WEB_PAGES_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_WEB_PAGES[] temp = services.STD_WEB_PAGES_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_WEB_PAGES>();
            return null;
        }

        public static int STD_WEB_PAGES_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_WEB_PAGES objSave)
        {
            return services.STD_WEB_PAGES_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_WEB_PAGES_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_WEB_PAGES_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_WKFACTIVITYSTS

        public static STD_WKFACTIVITYSTS STD_WKFACTIVITYSTS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_WKFACTIVITYSTS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_WKFACTIVITYSTS> STD_WKFACTIVITYSTS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_WKFACTIVITYSTS[] temp = services.STD_WKFACTIVITYSTS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_WKFACTIVITYSTS>();
            return null;
        }

        public static int STD_WKFACTIVITYSTS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_WKFACTIVITYSTS objSave)
        {
            return services.STD_WKFACTIVITYSTS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_WKFACTIVITYSTS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_WKFACTIVITYSTS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_WKFACTIVITYTYPE

        public static STD_WKFACTIVITYTYPE STD_WKFACTIVITYTYPE_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_WKFACTIVITYTYPE_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_WKFACTIVITYTYPE[] temp = services.STD_WKFACTIVITYTYPE_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_WKFACTIVITYTYPE>();
            return null;
        }

        public static int STD_WKFACTIVITYTYPE_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_WKFACTIVITYTYPE objSave)
        {
            return services.STD_WKFACTIVITYTYPE_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_WKFACTIVITYTYPE_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_WKFACTIVITYTYPE_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_WKFCASESTS

        public static STD_WKFCASESTS STD_WKFCASESTS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_WKFCASESTS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_WKFCASESTS> STD_WKFCASESTS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_WKFCASESTS[] temp = services.STD_WKFCASESTS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_WKFCASESTS>();
            return null;
        }

        public static int STD_WKFCASESTS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_WKFCASESTS objSave)
        {
            return services.STD_WKFCASESTS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_WKFCASESTS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_WKFCASESTS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region STD_WKFCASETYPE

        public static STD_WKFCASETYPE STD_WKFCASETYPE_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_WKFCASETYPE_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_WKFCASETYPE> STD_WKFCASETYPE_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_WKFCASETYPE[] temp = services.STD_WKFCASETYPE_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_WKFCASETYPE>();
            return null;
        }

        public static int STD_WKFCASETYPE_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, STD_WKFCASETYPE objSave)
        {
            return services.STD_WKFCASETYPE_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean STD_WKFCASETYPE_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_WKFCASETYPE_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region SURVEY_NOTES

        public static SURVEY_NOTES SURVEY_NOTES_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SURVEY_NOTES_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<SURVEY_NOTES> SURVEY_NOTES_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            SURVEY_NOTES[] temp = services.SURVEY_NOTES_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<SURVEY_NOTES>();
            return null;
        }

        public static int SURVEY_NOTES_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, SURVEY_NOTES objSave)
        {
            return services.SURVEY_NOTES_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean SURVEY_NOTES_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SURVEY_NOTES_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region SURVEY_RESULTS

        public static SURVEY_RESULTS SURVEY_RESULTS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SURVEY_RESULTS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<SURVEY_RESULTS> SURVEY_RESULTS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            SURVEY_RESULTS[] temp = services.SURVEY_RESULTS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<SURVEY_RESULTS>();
            return null;
        }

        public static int SURVEY_RESULTS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, SURVEY_RESULTS objSave)
        {
            return services.SURVEY_RESULTS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean SURVEY_RESULTS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SURVEY_RESULTS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region SURVEYS

        public static SURVEYS SURVEYS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SURVEYS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<SURVEYS> SURVEYS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            SURVEYS[] temp = services.SURVEYS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<SURVEYS>();
            return null;
        }

        public static int SURVEYS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, SURVEYS objSave)
        {
            return services.SURVEYS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean SURVEYS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.SURVEYS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region USER_ACTIVITY_LOG

        public static USER_ACTIVITY_LOG USER_ACTIVITY_LOG_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.USER_ACTIVITY_LOG_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<USER_ACTIVITY_LOG> USER_ACTIVITY_LOG_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            USER_ACTIVITY_LOG[] temp = services.USER_ACTIVITY_LOG_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<USER_ACTIVITY_LOG>();
            return null;
        }

        public static int USER_ACTIVITY_LOG_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, USER_ACTIVITY_LOG objSave)
        {
            return services.USER_ACTIVITY_LOG_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean USER_ACTIVITY_LOG_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.USER_ACTIVITY_LOG_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region USER_ROLES

        public static USER_ROLES USER_ROLES_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.USER_ROLES_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<USER_ROLES> USER_ROLES_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            USER_ROLES[] temp = services.USER_ROLES_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<USER_ROLES>();
            return null;
        }

        public static int USER_ROLES_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, USER_ROLES objSave)
        {
            return services.USER_ROLES_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean USER_ROLES_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.USER_ROLES_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region USERS

        public static USERS USERS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.USERS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<USERS> USERS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            USERS[] temp = services.USERS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<USERS>();
            return null;
        }

        public static int USERS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, USERS objSave)
        {
            return services.USERS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean USERS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.USERS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region WKF_CASE

        public static WKF_CASE WKF_CASE_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.WKF_CASE_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<WKF_CASE> WKF_CASE_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            WKF_CASE[] temp = services.WKF_CASE_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<WKF_CASE>();
            return null;
        }

        public static int WKF_CASE_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, WKF_CASE objSave)
        {
            return services.WKF_CASE_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean WKF_CASE_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.WKF_CASE_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region WKF_CASE_ACTIVITY

        public static WKF_CASE_ACTIVITY WKF_CASE_ACTIVITY_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.WKF_CASE_ACTIVITY_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id); 
        }

        public static List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            WKF_CASE_ACTIVITY[] temp = services.WKF_CASE_ACTIVITY_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<WKF_CASE_ACTIVITY>();
            return null;
        }

        public static int WKF_CASE_ACTIVITY_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, WKF_CASE_ACTIVITY objSave)
        {
            return services.WKF_CASE_ACTIVITY_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean WKF_CASE_ACTIVITY_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.WKF_CASE_ACTIVITY_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region WKF_CASE_ASSIGNMENT

        public static WKF_CASE_ASSIGNMENT WKF_CASE_ASSIGNMENT_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.WKF_CASE_ASSIGNMENT_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<WKF_CASE_ASSIGNMENT> WKF_CASE_ASSIGNMENT_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            WKF_CASE_ASSIGNMENT[] temp = services.WKF_CASE_ASSIGNMENT_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<WKF_CASE_ASSIGNMENT>();
            return null;
        }

        public static int WKF_CASE_ASSIGNMENT_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, WKF_CASE_ASSIGNMENT objSave)
        {
            return services.WKF_CASE_ASSIGNMENT_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean WKF_CASE_ASSIGNMENT_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.WKF_CASE_ASSIGNMENT_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion

        #region WKF_CASE_COMMENTS

        public static WKF_CASE_COMMENTS WKF_CASE_COMMENTS_GET(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.WKF_CASE_COMMENTS_GET(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<WKF_CASE_COMMENTS> WKF_CASE_COMMENTS_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            WKF_CASE_COMMENTS[] temp = services.WKF_CASE_COMMENTS_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<WKF_CASE_COMMENTS>();
            return null;
        }

        public static int WKF_CASE_COMMENTS_SAVE(string CURRENT_USER, int CURRENT_REGISTRY_ID, WKF_CASE_COMMENTS objSave)
        {
            return services.WKF_CASE_COMMENTS_SAVE(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);
        }

        public static Boolean WKF_CASE_COMMENTS_DELETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.WKF_CASE_COMMENTS_DELETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        #endregion
    }
}
