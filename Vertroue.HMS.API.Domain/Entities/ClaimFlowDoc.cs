namespace Vertroue.HMS.API.Domain.Entities;

public partial class ClaimFlowDoc
{
    public int ClaimFlowDocId { get; set; }

    public int? ClaimFlowId { get; set; }

    public string DocName { get; set; } = null!;

    public string DocUri { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ClaimFlow? ClaimFlow { get; set; }
}
