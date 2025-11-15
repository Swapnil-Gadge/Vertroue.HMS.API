namespace Vertroue.HMS.API.Domain.Entities;

public partial class TreatmentsMaster
{
    public int TreatmentMasterId { get; set; }

    public string? TreatmentName { get; set; }

    public virtual ICollection<ClaimFlow> ClaimFlows { get; } = new List<ClaimFlow>();
}
