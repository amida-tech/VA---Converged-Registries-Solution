using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	public partial class STD_INSTITUTION
	{
		#region Fields

        private Int32 fACID;
        private string fACTEXT;
        private string sTA3N;
        private Int32 vISNSID;
        private string vISNTEXT;

        private STD_FACILITYTYPE sTDFACILITYTYPE;
        private STD_STATE sTREETSTATE;
        private STD_INSTITUTION vISN;

		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public Int32 FACID
        {
            get { return this.fACID; }
            set { this.fACID = value; }
        }

        public string FACTEXT
        {
            get { return this.fACTEXT; }
            set { this.fACTEXT = value; }
        }

        public string STA3N
        {
            get { return this.sTA3N; }
            set { this.sTA3N = value; }
        }

        public Int32 VISNSID
        {
            get { return this.vISNSID; }
            set { this.vISNSID = value; }
        }

        public string VISNTEXT
        {
            get { return this.vISNTEXT; }
            set { this.vISNTEXT = value; }
        }

        public STD_FACILITYTYPE STD_FACILITYTYPE
        {
            get { return this.sTDFACILITYTYPE; }
            set { this.sTDFACILITYTYPE = value; }
        }

        public STD_STATE STREETSTATE
        {
            get { return this.sTREETSTATE; }
            set { this.sTREETSTATE = value; }
        }

        public STD_INSTITUTION VISN
        {
            get { return this.vISN; }
            set { this.vISN = value; }
        }

		#endregion
	}
}
