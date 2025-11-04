namespace Vertroue.HMS.API.Application.Models.Master
{
    public class TpaDto
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
    }
}
