using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRSe.CRS.BO
{
    public partial class RegistryWizard
    {
        private Int32 stdRegistryId;
        private string combatLocIds;
        private string cPTCodes;
        private string ethnicityIds;
        private string genderIds;
        private string healthFactorType;
        private string iCD10;
        private string iCD9;
        private string maritalStatusIds;
        private Boolean? oEFOIFLocation;
        private string raceIds;
        private string serviceIds;
        private DateTime? dOBMin;
        private DateTime? dOBMax;
        private string username;
        private bool count;

        public RegistryWizard() 
        {
        }

        public Int32 StdRegistryId
        {
            get { return this.stdRegistryId; }
            set { this.stdRegistryId = value; }
        }

        public string CombatLocIds
        {
            get { return this.combatLocIds; }
            set { this.combatLocIds = value; }
        }

        public string CPTCodes
        {
            get { return this.cPTCodes; }
            set { this.cPTCodes = value; }
        }

        public string EthnicityIds
        {
            get { return this.ethnicityIds; }
            set { this.ethnicityIds = value; }
        }

        public string GenderIds
        {
            get { return this.genderIds; }
            set { this.genderIds = value; }
        }

        public string HealthFactorType
        {
            get { return this.healthFactorType; }
            set { this.healthFactorType = value; }
        }

        public string ICD10
        {
            get { return this.iCD10; }
            set { this.iCD10 = value; }
        }

        public string ICD9
        {
            get { return this.iCD9; }
            set { this.iCD9 = value; }
        }

        public string MaritalStatusIds
        {
            get { return this.maritalStatusIds; }
            set { this.maritalStatusIds = value; }
        }

        public Boolean? OEFOIFLocation
        {
            get { return this.oEFOIFLocation; }
            set { this.oEFOIFLocation = value; }
        }

        public string RaceIds
        {
            get { return this.raceIds; }
            set { this.raceIds = value; }
        }

        public string ServiceIds
        {
            get { return this.serviceIds; }
            set { this.serviceIds = value; }
        }

        public DateTime? DOBMin
        {
            get { return this.dOBMin; }
            set { this.dOBMin = value; }
        }

        public DateTime? DOBMax
        {
            get { return this.dOBMax; }
            set { this.dOBMax = value; }
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public bool Count
        {
            get { return this.count; }
            set { this.count = value; }
        }
    }
}
