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
	public partial class STD_WEB_PAGESDB : DBUtils
	{
		#region Fields
		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public STD_WEB_PAGES ParseReaderAlt(DataRow row)
        {
            STD_WEB_PAGES objReturn = new STD_WEB_PAGES
            {
                CORE_PAGE = (bool)GetNullableObject(row.Field<object>("MENU_PAGE_CORE_PAGE")),
                CREATED = (DateTime)GetNullableObject(row.Field<object>("MENU_PAGE_CREATED")),
                CREATEDBY = (string)GetNullableObject(row.Field<object>("MENU_PAGE_CREATEDBY")),
                DISPLAY_TEXT = (string)GetNullableObject(row.Field<object>("MENU_PAGE_DISPLAY_TEXT")),
                INACTIVE_DATE = (DateTime?)GetNullableObject(row.Field<object>("MENU_PAGE_INACTIVE_DATE")),
                INACTIVE_FLAG = (bool)GetNullableObject(row.Field<object>("MENU_PAGE_INACTIVE_FLAG")),
                NAME = (string)GetNullableObject(row.Field<object>("MENU_PAGE_NAME")),
                PAGE_ID = (Int32)GetNullableObject(row.Field<object>("MENU_PAGE_PAGE_ID")),
                UPDATED = (DateTime)GetNullableObject(row.Field<object>("MENU_PAGE_UPDATED")),
                UPDATEDBY = (string)GetNullableObject(row.Field<object>("MENU_PAGE_UPDATEDBY")),
                URL = (string)GetNullableObject(row.Field<object>("MENU_PAGE_URL"))
            };

            return objReturn;
        }

		#endregion
	}
}
