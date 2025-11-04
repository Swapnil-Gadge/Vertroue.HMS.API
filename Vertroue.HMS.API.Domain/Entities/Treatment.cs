using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class Treatment
{
    public int TreatmentId { get; set; }

    public int? TreatmentMasterId { get; set; }

    public int? PatientId { get; set; }

    public bool? IsEnhancement { get; set; }

    public int? PackageId { get; set; }

    public int? ClaimStatusMasterId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ClaimStatusMaster? ClaimStatusMaster { get; set; }

    public virtual ICollection<Package> Packages { get; } = new List<Package>();

    public virtual Patient? Patient { get; set; }

    public virtual TreatmentsMaster? TreatmentMaster { get; set; }
}
