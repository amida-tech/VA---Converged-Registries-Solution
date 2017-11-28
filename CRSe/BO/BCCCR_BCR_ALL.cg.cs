using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRSe.CRS.BO
{
	[Serializable, DataContract]
	public partial class BCCCR_BCR_ALL
	{
		#region Fields

		private decimal? age;
		private Int32? bIRADScore;
		private string city;
		private string combatFlag;
		private DateTime? dateNextMammogramDue;
		private DateTime? dateOfBirth;
		private DateTime? dateOFMostRecentMammogram;
		private DateTime? dateOfMostRecentMammogramExclusionHealthFactor;
		private DateTime? dateOfMostRecentMammogramResult;
		private DateTime? dateOfMostRecentMammogramScreenFreq;
		private DateTime? dateOfMostRecentNexusClinicEncounter;
		private DateTime? dateOfMostRecentNexusClinicFormerEncounter;
		private DateTime? dateOfMostRecentPrimaryCareEncounter;
		private DateTime? dateOfMostRecentWomensHealthEncounter;
		private DateTime? dateOfMostRRecentNexusClinicPriorEncounter;
		private DateTime? dateOfNextAppointment;
		private string dateProcessed;
		private string deceased;
		private string ethnicity;
		private string gender;
		private bool? hadBilateralMastectomy;
		private bool? hadHysterectomy;
		private bool? hasATerminalHealthFactor;
		private bool? hasMammogramExclusionHealthFactor;
		private Int64? homeSta3N;
		private Int32 iD;
		private Int16? iSOEFOIF;
		private string locationNameOfNextAppointment;
		private string mammogramComplianceText;
		private string mammogramMostRecentScreenFreq;
		private string mammogramMostrecentScreenFreqHF;
		private string mammogramScreeningComplianceText;
		private Int32? monthSID;
		private decimal? mostRecentMammogramDiagnosticCode;
		private string mostRecentMammogramProcedure;
		private string mostRecentMammogramSource;
		private Int32? numberOfCancerDiagnosis;
		private Int32? numberOfNexusClinicEncounters;
		private Int32? numberOfNexusClinicFormerEncounters;
		private Int32? numberOfNexusClinicPriorEncounters;
		private Int32? numberOfPrimaryCareEncounters;
		private Int32? numberOfTerminalCADDiagnosis;
		private Int32? numberOfWomensHealthEncounters;
		private string patientFirstName;
		private string patientICN;
		private string patientIEN;
		private string patientLastName;
		private Int32 patientSID;
		private string patientSSN;
		private string pCMMStaffName;
		private Int64? pCMMStaffSID;
		private string pCMMTeam;
		private Int64? pCMMTeamSID;
		private string phoneCellular;
		private string phoneResidence;
		private string phoneWork;
		private string race;
		private Int16? region;
		private Int16 sta3n;
		private string state;
		private string streetAddress1;
		private string streetAddress2;
		private string streetAddress3;
		private string vAID;
		private string veteranFlag;
		private Int16 vISN;
		private string womensHealthVisitStatus;
		private string zip;

		#endregion

		#region Constructors

		public BCCCR_BCR_ALL()
		{
		}

		#endregion

		#region Properties

		public decimal? Age
		{
			get { return this.age; }
			set { this.age = value; }
		}

		public Int32? BIRADScore
		{
			get { return this.bIRADScore; }
			set { this.bIRADScore = value; }
		}

		public string City
		{
			get { return this.city; }
			set { this.city = value; }
		}

		public string CombatFlag
		{
			get { return this.combatFlag; }
			set { this.combatFlag = value; }
		}

		public DateTime? DateNextMammogramDue
		{
			get { return this.dateNextMammogramDue; }
			set { this.dateNextMammogramDue = value; }
		}

		public DateTime? DateOfBirth
		{
			get { return this.dateOfBirth; }
			set { this.dateOfBirth = value; }
		}

		public DateTime? DateOFMostRecentMammogram
		{
			get { return this.dateOFMostRecentMammogram; }
			set { this.dateOFMostRecentMammogram = value; }
		}

		public DateTime? DateOfMostRecentMammogramExclusionHealthFactor
		{
			get { return this.dateOfMostRecentMammogramExclusionHealthFactor; }
			set { this.dateOfMostRecentMammogramExclusionHealthFactor = value; }
		}

		public DateTime? DateOfMostRecentMammogramResult
		{
			get { return this.dateOfMostRecentMammogramResult; }
			set { this.dateOfMostRecentMammogramResult = value; }
		}

		public DateTime? DateOfMostRecentMammogramScreenFreq
		{
			get { return this.dateOfMostRecentMammogramScreenFreq; }
			set { this.dateOfMostRecentMammogramScreenFreq = value; }
		}

		public DateTime? DateOfMostRecentNexusClinicEncounter
		{
			get { return this.dateOfMostRecentNexusClinicEncounter; }
			set { this.dateOfMostRecentNexusClinicEncounter = value; }
		}

		public DateTime? DateOfMostRecentNexusClinicFormerEncounter
		{
			get { return this.dateOfMostRecentNexusClinicFormerEncounter; }
			set { this.dateOfMostRecentNexusClinicFormerEncounter = value; }
		}

		public DateTime? DateOfMostRecentPrimaryCareEncounter
		{
			get { return this.dateOfMostRecentPrimaryCareEncounter; }
			set { this.dateOfMostRecentPrimaryCareEncounter = value; }
		}

		public DateTime? DateOfMostRecentWomensHealthEncounter
		{
			get { return this.dateOfMostRecentWomensHealthEncounter; }
			set { this.dateOfMostRecentWomensHealthEncounter = value; }
		}

		public DateTime? DateOfMostRRecentNexusClinicPriorEncounter
		{
			get { return this.dateOfMostRRecentNexusClinicPriorEncounter; }
			set { this.dateOfMostRRecentNexusClinicPriorEncounter = value; }
		}

		public DateTime? DateOfNextAppointment
		{
			get { return this.dateOfNextAppointment; }
			set { this.dateOfNextAppointment = value; }
		}

		public string DateProcessed
		{
			get { return this.dateProcessed; }
			set { this.dateProcessed = value; }
		}

		public string Deceased
		{
			get { return this.deceased; }
			set { this.deceased = value; }
		}

		public string Ethnicity
		{
			get { return this.ethnicity; }
			set { this.ethnicity = value; }
		}

		public string Gender
		{
			get { return this.gender; }
			set { this.gender = value; }
		}

		public bool? HadBilateralMastectomy
		{
			get { return this.hadBilateralMastectomy; }
			set { this.hadBilateralMastectomy = value; }
		}

		public bool? HadHysterectomy
		{
			get { return this.hadHysterectomy; }
			set { this.hadHysterectomy = value; }
		}

		public bool? HasATerminalHealthFactor
		{
			get { return this.hasATerminalHealthFactor; }
			set { this.hasATerminalHealthFactor = value; }
		}

		public bool? HasMammogramExclusionHealthFactor
		{
			get { return this.hasMammogramExclusionHealthFactor; }
			set { this.hasMammogramExclusionHealthFactor = value; }
		}

		public Int64? HomeSta3N
		{
			get { return this.homeSta3N; }
			set { this.homeSta3N = value; }
		}

		public Int32 ID
		{
			get { return this.iD; }
			set { this.iD = value; }
		}

		public Int16? ISOEFOIF
		{
			get { return this.iSOEFOIF; }
			set { this.iSOEFOIF = value; }
		}

		public string LocationNameOfNextAppointment
		{
			get { return this.locationNameOfNextAppointment; }
			set { this.locationNameOfNextAppointment = value; }
		}

		public string MammogramComplianceText
		{
			get { return this.mammogramComplianceText; }
			set { this.mammogramComplianceText = value; }
		}

		public string MammogramMostRecentScreenFreq
		{
			get { return this.mammogramMostRecentScreenFreq; }
			set { this.mammogramMostRecentScreenFreq = value; }
		}

		public string MammogramMostrecentScreenFreqHF
		{
			get { return this.mammogramMostrecentScreenFreqHF; }
			set { this.mammogramMostrecentScreenFreqHF = value; }
		}

		public string MammogramScreeningComplianceText
		{
			get { return this.mammogramScreeningComplianceText; }
			set { this.mammogramScreeningComplianceText = value; }
		}

		public Int32? MonthSID
		{
			get { return this.monthSID; }
			set { this.monthSID = value; }
		}

		public decimal? MostRecentMammogramDiagnosticCode
		{
			get { return this.mostRecentMammogramDiagnosticCode; }
			set { this.mostRecentMammogramDiagnosticCode = value; }
		}

		public string MostRecentMammogramProcedure
		{
			get { return this.mostRecentMammogramProcedure; }
			set { this.mostRecentMammogramProcedure = value; }
		}

		public string MostRecentMammogramSource
		{
			get { return this.mostRecentMammogramSource; }
			set { this.mostRecentMammogramSource = value; }
		}

		public Int32? NumberOfCancerDiagnosis
		{
			get { return this.numberOfCancerDiagnosis; }
			set { this.numberOfCancerDiagnosis = value; }
		}

		public Int32? NumberOfNexusClinicEncounters
		{
			get { return this.numberOfNexusClinicEncounters; }
			set { this.numberOfNexusClinicEncounters = value; }
		}

		public Int32? NumberOfNexusClinicFormerEncounters
		{
			get { return this.numberOfNexusClinicFormerEncounters; }
			set { this.numberOfNexusClinicFormerEncounters = value; }
		}

		public Int32? NumberOfNexusClinicPriorEncounters
		{
			get { return this.numberOfNexusClinicPriorEncounters; }
			set { this.numberOfNexusClinicPriorEncounters = value; }
		}

		public Int32? NumberOfPrimaryCareEncounters
		{
			get { return this.numberOfPrimaryCareEncounters; }
			set { this.numberOfPrimaryCareEncounters = value; }
		}

		public Int32? NumberOfTerminalCADDiagnosis
		{
			get { return this.numberOfTerminalCADDiagnosis; }
			set { this.numberOfTerminalCADDiagnosis = value; }
		}

		public Int32? NumberOfWomensHealthEncounters
		{
			get { return this.numberOfWomensHealthEncounters; }
			set { this.numberOfWomensHealthEncounters = value; }
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

		public Int32 PatientSID
		{
			get { return this.patientSID; }
			set { this.patientSID = value; }
		}

		public string PatientSSN
		{
			get { return this.patientSSN; }
			set { this.patientSSN = value; }
		}

		public string PCMMStaffName
		{
			get { return this.pCMMStaffName; }
			set { this.pCMMStaffName = value; }
		}

		public Int64? PCMMStaffSID
		{
			get { return this.pCMMStaffSID; }
			set { this.pCMMStaffSID = value; }
		}

		public string PCMMTeam
		{
			get { return this.pCMMTeam; }
			set { this.pCMMTeam = value; }
		}

		public Int64? PCMMTeamSID
		{
			get { return this.pCMMTeamSID; }
			set { this.pCMMTeamSID = value; }
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

		public string Race
		{
			get { return this.race; }
			set { this.race = value; }
		}

		public Int16? Region
		{
			get { return this.region; }
			set { this.region = value; }
		}

		public Int16 Sta3n
		{
			get { return this.sta3n; }
			set { this.sta3n = value; }
		}

		public string State
		{
			get { return this.state; }
			set { this.state = value; }
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

		public string VAID
		{
			get { return this.vAID; }
			set { this.vAID = value; }
		}

		public string VeteranFlag
		{
			get { return this.veteranFlag; }
			set { this.veteranFlag = value; }
		}

		public Int16 VISN
		{
			get { return this.vISN; }
			set { this.vISN = value; }
		}

		public string WomensHealthVisitStatus
		{
			get { return this.womensHealthVisitStatus; }
			set { this.womensHealthVisitStatus = value; }
		}

		public string Zip
		{
			get { return this.zip; }
			set { this.zip = value; }
		}

		#endregion

		#region Methods
		#endregion
	}
}
