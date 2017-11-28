using System;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using CRSe.CRS.BLL;
using System.Configuration;

namespace CRSe.CRS.DAL
{
	public partial class DBUtils
	{
		public string SqlConnectionString
		{
            get { return ConfigurationManager.ConnectionStrings["RegistryConnectionString"].ConnectionString; }
		}

		public int SqlCommandTimeout
		{
			get
			{
				int iTimeout = 30; //Default
				if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SqlCommandTimeout"]))
				{
					int.TryParse(ConfigurationManager.AppSettings["SqlCommandTimeout"], out iTimeout);
				}
				return iTimeout;
			}
		}

		public void AddToArray<t>(ref t[] arrObject, t obj)
		{
			if (arrObject == null)
			{
				arrObject = (t[])Array.CreateInstance(typeof(t), 1);
			}
			else
			{
				Array.Resize(ref arrObject, arrObject.Length + 1);
			}

			arrObject.SetValue(obj, arrObject.GetUpperBound(0));
		}

		public object GetNullableObject(object obj)
		{
			object objReturn = null;

			try
			{
				if (!(obj is DBNull))
				{
					objReturn = obj;
				}
			}
			catch (Exception ex)
            {
                LogManager.LogError(ex.Message, String.Format("{0}.{1}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name), string.Empty, 0);
            }

			return objReturn;
		}

		public void AddParameter(ref SqlCommand sCmd, ref SqlParameter p, object obj)
		{
			if (obj == null)
			{
				p.Value = DBNull.Value;
				sCmd.Parameters.Add(p);
				return;
			}
			else
			{
				Boolean blnCheck = false;

				if (obj is string)
				{
					if (string.IsNullOrEmpty((string)obj))
					{
						p.Value = DBNull.Value;
						blnCheck = true;
					}
				}
                else if (obj is DateTime)
                {
                    DateTime dtCheck = (DateTime)obj;
                    if (dtCheck == DateTime.MinValue)
                    {
                        p.Value = DBNull.Value;
                        blnCheck = true;
                    }
                }

				if (!blnCheck)
				{
					p.Value = obj;
				}
			}

			sCmd.Parameters.Add(p);
			return;
		}
	}
}
