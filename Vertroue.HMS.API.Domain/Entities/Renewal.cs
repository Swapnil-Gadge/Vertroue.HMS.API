namespace Vertroue.HMS.API.Domain.Entities;

public partial class Renewal
{
    public int RenewalId { get; set; }

    public int HospitalId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? RenewalDate { get; set; }

    public DateTime? ExpireDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual Hospital Hospital { get; set; } = null!;

    public virtual ICollection<RenewalDoc> RenewalDocs { get; set; } = new List<RenewalDoc>();
}
