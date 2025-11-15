namespace Vertroue.HMS.API.Application.Models.Patient
{
    public class PatientDto
    {
        public int PatientId { get; set; }

        public int HospitalId { get; set; }

        public int TreatingDoctorId { get; set; }

        public string? TreatingDoctorName { get; set; }

        public string? TreatingDoctorContact { get; set; }

        public string? DoctorQualification { get; set; }

        public string? DoctorRegistrationNumber { get; set; }

        public string? TreatingDoctorNameDeclaration { get; set; }

        public int? InsuranceCompanyId { get; set; }

        public string? InsuranceCompanyName { get; set; }

        public string? InsuranceCompPhoneNumber { get; set; }

        public string? InsuranceCompFaxNumber { get; set; }

        public int? TpaId { get; set; }

        public string? TpaName { get; set; }

        public string? TpaPhoneNumber { get; set; }

        public string? TpaFaxNumber { get; set; }

        public string? TpaClaimId { get; set; }

        public string? PatientName { get; set; }

        public string? Gender { get; set; }

        public string? AgeYears { get; set; }

        public string? AgeMonths { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ContactNumber { get; set; }

        public string? RelativeContactNumber { get; set; }

        public string? InsuredCardNumber { get; set; }

        public string? PolicyNumber { get; set; }

        public string? CompanyName { get; set; }

        public string? EmployeeId { get; set; }

        public string? CurrentlyWithOtherMedician { get; set; } // bool in entity

        public string? OtherInsuranceCompany { get; set; }

        public string? FamilyPhysician { get; set; } // bool in entity

        public string? FamilyPhysicianName { get; set; }

        public string? FamilyPhysicianContact { get; set; }

        public string? IllnessNature { get; set; }

        public string? ClinicalFindings { get; set; }

        public string? PresentAilmentDuration { get; set; }

        public DateTime? FirstConsultationDate { get; set; }

        public string? PastHistoryAilment { get; set; }

        public string? ProvisionalDiagnosis { get; set; }

        public string? Icd11Code { get; set; }

        public string? TreatmentLine { get; set; }

        public string? InvestigationDetails { get; set; }

        public string? DrugAdministrationRoute { get; set; }

        public string? SurgicalDetails { get; set; }

        public string? Icd10PcsCode { get; set; }

        public string? OtherTreatmentDetails { get; set; }

        public string? InjuryOccurrence { get; set; }

        public DateTime? AdmissionDate { get; set; }

        public TimeSpan? AdmissionTime { get; set; }

        public string? AdmissionType { get; set; }

        public string? ExpectedStayDays { get; set; }

        public string? RoomType { get; set; }

        public decimal? ExpectedCost { get; set; }

        public decimal? PerDayRoomRent { get; set; }

        public decimal? IcuCharges { get; set; }

        public decimal? OtCharges { get; set; }

        public decimal? ExpectedInvestigationCost { get; set; }

        public decimal? ConsultationCharges { get; set; }

        public decimal? MedicinesConsumables { get; set; }

        public decimal? AllInclusivePackageRs { get; set; }

        public decimal? TotalExpectedCost { get; set; }

        public bool? AccidentCase { get; set; }

        public bool? AccidentIsRta { get; set; }

        public bool? AccidentReportedToPolice { get; set; }

        public string? AccidentFirNumber { get; set; }

        public DateTime? AccidentInjuryDate { get; set; }

        public bool? SubstanceAbuse { get; set; }

        public string? SubstanceAbuseReports { get; set; }

        public bool? MaternityCase { get; set; }

        public string? MaternityType { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public bool? Diabetes { get; set; }

        public string? DiabetesMonths { get; set; }

        public string? DiabetesYears { get; set; }

        public bool? HeartDisease { get; set; }

        public string? HeartDiseaseMonths { get; set; }

        public string? HeartDiseaseYears { get; set; }

        public bool? Hypertension { get; set; }

        public string? HypertensionMonths { get; set; }

        public string? HypertensionYears { get; set; }

        public bool? Hyperlipidemia { get; set; }

        public string? HyperlipidemiaMonths { get; set; }

        public string? HyperlipidemiaYears { get; set; }

        public bool? Osteoarthritis { get; set; }

        public string? OsteoarthritisMonths { get; set; }

        public string? OsteoarthritisYears { get; set; }

        public bool? AsthmaCopd { get; set; }

        public string? AsthmaCopdMonths { get; set; }

        public string? AsthmaCopdYears { get; set; }

        public bool? Cancer { get; set; }

        public string? CancerMonths { get; set; }

        public string? CancerYears { get; set; }

        public bool? AlcoholDrugAbuse { get; set; }

        public string? AlcoholDrugAbuseMonths { get; set; }

        public string? AlcoholDrugAbuseYears { get; set; }

        public bool? HivStdAilment { get; set; }

        public string? HivStdAilmentMonths { get; set; }

        public string? HivStdAilmentYears { get; set; }

        public string? OtherAilmentDetails { get; set; }

        public DateTime? DischargeDate { get; set; }

        public int? DischargeTypeId { get; set; }

        public string? ClaimStatus { get; set; }

        public DateTime? SubmitedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public List<int> AddedDocIds { get; set; } = new List<int>();

        public List<PatientDocDto> Documents { get; set; } = new List<PatientDocDto>();

        public List<ClaimFlowDto> ClaimFlows { get; set; } = new List<ClaimFlowDto>();    
    }
}
