namespace Vertroue.HMS.API.Domain.Entities;

public partial class Patient
{
    public int PatientId { get; set; }

    public int HospitalId { get; set; }

    public int? InsuranceCompanyId { get; set; }

    public int TreatingDoctorId { get; set; }

    public int? Tpaid { get; set; }

    public string? TpaclaimId { get; set; }

    public string? PatientName { get; set; }

    public string? Gender { get; set; }

    public int? AgeYears { get; set; }

    public int? AgeMonths { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? ContactNumber { get; set; }

    public string? RelativeContactNumber { get; set; }

    public string? InsuredCardNumber { get; set; }

    public string? PolicyNumber { get; set; }

    public string? CompanyName { get; set; }

    public string? EmployeeId { get; set; }

    public bool? CurrentlyWithOtherMedician { get; set; }

    public string? UniqueId { get; set; }

    public string? AadharId { get; set; }

    public bool? AccidentMLC { get; set; }

    public bool? AccidentSelfDeclaration { get; set; }

    public string? OtherInsuranceCompany { get; set; }

    public bool? HasFamilyPhysician { get; set; }

    public string? FamilyPhysicianName { get; set; }

    public string? FamilyPhysicianContact { get; set; }

    public string? IllnessNature { get; set; }

    public string? ClinicalFindings { get; set; }

    public int? PresentAilmentDuration { get; set; }

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

    public int? ExpectedStayDays { get; set; }

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

    public int? DiabetesMonths { get; set; }

    public int? DiabetesYears { get; set; }

    public bool? HeartDisease { get; set; }

    public int? HeartDiseaseMonths { get; set; }

    public int? HeartDiseaseYears { get; set; }

    public bool? Hypertension { get; set; }

    public int? HypertensionMonths { get; set; }

    public int? HypertensionYears { get; set; }

    public bool? Hyperlipidemia { get; set; }

    public int? HyperlipidemiaMonths { get; set; }

    public int? HyperlipidemiaYears { get; set; }

    public bool? Osteoarthritis { get; set; }

    public int? OsteoarthritisMonths { get; set; }

    public int? OsteoarthritisYears { get; set; }

    public bool? AsthmaCopd { get; set; }

    public int? AsthmaCopdMonths { get; set; }

    public int? AsthmaCopdYears { get; set; }

    public bool? Cancer { get; set; }

    public int? CancerMonths { get; set; }

    public int? CancerYears { get; set; }

    public bool? AlcoholDrugAbuse { get; set; }

    public int? AlcoholDrugAbuseMonths { get; set; }

    public int? AlcoholDrugAbuseYears { get; set; }

    public bool? HivStdAilment { get; set; }

    public int? HivStdAilmentMonths { get; set; }

    public int? HivStdAilmentYears { get; set; }

    public string? OtherAilmentDetails { get; set; }

    public DateTime? DischargeDate { get; set; }

    public int? DischargeTypeId { get; set; }

    public string? ClaimStatus { get; set; }

    public DateTime? SubmitedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual DischargeType? DischargeType { get; set; }

    public virtual Hospital Hospital { get; set; } = null!;

    public virtual InsuranceCompany? InsuranceCompany { get; set; }

    public virtual Tpa? Tpa { get; set; }

    public virtual DoctorsMaster TreatingDoctorDetails { get; }

    public virtual ICollection<PatientDoc> PatientDocs { get; } = new List<PatientDoc>();

    public virtual ICollection<ClaimFlow> ClaimFlows { get; } = new List<ClaimFlow>();
}
