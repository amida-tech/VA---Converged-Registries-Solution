using System;
using System.Collections.Generic;
using System.Text;

namespace CRSe_WEB.BaseCode
{
    [Serializable]
    public class SearchResult
    {
        #region Fields
        
        private DateTime? bIRTHDATE;
        private string cITY;
        private string fIRSTNAME;
        private string lASTFOUR;
        private string lASTNAME;
        private string gENDER;
        private string pOSTALCODE;
        private Int32 rESULTID;
        private string sTATE;

        #endregion

        #region Constructors

        public SearchResult()
        {
        }

        #endregion

        #region Properties

        public DateTime? BirthDate
        {
            get { return this.bIRTHDATE; }
            set { this.bIRTHDATE = value; }
        }

        public string City
        {
            get { return this.cITY; }
            set { this.cITY = value; }
        }

        public string FirstName
        {
            get { return this.fIRSTNAME; }
            set { this.fIRSTNAME = value; }
        }

        public string LastFour
        {
            get { return this.lASTFOUR; }
            set { this.lASTFOUR = value; }
        }

        public string LastName
        {
            get { return this.lASTNAME; }
            set { this.lASTNAME = value; }
        }

        public string Gender
        {
            get { return this.gENDER; }
            set { this.gENDER = value; }
        }

        public string PostalCode
        {
            get { return this.pOSTALCODE; }
            set { this.pOSTALCODE = value; }
        }

        public Int32 ResultId
        {
            get { return this.rESULTID; }
            set { this.rESULTID = value; }
        }

        public string State
        {
            get { return this.sTATE; }
            set { this.sTATE = value; }
        }

        #endregion

        #region Methods
        #endregion
    }
}