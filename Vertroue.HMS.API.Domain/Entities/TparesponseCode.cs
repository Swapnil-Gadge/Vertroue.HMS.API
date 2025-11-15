using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class TparesponseCode
{
    public int TparesponseCodeId { get; set; }

    public string? QueryCode { get; set; }

    public string? QueryDescription { get; set; }

    public virtual ICollection<ClaimFlow> ClaimFlows { get; } = new List<ClaimFlow>();
}
