namespace Vertroue.HMS.API.Domain.Entities;

public partial class StatesMaster
{
    public int StateId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<CitiesMaster> CitiesMasters { get; } = new List<CitiesMaster>();

    public virtual ICollection<Hospital> Hospitals { get; } = new List<Hospital>();
}
