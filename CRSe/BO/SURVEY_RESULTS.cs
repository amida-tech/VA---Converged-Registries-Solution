using System;
using System.Collections.Generic;
using System.Text;

namespace CRSe.CRS.BO
{
	public partial class SURVEY_RESULTS
	{
		#region Fields

        private STD_QUESTION sTDQUESTION;
        private STD_QUESTION_CHOICE sTDQUESTIONCHOICE;

		#endregion

		#region Constructors
		#endregion

		#region Properties

        public STD_QUESTION STD_QUESTION
        {
            get { return this.sTDQUESTION; }
            set { this.sTDQUESTION = value; }
        }

        public STD_QUESTION_CHOICE STD_QUESTION_CHOICE
        {
            get { return this.sTDQUESTIONCHOICE; }
            set { this.sTDQUESTIONCHOICE = value; }
        }

		#endregion

		#region Methods
		#endregion
	}
}
