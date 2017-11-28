using System;
using System.Collections.Generic;
using System.Text;

namespace CRSe.CRS.BO
{
	public partial class SURVEYS
	{
		#region Fields

        private PATIENT pATIENT;
        private STD_SURVEY_TYPE sTDSURVEYTYPE;
        private SStaff_SStaff sStaffSStaff;
        private List<SURVEY_RESULTS> sURVEYRESULTS;

		#endregion

		#region Constructors
		#endregion

		#region Properties

        public PATIENT PATIENT
        {
            get { return this.pATIENT; }
            set { this.pATIENT = value; }
        }

        public STD_SURVEY_TYPE STD_SURVEY_TYPE
        {
            get { return this.sTDSURVEYTYPE; }
            set { this.sTDSURVEYTYPE = value; }
        }

        public SStaff_SStaff SStaff_SStaff
        {
            get { return this.sStaffSStaff; }
            set { this.sStaffSStaff = value; }
        }

        public List<SURVEY_RESULTS> SURVEY_RESULTS
        {
            get { return this.sURVEYRESULTS; }
            set { this.sURVEYRESULTS = value; }
        }

		#endregion

		#region Methods
		#endregion
	}
}
