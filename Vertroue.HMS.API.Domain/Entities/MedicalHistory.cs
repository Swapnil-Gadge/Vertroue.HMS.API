using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class MedicalHistory
{
    public int HistoryId { get; set; }

    public int? HistoryMasterId { get; set; }

    public int? PatientId { get; set; }

    public string? SinceMonthYear { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual MedicalHistoriesMaster? HistoryMaster { get; set; }

    public virtual Patient? Patient { get; set; }
}
