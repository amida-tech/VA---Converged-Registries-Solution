using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class DIM_TIMEManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static DIM_TIME GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DateTime PK_Date)
		{
			DIM_TIME objReturn = null;
			DIM_TIMEDB objDB = new DIM_TIMEDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, PK_Date);

			return objReturn;
		}

		public static List<DIM_TIME> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<DIM_TIME> objReturn = null;
			DIM_TIMEDB objDB = new DIM_TIMEDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static DateTime Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DIM_TIME objSave)
		{
			DateTime objReturn = DateTime.MinValue;
			DIM_TIMEDB objDB = new DIM_TIMEDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DateTime PK_Date)
		{
			Boolean objReturn = false;
			DIM_TIMEDB objDB = new DIM_TIMEDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, PK_Date);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, DIM_TIME objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.PK_Date);
		}

		#endregion
	}
}
