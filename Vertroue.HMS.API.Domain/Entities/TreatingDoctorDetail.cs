using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class TreatingDoctorDetail
{
    public int TreatingDoctorId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual DoctorsMaster? Doctor { get; set; }
}
