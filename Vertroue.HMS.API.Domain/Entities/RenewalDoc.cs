namespace Vertroue.HMS.API.Domain.Entities;

public partial class RenewalDoc
{
    public int RenewalDocId { get; set; }

    public int RenewalId { get; set; }

    public string DocName { get; set; } = null!;

    public string DocUri { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual Renewal Renewal { get; set; } = null!;
}
