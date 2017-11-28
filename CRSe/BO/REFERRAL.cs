using System;
using System.Collections.Generic;
using System.Text;

namespace CRSe.CRS.BO
{
	public partial class REFERRAL
	{
		#region Fields

        private STD_REFERRALSTS sTDREFERRALSTS;
        private STD_REGISTRY sTDREGISTRY;
        private PATIENT pATIENT;
        private SPATIENT sPATIENT;
        private SStaff_SStaff sStaffSStaff;

		#endregion

		#region Constructors
		#endregion

		#region Properties
		#endregion

		#region Methods

        public STD_REFERRALSTS STD_REFERRALSTS
        {
            get { return this.sTDREFERRALSTS; }
            set { this.sTDREFERRALSTS = value; }
        }

        public STD_REGISTRY STD_REGISTRY
        {
            get { return this.sTDREGISTRY; }
            set { this.sTDREGISTRY = value; }
        }
        public PATIENT PATIENT
        {
            get { return this.pATIENT; }
            set { this.pATIENT = value; }
        }
        public SPATIENT SPATIENT
        {
            get { return this.sPATIENT; }
            set { this.sPATIENT = value; }
        }
        public SStaff_SStaff SStaff_SStaff
        {
            get { return this.sStaffSStaff; }
            set { this.sStaffSStaff = value; }
        }

		#endregion
	}
}
