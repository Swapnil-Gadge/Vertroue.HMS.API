using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }

    public int? HospitalId { get; set; }

    public string Name { get; set; } = null!;

    public int UserRoleId { get; set; }

    public string Email { get; set; } = null!;

    public string UserLoginId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? ContactNumber { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual Hospital? Hospital { get; set; }

    public virtual UserRole UserRole { get; set; } = null!;
}
