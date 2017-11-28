using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CRSe.CRS.BLL;
using CRSe.CRS.BO;

namespace CRSe.CRS.DAL
{
	public partial class STD_MENU_ITEMSDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public List<STD_MENU_ITEMS> GetItemsByRegistry(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
        {
            List<STD_MENU_ITEMS> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_STD_MENU_ITEMS_getitemsByRegistry", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
                {
                    var myData = objTemp.Tables[0].AsEnumerable().Select(r => ParseReaderComplete(r));
                    if (myData != null)
                    {
                        objReturn = myData.ToList<STD_MENU_ITEMS>();
                    }
                }

                sConn.Close();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }
            finally
            {
                if (sAdapter != null)
                {
                    sAdapter.Dispose();
                    sAdapter = null;
                }
                if (sCmd != null)
                {
                    sCmd.Dispose();
                    sCmd = null;
                }
                if (sConn != null)
                {
                    if (sConn.State != ConnectionState.Closed) { sConn.Close(); }
                    sConn.Dispose();
                    sConn = null;
                }
            }

            return objReturn;
        }

        public List<STD_MENU_ITEMS> GetItemsByUserRegistryPath(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, string PATH)
        {
            List<STD_MENU_ITEMS> objReturn = null;

            SqlConnection sConn = null;
            SqlCommand sCmd = null;
            SqlDataAdapter sAdapter = null;
            DataSet objTemp = null;

            try
            {
                sConn = new SqlConnection(SqlConnectionString);

                sConn.Open();

                sCmd = new SqlCommand("CRS.usp_STD_MENU_ITEMS_getitemsByUserRegistryPath", sConn);
                sCmd.CommandTimeout = SqlCommandTimeout;
                sCmd.CommandType = CommandType.StoredProcedure;
                sCmd.Parameters.AddWithValue("@CURRENT_USER", CURRENT_USER);
                sCmd.Parameters.AddWithValue("@CURRENT_REGISTRY_ID", CURRENT_REGISTRY_ID);
                sCmd.Parameters.AddWithValue("@PATH", PATH);

                objTemp = new DataSet();
                sAdapter = new SqlDataAdapter(sCmd);

                LogDetails logDetails = new LogDetails(String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                sAdapter.Fill(objTemp);
                LogManager.LogTiming(logDetails);
                CheckDataSet(objTemp);

                if (objTemp != null && objTemp.Tables.Count > 0 && objTemp.Tables[0].Rows.Count > 0)
                {
                    var myData = objTemp.Tables[0].AsEnumerable().Select(r => ParseReaderMenu(r));
                    if (myData != null)
                    {
                        objReturn = myData.ToList<STD_MENU_ITEMS>();
                    }
                }

                sConn.Close();
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), CURRENT_USER, CURRENT_REGISTRY_ID);
                throw ex;
            }
            finally
            {
                if (sAdapter != null)
                {
                    sAdapter.Dispose();
                    sAdapter = null;
                }
                if (sCmd != null)
                {
                    sCmd.Dispose();
                    sCmd = null;
                }
                if (sConn != null)
                {
                    if (sConn.State != ConnectionState.Closed) { sConn.Close(); }
                    sConn.Dispose();
                    sConn = null;
                }
            }

            return objReturn;
        }

        public STD_MENU_ITEMS ParseReaderComplete(DataRow row)
        {
            STD_MENU_ITEMS objReturn = ParseReaderCustom(row);
            if (objReturn != null)
            {
                if (objReturn.STD_REGISTRY_ID > 0)
                {
                    STD_REGISTRYDB sTD_REGISTRYDB = new STD_REGISTRYDB();
                    objReturn.STD_REGISTRY = sTD_REGISTRYDB.ParseReaderCustom(row);
                }

                STD_WEB_PAGESDB sTD_WEB_PAGESDB = new STD_WEB_PAGESDB();
                if (objReturn.PAGE_ID > 0)
                {
                    objReturn.STD_WEB_PAGES = sTD_WEB_PAGESDB.ParseReaderCustom(row);
                }

                if (objReturn.MENU_PAGE_ID > 0)
                {
                    objReturn.MENU_PAGE = sTD_WEB_PAGESDB.ParseReaderAlt(row);
                }

                if (objReturn.STD_ROLE_ID > 0)
                {
                    STD_ROLEDB sTD_ROLEDB = new STD_ROLEDB();
                    objReturn.STD_ROLE = sTD_ROLEDB.ParseReaderCustom(row);
                }
            }

            return objReturn;
        }

        public STD_MENU_ITEMS ParseReaderMenu(DataRow row)
        {
            STD_MENU_ITEMS objReturn = new STD_MENU_ITEMS()
            {
                SORT_ORDER = (Int32)GetNullableObject(row.Field<object>("STD_MENU_ITEMS_SORT_ORDER")),
                STD_REGISTRY = new STD_REGISTRY() 
                {
                    NAME = (string)GetNullableObject(row.Field<object>("STD_REGISTRY_NAME")),
                },
                MENU_PAGE = new STD_WEB_PAGES()
                {
                    DISPLAY_TEXT = (string)GetNullableObject(row.Field<object>("MENU_PAGE_DISPLAY_TEXT")),
                    URL = (string)GetNullableObject(row.Field<object>("MENU_PAGE_URL"))
                }
            };

            return objReturn;
        }

		#endregion
	}
}
