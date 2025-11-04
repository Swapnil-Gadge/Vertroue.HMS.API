using System;
using System.Collections.Generic;

namespace Vertroue.HMS.API.Domain.Entities;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
