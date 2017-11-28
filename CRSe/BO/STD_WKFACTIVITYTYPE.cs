using System;
using System.Collections.Generic;
using System.Text;

namespace CRSe.CRS.BO
{
	public partial class STD_WKFACTIVITYTYPE
	{
		#region Fields

        private string wORKSTREAM;
        private STD_WKFCASETYPE sTDWKFCASETYPE;

		#endregion

		#region Constructors
		#endregion

		#region Properties

        public string WORKSTREAM
        {
            get { return this.wORKSTREAM; }
            set { this.wORKSTREAM = value; }
        }

        public STD_WKFCASETYPE STD_WKFCASETYPE
        {
            get { return this.sTDWKFCASETYPE; }
            set { this.sTDWKFCASETYPE = value; }
        }

		#endregion

		#region Methods
		#endregion
	}
}
