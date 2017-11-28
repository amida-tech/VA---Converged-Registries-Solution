using System;
using System.Collections.Generic;
using System.Text;

namespace CRSe.CRS.BO
{
    public partial class STD_REGISTRY
    {
        #region Fields

        private USERS registryOwnerUser;
        private USERS registryAdministratorUser;
        private USERS supportContactUser;

        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        public USERS REGISTRY_OWNER_USER
        {
            get { return this.registryOwnerUser; }
            set { this.registryOwnerUser = value; }
        }

        public USERS REGISTRY_ADMINISTRATOR_USER
        {
            get { return this.registryAdministratorUser; }
            set { this.registryAdministratorUser = value; }
        }

        public USERS SUPPORT_CONTACT_USER
        {
            get { return this.supportContactUser; }
            set { this.supportContactUser = value; }
        }

        #endregion
    }
}
