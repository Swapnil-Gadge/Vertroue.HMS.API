namespace Vertroue.HMS.API.Domain.Entities;

public partial class ClaimStatusMaster
{
    public int ClaimStatusMasterId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Claim> Claims { get; } = new List<Claim>();

    public virtual ICollection<FileFlow> FileFlows { get; } = new List<FileFlow>();

    public virtual ICollection<Tparesponse> Tparesponses { get; } = new List<Tparesponse>();

    public virtual ICollection<Treatment> Treatments { get; } = new List<Treatment>();
}
