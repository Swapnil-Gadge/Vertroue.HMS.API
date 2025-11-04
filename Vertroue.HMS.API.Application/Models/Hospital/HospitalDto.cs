namespace Vertroue.HMS.API.Application.Models.Hospital
{
    public class HospitalDto
    {
        public int HospitalId { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public string WebSite { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool? IsActive { get; set; }

        public int CityId { get; set; }

        public int StateId { get; set; }

        public string CityName { get; set; } = null!;

        public string StateName { get; set; } = null!;

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
    }
}
