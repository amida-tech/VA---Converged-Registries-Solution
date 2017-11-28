using System;
using System.Collections.Generic;
using System.Text;

namespace CRSe.CRS.BO
{
	public partial class USERS
	{
		#region Fields

        private List<USER_ROLES> uSERROLES;

		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public List<USER_ROLES> USER_ROLES
        {
            get { return this.uSERROLES; }
            set { this.uSERROLES = value; }
        }

		#endregion
	}
}
