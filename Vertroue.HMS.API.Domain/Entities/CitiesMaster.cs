namespace Vertroue.HMS.API.Domain.Entities;

public partial class CitiesMaster
{
    public int CityId { get; set; }

    public string? Name { get; set; }

    public int? StateId { get; set; }

    public virtual ICollection<Hospital> Hospitals { get; } = new List<Hospital>();

    public virtual StatesMaster? State { get; set; }
}
