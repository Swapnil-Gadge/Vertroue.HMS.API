using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class PackagesMaster
{
    public int PackageMasterId { get; set; }

    public string? PackageName { get; set; }

    public int? HospitalId { get; set; }

    public decimal? Cost { get; set; }

    public decimal? TpapayablePercent { get; set; }

    public virtual Hospital? Hospital { get; set; }

    public virtual ICollection<ClaimFlow> ClaimFlows { get; } = new List<ClaimFlow>();
}
