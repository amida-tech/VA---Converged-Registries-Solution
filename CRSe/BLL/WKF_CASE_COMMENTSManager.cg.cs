using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class WKF_CASE_COMMENTSManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static WKF_CASE_COMMENTS GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_COMMENT_ID)
		{
			WKF_CASE_COMMENTS objReturn = null;
			WKF_CASE_COMMENTSDB objDB = new WKF_CASE_COMMENTSDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_COMMENT_ID);

			return objReturn;
		}

		public static List<WKF_CASE_COMMENTS> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<WKF_CASE_COMMENTS> objReturn = null;
			WKF_CASE_COMMENTSDB objDB = new WKF_CASE_COMMENTSDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, WKF_CASE_COMMENTS objSave)
		{
			Int32 objReturn = 0;
			WKF_CASE_COMMENTSDB objDB = new WKF_CASE_COMMENTSDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 WKF_CASE_COMMENT_ID)
		{
			Boolean objReturn = false;
			WKF_CASE_COMMENTSDB objDB = new WKF_CASE_COMMENTSDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, WKF_CASE_COMMENT_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, WKF_CASE_COMMENTS objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.WKF_CASE_COMMENT_ID);
		}

		#endregion
	}
}
