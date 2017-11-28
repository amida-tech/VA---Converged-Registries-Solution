using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRSe_WEB.SoaServices;

namespace CRSe_WEB.BaseCode
{
    public static partial class ServiceInterfaceManager
    {
        #region APPLICATION_STATUS
        #endregion

        #region BCCCR_BCR_ALL

        public static List<BCCCR_BCR_ALL> BCCCR_BCR_ALL_GET_ALL_BY_SEARCH(string CURRENT_USER, int CURRENT_REGISTRY_ID, short STA3N, string PATIENT_SEARCH)
        {
            BCCCR_BCR_ALL[] temp = services.BCCCR_BCR_ALL_GET_ALL_BY_SEARCH(CURRENT_USER, CURRENT_REGISTRY_ID, STA3N, PATIENT_SEARCH);
            if (temp != null)
                return temp.ToList<BCCCR_BCR_ALL>();
            return null;
        }

        public static List<BCCCR_BCR_ALL> BCCCR_BCR_ALL_GET_ALL_BY_SEARCH(string CURRENT_USER, int CURRENT_REGISTRY_ID, short STA3N, string PATIENT_SEARCH, string SORT_EXPRESSION)
        {
            List<BCCCR_BCR_ALL> objReturn = BCCCR_BCR_ALL_GET_ALL_BY_SEARCH(CURRENT_USER, CURRENT_REGISTRY_ID, STA3N, PATIENT_SEARCH);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<BCCCR_BCR_ALL>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<BCCCR_BCR_ALL>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<BCCCR_BCR_ALL>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<BCCCR_BCR_ALL>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<BCCCR_BCR_ALL>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<BCCCR_BCR_ALL>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        #endregion

        #region DATA_DICTIONARY

        public static List<DATA_DICTIONARY> DATA_DICTIONARY_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<DATA_DICTIONARY> objReturn = DATA_DICTIONARY_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<DATA_DICTIONARY>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<DATA_DICTIONARY>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<DATA_DICTIONARY>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<DATA_DICTIONARY>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<DATA_DICTIONARY>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<DATA_DICTIONARY>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<DATA_DICTIONARY>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<DATA_DICTIONARY>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<DATA_DICTIONARY>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        #endregion

        #region DB_LOG
        #endregion

        #region DIM_TIME
        #endregion

        #region ETL_ExtractBatch_Log

        public static List<ETL_ExtractBatch_Log> ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            ETL_ExtractBatch_Log[] temp = services.ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<ETL_ExtractBatch_Log>();
            return null;
        }

        public static List<ETL_ExtractBatch_Log> ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<ETL_ExtractBatch_Log> objReturn = ETL_ExtractBatch_Log_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<ETL_ExtractBatch_Log>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<ETL_ExtractBatch_Log>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<ETL_ExtractBatch_Log>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<ETL_ExtractBatch_Log>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<ETL_ExtractBatch_Log>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<ETL_ExtractBatch_Log>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<ETL_ExtractBatch_Log>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<ETL_ExtractBatch_Log>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<ETL_ExtractBatch_Log>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        #endregion

        #region INDIVIDUAL
        #endregion

        #region INDIVIDUAL_ADDRESS
        #endregion

        #region MESSAGE_LOG
        #endregion

        #region PATIENT

        public static PATIENT PATIENT_GET_COMPLETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int PATIENT_ID)
        {
            return services.PATIENT_GET_COMPLETE(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID);
        }

        public static List<PATIENT> PATIENT_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            PATIENT[] temp = services.PATIENT_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<PATIENT>();
            return null;
        }

        public static List<PATIENT> PATIENT_GET_ALL_BY_NAME(string CURRENT_USER, int CURRENT_REGISTRY_ID, string LAST_NAME, string FIRST_NAME)
        {
            PATIENT[] temp = services.PATIENT_GET_ALL_BY_NAME(CURRENT_USER, CURRENT_REGISTRY_ID, LAST_NAME, FIRST_NAME);
            if (temp != null)
                return temp.ToList<PATIENT>();
            return null;
        }

        #endregion

        #region PATIENT_IDS
        #endregion

        #region PATIENT_UDFs

        public static PATIENT_UDFs PATIENT_UDFs_GET_BY_PATIENT_UDF(string CURRENT_USER, int CURRENT_REGISTRY_ID, int PATIENT_ID, int STD_REG_UDFs_ID)
        {
            return services.PATIENT_UDFs_GET_BY_PATIENT_UDF(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID, STD_REG_UDFs_ID);
        }

        #endregion

        #region REFERRAL

        public static REFERRAL REFERRAL_GET_COMPLETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int REFERRAL_ID)
        {
            return services.REFERRAL_GET_COMPLETE(CURRENT_USER, CURRENT_REGISTRY_ID, REFERRAL_ID);
        }

        public static List<REFERRAL> REFERRAL_GET_ALL_BY_REGISTRY_STATUS(string CURRENT_USER, int CURRENT_REGISTRY_ID, int STD_REFERRALSTS_ID)
        {
            REFERRAL[] temp = services.REFERRAL_GET_ALL_BY_REGISTRY_STATUS(CURRENT_USER, CURRENT_REGISTRY_ID, STD_REFERRALSTS_ID);
            if (temp != null)
                return temp.ToList<REFERRAL>();
            return null;
        }

        public static List<REFERRALcommon> REFERRAL_GET_COMMON_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            REFERRALcommon[] temp = services.REFERRAL_GET_COMMON_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<REFERRALcommon>();
            return null;
        }

        public static List<REFERRALcommon> REFERRAL_GET_COMMON_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<REFERRALcommon> objReturn = REFERRAL_GET_COMMON_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                if (objReturn.Any(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)) != null))
                                {
                                    objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList();
                                }
                                else
                                {
                                    objReturn = new List<REFERRALcommon>();
                                }
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static List<REFERRALcommon> REFERRAL_GET_COMMON_BY_PATIENT(string CURRENT_USER, int CURRENT_REGISTRY_ID, int PATIENT_ID)
        {
            REFERRALcommon[] temp = services.REFERRAL_GET_COMMON_BY_PATIENT(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID);
            if (temp != null)
                return temp.ToList<REFERRALcommon>();
            return null;
        }

        public static List<REFERRALcommon> REFERRAL_GET_COMMON_BY_PATIENT(string CURRENT_USER, int CURRENT_REGISTRY_ID, int PATIENT_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<REFERRALcommon> objReturn = REFERRAL_GET_COMMON_BY_PATIENT(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList();
                                }
                            }
                            else
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList();
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList();
                                }
                            }
                            else
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList();
                        }
                    }
                }
            }
            return objReturn;
        }

        public static List<REFERRALcommon> REFERRAL_GET_COMMON_BY_PROVIDER(string CURRENT_USER, int CURRENT_REGISTRY_ID, int PROVIDER_ID)
        {
            REFERRALcommon[] temp = services.REFERRAL_GET_COMMON_BY_PROVIDER(CURRENT_USER, CURRENT_REGISTRY_ID, PROVIDER_ID);
            if (temp != null)
                return temp.ToList<REFERRALcommon>();
            return null;
        }

        public static List<REFERRALcommon> REFERRAL_GET_COMMON_BY_PROVIDER(string CURRENT_USER, int CURRENT_REGISTRY_ID, int PROVIDER_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<REFERRALcommon> objReturn = REFERRAL_GET_COMMON_BY_PROVIDER(CURRENT_USER, CURRENT_REGISTRY_ID, PROVIDER_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList();
                                }
                            }
                            else
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList();
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList();
                                }
                            }
                            else
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList();
                        }
                    }
                }
            }

            return objReturn;
        }

        public static bool REFERRAL_PATIENT_EXISTS(string CURRENT_USER, int CURRENT_REGISTRY_ID, int PATIENT_ID)
        {
            return services.REFERRAL_PATIENT_EXISTS(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID);
        }

        public static int REFERRAL_SAVE_MANUAL(string CURRENT_USER, int CURRENT_REGISTRY_ID, int PATIENT_ID, int PROVIDER_ID)
        {
            return services.REFERRAL_SAVE_MANUAL(CURRENT_USER, CURRENT_REGISTRY_ID, PATIENT_ID, PROVIDER_ID);
        }

        public static List<SearchResult> RESULTS_GET_ALL_BY_NAME(string CURRENT_USER, int CURRENT_REGISTRY_ID, string LAST_NAME, string FIRST_NAME, string SEARCH_TYPE)
        {
            List<SearchResult> objReturn = null;

            if (SEARCH_TYPE == "PATIENT")
            {
                PATIENT[] temp = services.PATIENT_GET_ALL_BY_NAME(CURRENT_USER, CURRENT_REGISTRY_ID, LAST_NAME, FIRST_NAME);
                if (temp != null)
                    objReturn = temp.Select(r => new SearchResult()
                    {
                        BirthDate = r.BIRTH_DATE.GetValueOrDefault(),
                        City = r.SPATIENT.City,
                        FirstName = r.FIRST_NAME,
                        LastFour = r.SPATIENT.PatientLastFour,
                        LastName = r.LAST_NAME,
                        Gender = r.SPATIENT.Gender,
                        PostalCode = r.SPATIENT.PostalCode,
                        ResultId = r.PATIENT_ID,
                        State = r.SPATIENT.State
                    }).ToList<SearchResult>();
            }
            else if (SEARCH_TYPE == "PROVIDER")
            {
                SStaff_SStaff[] temp = services.SStaff_SStaff_GET_ALL_BY_NAME(CURRENT_USER, CURRENT_REGISTRY_ID, LAST_NAME, FIRST_NAME);
                if (temp != null)
                    objReturn = temp.Select(r => new SearchResult()
                    {
                        BirthDate = null,
                        City = r.City,
                        FirstName = r.FirstName,
                        LastFour = string.Empty,
                        LastName = r.LastName,
                        Gender = r.Gender,
                        PostalCode = r.ZipCode,
                        ResultId = r.Provider_ID,
                        State = r.StateName
                    }).ToList<SearchResult>();
            }

            return objReturn;
        }

        public static List<SearchResult> RESULTS_GET_ALL_BY_NAME(string CURRENT_USER, int CURRENT_REGISTRY_ID, string LAST_NAME, string FIRST_NAME, string SEARCH_TYPE, string SORT_EXPRESSION, string SEARCH_COLUMN, string SEARCH_TEXT)
        {
            // List<SearchResult> objReturn = null;
            List<SearchResult> objReturn = null;

            if (SEARCH_TYPE == "PATIENT")
            {
                PATIENT[] temp = services.PATIENT_GET_ALL_BY_NAME(CURRENT_USER, CURRENT_REGISTRY_ID, LAST_NAME, FIRST_NAME);
                if (temp != null)
                    objReturn = temp.Select(r => new SearchResult()
                    {
                        BirthDate = r.BIRTH_DATE.GetValueOrDefault(),
                        City = r.SPATIENT.City,
                        FirstName = r.FIRST_NAME,
                        LastFour = r.SPATIENT.PatientLastFour,
                        LastName = r.LAST_NAME,
                        Gender = r.SPATIENT.Gender,
                        PostalCode = r.SPATIENT.PostalCode,
                        ResultId = r.PATIENT_ID,
                        State = r.SPATIENT.State
                    }).ToList<SearchResult>();
            }
            else if (SEARCH_TYPE == "PROVIDER")
            {
                SStaff_SStaff[] temp = services.SStaff_SStaff_GET_ALL_BY_NAME(CURRENT_USER, CURRENT_REGISTRY_ID, LAST_NAME, FIRST_NAME);
                if (temp != null)
                    objReturn = temp.Select(r => new SearchResult()
                    {
                        BirthDate = null,
                        City = r.City,
                        FirstName = r.FirstName,
                        LastFour = string.Empty,
                        LastName = r.LastName,
                        Gender = r.Gender,
                        PostalCode = r.ZipCode,
                        ResultId = r.Provider_ID,
                        State = r.StateName
                    }).ToList<SearchResult>();
            }

            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<SearchResult>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<SearchResult>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<SearchResult>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<SearchResult>();
                                }
                            }
                            else
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<SearchResult>();
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<SearchResult>();
                                }
                            }
                            else
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<SearchResult>();
                        }
                    }
                }
            }
            return objReturn;
        }

        public static bool REFERRAL_UPDATE_STATUS(string CURRENT_USER, int CURRENT_REGISTRY_ID, int REFERRAL_ID, int STD_REFERRALSTS_ID)
        {
            return services.REFERRAL_UPDATE_STATUS(CURRENT_USER, CURRENT_REGISTRY_ID, REFERRAL_ID, STD_REFERRALSTS_ID);
        }

        #endregion

        #region REFERRAL_DETAIL
        #endregion

        #region REGISTRY_COHORT_DATA

        public static List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            REGISTRY_COHORT_DATA[] temp = services.REGISTRY_COHORT_DATA_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<REGISTRY_COHORT_DATA>();
            return null;
        }

        public static List<REGISTRY_COHORT_DATA> REGISTRY_COHORT_DATA_GET_ALL_SELECTED_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            REGISTRY_COHORT_DATA[] temp = services.REGISTRY_COHORT_DATA_GET_ALL_SELECTED_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<REGISTRY_COHORT_DATA>();
            return null;
        }

        public static int REGISTRY_COHORT_DATA_GET_PREVIEW_COUNT(string CURRENT_USER, int CURRENT_REGISTRY_ID, List<REGISTRY_COHORT_DATA> cohorts)
        {
            REGISTRY_COHORT_DATA[] temp = (cohorts != null ? cohorts.ToArray() : null);
            return services.REGISTRY_COHORT_DATA_GET_PREVIEW_COUNT(CURRENT_USER, CURRENT_REGISTRY_ID, temp);
        }

        public static bool REGISTRY_COHORT_DATA_SAVE_LIST(string CURRENT_USER, int CURRENT_REGISTRY_ID, List<REGISTRY_COHORT_DATA> cohorts)
        {
            REGISTRY_COHORT_DATA[] temp = (cohorts != null ? cohorts.ToArray() : null);
            return services.REGISTRY_COHORT_DATA_SAVE_LIST(CURRENT_USER, CURRENT_REGISTRY_ID, temp);
        }

        #endregion

        #region REGISTRY_CORE_DATA

        public static REGISTRY_CORE_DATA REGISTRY_CORE_DATA_GET_BY_REGISTRY_CORE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int CORE_TYPE_ID)
        {
            return services.REGISTRY_CORE_DATA_GET_BY_REGISTRY_CORE(CURRENT_USER, CURRENT_REGISTRY_ID, CORE_TYPE_ID);
        }

        public static List<REGISTRY_CORE_DATA> REGISTRY_CORE_DATA_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            REGISTRY_CORE_DATA[] temp = services.REGISTRY_CORE_DATA_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<REGISTRY_CORE_DATA>();
            return null;
        }

        public static bool REGISTRY_CORE_DATA_SAVE_LIST(string CURRENT_USER, int CURRENT_REGISTRY_ID, List<REGISTRY_CORE_DATA> cores)
        {
            REGISTRY_CORE_DATA[] temp = (cores != null ? cores.ToArray() : null);
            return services.REGISTRY_CORE_DATA_SAVE_LIST(CURRENT_USER, CURRENT_REGISTRY_ID, temp);
        }

        #endregion

        #region ROLE_PERMISSIONS
        #endregion

        #region SETTINGS

        public static SETTINGS SETTINGS_GET_REGISTRYNAME(string CURRENT_USER, int CURRENT_REGISTRY_ID, string NAME)
        {
            return services.SETTINGS_GET_REGISTRYNAME(CURRENT_USER, CURRENT_REGISTRY_ID, NAME);
        }

        public static SETTINGS GET_HOME_PAGE_SETTING()
        {
            return services.GET_HOME_PAGE_SETTING();
        }

        #endregion

        #region SPATIENT
        #endregion

        #region SStaff_SStaff

        public static List<SStaff_SStaff> SStaff_SStaff_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            SStaff_SStaff[] temp = services.SStaff_SStaff_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<SStaff_SStaff>();
            return null;
        }

        public static List<SStaff_SStaff> SStaff_SStaff_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<SStaff_SStaff> objReturn = SStaff_SStaff_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<SStaff_SStaff>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<SStaff_SStaff>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<SStaff_SStaff>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<SStaff_SStaff>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<SStaff_SStaff>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<SStaff_SStaff>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<SStaff_SStaff>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<SStaff_SStaff>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<SStaff_SStaff>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static List<SStaff_SStaff> SStaff_SStaff_GET_ALL_BY_NAME(string CURRENT_USER, int CURRENT_REGISTRY_ID, string LAST_NAME, string FIRST_NAME)
        {
            SStaff_SStaff[] temp = services.SStaff_SStaff_GET_ALL_BY_NAME(CURRENT_USER, CURRENT_REGISTRY_ID, LAST_NAME, FIRST_NAME);
            if (temp != null)
                return temp.ToList<SStaff_SStaff>();
            return null;
        }

        #endregion

        #region STD_COUNTRY
        #endregion

        #region STD_GUI_CONTROLS
        #endregion

        #region STD_INDIVIDUAL_GROUP
        #endregion

        #region STD_INDIVIDUAL_TYPE
        #endregion

        #region STD_INSTITUTION

        public static STD_INSTITUTION STD_INSTITUTION_GET_COMPLETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int id)
        {
            return services.STD_INSTITUTION_GET_COMPLETE(CURRENT_USER, CURRENT_REGISTRY_ID, id);
        }

        public static List<STD_INSTITUTION> STD_INSTITUTION_GET_FACS(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_INSTITUTION[] temp = services.STD_INSTITUTION_GET_FACS(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_INSTITUTION>();
            return null;
        }

        #endregion

        #region STD_MENU_ITEMS

        public static List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_MENU_ITEMS[] temp = services.STD_MENU_ITEMS_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_MENU_ITEMS>();
            return null;
        }

        public static List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, int STD_ROLE_ID)
        {
            List<STD_MENU_ITEMS> temp = STD_MENU_ITEMS_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null && STD_ROLE_ID > 0)
            {
                temp = temp.Where(w => w.STD_ROLE_ID == STD_ROLE_ID).ToList();
            }

            return temp;
        }

        public static List<STD_MENU_ITEMS> STD_MENU_ITEMS_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, int STD_ROLE_ID, string SORT_EXPRESSION, string SEARCH_COLUMN, string SEARCH_TEXT)
        {
            List<STD_MENU_ITEMS> objReturn = STD_MENU_ITEMS_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID, STD_ROLE_ID);

            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_MENU_ITEMS>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_MENU_ITEMS>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_MENU_ITEMS>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_MENU_ITEMS>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_MENU_ITEMS>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_MENU_ITEMS>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_MENU_ITEMS>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_MENU_ITEMS>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_MENU_ITEMS>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static List<STD_WEB_PAGES> STD_WEB_PAGES_GET_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SORT_EXPRESSION, string SEARCH_COLUMN, string SEARCH_TEXT)
        {
            List<STD_WEB_PAGES> objReturn = STD_WEB_PAGES_GET_ALL(CURRENT_USER, CURRENT_REGISTRY_ID);

            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_WEB_PAGES>();
                            }
                            else
                            {
                                objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_WEB_PAGES>();
                                objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_WEB_PAGES>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_WEB_PAGES>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_WEB_PAGES>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length > 3)
                        {
                            if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                            {
                                SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                                if (SORT_EXPRESSION.Contains("."))
                                {
                                    string[] props = SORT_EXPRESSION.Split('.');
                                    if (props != null && props.Count() == 2)
                                    {
                                        objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_WEB_PAGES>();
                                    }
                                }
                                else
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_WEB_PAGES>();
                            }
                            else
                            {
                                if (SORT_EXPRESSION.Contains("."))
                                {
                                    string[] props = SORT_EXPRESSION.Split('.');
                                    if (props != null && props.Count() == 2)
                                    {
                                        objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_WEB_PAGES>();
                                    }
                                }
                                else
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_WEB_PAGES>();
                                }
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_WEB_PAGES>();
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_WEB_PAGES>();
                            }
                        }
                    }
                }
            }
            return objReturn;
        }

        public static CrsMenu STD_MENU_ITEMS_GET_MENU(string CURRENT_USER, int CURRENT_REGISTRY_ID, string PATH)
        {
            CrsMenu crsMenu = null;

            STD_MENU_ITEMS[] temp = services.STD_MENU_ITEMS_GET_MENU(CURRENT_USER, CURRENT_REGISTRY_ID, PATH);
            if (temp != null)
            {
                List<CrsMenuItem> menuItems = new List<CrsMenuItem>();

                foreach (STD_MENU_ITEMS item in temp)
                {
                    if (item.MENU_PAGE != null)
                        menuItems.Add(new CrsMenuItem(item.MENU_PAGE.DISPLAY_TEXT, item.MENU_PAGE.URL));
                }

                crsMenu = new CrsMenu(menuItems);
            }

            return crsMenu;
        }

        #endregion

        #region STD_QUESTION

        public static List<STD_QUESTION> STD_QUESTION_GET_ALL_BY_SURVEY(string CURRENT_USER, int CURRENT_REGISTRY_ID, int STD_SURVEY_TYPE_ID)
        {
            STD_QUESTION[] temp = services.STD_QUESTION_GET_ALL_BY_SURVEY(CURRENT_USER, CURRENT_REGISTRY_ID, STD_SURVEY_TYPE_ID);
            if (temp != null)
                return temp.ToList<STD_QUESTION>();
            return null;
        }

        public static List<STD_QUESTION> STD_QUESTION_GET_ALL_BY_SURVEY(string CURRENT_USER, int CURRENT_REGISTRY_ID, int STD_SURVEY_TYPE_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<STD_QUESTION> objReturn = STD_QUESTION_GET_ALL_BY_SURVEY(CURRENT_USER, CURRENT_REGISTRY_ID, STD_SURVEY_TYPE_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_QUESTION>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_QUESTION>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_QUESTION>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_QUESTION>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_QUESTION>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_QUESTION>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_QUESTION>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_QUESTION>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_QUESTION>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static bool STD_QUESTION_COPY_CHOICES(string CURRENT_USER, int CURRENT_REGISTRY_ID, int OLD_QUESTION_ID, int NEW_QUESTION_ID)
        {
            return services.STD_QUESTION_COPY_CHOICES(CURRENT_USER, CURRENT_REGISTRY_ID, OLD_QUESTION_ID, NEW_QUESTION_ID);
        }

        #endregion

        #region STD_QUESTION_CHOICE

        public static List<STD_QUESTION_CHOICE> STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION(string CURRENT_USER, int CURRENT_REGISTRY_ID, int STD_QUESTION_ID)
        {
            STD_QUESTION_CHOICE[] temp = services.STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION(CURRENT_USER, CURRENT_REGISTRY_ID, STD_QUESTION_ID);
            if (temp != null)
                return temp.ToList<STD_QUESTION_CHOICE>();
            return null;
        }

        public static List<STD_QUESTION_CHOICE> STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION(string CURRENT_USER, int CURRENT_REGISTRY_ID, int STD_QUESTION_ID, string SORT_EXPRESSION, string SEARCH_COLUMN, string SEARCH_TEXT)
        {
            List<STD_QUESTION_CHOICE> objReturn = STD_QUESTION_CHOICE_GET_ALL_BY_QUESTION(CURRENT_USER, CURRENT_REGISTRY_ID, STD_QUESTION_ID);

            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_QUESTION_CHOICE>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_QUESTION_CHOICE>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_QUESTION_CHOICE>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_QUESTION_CHOICE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_QUESTION_CHOICE>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_QUESTION_CHOICE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_QUESTION_CHOICE>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_QUESTION_CHOICE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_QUESTION_CHOICE>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        #endregion

        #region STD_REFERRALSTS

        public static STD_REFERRALSTS STD_REFERRALSTS_GET_BY_CODE(string CURRENT_USER, int CURRENT_REGISTRY_ID, string CODE)
        {
            return services.STD_REFERRALSTS_GET_BY_CODE(CURRENT_USER, CURRENT_REGISTRY_ID, CODE);
        }

        #endregion

        #region STD_REG_UDFs

        public static List<STD_REG_UDFs> STD_REG_UDFs_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_REG_UDFs[] temp = services.STD_REG_UDFs_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_REG_UDFs>();
            return null;
        }

        public static List<STD_REG_UDFs> STD_REG_UDFs_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<STD_REG_UDFs> objReturn = STD_REG_UDFs_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_REG_UDFs>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_REG_UDFs>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_REG_UDFs>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_REG_UDFs>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_REG_UDFs>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_REG_UDFs>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_REG_UDFs>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_REG_UDFs>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_REG_UDFs>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        #endregion

        #region STD_REGISTRY

        public static STD_REGISTRY STD_REGISTRY_GET_COMPLETE(string CURRENT_USER, int CURRENT_REGISTRY_ID, int ID)
        {
            return services.STD_REGISTRY_GET_COMPLETE(CURRENT_USER, CURRENT_REGISTRY_ID, ID);
        }

        public static STD_REGISTRY STD_REGISTRY_GET_SYSTEM()
        {
            return services.STD_REGISTRY_GET_SYSTEM();
        }

        public static List<STD_REGISTRY> STD_REGISTRY_GET_ALL_BY_USER(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_REGISTRY[] temp = services.STD_REGISTRY_GET_ALL_BY_USER(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_REGISTRY>();
            return null;
        }

        public static List<STD_REGISTRY> STD_REGISTRY_GET_ALL_BY_USER(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<STD_REGISTRY> objReturn = STD_REGISTRY_GET_ALL_BY_USER(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_REGISTRY>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_REGISTRY>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_REGISTRY>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_REGISTRY>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_REGISTRY>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_REGISTRY>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_REGISTRY>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_REGISTRY>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_REGISTRY>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static List<STD_REGISTRY> STD_REGISTRY_GET_ALL_NON_SYSTEM()
        {
            STD_REGISTRY[] temp = services.STD_REGISTRY_GET_ALL_NON_SYSTEM();
            if (temp != null)
                return temp.ToList<STD_REGISTRY>();
            return null;
        }

        public static List<STD_REGISTRY> STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_REGISTRY[] temp = services.STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_REGISTRY>();
            return null;
        }

        public static List<STD_REGISTRY> STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SORT_EXPRESSION, string SEARCH_COLUMN, string SEARCH_TEXT)
        {
            List<STD_REGISTRY> objReturn = STD_REGISTRY_GET_ALL_NON_SYSTEM_BY_USER(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_REGISTRY>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_REGISTRY>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_REGISTRY>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_REGISTRY>();
                                }
                            }
                            else
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_REGISTRY>();
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_REGISTRY>();
                                }
                            }
                            else
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_REGISTRY>();
                        }
                    }
                }
            }
            return objReturn;
        }

        #endregion

        #region STD_REGISTRY_CODES
        #endregion

        #region STD_REGISTRY_COHORT_TYPES
        #endregion

        #region STD_REGISTRY_CORE_TYPES
        #endregion

        #region STD_ROLE

        public static List<STD_ROLE> STD_ROLE_GET_ALL_SYSTEM_ROLES(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_ROLE[] temp = services.STD_ROLE_GET_ALL_SYSTEM_ROLES(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_ROLE>();
            return null;
        }

        public static List<STD_ROLE> STD_ROLE_GET_ALL_REGISTRY_ROLES(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_ROLE[] temp = services.STD_ROLE_GET_ALL_REGISTRY_ROLES(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_ROLE>();
            return null;
        }

        public static List<STD_ROLE> STD_ROLE_GET_ALL_REGISTRY_ROLES(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<STD_ROLE> objReturn = STD_ROLE_GET_ALL_REGISTRY_ROLES(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_ROLE>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_ROLE>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_ROLE>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_ROLE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_ROLE>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_ROLE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_ROLE>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_ROLE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_ROLE>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static List<STD_ROLE> STD_ROLE_GET_ALL_BY_USER_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_ROLE[] temp = services.STD_ROLE_GET_ALL_BY_USER_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_ROLE>();
            return null;
        }

        public static List<STD_ROLE> STD_ROLE_GET_ALL_BY_USER_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string STD_ROLE_ID, string SORT_EXPRESSION, string SEARCH_COLUMN, string SEARCH_TEXT)
        {
            List<STD_ROLE> objReturn = STD_ROLE_GET_ALL_BY_USER_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_ROLE>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_ROLE>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_ROLE>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_ROLE>();
                                }
                            }
                            else
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_ROLE>();
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_ROLE>();
                                }
                            }
                            else
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_ROLE>();
                        }
                    }
                }
            }
            return objReturn;
        }

        #endregion

        #region STD_SERVICE_OCCUPATION
        #endregion

        #region STD_STATE
        #endregion

        #region STD_SURVEY_SECTION
        #endregion

        #region STD_SURVEY_SUB_SECTION
        #endregion

        #region STD_SURVEY_TYPE

        public static List<STD_SURVEY_TYPE> STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_SURVEY_TYPE[] temp = services.STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_SURVEY_TYPE>();
            return null;
        }

        public static List<STD_SURVEY_TYPE> STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<STD_SURVEY_TYPE> objReturn = STD_SURVEY_TYPE_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_SURVEY_TYPE>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_SURVEY_TYPE>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_SURVEY_TYPE>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_SURVEY_TYPE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_SURVEY_TYPE>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_SURVEY_TYPE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_SURVEY_TYPE>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_SURVEY_TYPE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_SURVEY_TYPE>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        #endregion

        #region STD_USER_ACTIVITY_TYPE
        #endregion

        #region STD_WKFACTIVITYSTS

        public static STD_WKFACTIVITYSTS STD_WKFACTIVITYSTS_GET_BY_CODE(string CURRENT_USER, int CURRENT_REGISTRY_ID, string CODE)
        {
            return services.STD_WKFACTIVITYSTS_GET_BY_CODE(CURRENT_USER, CURRENT_REGISTRY_ID, CODE);
        }

        #endregion

        #region STD_WKFACTIVITYTYPE

        public static List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_WKFACTIVITYTYPE[] temp = services.STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_WKFACTIVITYTYPE>();
            return null;
        }

        public static List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<STD_WKFACTIVITYTYPE> objReturn = STD_WKFACTIVITYTYPE_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_WKFACTIVITYTYPE>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_WKFACTIVITYTYPE>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_WKFACTIVITYTYPE>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_WKFACTIVITYTYPE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_WKFACTIVITYTYPE>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_WKFACTIVITYTYPE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_WKFACTIVITYTYPE>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_WKFACTIVITYTYPE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_WKFACTIVITYTYPE>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static List<STD_WKFACTIVITYTYPE> STD_WKFACTIVITYTYPE_GET_ALL_BY_WORKSTREAM(string CURRENT_USER, int CURRENT_REGISTRY_ID, int STD_WKFCASETYPE_ID)
        {
            STD_WKFACTIVITYTYPE[] temp = services.STD_WKFACTIVITYTYPE_GET_ALL_BY_WORKSTREAM(CURRENT_USER, CURRENT_REGISTRY_ID, STD_WKFCASETYPE_ID);
            if (temp != null)
                return temp.ToList<STD_WKFACTIVITYTYPE>();
            return null;
        }

        #endregion

        #region STD_WKFCASESTS

        public static STD_WKFCASESTS STD_WKFCASESTS_GET_BY_CODE(string CURRENT_USER, int CURRENT_REGISTRY_ID, string CODE)
        {
            return services.STD_WKFCASESTS_GET_BY_CODE(CURRENT_USER, CURRENT_REGISTRY_ID, CODE);
        }

        #endregion

        #region STD_WKFCASETYPE

        public static List<STD_WKFCASETYPE> STD_WKFCASETYPE_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            STD_WKFCASETYPE[] temp = services.STD_WKFCASETYPE_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<STD_WKFCASETYPE>();
            return null;
        }

        public static List<STD_WKFCASETYPE> STD_WKFCASETYPE_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<STD_WKFCASETYPE> objReturn = STD_WKFCASETYPE_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_WKFCASETYPE>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<STD_WKFCASETYPE>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<STD_WKFCASETYPE>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_WKFCASETYPE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_WKFCASETYPE>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_WKFCASETYPE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_WKFCASETYPE>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<STD_WKFCASETYPE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<STD_WKFCASETYPE>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        #endregion

        #region SURVEY_NOTES
        #endregion

        #region SURVEY_RESULTS

        public static List<SURVEY_RESULTS> SURVEY_RESULTS_GET_ALL_BY_SURVEY(string CURRENT_USER, int CURRENT_REGISTRY_ID, int SURVEY_ID)
        {
            SURVEY_RESULTS[] temp = services.SURVEY_RESULTS_GET_ALL_BY_SURVEY(CURRENT_USER, CURRENT_REGISTRY_ID, SURVEY_ID);
            if (temp != null)
                return temp.ToList<SURVEY_RESULTS>();
            return null;
        }

        public static bool SURVEY_RESULTS_SAVE_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID, List<SURVEY_RESULTS> RESULTS)
        {
            SURVEY_RESULTS[] temp = RESULTS.ToArray();
            return services.SURVEY_RESULTS_SAVE_ALL(CURRENT_USER, CURRENT_REGISTRY_ID, temp);
        }

        #endregion

        #region SURVEYS

        public static SURVEYS SURVEYS_GET_FOR_SURVEY(string CURRENT_USER, int CURRENT_REGISTRY_ID, int SURVEYS_ID)
        {
            return services.SURVEYS_GET_FOR_SURVEY(CURRENT_USER, CURRENT_REGISTRY_ID, SURVEYS_ID);
        }

        public static List<SURVEYS> SURVEYS_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            SURVEYS[] temp = services.SURVEYS_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<SURVEYS>();
            return null;
        }

        public static List<SURVEYS> SURVEYS_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<SURVEYS> objReturn = SURVEYS_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<SURVEYS>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<SURVEYS>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<SURVEYS>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<SURVEYS>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<SURVEYS>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<SURVEYS>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<SURVEYS>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<SURVEYS>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<SURVEYS>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        #endregion

        #region USER_ACTIVITY_LOG
        #endregion

        #region USER_ROLES

        public static USER_ROLES USER_ROLES_GET_BY_USERID_ROLEID(string CURRENT_USER, int CURRENT_REGISTRY_ID, int USER_ID, int STD_ROLE_ID)
        {
            return services.USER_ROLES_GET_BY_USERID_ROLEID(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ID, STD_ROLE_ID);
        }

        public static USER_ROLES USER_ROLES_GET_BY_USER_ROLE(string Username, string RoleName)
        {
            return services.USER_ROLES_GET_BY_USER_ROLE(Username, RoleName);
        }

        public static string[] USER_ROLES_GET_ROLES(string Username)
        {
            return services.USER_ROLES_GET_ROLES(Username);
        }

        public static List<USER_ROLES> USER_ROLES_GET_ALL_BY_USER(string CURRENT_USER, int CURRENT_REGISTRY_ID, int USER_ID)
        {
            USER_ROLES[] temp = services.USER_ROLES_GET_ALL_BY_USER(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ID);
            if (temp != null)
                return temp.ToList<USER_ROLES>();
            return null;
        }

        public static bool USER_ROLES_DELETE_BY_USER_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, int USER_ID, int STD_REGISTRY_ID)
        {
            return services.USER_ROLES_DELETE_BY_USER_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID, USER_ID, STD_REGISTRY_ID);
        }

        public static bool USER_ROLES_SAVE_ALL(string CURRENT_USER, int CURRENT_REGISTRY_ID, List<USER_ROLES> USER_ROLES)
        {
            if (USER_ROLES == null)
                return false;

            USER_ROLES[] temp = USER_ROLES.ToArray();
            return services.USER_ROLES_SAVE_ALL(CURRENT_USER, CURRENT_REGISTRY_ID, temp);
        }

        public static bool USER_ROLES_GET_BY_REGISTRYID_USERNAME_SET_READONLY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            string[] temp = services.USER_ROLES_GET_BY_REGISTRYID_USERNAME(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
            {
                List<string> roleList = temp.ToList();
                bool isAdmin = false;
                bool canEdit = false;
                bool hasRead = false;
                UserSession userSession = (UserSession)HttpContext.Current.Session["UserSession"];
                if (userSession == null) userSession = new UserSession();

                if (roleList != null)
                {                   
                    for (int i = 0; i < roleList.Count; i++)
                    {
                        if (roleList[i].ToUpper() == "CRSADMIN" || roleList[i].ToUpper() == "REGADMIN")
                        {
                            if (roleList[i].ToUpper() == "CRSADMIN") { userSession.IsSystemAdministrator = true; }
                            if (roleList[i].ToUpper() == "REGADMIN") { userSession.IsRegistryAdministrator = true; }
                            isAdmin = true;
                            break;
                        }
                    }
                    //Admins supercede the following roles - why check for them if user is admin
                    if (isAdmin == false)
                    {
                        for (int i = 0; i < roleList.Count; i++)
                        {
                            if (roleList[i].ToUpper() == "CRSUPD" || roleList[i].ToUpper() == "REGUPD")
                            {
                                canEdit = true;
                                break;
                            }
                            if (roleList[i].ToUpper() == "CRSREAD" || roleList[i].ToUpper() == "REGREAD")
                            {
                                hasRead = true;
                                break;
                            }
                        }
                    }
                    /* JUST MADE THE LOGIC SIMPLIER - HEATH - AND RETURN BASED IN THE ORDER OF THE ROLE VALUE SIGNIFICANCE */
                    if (isAdmin)
                    {
                        return false;
                    }
                    if (canEdit)
                    {
                        return false;
                    }
                    if (hasRead)
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        #endregion

        #region USERS

        public static DomainNames USERS_LOAD_FROM_AD()
        {
            return services.USERS_LOAD_FROM_AD();
        }

        public static List<DomainUser> USERS_GET_ALL_BY_AD(DomainNames domainNames, string searchString)
        {
            DomainUser[] temp = services.USERS_GET_ALL_BY_AD(domainNames, searchString);
            if (temp != null)
                return temp.ToList<DomainUser>();
            return null;
        }

        public static List<DomainUser> USERS_GET_ALL_BY_AD(DomainNames domainNames, string searchString, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<DomainUser> objReturn = USERS_GET_ALL_BY_AD(domainNames, searchString);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<DomainUser>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<DomainUser>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<DomainUser>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<DomainUser>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<DomainUser>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<DomainUser>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<DomainUser>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<DomainUser>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<DomainUser>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static USERS USERS_GET_BY_NAME(string CURRENT_USER, int CURRENT_REGISTRY_ID, string username)
        {
            return services.USERS_GET_BY_NAME(CURRENT_USER, CURRENT_REGISTRY_ID, username);
        }

        public static List<USERS> USERS_GET_ALL_BY_USER(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            USERS[] temp = services.USERS_GET_ALL_BY_USER(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<USERS>();
            return null;
        }

        public static List<USERS> USERS_GET_ALL_BY_USER(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<USERS> objReturn = USERS_GET_ALL_BY_USER(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<USERS>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<USERS>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<USERS>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<USERS>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<USERS>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<USERS>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<USERS>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<USERS>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<USERS>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static bool USERS_DEFAULT_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, bool IS_DEFAULT)
        {
            return services.USERS_DEFAULT_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID, IS_DEFAULT);
        }

        #endregion

        #region WKF_CASE

        public static List<WKF_CASE> WKF_CASE_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            WKF_CASE[] temp = services.WKF_CASE_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<WKF_CASE>();
            return null;
        }

        public static List<WKF_CASE> WKF_CASE_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<WKF_CASE> objReturn = WKF_CASE_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<WKF_CASE>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<WKF_CASE>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<WKF_CASE>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<WKF_CASE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<WKF_CASE>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<WKF_CASE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<WKF_CASE>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<WKF_CASE>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<WKF_CASE>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static bool WKF_CASE_UPDATE_STATUS(string CURRENT_USER, int CURRENT_REGISTRY_ID, int WKF_CASE_ID, int STD_WKFCASESTS_ID)
        {
            return services.WKF_CASE_UPDATE_STATUS(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_ID, STD_WKFCASESTS_ID);
        }

        #endregion

        #region WKF_CASE_ACTIVITY

        public static List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            WKF_CASE_ACTIVITY[] temp = services.WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<WKF_CASE_ACTIVITY>();
            return null;
        }

        public static List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<WKF_CASE_ACTIVITY> objReturn = WKF_CASE_ACTIVITY_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null && objReturn.Count != 0)
            {
                if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                {
                    if (SEARCH_COLUMN.Contains("."))
                    {
                        string[] props = SEARCH_COLUMN.Split('.');
                        if (props != null && props.Count() == 2)
                        {
                            objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<WKF_CASE_ACTIVITY>();
                        }
                        else if (props != null && props.Count() == 3)
                        {
                            objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).GetType().GetProperty(props[2]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<WKF_CASE_ACTIVITY>();
                        }
                    }
                    else
                    {
                        objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<WKF_CASE_ACTIVITY>();
                        objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<WKF_CASE_ACTIVITY>();
                    }
                }
                else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                {
                    if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                    {
                        SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                        if (SORT_EXPRESSION.Contains("."))
                        {
                            string[] props = SORT_EXPRESSION.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<WKF_CASE_ACTIVITY>();
                            }
                            else if (props != null && props.Count() == 3)
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).GetType().GetProperty(props[2]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)))).ToList<WKF_CASE_ACTIVITY>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<WKF_CASE_ACTIVITY>();
                        }
                    }
                    else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                    {
                        SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                        if (SORT_EXPRESSION.Contains("."))
                        {
                            string[] props = SORT_EXPRESSION.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<WKF_CASE_ACTIVITY>();
                            }
                            else if (props != null && props.Count() == 3)
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).GetType().GetProperty(props[2]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)))).ToList<WKF_CASE_ACTIVITY>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<WKF_CASE_ACTIVITY>();
                        }
                    }
                    else
                    {
                        if (SORT_EXPRESSION.Contains("."))
                        {
                            string[] props = SORT_EXPRESSION.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<WKF_CASE_ACTIVITY>();
                            }
                            else if (props != null && props.Count() == 3)
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).GetType().GetProperty(props[2]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)))).ToList<WKF_CASE_ACTIVITY>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<WKF_CASE_ACTIVITY>();
                        }
                    }
                }
            }

            return objReturn;
        }

        public static List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM(string CURRENT_USER, int CURRENT_REGISTRY_ID, int WKF_CASE_ID)
        {
            WKF_CASE_ACTIVITY[] temp = services.WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_ID);
            if (temp != null)
                return temp.ToList<WKF_CASE_ACTIVITY>();
            return null;
        }

        public static List<WKF_CASE_ACTIVITY> WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM(string CURRENT_USER, int CURRENT_REGISTRY_ID, int WKF_CASE_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<WKF_CASE_ACTIVITY> objReturn = WKF_CASE_ACTIVITY_GET_ALL_BY_WORKSTREAM(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_ID);
            if (objReturn != null && objReturn.Count != 0)
            {
                if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                {
                    if (SEARCH_COLUMN.Contains("."))
                    {
                        string[] props = SEARCH_COLUMN.Split('.');
                        if (props != null && props.Count() == 2)
                        {
                            objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<WKF_CASE_ACTIVITY>();
                        }
                        else if (props != null && props.Count() == 3)
                        {
                            // objReturn = objReturn.Where(s => s.GetType().GetProperty(props[1]).GetValue(s).GetType().GetProperty(props[2]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<WKF_CASE_ACTIVITY>();
                        }
                    }
                    else
                    {
                        objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<WKF_CASE_ACTIVITY>();
                        objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<WKF_CASE_ACTIVITY>();
                    }
                }
                else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                {
                    if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                    {
                        SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                        if (SORT_EXPRESSION.Contains("."))
                        {
                            string[] props = SORT_EXPRESSION.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<WKF_CASE_ACTIVITY>();
                            }
                            else if (props != null && props.Count() == 3)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[1]).GetValue(s).GetType().GetProperty(props[2]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<WKF_CASE_ACTIVITY>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<WKF_CASE_ACTIVITY>();
                        }
                    }
                    else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                    {
                        SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                        if (SORT_EXPRESSION.Contains("."))
                        {
                            string[] props = SORT_EXPRESSION.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<WKF_CASE_ACTIVITY>();
                            }
                            else if (props != null && props.Count() == 3)
                            {
                            }
                        }
                        else
                        {
                            objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<WKF_CASE_ACTIVITY>();
                        }
                    }
                    else
                    {
                        if (SORT_EXPRESSION.Contains("."))
                        {
                            string[] props = SORT_EXPRESSION.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<WKF_CASE_ACTIVITY>();
                            }
                            else if (props != null && props.Count() == 3)
                            {
                                // objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetType().GetProperty(props[2]).GetValue(s.GetType().GetProperty(props[2]).GetValue(s))).ToList<WKF_CASE_ACTIVITY>();
                                //   objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s).GetType().GetProperty(props[2]).GetValue(s.GetType().GetProperty(props[1]).GetValue(s))).ToList<WKF_CASE_ACTIVITY>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<WKF_CASE_ACTIVITY>();
                        }
                    }
                }
            }

            return objReturn;
        }

        public static bool WKF_CASE_ACTIVITY_UPDATE_STATUS(string CURRENT_USER, int CURRENT_REGISTRY_ID, int WKF_CASE_ACTIVITY_ID, int STD_WKFACTIVITYSTS_ID)
        {
            return services.WKF_CASE_ACTIVITY_UPDATE_STATUS(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_ACTIVITY_ID, STD_WKFACTIVITYSTS_ID);
        }

        #endregion

        #region WKF_CASE_ASSIGNMENT
        #endregion

        #region WKF_CASE_COMMENTS
        #endregion

        #region LOGS

        public static void LogDetails(LogDetails logDetails)
        {
            services.LOG_DETAILS(logDetails);
        }

        public static void LogTiming(LogDetails logDetails)
        {
            services.LOG_TIMING(logDetails);
        }

        public static void LogInformation(string message, string processName, string username, int registryId)
        {
            services.LOG_INFORMATION(message, processName, username, registryId);
        }

        public static void LogError(string message, string processName, string username, int registryId)
        {
            services.LOG_ERROR(message, processName, username, registryId);
        }

        #endregion

        #region REPORTS

        public static List<ReportItem> REPORTS_GET_ALL_BY_USER_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            ReportItem[] temp = services.REPORTS_GET_ALL_BY_USER_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<ReportItem>();
            return null;
        }

        public static List<ReportItem> REPORTS_GET_ALL_BY_USER_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID, string SEARCH_COLUMN, string SEARCH_TEXT, string SORT_EXPRESSION)
        {
            List<ReportItem> objReturn = REPORTS_GET_ALL_BY_USER_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (objReturn != null)
            {
                if (objReturn != null && objReturn.Count != 0)
                {
                    if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SEARCH_TEXT))
                    {
                        if (SEARCH_COLUMN.Contains("."))
                        {
                            string[] props = SEARCH_COLUMN.Split('.');
                            if (props != null && props.Count() == 2)
                            {
                                objReturn = objReturn.Where(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s)).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<ReportItem>();
                            }
                        }
                        else
                        {
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w) != null).ToList<ReportItem>();
                            objReturn = objReturn.Where(w => w.GetType().GetProperty(SEARCH_COLUMN).GetValue(w).ToString().ToLower().Contains(SEARCH_TEXT.ToLower())).ToList<ReportItem>();
                        }
                    }
                    else if (!string.IsNullOrEmpty(SEARCH_COLUMN) && !string.IsNullOrEmpty(SORT_EXPRESSION))
                    {
                        if (SORT_EXPRESSION.Length >= 4 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 4, 4).ToUpper() == "DESC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 5);

                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<ReportItem>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderByDescending(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<ReportItem>();
                            }
                        }
                        else if (SORT_EXPRESSION.Length >= 3 && SORT_EXPRESSION.Substring(SORT_EXPRESSION.Length - 3, 3).ToUpper() == "ASC")
                        {
                            SORT_EXPRESSION = SORT_EXPRESSION.Substring(0, SORT_EXPRESSION.Length - 4);
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<ReportItem>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<ReportItem>();
                            }
                        }
                        else
                        {
                            if (SORT_EXPRESSION.Contains("."))
                            {
                                string[] props = SORT_EXPRESSION.Split('.');
                                if (props != null && props.Count() == 2)
                                {
                                    objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(props[0]).GetValue(s).GetType().GetProperty(props[1]).GetValue(s.GetType().GetProperty(props[0]).GetValue(s))).ToList<ReportItem>();
                                }
                                else if (props != null && props.Count() == 3)
                                {
                                }
                            }
                            else
                            {
                                objReturn = objReturn.OrderBy(s => s.GetType().GetProperty(SORT_EXPRESSION).GetValue(s)).ToList<ReportItem>();
                            }
                        }
                    }
                }
            }

            return objReturn;
        }

        public static List<ReportItem> REPORTS_GET_ALL_BY_REGISTRY(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            ReportItem[] temp = services.REPORTS_GET_ALL_BY_REGISTRY(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<ReportItem>();
            return null;
        }

        public static List<ReportItem> REPORTS_GET_ALL_SYSTEM(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            ReportItem[] temp = services.REPORTS_GET_ALL_SYSTEM(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<ReportItem>();
            return null;
        }

        public static List<ReportItem> REPORTS_GET_ALL_BY_USER(string CURRENT_USER, int CURRENT_REGISTRY_ID)
        {
            ReportItem[] temp = services.REPORTS_GET_ALL_BY_USER(CURRENT_USER, CURRENT_REGISTRY_ID);
            if (temp != null)
                return temp.ToList<ReportItem>();
            return null;
        }

        public static bool REPORTS_UPDATE_ITEM_PROPERTIES(string CURRENT_USER, int CURRENT_REGISTRY_ID, string ITEM_PATH, string DESCRIPTION)
        {
            return services.REPORTS_UPDATE_ITEM_PROPERTIES(CURRENT_USER, CURRENT_REGISTRY_ID, ITEM_PATH, DESCRIPTION);
        }

        #endregion

        #region APPSETTINGS

        public static AppSettings APPSETTINGS_GET(string identity, int registryId)
        {
            return services.APPSETTINGS_GET(identity, registryId);
        }

        public static bool APPSETTINGS_SAVE(string identity, int registryId, AppSettings appSettings)
        {
            return services.APPSETTINGS_SAVE(identity, registryId, appSettings);
        }

        #endregion

        #region MVI

        public static bool PRPA_IN201305UV02(string CURRENT_USER, int CURRENT_REGISTRY_ID, int CURRENT_PATIENT_ID)
        {
            return services.PRPA_IN201305UV02(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_PATIENT_ID);
        }

        public static bool PRPA_IN201309UV02(string CURRENT_USER, int CURRENT_REGISTRY_ID, int CURRENT_PATIENT_ID)
        {
            return services.PRPA_IN201309UV02(CURRENT_USER, CURRENT_REGISTRY_ID, CURRENT_PATIENT_ID);
        }

        #endregion
    }
}
