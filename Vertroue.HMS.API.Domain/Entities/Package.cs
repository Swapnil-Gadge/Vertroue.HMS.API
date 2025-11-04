using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class Package
{
    public int PackageId { get; set; }

    public int? PackageMasterId { get; set; }

    public int? TreatmentId { get; set; }

    public string? PackageName { get; set; }

    public int? PatientId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual PackagesMaster? PackageMaster { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual Treatment? Treatment { get; set; }
}
