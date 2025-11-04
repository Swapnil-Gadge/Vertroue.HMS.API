using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class FileFlow
{
    public int FileFlowId { get; set; }

    public int? PatientId { get; set; }

    public string? Status { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? ClaimStatusMasterId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ClaimStatusMaster? ClaimStatusMaster { get; set; }

    public virtual Patient? Patient { get; set; }
}
