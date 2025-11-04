namespace Vertroue.HMS.API.Domain.Entities;

public partial class InsuranceCompany
{
    public int InsuranceCompanyId { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactNumber { get; set; }

    public string? FaxNumber { get; set; }

    public string WebSite { get; set; } = null!;

    public string? Code { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ICollection<Patient> Patients { get; } = new List<Patient>();

    public virtual ICollection<EmpanelledInsuranceCompany> EmpanelledInsuranceCompanies { get; } = new List<EmpanelledInsuranceCompany>();
}
