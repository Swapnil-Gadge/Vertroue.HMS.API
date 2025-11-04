using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class Tparesponse
{
    public int ResponseId { get; set; }

    public int? PatientId { get; set; }

    public int? TparesponseCodeId { get; set; }

    public string? ResponseNotes { get; set; }

    public string? ResponseDocName { get; set; }

    public string? ResponseDocument { get; set; }

    public int? ClaimStatusMasterId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ClaimStatusMaster? ClaimStatusMaster { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual TparesponseCode? TparesponseCode { get; set; }
}
