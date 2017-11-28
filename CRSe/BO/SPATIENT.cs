using System;
using System.Collections.Generic;
using System.Text;

namespace CRSe.CRS.BO
{
	public partial class SPATIENT
	{
		#region Fields

        private string patientLastFour;

		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public string PatientLastFour
        {
            get { return this.patientLastFour; }
            set { this.patientLastFour = value; }
        }

		#endregion
	}
}
