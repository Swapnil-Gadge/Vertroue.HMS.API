namespace Vertroue.HMS.API.Domain.Entities
{
    public partial class PatientDoc
    {
        public int PatientDocId { get; set; }

        public int? PatientId { get; set; }

        public string Title { get; set; } = null!;

        public string DocName { get; set; } = null!;

        public string DocUri { get; set; } = null!;

        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public virtual Patient Patient { get; set; } = null!;
    }
}
