using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	public partial class REGISTRY_CORE_DATA
	{
        #region Fields

        private STD_REGISTRY_CORE_TYPES stdRegistryCoreTypes;

        #endregion

        #region Constructors
        #endregion

        #region Properties

        public STD_REGISTRY_CORE_TYPES STD_REGISTRY_CORE_TYPES
        {
            get { return this.stdRegistryCoreTypes; }
            set { this.stdRegistryCoreTypes = value; }
        }

        #endregion

        #region Methods
        #endregion
	}
}
