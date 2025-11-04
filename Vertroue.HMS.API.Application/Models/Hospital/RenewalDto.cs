namespace Vertroue.HMS.API.Application.Models.Hospital
{
    public class RenewalDto
    {
        public int RenewalId { get; set; }

        public int HospitalId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string DocName { get; set; } = null!;

        public string DocUri { get; set; } = null!;

        public bool? IsActive { get; set; }

        public DateTime? RenewalDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public List<RenewalDocDto> Documents { get; set; }
    }

    public class RenewalDocDto
    {
        public int RenewalDocId { get; set; }

        public string DocName { get; set; } = null!;

        public string DocUri { get; set; } = null!;
    }
}
