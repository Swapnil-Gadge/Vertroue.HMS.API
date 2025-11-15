namespace Vertroue.HMS.API.Application.Models.Hospital
{
    public class PackageDto
    {
        public int PackageMasterId { get; set; }

        public string? PackageName { get; set; }

        public int? HospitalId { get; set; }

        public decimal? Cost { get; set; }

        public decimal? TpapayablePercent { get; set; }
    }
}
