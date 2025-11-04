namespace Vertroue.HMS.API.Domain.Entities;

public partial class Patient
{
    public int PatientId { get; set; }

    public int HospitalId { get; set; }

    public int? InsuranceCompanyId { get; set; }

    public int? Tpaid { get; set; }

    public string? TpaclaimId { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public int? AgeYears { get; set; }

    public int? AgeMonths { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? ContactNumber { get; set; }

    public string? RelativeContactNumber { get; set; }

    public string? HealthCardNumber { get; set; }

    public string? PolicyNumber { get; set; }

    public string? CorporateName { get; set; }

    public string? EmployeeId { get; set; }

    public bool? HasOtherInsurance { get; set; }

    public string? OtherInsuranceCompany { get; set; }

    public bool? HasFamilyPhysician { get; set; }

    public string? FamilyPhysicianName { get; set; }

    public string? FamilyPhysicianContact { get; set; }

    public string? NatureOfIllness { get; set; }

    public string? ClinicalFindings { get; set; }

    public int? DurationOfAilment { get; set; }

    public DateTime? DateOfFirstConsultation { get; set; }

    public string? PastHistoryOfAilment { get; set; }

    public string? ProvisionalDiagnosis { get; set; }

    public string? Icd10code { get; set; }

    public int? LineOfTreatmentId { get; set; }

    public string? InvestigationOrMedicalManagementDetails { get; set; }

    public string? RouteOfDrugAdmin { get; set; }

    public string? NameOfSurgery { get; set; }

    public string? Icd10pcscode { get; set; }

    public string? OtherTreatmentDetails { get; set; }

    public string? HowInjuryOccured { get; set; }

    public string? Maternity { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? AdmissionDate { get; set; }

    public int? AdmissionTypeId { get; set; }

    public int? ExpectedStayDays { get; set; }

    public int? RoomTypeId { get; set; }

    public decimal? ExpectedCost { get; set; }

    public decimal? PerDayCharges { get; set; }

    public decimal? Icucharges { get; set; }

    public decimal? Otcharges { get; set; }

    public decimal? ProfessionalCharges { get; set; }

    public decimal? MedicineCost { get; set; }

    public decimal? AllInclusivePackageCharges { get; set; }

    public decimal? TotalCostToHospital { get; set; }

    public string? AnyOtherAilment { get; set; }

    public DateTime? DischargeDate { get; set; }

    public int? DischargeTypeId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ICollection<AccidentDetail> AccidentDetails { get; } = new List<AccidentDetail>();

    public virtual AdmissionType? AdmissionType { get; set; }

    public virtual ICollection<Claim> Claims { get; } = new List<Claim>();

    public virtual DischargeType? DischargeType { get; set; }

    public virtual ICollection<FileFlow> FileFlows { get; } = new List<FileFlow>();

    public virtual Hospital Hospital { get; set; } = null!;

    public virtual InsuranceCompany? InsuranceCompany { get; set; }

    public virtual LineOfTreatment? LineOfTreatment { get; set; }

    public virtual ICollection<MedicalHistory> MedicalHistories { get; } = new List<MedicalHistory>();

    public virtual ICollection<Package> Packages { get; } = new List<Package>();

    public virtual RoomType? RoomType { get; set; }

    public virtual Tpa? Tpa { get; set; }

    public virtual ICollection<Tparesponse> Tparesponses { get; } = new List<Tparesponse>();

    public virtual ICollection<TreatingDoctorDetail> TreatingDoctorDetails { get; } = new List<TreatingDoctorDetail>();

    public virtual ICollection<Treatment> Treatments { get; } = new List<Treatment>();

    public virtual ICollection<PatientDoc> PatientDocs { get; } = new List<PatientDoc>();
}
