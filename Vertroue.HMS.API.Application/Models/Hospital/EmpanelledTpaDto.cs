namespace Vertroue.HMS.API.Application.Models.Hospital
{
    public class EmpanelledTpaDto
    {
        public int EmpanelledTpaId { get; set; }

        public int? TpaId { get; set; }

        public string TpaName { get; set; } = null!;

        public string? ContactNumber { get; set; }

        public string? FaxNumber { get; set; }

        public DateTime? EmpanelledDate { get; set; }

        public string Portal { get; set; } = null!;

        public string? UserName { get; set; }

        public string? PassWord { get; set; }

        public int? HospitalId { get; set; }

        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
    }
}
