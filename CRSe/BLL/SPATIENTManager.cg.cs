using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRSe.CRS.BO;
using CRSe.CRS.DAL;

namespace CRSe.CRS.BLL
{
	public static partial class SPATIENTManager
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Methods

        public static SPATIENT GetItem(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PK_ID)
		{
			SPATIENT objReturn = null;
			SPATIENTDB objDB = new SPATIENTDB();

            objReturn = objDB.GetItem(CURRENT_USER, CURRENT_REGISTRY_ID, PK_ID);

			return objReturn;
		}

		public static List<SPATIENT> GetItems(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID)
		{
			List<SPATIENT> objReturn = null;
			SPATIENTDB objDB = new SPATIENTDB();

			objReturn = objDB.GetItems(CURRENT_USER, CURRENT_REGISTRY_ID);

			return objReturn;
		}

		public static Int32 Save(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SPATIENT objSave)
		{
			Int32 objReturn = 0;
			SPATIENTDB objDB = new SPATIENTDB();

			objReturn = objDB.Save(CURRENT_USER, CURRENT_REGISTRY_ID, objSave);

			return objReturn;
		}

        public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, Int32 PK_ID)
		{
			Boolean objReturn = false;
			SPATIENTDB objDB = new SPATIENTDB();

            objReturn = objDB.Delete(CURRENT_USER, CURRENT_REGISTRY_ID, PK_ID);

			return objReturn;
		}

		public static Boolean Delete(string CURRENT_USER, Int32 CURRENT_REGISTRY_ID, SPATIENT objDelete)
		{
            return Delete(CURRENT_USER, CURRENT_REGISTRY_ID, objDelete.PK_ID);
		}

		#endregion
	}
}
