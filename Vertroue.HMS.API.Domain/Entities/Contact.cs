namespace Vertroue.HMS.API.Domain.Entities;

public partial class Contact
{
    public int ContactId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ContactNo { get; set; }

    public int? EmpanelledInsCompId { get; set; }

    public int? EmpanelledTpaId { get; set; }

    public int? HospitalId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual Hospital? Hospital { get; set; }

    public virtual EmpanelledInsuranceCompany? EmpanelledInsComp { get; set; }

    public virtual EmpanelledTpa? EmpanelledTpa { get; set; }
}
