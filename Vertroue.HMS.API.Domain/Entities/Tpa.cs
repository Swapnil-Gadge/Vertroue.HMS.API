using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class Tpa
{
    public int Tpaid { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactNumber { get; set; }

    public string? FaxNumber { get; set; }

    public string? Ceo { get; set; }

    public string? LicenseNumber { get; set; }

    public DateTime? LicenseValidTill { get; set; }

    public string Address { get; set; } = null!;

    public string? Email { get; set; }

    public string? WebSite { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ICollection<Patient> Patients { get; } = new List<Patient>();

    public virtual ICollection<EmpanelledTpa> EmpanelledTpas { get; } = new List<EmpanelledTpa>();
}
