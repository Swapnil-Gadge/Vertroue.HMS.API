namespace Vertroue.HMS.API.Domain.Entities;

public partial class Hospital
{
    public int HospitalId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string WebSite { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int CityId { get; set; }

    public int StateId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ICollection<PackagesMaster> PackagesMasters { get; } = new List<PackagesMaster>();

    public virtual ICollection<Patient> Patients { get; } = new List<Patient>();

    public virtual ICollection<User> Users { get; } = new List<User>();

    public virtual ICollection<Renewal> Renewals { get; set; } = new List<Renewal>();

    public virtual CitiesMaster City { get; set; } = null!;
    
    public virtual StatesMaster State { get; set; } = null!;

    public virtual ICollection<DoctorsMaster> DoctorsMasters { get; } = new List<DoctorsMaster>();

    public virtual ICollection<EmpanelledTpa> EmpanelledTpas { get; } = new List<EmpanelledTpa>();

    public virtual ICollection<EmpanelledInsuranceCompany> EmpanelledInsuranceCompanies { get; } = new List<EmpanelledInsuranceCompany>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Mou> Mous { get; set; } = new List<Mou>();
}
