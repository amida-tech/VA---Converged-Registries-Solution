using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class ETL_ExtractBatch_LogManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

		public static ETL_ExtractBatch_Log GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			ETL_ExtractBatch_Log objReturn = null;
			ETL_ExtractBatch_LogDB objDB = new ETL_ExtractBatch_LogDB();

			objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static List<ETL_ExtractBatch_Log> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<ETL_ExtractBatch_Log> objReturn = null;
			ETL_ExtractBatch_LogDB objDB = new ETL_ExtractBatch_LogDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, ETL_ExtractBatch_Log objSave)
		{
			Int32 objReturn = 0;
			ETL_ExtractBatch_LogDB objDB = new ETL_ExtractBatch_LogDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 ID)
		{
			Boolean objReturn = false;
			ETL_ExtractBatch_LogDB objDB = new ETL_ExtractBatch_LogDB();

			objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, ETL_ExtractBatch_Log objDelete)
		{
			return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.ID);
		}

		#endregion
	}
}
