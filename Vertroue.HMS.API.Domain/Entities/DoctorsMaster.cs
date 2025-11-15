namespace Vertroue.HMS.API.Domain.Entities;

public partial class DoctorsMaster
{
    public int DoctorId { get; set; }

    public string? DoctorName { get; set; }

    public int? HospitalId { get; set; }

    public string? ContactNumber { get; set; }

    public string? Qualification { get; set; }

    public string? RegistrationNumber { get; set; }

    public bool? IsVisitingDoctor { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual Hospital? Hospital { get; set; }

    public virtual ICollection<Patient> Patients { get; } = new List<Patient>();

    public virtual ICollection<TreatingDoctorDetail> TreatingDoctorDetails { get; } = new List<TreatingDoctorDetail>();
}
