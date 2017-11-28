using System;
using System.Collections.Generic;
using System.Text;

namespace CRSe.CRS.BO
{
	public partial class WKF_CASE_ACTIVITY
	{
		#region Fields

        private WKF_CASE wKFCASE;
        private STD_WKFACTIVITYTYPE sTDWKFACTIVITYTYPE;
        private STD_WKFACTIVITYSTS sTDWKFACTIVITYSTS;

		#endregion

		#region Constructors
		#endregion

		#region Properties

        public WKF_CASE WKF_CASE
        {
            get { return this.wKFCASE; }
            set { this.wKFCASE = value;  }
        }

        public STD_WKFACTIVITYTYPE STD_WKFACTIVITYTYPE
        {
            get { return this.sTDWKFACTIVITYTYPE; }
            set { this.sTDWKFACTIVITYTYPE = value; }
        }

        public STD_WKFACTIVITYSTS STD_WKFACTIVITYSTS
        {
            get { return this.sTDWKFACTIVITYSTS; }
            set { this.sTDWKFACTIVITYSTS = value; }
        }

		#endregion

		#region Methods
		#endregion
	}
}
