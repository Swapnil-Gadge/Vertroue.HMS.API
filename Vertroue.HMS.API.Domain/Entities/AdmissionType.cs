namespace Vertroue.HMS.API.Domain.Entities;

public partial class AdmissionType
{
    public int AdmissionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }
}
