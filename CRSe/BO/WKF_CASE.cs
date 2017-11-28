using System;
using System.Collections.Generic;
using System.Text;

namespace CRSe.CRS.BO
{
	public partial class WKF_CASE
	{
		#region Fields

        private PATIENT pATIENT;
        private STD_WKFCASETYPE sTDWKFCASETYPE;
        private STD_WKFCASESTS sTDWKFCASESTS;
        private REFERRAL rEFERRAL;

		#endregion

		#region Constructors
		#endregion

		#region Properties

        public PATIENT PATIENT
        {
            get { return this.pATIENT; }
            set { this.pATIENT = value; }
        }

        public STD_WKFCASETYPE STD_WKFCASETYPE
        {
            get { return this.sTDWKFCASETYPE; }
            set { this.sTDWKFCASETYPE = value; }
        }

        public STD_WKFCASESTS STD_WKFCASESTS
        {
            get { return this.sTDWKFCASESTS; }
            set { this.sTDWKFCASESTS = value; }
        }

        public REFERRAL REFERRAL
        {
            get { return this.rEFERRAL; }
            set { this.rEFERRAL = value; }
        }
		#endregion

		#region Methods
		#endregion
	}
}
