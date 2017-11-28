using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
    [Serializable, DataContract]
    public partial class SPATIENT
    {
        #region Fields

        private string addressChangeInstitutionIEN;
        private Int32? addressChangeInstitutionSID;
        private string addressChangeStaffIEN;
        private Int32? addressChangeStaffSID;
        private decimal? age;
        private string badAddressIndicator;
        private string cDDeterminingInstitutionIEN;
        private string city;
        private string combatFromVistaDate;
        private string combatToVistaDate;
        private string confidentialAddressActiveFlag;
        private string country;
        private string countryIEN;
        private Int32? countrySID;
        private string county;
        private DateTime? created;
        private string createdBy;
        private string currentMeansTestStatusIEN;
        private DateTime? dateOfBirth;
        private string dateOfBirthText;
        private DateTime? dateOfDeath;
        private string dateOfDeathText;
        private string deceased;
        private bool? dEFAULTRECORD;
        private string eligibility;
        private string eligibilityIEN;
        private Int32? eligibilitySID;
        private string eligibilityStatus;
        private decimal? eligibilityVACode;
        private string eligibilityVerificationSource;
        private string emailAddress;
        private DateTime? enteredIntoFileDate;
        private Int64? enteredIntoFileDateTransformSID;
        private string enteredIntoFileVistaErrorDate;
        private Int32? eTLBatchID;
        private string excludeFromFacilityDirectoryFlag;
        private string gender;
        private string gISAddressType;
        private DateTime? gISAddressUpdatedDate;
        private string gISCongressDistrict;
        private string gISFIPSCode;
        private string gISLocatorName;
        private string gISMarket;
        private string gISMatchedAddress;
        private string gISMatchMethodCode;
        private Int32? gISMatchScore;
        private string gISMatchStatusCode;
        private double? gISPatientAddressLatitude;
        private double? gISPatientAddressLongitude;
        private string gISSector;
        private string gISStreetSide;
        private string gISSubmarket;
        private string gISURH;
        private string insuranceCoverageFlag;
        private DateTime? lastServiceEntryDate;
        private Int64? lastServiceEntryDateTransformSID;
        private string lastServiceEntryVistaErrorDate;
        private DateTime? lastServiceSeparationDate;
        private Int64? lastServiceSeparationDateTransformSID;
        private string lastServiceSeparationVistaErrorDate;
        private string maritalStatus;
        private string maritalStatusIEN;
        private Int32? maritalStatusSID;
        private string medicaidNumber;
        private string mothersMaidenName;
        private bool? oEFOIFIND;
        private string opCode;
        private Int32? patientID;
        private string patientFirstName;
        private string patientICN;
        private string patientICNChecksum;
        private string patientIEN;
        private string patientLastName;
        private string patientName;
        private Int32? patientSID;
        private string patientSSN;
        private Int32? percentServiceConnect;
        private string periodOfService;
        private string periodOfServiceIEN;
        private Int32? periodOfServiceSID;
        private string phoneCellular;
        private string phoneResidence;
        private string phoneWork;
        private Int32 pKID;
        private string postalCode;
        private string pOWLocationIEN;
        private string preferredInstitutionIEN;
        private string province;
        private string pseudoSSNFlag;
        private string purpleHeartInstitutionIEN;
        private string race;
        private string raceIEN;
        private Int32? raceSID;
        private string religion;
        private string religionIEN;
        private Int32? religionSID;
        private string roomBedIEN;
        private string scrSSN;
        private string sensitiveFlag;
        private Int16? sta3n;
        private string state;
        private string stateIEN;
        private Int32? stateSID;
        private Int32? sTDCOMBATLOCATIONID;
        private Int32? sTDENTHNICITYID;
        private Int32? sTDGENDERID;
        private Int32? sTDMARITALSTATUSID;
        private Int32? sTDRACEID;
        private Int32? sTDSERVICEBRANCHID;
        private Int32? stdRegistryId;
        private string streetAddress1;
        private string streetAddress2;
        private string streetAddress3;
        private string temporaryAddressChangeInstitutionIEN;
        private DateTime? updatedate;
        private string updatedBy;
        private string veteranFlag;
        private DateTime? vistaCreateDate;
        private DateTime? vistaEditDate;
        private string zip;
        private string zip4;

        #endregion

        #region Constructors

        public SPATIENT()
        {
        }

        #endregion

        #region Properties

        public string AddressChangeInstitutionIEN
        {
            get { return this.addressChangeInstitutionIEN; }
            set { this.addressChangeInstitutionIEN = value; }
        }

        public Int32? AddressChangeInstitutionSID
        {
            get { return this.addressChangeInstitutionSID; }
            set { this.addressChangeInstitutionSID = value; }
        }

        public string AddressChangeStaffIEN
        {
            get { return this.addressChangeStaffIEN; }
            set { this.addressChangeStaffIEN = value; }
        }

        public Int32? AddressChangeStaffSID
        {
            get { return this.addressChangeStaffSID; }
            set { this.addressChangeStaffSID = value; }
        }

        public decimal? Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string BadAddressIndicator
        {
            get { return this.badAddressIndicator; }
            set { this.badAddressIndicator = value; }
        }

        public string CDDeterminingInstitutionIEN
        {
            get { return this.cDDeterminingInstitutionIEN; }
            set { this.cDDeterminingInstitutionIEN = value; }
        }

        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }

        public string CombatFromVistaDate
        {
            get { return this.combatFromVistaDate; }
            set { this.combatFromVistaDate = value; }
        }

        public string CombatToVistaDate
        {
            get { return this.combatToVistaDate; }
            set { this.combatToVistaDate = value; }
        }

        public string ConfidentialAddressActiveFlag
        {
            get { return this.confidentialAddressActiveFlag; }
            set { this.confidentialAddressActiveFlag = value; }
        }

        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }

        public string CountryIEN
        {
            get { return this.countryIEN; }
            set { this.countryIEN = value; }
        }

        public Int32? CountrySID
        {
            get { return this.countrySID; }
            set { this.countrySID = value; }
        }

        public string County
        {
            get { return this.county; }
            set { this.county = value; }
        }

        public DateTime? Created
        {
            get { return this.created; }
            set { this.created = value; }
        }

        public string CreatedBy
        {
            get { return this.createdBy; }
            set { this.createdBy = value; }
        }

        public string CurrentMeansTestStatusIEN
        {
            get { return this.currentMeansTestStatusIEN; }
            set { this.currentMeansTestStatusIEN = value; }
        }

        public DateTime? DateOfBirth
        {
            get { return this.dateOfBirth; }
            set { this.dateOfBirth = value; }
        }

        public string DateOfBirthText
        {
            get { return this.dateOfBirthText; }
            set { this.dateOfBirthText = value; }
        }

        public DateTime? DateOfDeath
        {
            get { return this.dateOfDeath; }
            set { this.dateOfDeath = value; }
        }

        public string DateOfDeathText
        {
            get { return this.dateOfDeathText; }
            set { this.dateOfDeathText = value; }
        }

        public string Deceased
        {
            get { return this.deceased; }
            set { this.deceased = value; }
        }

        public bool? DEFAULT_RECORD
        {
            get { return this.dEFAULTRECORD; }
            set { this.dEFAULTRECORD = value; }
        }

        public string Eligibility
        {
            get { return this.eligibility; }
            set { this.eligibility = value; }
        }

        public string EligibilityIEN
        {
            get { return this.eligibilityIEN; }
            set { this.eligibilityIEN = value; }
        }

        public Int32? EligibilitySID
        {
            get { return this.eligibilitySID; }
            set { this.eligibilitySID = value; }
        }

        public string EligibilityStatus
        {
            get { return this.eligibilityStatus; }
            set { this.eligibilityStatus = value; }
        }

        public decimal? EligibilityVACode
        {
            get { return this.eligibilityVACode; }
            set { this.eligibilityVACode = value; }
        }

        public string EligibilityVerificationSource
        {
            get { return this.eligibilityVerificationSource; }
            set { this.eligibilityVerificationSource = value; }
        }

        public string EmailAddress
        {
            get { return this.emailAddress; }
            set { this.emailAddress = value; }
        }

        public DateTime? EnteredIntoFileDate
        {
            get { return this.enteredIntoFileDate; }
            set { this.enteredIntoFileDate = value; }
        }

        public Int64? EnteredIntoFileDateTransformSID
        {
            get { return this.enteredIntoFileDateTransformSID; }
            set { this.enteredIntoFileDateTransformSID = value; }
        }

        public string EnteredIntoFileVistaErrorDate
        {
            get { return this.enteredIntoFileVistaErrorDate; }
            set { this.enteredIntoFileVistaErrorDate = value; }
        }

        public Int32? ETLBatchID
        {
            get { return this.eTLBatchID; }
            set { this.eTLBatchID = value; }
        }

        public string ExcludeFromFacilityDirectoryFlag
        {
            get { return this.excludeFromFacilityDirectoryFlag; }
            set { this.excludeFromFacilityDirectoryFlag = value; }
        }

        public string Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }

        public string GISAddressType
        {
            get { return this.gISAddressType; }
            set { this.gISAddressType = value; }
        }

        public DateTime? GISAddressUpdatedDate
        {
            get { return this.gISAddressUpdatedDate; }
            set { this.gISAddressUpdatedDate = value; }
        }

        public string GISCongressDistrict
        {
            get { return this.gISCongressDistrict; }
            set { this.gISCongressDistrict = value; }
        }

        public string GISFIPSCode
        {
            get { return this.gISFIPSCode; }
            set { this.gISFIPSCode = value; }
        }

        public string GISLocatorName
        {
            get { return this.gISLocatorName; }
            set { this.gISLocatorName = value; }
        }

        public string GISMarket
        {
            get { return this.gISMarket; }
            set { this.gISMarket = value; }
        }

        public string GISMatchedAddress
        {
            get { return this.gISMatchedAddress; }
            set { this.gISMatchedAddress = value; }
        }

        public string GISMatchMethodCode
        {
            get { return this.gISMatchMethodCode; }
            set { this.gISMatchMethodCode = value; }
        }

        public Int32? GISMatchScore
        {
            get { return this.gISMatchScore; }
            set { this.gISMatchScore = value; }
        }

        public string GISMatchStatusCode
        {
            get { return this.gISMatchStatusCode; }
            set { this.gISMatchStatusCode = value; }
        }

        public double? GISPatientAddressLatitude
        {
            get { return this.gISPatientAddressLatitude; }
            set { this.gISPatientAddressLatitude = value; }
        }

        public double? GISPatientAddressLongitude
        {
            get { return this.gISPatientAddressLongitude; }
            set { this.gISPatientAddressLongitude = value; }
        }

        public string GISSector
        {
            get { return this.gISSector; }
            set { this.gISSector = value; }
        }

        public string GISStreetSide
        {
            get { return this.gISStreetSide; }
            set { this.gISStreetSide = value; }
        }

        public string GISSubmarket
        {
            get { return this.gISSubmarket; }
            set { this.gISSubmarket = value; }
        }

        public string GISURH
        {
            get { return this.gISURH; }
            set { this.gISURH = value; }
        }

        public string InsuranceCoverageFlag
        {
            get { return this.insuranceCoverageFlag; }
            set { this.insuranceCoverageFlag = value; }
        }

        public DateTime? LastServiceEntryDate
        {
            get { return this.lastServiceEntryDate; }
            set { this.lastServiceEntryDate = value; }
        }

        public Int64? LastServiceEntryDateTransformSID
        {
            get { return this.lastServiceEntryDateTransformSID; }
            set { this.lastServiceEntryDateTransformSID = value; }
        }

        public string LastServiceEntryVistaErrorDate
        {
            get { return this.lastServiceEntryVistaErrorDate; }
            set { this.lastServiceEntryVistaErrorDate = value; }
        }

        public DateTime? LastServiceSeparationDate
        {
            get { return this.lastServiceSeparationDate; }
            set { this.lastServiceSeparationDate = value; }
        }

        public Int64? LastServiceSeparationDateTransformSID
        {
            get { return this.lastServiceSeparationDateTransformSID; }
            set { this.lastServiceSeparationDateTransformSID = value; }
        }

        public string LastServiceSeparationVistaErrorDate
        {
            get { return this.lastServiceSeparationVistaErrorDate; }
            set { this.lastServiceSeparationVistaErrorDate = value; }
        }

        public string MaritalStatus
        {
            get { return this.maritalStatus; }
            set { this.maritalStatus = value; }
        }

        public string MaritalStatusIEN
        {
            get { return this.maritalStatusIEN; }
            set { this.maritalStatusIEN = value; }
        }

        public Int32? MaritalStatusSID
        {
            get { return this.maritalStatusSID; }
            set { this.maritalStatusSID = value; }
        }

        public string MedicaidNumber
        {
            get { return this.medicaidNumber; }
            set { this.medicaidNumber = value; }
        }

        public string MothersMaidenName
        {
            get { return this.mothersMaidenName; }
            set { this.mothersMaidenName = value; }
        }

        public bool? OEF_OIF_IND
        {
            get { return this.oEFOIFIND; }
            set { this.oEFOIFIND = value; }
        }

        public string OpCode
        {
            get { return this.opCode; }
            set { this.opCode = value; }
        }

        public Int32? Patient_ID
        {
            get { return this.patientID; }
            set { this.patientID = value; }
        }

        public string PatientFirstName
        {
            get { return this.patientFirstName; }
            set { this.patientFirstName = value; }
        }

        public string PatientICN
        {
            get { return this.patientICN; }
            set { this.patientICN = value; }
        }

        public string PatientICNChecksum
        {
            get { return this.patientICNChecksum; }
            set { this.patientICNChecksum = value; }
        }

        public string PatientIEN
        {
            get { return this.patientIEN; }
            set { this.patientIEN = value; }
        }

        public string PatientLastName
        {
            get { return this.patientLastName; }
            set { this.patientLastName = value; }
        }

        public string PatientName
        {
            get { return this.patientName; }
            set { this.patientName = value; }
        }

        public Int32? PatientSID
        {
            get { return this.patientSID; }
            set { this.patientSID = value; }
        }

        public string PatientSSN
        {
            get { return this.patientSSN; }
            set { this.patientSSN = value; }
        }

        public Int32? PercentServiceConnect
        {
            get { return this.percentServiceConnect; }
            set { this.percentServiceConnect = value; }
        }

        public string PeriodOfService
        {
            get { return this.periodOfService; }
            set { this.periodOfService = value; }
        }

        public string PeriodOfServiceIEN
        {
            get { return this.periodOfServiceIEN; }
            set { this.periodOfServiceIEN = value; }
        }

        public Int32? PeriodOfServiceSID
        {
            get { return this.periodOfServiceSID; }
            set { this.periodOfServiceSID = value; }
        }

        public string PhoneCellular
        {
            get { return this.phoneCellular; }
            set { this.phoneCellular = value; }
        }

        public string PhoneResidence
        {
            get { return this.phoneResidence; }
            set { this.phoneResidence = value; }
        }

        public string PhoneWork
        {
            get { return this.phoneWork; }
            set { this.phoneWork = value; }
        }

        public Int32 PK_ID
        {
            get { return this.pKID; }
            set { this.pKID = value; }
        }

        public string PostalCode
        {
            get { return this.postalCode; }
            set { this.postalCode = value; }
        }

        public string POWLocationIEN
        {
            get { return this.pOWLocationIEN; }
            set { this.pOWLocationIEN = value; }
        }

        public string PreferredInstitutionIEN
        {
            get { return this.preferredInstitutionIEN; }
            set { this.preferredInstitutionIEN = value; }
        }

        public string Province
        {
            get { return this.province; }
            set { this.province = value; }
        }

        public string PseudoSSNFlag
        {
            get { return this.pseudoSSNFlag; }
            set { this.pseudoSSNFlag = value; }
        }

        public string PurpleHeartInstitutionIEN
        {
            get { return this.purpleHeartInstitutionIEN; }
            set { this.purpleHeartInstitutionIEN = value; }
        }

        public string Race
        {
            get { return this.race; }
            set { this.race = value; }
        }

        public string RaceIEN
        {
            get { return this.raceIEN; }
            set { this.raceIEN = value; }
        }

        public Int32? RaceSID
        {
            get { return this.raceSID; }
            set { this.raceSID = value; }
        }

        public string Religion
        {
            get { return this.religion; }
            set { this.religion = value; }
        }

        public string ReligionIEN
        {
            get { return this.religionIEN; }
            set { this.religionIEN = value; }
        }

        public Int32? ReligionSID
        {
            get { return this.religionSID; }
            set { this.religionSID = value; }
        }

        public string RoomBedIEN
        {
            get { return this.roomBedIEN; }
            set { this.roomBedIEN = value; }
        }

        public string ScrSSN
        {
            get { return this.scrSSN; }
            set { this.scrSSN = value; }
        }

        public string SensitiveFlag
        {
            get { return this.sensitiveFlag; }
            set { this.sensitiveFlag = value; }
        }

        public Int16? Sta3n
        {
            get { return this.sta3n; }
            set { this.sta3n = value; }
        }

        public string State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public string StateIEN
        {
            get { return this.stateIEN; }
            set { this.stateIEN = value; }
        }

        public Int32? StateSID
        {
            get { return this.stateSID; }
            set { this.stateSID = value; }
        }

        public Int32? STD_COMBATLOCATION_ID
        {
            get { return this.sTDCOMBATLOCATIONID; }
            set { this.sTDCOMBATLOCATIONID = value; }
        }

        public Int32? STD_ENTHNICITY_ID
        {
            get { return this.sTDENTHNICITYID; }
            set { this.sTDENTHNICITYID = value; }
        }

        public Int32? STD_GENDER_ID
        {
            get { return this.sTDGENDERID; }
            set { this.sTDGENDERID = value; }
        }

        public Int32? STD_MARITALSTATUS_ID
        {
            get { return this.sTDMARITALSTATUSID; }
            set { this.sTDMARITALSTATUSID = value; }
        }

        public Int32? STD_RACE_ID
        {
            get { return this.sTDRACEID; }
            set { this.sTDRACEID = value; }
        }

        public Int32? STD_SERVICEBRANCH_ID
        {
            get { return this.sTDSERVICEBRANCHID; }
            set { this.sTDSERVICEBRANCHID = value; }
        }

        public Int32? StdRegistryId
        {
            get { return this.stdRegistryId; }
            set { this.stdRegistryId = value; }
        }

        public string StreetAddress1
        {
            get { return this.streetAddress1; }
            set { this.streetAddress1 = value; }
        }

        public string StreetAddress2
        {
            get { return this.streetAddress2; }
            set { this.streetAddress2 = value; }
        }

        public string StreetAddress3
        {
            get { return this.streetAddress3; }
            set { this.streetAddress3 = value; }
        }

        public string TemporaryAddressChangeInstitutionIEN
        {
            get { return this.temporaryAddressChangeInstitutionIEN; }
            set { this.temporaryAddressChangeInstitutionIEN = value; }
        }

        public DateTime? Updatedate
        {
            get { return this.updatedate; }
            set { this.updatedate = value; }
        }

        public string UpdatedBy
        {
            get { return this.updatedBy; }
            set { this.updatedBy = value; }
        }

        public string VeteranFlag
        {
            get { return this.veteranFlag; }
            set { this.veteranFlag = value; }
        }

        public DateTime? VistaCreateDate
        {
            get { return this.vistaCreateDate; }
            set { this.vistaCreateDate = value; }
        }

        public DateTime? VistaEditDate
        {
            get { return this.vistaEditDate; }
            set { this.vistaEditDate = value; }
        }

        public string Zip
        {
            get { return this.zip; }
            set { this.zip = value; }
        }

        public string Zip4
        {
            get { return this.zip4; }
            set { this.zip4 = value; }
        }

        #endregion

        #region Methods
        #endregion
    }
}
