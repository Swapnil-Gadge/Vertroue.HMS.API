namespace Vertroue.HMS.API.Domain.Entities;

public partial class MedicalHistoriesMaster
{
    public int HistoryMasterId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MedicalHistory> MedicalHistories { get; } = new List<MedicalHistory>();
}
