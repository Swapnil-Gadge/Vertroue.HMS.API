using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class AccidentDetail
{
    public int AccidentId { get; set; }

    public int? PatientId { get; set; }

    public bool? IsRta { get; set; }

    public DateTime? DateOfInjury { get; set; }

    public bool? ReportedToPolice { get; set; }

    public string? Firnumber { get; set; }

    public bool? DueToSubstanceAbuse { get; set; }

    public bool? TestConducted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual Patient? Patient { get; set; }
}
