namespace Vertroue.HMS.API.Domain.Entities;

public partial class LineOfTreatment
{
    public int LineOfTreatmentId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }
}
