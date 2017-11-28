using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
    [Serializable, DataContract]
    public partial class REFERRALcommon
    {
        #region Fields

        private Int32 pATIENTID;
        private Int32? pROVIDERID;
        private string rEGISTRYNAME;
        private DateTime? rEFERRALDATE;
        private Int32 rEFERRALID;
        private string sTDREFERRALSTSCODE;
        private string pATIENTLastFour;
        private string pATIENTLASTNAME;
        private string pATIENTFIRSTNAME;
        private DateTime? pATIENTBIRTHDATE;
        private string pATIENTGender;
        private string pATIENTCity;
        private string pATIENTState;
        private string pATIENTPostalCode;

        #endregion

        #region Constructors

        public REFERRALcommon()
        {
        }

        #endregion

        #region Properties

        public Int32 PATIENT_ID
        {
            get { return this.pATIENTID; }
            set { this.pATIENTID = value; }
        }

        public Int32? PROVIDER_ID
        {
            get { return this.pROVIDERID; }
            set { this.pROVIDERID = value; }
        }

        public string REGISTRY_NAME
        {
            get { return this.rEGISTRYNAME; }
            set { this.rEGISTRYNAME = value; }
        }

        public DateTime? REFERRAL_DATE
        {
            get { return this.rEFERRALDATE; }
            set { this.rEFERRALDATE = value; }
        }

        public Int32 REFERRAL_ID
        {
            get { return this.rEFERRALID; }
            set { this.rEFERRALID = value; }
        }

        public string STD_REFERRALSTS_CODE
        {
            get { return this.sTDREFERRALSTSCODE; }
            set { this.sTDREFERRALSTSCODE = value; }
        }

        public string PATIENT_LastFour
        {
            get { return this.pATIENTLastFour; }
            set { this.pATIENTLastFour = value; }
        }

        public string PATIENT_LAST_NAME
        {
            get { return this.pATIENTLASTNAME; }
            set { this.pATIENTLASTNAME = value; }
        }

        public string PATIENT_FIRST_NAME
        {
            get { return this.pATIENTFIRSTNAME; }
            set { this.pATIENTFIRSTNAME = value; }
        }

        public DateTime? PATIENT_BIRTH_DATE
        {
            get { return this.pATIENTBIRTHDATE; }
            set { this.pATIENTBIRTHDATE = value; }
        }

        public string PATIENT_Gender
        {
            get { return this.pATIENTGender; }
            set { this.pATIENTGender = value; }
        }

        public string PATIENT_City
        {
            get { return this.pATIENTCity; }
            set { this.pATIENTCity = value; }
        }

        public string PATIENT_State
        {
            get { return this.pATIENTState; }
            set { this.pATIENTState = value; }
        }

        public string PATIENT_PostalCode
        {
            get { return this.pATIENTPostalCode; }
            set { this.pATIENTPostalCode = value; }
        }

        #endregion

        #region Methods
        #endregion
    }
}
