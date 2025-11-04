namespace Vertroue.HMS.API.Domain.Entities;

public partial class Mou
{
    public int Mouid { get; set; }

    public int? EmpanelledInsCompId { get; set; }

    public int? EmpanelledTpaId { get; set; }

    public string DocName { get; set; } = null!;

    public string DocUri { get; set; } = null!;

    public int? HospitalId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? MouStartDate { get; set; }

    public DateTime? MouEndDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual EmpanelledInsuranceCompany? EmpanelledInsComp { get; set; }

    public virtual EmpanelledTpa? EmpanelledTpa { get; set; }

    public virtual Hospital? Hospital { get; set; }
}
